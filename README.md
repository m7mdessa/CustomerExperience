    public class AuditLog
    {
        public string? FieldName { get; set; }

        public string? OldValue { get; set; }
        public string? NewValue { get; set; }

        public string? OldName { get; set; }
        public string? NewName { get; set; }
    }
        public class AuditTrail : AuditableSoftDeleteEntity
    {
        public required Guid EntityId { get; set; }
        public required string EntityName { get; set; }
        public required string ActionTypeCode { get; set; }
        public string? ChangesDetails { get; set; }
        public string? UserName { get; set; }
        public required DateTime CreatedOn { get; set; }
        public List<AuditLog>? Changes { get; set; }

        public virtual List<AuditTrailRelation>? AuditTrailRelations { get; set; }
    }

        public class AuditTrailRelation : AuditableSoftDeleteEntity
    {
        public Guid? EntityId { get; set; }
        public string? EntityName { get; set; }
        public string? RelationName { get; set; }
        public string? ActionTypeCode { get; set; }
        public Guid? RelatedEntityId { get; set; }
        public string? ChangesDetails { get; set; }
        public List<AuditLog>? Changes { get; set; }

        public Guid? AuditTrailId { get; set; }
        public virtual AuditTrail? AuditTrail { get; set; }
    }
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Text.Json;

public class AuditSaveChangesInterceptor : SaveChangesInterceptor
{
    private readonly string _currentUser;

    public AuditSaveChangesInterceptor(string currentUser)
    {
        _currentUser = currentUser;
    }

    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context is not AppDbContext dbContext)
            return base.SavingChanges(eventData, result);

        var auditTrails = new List<AuditTrail>();

        foreach (var entry in dbContext.ChangeTracker.Entries()
                     .Where(e => e.State is EntityState.Added or EntityState.Modified or EntityState.Deleted))
        {
            var entityType = entry.Entity.GetType();
            var entityId = GetEntityKeyValue(entry.Entity);
            if (entityId == Guid.Empty) continue;

            // 1️⃣ Create AuditTrail for main entity
            var auditTrail = new AuditTrail
            {
                EntityId = entityId,
                EntityName = entityType.Name,
                ActionTypeCode = entry.State.ToString(),
                CreatedOn = DateTime.UtcNow,
                UserName = _currentUser,
                Changes = GetFieldChanges(entry)
            };

            // 2️⃣ Detect M-M or child relations
            var auditRelations = new List<AuditTrailRelation>();

            foreach (var coll in entry.Collections)
            {
                if (!coll.IsModified) continue;

                var added = coll.CurrentValue?.Cast<object>().Except(coll.OriginalValue?.Cast<object>() ?? Array.Empty<object>()).ToList() ?? new List<object>();
                var removed = coll.OriginalValue?.Cast<object>().Except(coll.CurrentValue?.Cast<object>() ?? Array.Empty<object>()).ToList() ?? new List<object>();

                foreach (var target in added)
                {
                    auditRelations.Add(new AuditTrailRelation
                    {
                        EntityId = entityId,
                        EntityName = entityType.Name,
                        RelationName = coll.Metadata.Name,
                        ActionTypeCode = "RelationAdded",
                        RelatedEntityId = GetEntityKeyValue(target),
                        Changes = GetFieldChanges(target),
                        AuditTrail = auditTrail
                    });
                }

                foreach (var target in removed)
                {
                    auditRelations.Add(new AuditTrailRelation
                    {
                        EntityId = entityId,
                        EntityName = entityType.Name,
                        RelationName = coll.Metadata.Name,
                        ActionTypeCode = "RelationRemoved",
                        RelatedEntityId = GetEntityKeyValue(target),
                        Changes = GetFieldChanges(target),
                        AuditTrail = auditTrail
                    });
                }
            }

            auditTrail.AuditTrailRelations = auditRelations;
            auditTrails.Add(auditTrail);
        }

        if (auditTrails.Count > 0)
            dbContext.Set<AuditTrail>().AddRange(auditTrails);

        return base.SavingChanges(eventData, result);
    }

    private static Guid GetEntityKeyValue(object entity)
    {
        var keyProp = entity.GetType().GetProperties()
            .FirstOrDefault(p => p.Name.Equals("Id", StringComparison.OrdinalIgnoreCase));
        return keyProp != null && keyProp.GetValue(entity) != null
            ? Guid.Parse(keyProp.GetValue(entity)!.ToString()!)
            : Guid.Empty;
    }

    private static List<AuditLog> GetFieldChanges(object entity)
    {
        var changes = new List<AuditLog>();
        var props = entity.GetType().GetProperties().Where(p => p.CanRead);

        foreach (var prop in props)
        {
            changes.Add(new AuditLog
            {
                FieldName = prop.Name,
                NewValue = prop.GetValue(entity)?.ToString()
            });
        }

        return changes;
    }

    private static List<AuditLog> GetFieldChanges(EntityEntry entry)
    {
        var changes = new List<AuditLog>();
        foreach (var prop in entry.Properties)
        {
            if (entry.State == EntityState.Modified && !prop.IsModified) continue;

            changes.Add(new AuditLog
            {
                FieldName = prop.Metadata.Name,
                OldValue = entry.State != EntityState.Added ? prop.OriginalValue?.ToString() : null,
                NewValue = prop.CurrentValue?.ToString()
            });
        }

        return changes;
    }
}
