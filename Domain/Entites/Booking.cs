using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Entities;
public class Booking : BaseDomainEntity
{
    public int MovieId { get; set; }
    public int CinemaId { get; set; }
    public int ShowtimeId { get; set; }
    public int UserId { get; set; }
    public string SeatNumber { get; set; }
    public string Status { get; set; }
}



