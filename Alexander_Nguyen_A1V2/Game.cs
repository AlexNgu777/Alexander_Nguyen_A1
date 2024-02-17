//*Alexander Nguyen
//*Feb 17th, 2024
//*Student ID: 991753208
using System;
namespace Alexander_Nguyen_A1V2
{
    public class Game 
    {
        public string answerWord { get; set; } //change some of these to private, they dont all need to public
        public Word returnHintWord { get; set; }
        List<Word> WordList;
        public int gamesPlayed { get; set; }
        public int gamesWon { get; set; }
        public int streakCount { get; set; }
        public int maxWinStreak { get; set; }
        

        public Game() 
        {
            WordList = new List<Word>();
            FillList();
            returnHintWord = RandomWord();
            answerWord = returnHintWord.Text;
        }

        private void FillList()
        { //method for filling list, loops through array and fills in the list

            string[] _wordArray = { "Apple", "Hello", "Stair", "Sauce", "Candy", "Learn", "Magic", "Leave", "Alive", "Crown" };
            string[] _hintArray = { "A _____ a Day Keeps the Doctor Sway", "A word for greeting someone", "A way to ascend", "Makes food taste better",
                "Something to satisfy your sweet tooth", "I go to school to _____", "Harry Houdini",
                "I will take my _____", "What a child is when they are just born", "Something only for the king"};

            for (int i = 0; i < _wordArray.Length; i++) //loop through the entire array
            {
                WordList.Add(new Word(_wordArray[i], _hintArray[i])); //create word object with text and hint and add to list
            }
        }

        public int CheckUserGuess(string userGuess) //check whether or not the user guess is correct
        {
            if (userGuess.ToLower() == answerWord.ToLower()) // if the user guessed the right answer return the value 10, to signify the user has guessed the correct answer
            {
                return 100; //100 will be used as the value signifying the user guessed the word correct
            }

            return 20; 
        }

        public int CheckWordIndex(char guessLetter, int indexLetter) //checks each letter in word and returns a value depending on the condition
        {
            
            if (guessLetter == answerWord[indexLetter]) //this will return the value of the specific index if the letter is the right spot
            {
                return indexLetter + 5; //GREEENN BACKGROUND
            }
            else if (answerWord.Contains(guessLetter)) //if the spot is wrong but the word does contain the letter return i
            {
                streakCount = 0; //reset streak after user hits check
                return indexLetter; // ORANGEEEEEE BACKGROUND
            } else if (!answerWord.Contains(guessLetter)) //this is for checking if the word has the letter at all returns the index + 10
            {
                streakCount = 0;
                return indexLetter + 10; //originally i thought you had to change the background to red if the letter was not in the answer word but i later found out that is not the case
            }
            return 90000000;
        }

        private int getGameStats() //return games played
        {
            return gamesPlayed;
        }

        public double getWinPercentage() //return win percentage
        {
            return ((double)gamesWon / (double)gamesPlayed);
        }

        public int getWinStreak() //return win streak
        {
            return streakCount;
        }

        public int getMaxWinStreak() //return max win streak
        {
            return maxWinStreak;
        }

        public string ProvideHint() //provide hint to user
        {
            return returnHintWord.Hint;
        }

        public Word RandomWord() //pick randomword and return the object
        {
            Random random = new Random();
            var number = random.Next(0,10);
            answerWord = WordList[number].Text;
            returnHintWord = WordList[number];
            return WordList[number];
        }
    }
}

