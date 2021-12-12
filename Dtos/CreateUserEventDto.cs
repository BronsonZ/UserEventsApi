using System.ComponentModel.DataAnnotations;

namespace UserEventsApi.Dtos
{
    public class CreateUserEventDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string ActionTaken { get; set; }
        [Required]
        public string Data { get; set; }
    }
}
