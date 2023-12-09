using System;
using System.Collections.Generic;

namespace _5letters.Models
{
    public class Word : BaseEntity
    {
        public string StringWord { get; set; }
        public List<Letter> Letters { get; set; }
        public WordStatus Status { get; set; }

        public Word(string stringWord)
		{
			StringWord = stringWord;
			Letters = new List<Letter>();
		}
    }
}