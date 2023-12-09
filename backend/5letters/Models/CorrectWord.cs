using System;

namespace _5letters.Models
{
    public class CorrectWord : BaseEntity
    {
        public string StringWord { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}