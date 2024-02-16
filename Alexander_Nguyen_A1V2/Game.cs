using System;
namespace Alexander_Nguyen_A1V2
{
    public class Game 
    {

        public string answerWord { get; set; }
        List<Word> WordList;
        private int gamesPlayed = 0;
        private int gamesWon = 0;
        private int streakCount = 0;
        

        public Game() //ask prof about why when adding filllist it blows up the code
        {
            
            WordList = new List<Word>();
            FillList();
            answerWord = RandomWord().Text;
        }

        public void FillList()
        { //method for filling list, loops through array and fills in the list

            string[] _wordArray = { "Apple", "Hello", "Stair", "Sauce", "Candy", "Learn", "Magic", "Leave", "Alive", "Crown" };
            string[] _hintArray = { "Hint 1", "Hint 2", "Hint 3", "Hint 4", "Hint 5", "Hint 6", "Hint 7", "Hint 8", "Hint 9", "Hint 10"};

            for (int i = 0; i < _wordArray.Length; i++)
            {
                WordList.Add(new Word(_wordArray[i], _hintArray[i]));
            }
        }

        public int CheckUserGuess(string userGuess)
        {

            if (userGuess.ToLower() == answerWord.ToLower()) // if the user guessed the right answer return the value 10, to signify the user has guessed the correct answer
            {
                streakCount++; //since user won increase streakcount
                gamesWon++; //since user won increase games won
                gamesPlayed++;
                return 100; //100 will be used as the value signifying the user guessed the word correct
            }

            for (int i = 0; i < userGuess.Length; i++)
            {
                CheckWordIndex(userGuess[i], i);
            }
            return 20; // code shouldnt get this far

        }

        private int CheckWordIndex(char guessLetter, int indexLetter)
        {
            if (!answerWord.Contains(guessLetter)) //this is for checking if the word has the letter at all returns the index + 10
            {

                streakCount = 0;
                return indexLetter + 10;

            }

            for (int i = 0; i < answerWord.Length; i++)
            {
                if (guessLetter == answerWord[i] && answerWord.Contains(guessLetter)) //this will return the value of the specific index if the letter is the right spot
                {
                    streakCount = 0; //reset streak count if user guessed;
                    return i + 5; //if index is correct add 5 to it 
                }
                else if (answerWord.Contains(guessLetter)) //if the spot is wrong but the word does contain the letter return i
                {
                    streakCount = 0; //reset streak after user hits check
                    return i; //return the index of the right character in the wrong position
                }
            }

            return 1;
        }

        public int returnGameStats()
        {
            return gamesPlayed;
        }

        public int returnGamesWon()
        {
            return gamesWon;
        }

        public int returnGamesStreak()
        {
            return streakCount;
        }

        public string ProvideHint(Word word)
        {
            return word.Hint.ToString();
        }

        public Word RandomWord()
        {
            Random random = new Random();
            var number = random.Next(0,9);
            return WordList[number];
        }
    }
}

