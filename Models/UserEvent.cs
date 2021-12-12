using System;
using System.ComponentModel.DataAnnotations;

namespace UserEventsApi.Models
{
    public class UserEvent
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string ActionTaken { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        public DateTimeOffset TimeStamp { get; set; }
    }
}
