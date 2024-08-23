using System;
using System.Collections.Generic;

public class MathGame
{
    public string Operation { get; set; }
    public int Operand1 { get; set; }
    public int Operand2 { get; set; }
    public int Result { get; set; }

    public override string ToString()
    {
        return $"{Operand1} {Operation} {Operand2} = {Result}";
    }
}

class Program
{
    static List<MathGame> gameHistory = new List<MathGame>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Math Game Menu:");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            Console.WriteLine("5. View History");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformOperation("+");
                    break;
                case "2":
                    PerformOperation("-");
                    break;
                case "3":
                    PerformOperation("*");
                    break;
                case "4":
                    PerformOperation("/");
                    break;
                case "5":
                    ViewHistory();
                    break;
                case "6":
                    return; // Exit the program
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    static void PerformOperation(string operation)
    {
        Random rand = new Random();
        int operand1 = rand.Next(0, 101);
        int operand2 = rand.Next(0, 101);
        int result = 0;
        bool valid = true;

        switch (operation)
        {
            case "+":
                result = operand1 + operand2;
                break;
            case "-":
                result = operand1 - operand2;
                break;
            case "*":
                result = operand1 * operand2;
                break;
            case "/":
                if (operand2 != 0 && operand1 % operand2 == 0)
                {
                    result = operand1 / operand2;
                }
                else
                {
                    Console.WriteLine("Invalid division operation.");
                    valid = false;
                }
                break;
        }

        if (valid)
        {
            Console.WriteLine($"{operand1} {operation} {operand2} = {result}");
            gameHistory.Add(new MathGame
            {
                Operation = operation,
                Operand1 = operand1,
                Operand2 = operand2,
                Result = result
            });
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }

    static void ViewHistory()
    {
        Console.WriteLine("Game History:");
        if (gameHistory.Count == 0)
        {
            Console.WriteLine("No history available.");
        }
        else
        {
            foreach (var game in gameHistory)
            {
                Console.WriteLine(game);
            }
        }
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}
