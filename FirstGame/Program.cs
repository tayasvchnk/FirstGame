namespace FirstGame;

using System.Text;
using static System.Console;

class Program
{
    private static Game _game = new Game();
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.Unicode;
        while (_game.GetWinner() == Winner.None)
        {
            PrintGame();
            Write("Введите букву: ");
            string? letString = ReadLine();
            if (letString != "" && letString is not null)
            {
                Char letChar = Char.Parse(letString);
                _game.Turn(letChar);
            }
        }
        PrintGame();
        WriteLine(_game.GetWinner() == Winner.Win ? "Победа" : $"Проиграл, слово было {_game.Word}");
        ReadKey(true);
    }

    static void PrintGame()
    {
        Clear();
        WriteLine($"Слово из {_game.Word.Length} букв, осталось ходов: {_game.Counter}");
        WriteLine(_game.Answer);
        string output = "";
        switch (_game.Counter)
        {
            case 6:
                output = @"
  ____   
 |    
 |
 |
 |
_| ___  ";
                break;
            case 5:
                output = @"
  ____   
 |    |
 |
 |
 |
_| ___  ";
                break;
            case 4:
                output = @"
  ____   
 |    |
 |    O
 |
 |
_| ___  ";
                break;
            case 3:
                output = @"
  ____   
 |    |
 |   _O_
 |
 |
_| ___  ";
                break;
            case 2:
                output = @"
  ____   
 |    |
 |   _O_
 |    |
 |
_| ___  ";
                break;
            case 1:
                output = @"
  ____   
 |    |
 |   _O_
 |    |
 |   /
_| ___  ";
                break;
            case 0:
                output = @"
  ____   
 |    |
 |   _O_
 |    |
 |   / \
_| ___  ";
                break;
        }
        Console.WriteLine(output);
    }
}
