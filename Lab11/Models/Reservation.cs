using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public int ReservationId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime ReservationDate { get; set; }

        [ForeignKey("RoomId")]
        public Room Room { get; set; }
    }
}