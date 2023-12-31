using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Common;

public abstract class BaseDomainEntity
{
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
}

