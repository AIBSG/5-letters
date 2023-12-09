using System;
using System.Collections.Generic;

namespace _5letters.Models
{
    public class Game : BaseEntity
    {
        public Guid UserId { get; set; }
        public DateTimeOffset Date { get; set; } = DateTimeOffset.UtcNow;
        public List<Word> Words { get; set; }
        public CorrectWord CorrectWord { get; set; }
        public GameStages GameStage { get; set; }

    }
}