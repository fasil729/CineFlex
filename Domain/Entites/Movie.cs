using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities;
public class Movie : BaseDomainEntity
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public string Rating { get; set; }
    public int MovieLength { get; set; }
    public string Plot { get; set; }
}