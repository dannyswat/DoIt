using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Core.Entities;

public interface IAggregateRoot : IEntity
{
    
    DateTime CreatedAt { get; set; }

    string CreatedBy { get; set; }

    DateTime UpdatedAt { get; set; }

    string UpdatedBy { get; set; }

    byte[] RowVersion { get; set; }
}
