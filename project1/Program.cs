using System;
using System.Collections.Generic;

public delegate void OnResult(string result);
public delegate string InputProvider(string prompt);

interface Operation
{
    void Perform();
}

class SumOperation : Operation
{
    private readonly OnResult onResult;
    private readonly InputProvider inputProvider;

    public SumOperation(OnResult onResult, InputProvider inputProvider)
    {
        this.onResult = onResult;
        this.inputProvider = inputProvider;
    }

    public void Perform()
    {
        int firstTerm = int.Parse(inputProvider("Enter first number: "));
        int secondTerm = int.Parse(inputProvider("Enter second number: "));
        onResult($"Sum: {firstTerm + secondTerm}");
    }
}

class DifferenceOperation : Operation
{
    private readonly OnResult onResult;
    private readonly InputProvider inputProvider;

    public DifferenceOperation(OnResult onResult, InputProvider inputProvider)
    {
        this.onResult = onResult;
        this.inputProvider = inputProvider;
    }

    public void Perform()
    {
        int firstTerm = int.Parse(inputProvider("Enter first number: "));
        int secondTerm = int.Parse(inputProvider("Enter second number: "));
        onResult($"Difference: {firstTerm - secondTerm}");
    }
}

class ExitOperation : Operation
{
    private readonly Action exitAction;
    private readonly OnResult onResult;

    public ExitOperation(Action exitAction, OnResult onResult)
    {
        this.exitAction = exitAction;
        this.onResult = onResult;
    }

    public void Perform()
    {
        exitAction();
        onResult("Program end");
    }
}

internal class Program
{
    static bool runs = true;

    private static void Main(string[] args)
    {
        var commands = new Dictionary<string, Operation>
        {
            { "sum", new SumOperation(Console.WriteLine, ReadInput) },
            { "diff", new DifferenceOperation(Console.WriteLine, ReadInput) },
            { "exit", new ExitOperation(() => runs = false, Console.WriteLine) }
        };

        while (runs)
        {
            Console.Write("Enter command , sum,diff or exit: ");
            string? command = Console.ReadLine();

            if (string.IsNullOrEmpty(command))
            {
                Console.WriteLine("Invalid input. Please enter a command.");
                continue;
            }

            if (commands.ContainsKey(command))
            {
                commands[command].Perform();
            }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }
    }

    public static string ReadInput(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? "";
    }
}
