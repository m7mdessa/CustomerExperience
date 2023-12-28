using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerExperience.Packages

{
    public interface ISoftDelete
    {

        bool IsDeleted { get; }

        DateTime DeletedDate { get; }

        string? DeletedBy { get; }
    }
}
