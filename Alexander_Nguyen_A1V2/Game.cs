using System;
namespace Alexander_Nguyen_A1V2
{
    public class Game
    {
        List<String> WordList;
        private int gamesPlayed = 0;
        private int gamesWon = 0;
        private int streakCount = 0;

        public Game()
        {
            WordList = new List<string>();
            RandomWord();
        }

        private void FillList()
        { //method for filling list, loops through array and fills in the list

            string[] _wordArray = { "Apple", "Hello", "Stair", "Sauce", "Candy", "Learn", "Magic", "Leave", "Alive", "Crown" };
            for (int i = 0; i < _wordArray.Count(); i++)
            {
                WordList[i] = _wordArray[i];
            }
        }

        private int CheckUserGuess(string userGuess, string answerWord)
        {

            if (userGuess == RandomWord())
            {
                streakCount++; //since user won increase streakcount
                gamesWon++; //since user won increase games won
                return 10; //10 will be used as the value signifying the user guessed the word correct
            }


            for (int i = 0; i < userGuess.Count(); i++)
            {
                if (CheckWordIndex(userGuess[i], i) == 6)
                {
                    return 6;
                }
                if (CheckWordIndex(userGuess[i], i) == 7)
                {
                    return 7;
                }
                else
                {
                    return CheckWordIndex(userGuess[i], i);
                }
            }
            return 20;
        }

        private int CheckWordIndex(char guessLetter, int indexLetter)
        {

            var word = RandomWord();
            if (guessLetter == word[indexLetter])
            {
                return indexLetter; //returns the index position of the letter that is in the correct position
            }
            else if (word.Contains(guessLetter))
            {
                return 6; //6 will be the return value used to signify that the letter is contained in the character
            }
            else
            {
                return 7; //7 will signify that the letter does not exist in the aswer word
            }
        }

        protected string ProvideHint(string answerWord)
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

        private string RandomWord()
        {
            Random random = new Random();
            var number = random.Next(0, 9);
            return WordList[number];
        }
    }
}

