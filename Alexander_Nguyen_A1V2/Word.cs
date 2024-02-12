using System;
namespace Alexander_Nguyen_A1V2
{
	public class Word
	{
        public string text { get; set; }
        public string hint { get; set; }

        public Word(string text, string hint)
        {
            this.hint = hint;
            this.text = text;
        }

    }
}

