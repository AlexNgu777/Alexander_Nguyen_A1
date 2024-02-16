using System;

namespace Alexander_Nguyen_A1V2;

public partial class MainPage : ContentPage
{
	int count = 0;
    Game game = new Game();
   
	public MainPage()
	{
        InitializeComponent();

        AnswerWordDisplay.Text = game.answerWord;

        //while(WordEntry.Text != null)
        //{
        //    char[] userInput = WordEntry.Text.ToCharArray(); //put user input into a char array and then put each letter in the display box
        //    LetterLabel1.Text = Convert.ToString(userInput[0]);
        //    LetterLabel2.Text = Convert.ToString(userInput[1]);
        //    LetterLabel3.Text = Convert.ToString(userInput[2]);
        //    LetterLabel4.Text = Convert.ToString(userInput[3]);
        //    LetterLabel5.Text = Convert.ToString(userInput[4]);

        //}
        
    }

    void CheckButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if(game.CheckUserGuess(WordEntry.Text) == 100)
        {
            LetterLabel1.BackgroundColor = Colors.Green;
            LetterLabel2.BackgroundColor = Colors.Green;
            LetterLabel3.BackgroundColor = Colors.Green;
            LetterLabel4.BackgroundColor = Colors.Green;
            LetterLabel5.BackgroundColor = Colors.Green;
            return;
        }

        for (int i = 0; i < WordEntry.Text.Length; i++)
        {

            if (game.CheckWordIndex(WordEntry.Text[i], i) < 5)
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
                        LetterLabel5.BackgroundColor = Colors.Orange;
                        break;
                    default:
                        Console.WriteLine("hello");
                        break;
                }
            }
            else if (game.CheckWordIndex(WordEntry.Text[i], i) > 4)
            {
                switch (game.CheckWordIndex(WordEntry.Text[i], i))
                {
                    case 5:
                        LetterLabel1.BackgroundColor = Colors.Orange;
                        break;
                    case 6:
                        LetterLabel2.BackgroundColor = Colors.Orange;
                        break;
                    case 7:
                        LetterLabel3.BackgroundColor = Colors.Orange;
                        break;
                    case 8:
                        LetterLabel4.BackgroundColor = Colors.Orange;
                        break;
                    case 9:
                        LetterLabel5.BackgroundColor = Colors.Orange;
                        break;
                    default:
                        Console.WriteLine("hello");
                        break;
                }
            }
            
        }
    }

    void AnswerButton_Clicked(System.Object sender, System.EventArgs e)
    {
        
    }

    void HintButton_Clicked(System.Object sender, System.EventArgs e)
    {
        DisplayAlert("HINT BCUZ U R NOOB", "Your Hint: " + game.ProvideHint(game.returnHintWord), "THANKS MAN");
    }

    void StatsButton_Clicked(System.Object sender, System.EventArgs e)
    {
        DisplayAlert("YOUR STATS", "Games Played: " + game.returnGameStats() +
            "\n Games won: " + game.returnGamesWon() + "\n Game Winstreak: " + game.returnGamesWon(), "THANKS MAN");
    }
}


