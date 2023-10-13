using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities;
public class Showtime : BaseDomainEntity
{
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public DateTime DateTime { get; set; }
}