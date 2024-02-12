using System;
namespace Alexander_Nguyen_A1V2
{
    public class Game
    {
        private string answerWord { get; set; }

        List<Word> WordList = new List<Word>();
        private int gamesPlayed = 0;
        private int gamesWon = 0;
        private int streakCount = 0;
        

        public Game()
        {
            this.answerWord = RandomWord();
        }

        public void FillList()
        { //method for filling list, loops through array and fills in the list

            string[] _wordArray = { "Apple", "Hello", "Stair", "Sauce", "Candy", "Learn", "Magic", "Leave", "Alive", "Crown" };
            //for (int i = 0; i < _wordArray.Count(); i++)
            //{
            //    WordList[i] = _wordArray[i];
            //}
        }

        public int CheckUserGuess(string userGuess)
        {

            if (userGuess.ToLower() == RandomWord().ToLower()) // if the user guessed the right answer return the value 10, to signify the user has guessed the correct answer
            {
                streakCount++; //since user won increase streakcount
                gamesWon++; //since user won increase games won
                return 10; //10 will be used as the value signifying the user guessed the word correct
            }
            return 20;
           
        }

        private int CheckWordIndex(char guessLetter, int indexLetter)
        {
            if(!answerWord.Contains(guessLetter)) //the value 6 will be used to signify that the letter is not in the word to be guessed
            {
                return 6;
            }

            for (int i = 0; i < answerWord.Count(); i++)
            {
                if (guessLetter == answerWord[i] && answerWord.Contains(guessLetter)) //this will return the value of the specific index if the letter is the right spot
                {
                    return i;
                } else if(answerWord.Contains(guessLetter)) //if the spot is wrong but the word does contain the letter return 7
                {
                    return 7;
                }
            }

            return 1;
        }

        public void returnStats()
        {

        }

        public string ProvideHint(string answerWord)
        {
            switch (answerWord.ToLower())
            {
                case "apple":
                    return "A _____ a day keeps the doctor away.";
                case "hello":
                    return "";
                case "stair":
                    return "";
                case "sauce":
                    return "";
                case "candy":
                    return "";
                case "learn":
                    return "";
                case "magic":
                    return "";
                case "leave":
                    return "";
                case "alive":
                    return "";
                case "crown":
                    return "";
                default:
                    return "you shouldnt be here";
            }
        }

        public string RandomWord()
        {
            Random random = new Random();
            var number = random.Next(0, 9);
            var answerWord = WordList[number];
            return WordList[number];
        }
    }
}

