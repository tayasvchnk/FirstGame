namespace FirstGame;
public enum Winner
{
    None,
    Win,
    Louse
}
//класс Game Главный класс
class Game
{
    public string Word { get; set; }
    public string Answer { get; set; }
    public int Counter { get; set; }

    public Game()
    {
        string[] words = File.ReadAllLines("WordsStockRus.txt");
        Random rnd = new Random();
        int randomIndex = rnd.Next(words.Length - 1);
        Word = words[randomIndex];

        for (int i = 0; i < Word.Length; i++)
        {
            Answer += '*';
        }

        Counter = 6;
    }

    public void Turn(char letChar)
    {
        string result = String.Empty;
        bool yesChar = true;
        for (int i = 0; i < Word.Length; i++)
        {
            if (Word[i] == letChar)
            {
                result += Word[i];
                yesChar = false;
            }
            else
            {
                result += Answer[i] != '*' ? Answer[i] : '*';
            }

        }
        if (yesChar)
        {
            Counter--;
        }
        Answer = result;
    }
    public Winner GetWinner()
    {
        if (Word == Answer)
        {
            return Winner.Win;
        }
        if (Counter == 0)
        {
            return Winner.Louse;
        }
        return Winner.None;
    }
}