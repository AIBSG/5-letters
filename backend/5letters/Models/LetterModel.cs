namespace _5letters.Models
{
    public class Letter
    {
        public char WordLetter { get; set; }
        public LetterStatus  LetterStatus { get; set; }
        
        public Letter(char letter, LetterStatus letterStatus)
		{
			WordLetter = letter;
			LetterStatus = letterStatus;
		}
    }
}