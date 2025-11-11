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
