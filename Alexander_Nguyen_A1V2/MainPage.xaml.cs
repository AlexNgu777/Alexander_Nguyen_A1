namespace Alexander_Nguyen_A1V2;

public partial class MainPage : ContentPage
{
	int count = 0;
    Game game = new Game();
    
    Word word = new Word(game.RandomWord(), "hello");

    

	public MainPage()
	{
        game.FillList();
        string answerWord = game.RandomWord();
        
    }

    void CheckButton_Clicked(System.Object sender, System.EventArgs e)
    {
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


