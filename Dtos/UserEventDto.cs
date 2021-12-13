using System;

namespace UserEventsApi.Dtos
{
    public class UserEventDto
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string ActionTaken { get; set; }

        public string Data { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
    }
}
