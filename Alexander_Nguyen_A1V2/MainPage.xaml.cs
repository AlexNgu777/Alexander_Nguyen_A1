//*Alexander Nguyen
//*Feb 17th, 2024
//*Student ID: 991753208
using System;
using System.Linq;

namespace Alexander_Nguyen_A1V2;

public partial class MainPage : ContentPage
{
    Game game;
    public MainPage()
	{
        InitializeComponent();
        game = new Game();
        AnswerWordDisplay.Text = game.answerWord;  
    }

    void CheckButton_Clicked(System.Object sender, System.EventArgs e)
    {
        game.gamesPlayed++; //increment gamesPlayed when check button has been clicked

        if(WordEntry.Text.Length != 5 || WordEntry.Text.Contains('1') || WordEntry.Text.Contains('2')
            || WordEntry.Text.Contains('3') || WordEntry.Text.Contains('4') || WordEntry.Text.Contains('5') || WordEntry.Text.Contains('7')
            || WordEntry.Text.Contains('8') || WordEntry.Text.Contains('9') || WordEntry.Text.Contains('0'))
        { //if entry is too long or too short let user known also check if for if the user puts numbers in the input
            DisplayAlert("ALERT","Make sure your input is 5 letters and NO numbers","Okay");
            throw new Exception();
        }

        char[] userInput = WordEntry.Text.ToCharArray(); //put user input into a char array and then put each letter in the display box
        LetterLabel1.Text = Convert.ToString(userInput[0]).ToUpper();
        LetterLabel2.Text = Convert.ToString(userInput[1]).ToUpper();
        LetterLabel3.Text = Convert.ToString(userInput[2]).ToUpper();
        LetterLabel4.Text = Convert.ToString(userInput[3]).ToUpper();
        LetterLabel5.Text = Convert.ToString(userInput[4]).ToUpper();


        if (game.CheckUserGuess(WordEntry.Text) == 100) //if userguess is correct the method returns 100 to signify guess is correct
        {
            LetterLabel1.BackgroundColor = Colors.Green;
            LetterLabel2.BackgroundColor = Colors.Green;
            LetterLabel3.BackgroundColor = Colors.Green;
            LetterLabel4.BackgroundColor = Colors.Green;
            LetterLabel5.BackgroundColor = Colors.Green;
            game.gamesWon++; //increment gamesWon, streakCount, maxWinStreak counter
            game.streakCount++;
            game.maxWinStreak++;
            int tempGamesPlayed = game.gamesPlayed; //save the users stats to temp variables before restting games
            int tempWonGames = game.gamesWon;
            int tempStreak = game.streakCount;
            int tempMaxStreak = game.maxWinStreak;
            string tempLastWord = game.answerWord;
            game = new Game(); //reset game if they guess the answerWord
            while (game.answerWord == tempLastWord)
            {
                game = new Game();
            }
            game.gamesPlayed = tempGamesPlayed; //override the values with stats of the previous instance of the game
            game.gamesWon = tempWonGames;
            game.streakCount = tempStreak;
            game.maxWinStreak = tempMaxStreak;
            AnswerWordDisplay.Text = game.answerWord;
            return;
        }

        for (int i = 0; i < WordEntry.Text.Length; i++) //loop through every letter of the userinput
        {
                switch (game.CheckWordIndex(WordEntry.Text[i], i))
                {
                    case 0:
                        LetterLabel1.BackgroundColor = Colors.Orange;
                        break;
                    case 1:
                        LetterLabel2.BackgroundColor = Colors.Orange;
                        break;
                    case 2:
                        LetterLabel3.BackgroundColor = Colors.Orange;
                        break;
                    case 3:
                        LetterLabel4.BackgroundColor = Colors.Orange;
                        break;
                    case 4:
                        LetterLabel5.BackgroundColor = Colors.Orange; //0 - 4 is for orange background
                        break;
                    case 5:
                        LetterLabel1.BackgroundColor = Colors.Green;
                        break;
                    case 6:
                        LetterLabel2.BackgroundColor = Colors.Green;
                        break;
                    case 7:
                        LetterLabel3.BackgroundColor = Colors.Green;
                        break;
                    case 8:
                        LetterLabel4.BackgroundColor = Colors.Green;
                        break;
                    case 9:
                        LetterLabel5.BackgroundColor = Colors.Green; // 5 - 9 is for green background
                        break;
                    case 10:
                        LetterLabel1.BackgroundColor = Colors.Gray;
                        break;
                    case 11:
                        LetterLabel2.BackgroundColor = Colors.Gray;
                        break;
                    case 12:
                        LetterLabel3.BackgroundColor = Colors.Gray;
                        break;
                    case 13:
                        LetterLabel4.BackgroundColor = Colors.Gray;
                        break;
                    case 14:
                        LetterLabel5.BackgroundColor = Colors.Gray; // 9 - 14 sets background to grey
                        break;
                    default:
                        Console.WriteLine("hello");
                        break;
                }
        }
    }

    void AnswerButton_Clicked(System.Object sender, System.EventArgs e) //when clicked display the answer and reset word to a new random word
    {
        DisplayAlert("YOU LOSEEEE","The answer word is: " + game.answerWord, "Bad game");
        game.gamesPlayed++;
        game.streakCount = 0;
        int tempGamesPlayed = game.gamesPlayed;
        int tempGames = game.gamesWon;
        int tempStreak = game.streakCount;
        int tempMaxStreak = game.maxWinStreak;
        string tempLastWord = game.answerWord;
        game = new Game(); //reset game if they guess the answerWord
        while (game.answerWord == tempLastWord) //if new word is same as last word, reroll
        {
            game = new Game();
        }
        LetterLabel1.BackgroundColor = Colors.Gray; //reset background colours 
        LetterLabel2.BackgroundColor = Colors.Gray;
        LetterLabel3.BackgroundColor = Colors.Gray;
        LetterLabel4.BackgroundColor = Colors.Gray;
        LetterLabel5.BackgroundColor = Colors.Gray;
        AnswerWordDisplay.Text = game.answerWord;
        game.gamesPlayed = tempGamesPlayed;
        game.gamesWon = tempGames;
        game.streakCount = tempStreak;
        game.maxWinStreak = tempMaxStreak;
    }

    void HintButton_Clicked(System.Object sender, System.EventArgs e) //when clicked display hint of word for user 
    {
        DisplayAlert("HINT", "Your Hint: " + game.ProvideHint(), "THANKS MAN");
    }

    void StatsButton_Clicked(System.Object sender, System.EventArgs e) //when clicked display user stats
    {
        var temp = String.Format("{0:0}", game.getWinPercentage() * 100); //get rid of all the extra decimals so output looks better
        DisplayAlert("YOUR STATS", "Games Played: " + game.gamesPlayed +
             "\n Game Win Percentage: " + temp  + "%" + "\n Current Win Streak :"
             + game.getWinStreak() + "\n Max Win Streak:" + game.getMaxWinStreak(), "THANKS MAN");
    }
}


