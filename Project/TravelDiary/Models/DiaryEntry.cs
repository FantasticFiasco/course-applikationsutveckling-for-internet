using System;

namespace TravelDiary.Models
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Destination { get; set; }
        public DateTime Date { get; set; }
    }
}