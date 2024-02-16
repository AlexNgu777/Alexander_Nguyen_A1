using System;
namespace Alexander_Nguyen_A1V2
{
	public class Word
	{
        public string Text { get; set; }
        public string Hint { get; set; }

        public Word(string text, string hint)
        {
            Hint = hint;
            Text = text;
        }

    }
}

