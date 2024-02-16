namespace Alexander_Nguyen_A1V2;

public partial class MainPage : ContentPage
{
	int count = 0;
    Game game = new Game();
   
	public MainPage()
	{
        InitializeComponent();

        AnswerWordDisplay.Text = game.answerWord;

        
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
        }

        game.CheckUserGuess(WordEntry.Text);
        if (game.CheckUserGuess(WordEntry.Text) < 5)
        {
            if (game.CheckUserGuess(WordEntry.Text) == 0)
            {
                LetterLabel1.BackgroundColor = Colors.Orange;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 1)
            {
                LetterLabel2.BackgroundColor = Colors.Orange;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 2)
            {
                LetterLabel3.BackgroundColor = Colors.Orange;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 3)
            {
                LetterLabel4.BackgroundColor = Colors.Orange;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 4)
            {
                LetterLabel5.BackgroundColor = Colors.Orange;
            }
        }
        else if (game.CheckUserGuess(WordEntry.Text) > 4 && game.CheckUserGuess(WordEntry.Text) < 10)
        {
            if (game.CheckUserGuess(WordEntry.Text) == 5)
            {
                LetterLabel1.BackgroundColor = Colors.Green;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 6)
            {
                LetterLabel2.BackgroundColor = Colors.Green;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 7)
            {
                LetterLabel3.BackgroundColor = Colors.Green;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 8)
            {
                LetterLabel4.BackgroundColor = Colors.Green;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 9)
            {
                LetterLabel5.BackgroundColor = Colors.Green;
            }
        }
        else if (game.CheckUserGuess(WordEntry.Text) > 9 && game.CheckUserGuess(WordEntry.Text) != 20)
        {
            if (game.CheckUserGuess(WordEntry.Text) == 10)
            {
                LetterLabel1.BackgroundColor = Colors.Red;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 11)
            {
                LetterLabel1.BackgroundColor = Colors.Red;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 12)
            {
                LetterLabel1.BackgroundColor = Colors.Red;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 13)
            {
                LetterLabel1.BackgroundColor = Colors.Red;
            }
            else if (game.CheckUserGuess(WordEntry.Text) == 14)
            {
                LetterLabel1.BackgroundColor = Colors.Red;
            }
        }
    }

    void AnswerButton_Clicked(System.Object sender, System.EventArgs e)
    {
    }

    void HintButton_Clicked(System.Object sender, System.EventArgs e)
    {
        //game.ProvideHint();
    }

    void StatsButton_Clicked(System.Object sender, System.EventArgs e)
    {
    }
}


