
using Microsoft.EntityFrameworkCore;

namespace UserEventsApi.Models
{
    [Keyless]
    public class UserEventData
    {   
        public string MostFreqEvent { get; set; }
        
        public int NumberOfTimes { get; set; }
       
        public double NumberOfTimesPerUser { get; set; }
    }
}
