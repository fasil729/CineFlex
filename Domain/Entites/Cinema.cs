using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities;
public class Cinema : BaseDomainEntity

{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public string ContactInformation { get; set; }
}

