using System;

namespace Alexander_Nguyen_A1V2;

public partial class MainPage : ContentPage
{
	int count = 0;

    Game game;

    public MainPage()
	{
        InitializeComponent();
        game = new Game();
        AnswerWordDisplay.Text = game.answerWord;  
    }

    void CheckButton_Clicked(System.Object sender, System.EventArgs e)
    {
        game.gamesPlayed++;

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
    }

    void HintButton_Clicked(System.Object sender, System.EventArgs e) //when clicked display hint of word for user 
    {
        DisplayAlert("HINT BCUZ U R NOOB", "Your Hint: " + game.ProvideHint(game.returnHintWord), "THANKS MAN");
    }

    void StatsButton_Clicked(System.Object sender, System.EventArgs e) //when clicked display user stats
    {
        var temp = String.Format("{0:0.00}", ((-game.getWinPercentage() + 1.00) * 100)); //get rid of all the extra decimals so output looks m
        DisplayAlert("YOUR STATS", "Games Played: " + game.gamesPlayed +
             "\n Game Win Percentage: " + temp  + "%" + "\n Current Win Streak :"
             + game.getWinStreak() + "\n Max Win Streak:" + game.getMaxWinStreak(), "THANKS MAN");
    }
}


