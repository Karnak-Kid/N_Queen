using NQueen;
using System.Transactions;

const int min = 4;
const int max = 1000;

while (true)
{
    Console.Write("\nPress Q to quit otherwise,\n" +
        "Enter the amount of queens to solve for, " +
        "Minimum(" + min + ") - Maximum(" + max + "): ");
    string answer = Console.ReadLine();

    if (answer.ToUpper() == "Q")
        break;

    try
    {
        int value = Int32.Parse(answer);

        if (value < min || value > max)
        {
            Console.WriteLine("Error, entered value was out of range. Try again...\n");
            continue;
        }

        Solver solver = new Solver(value);
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
        continue;
    }
}


