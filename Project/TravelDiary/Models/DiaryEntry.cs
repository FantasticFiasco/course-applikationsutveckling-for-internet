using System;

namespace TravelDiary.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }
        public DateTime Date { get; set; }
        public int? PreviousId { get; set; }
        public int? NextId { get; set; }
    }
}