class Program
{
    static Dictionary<string, char> TYPE_MAP = new Dictionary<string, char>(){
        { "TYPE_ADD", '+' },
        { "TYPE_SUB", '-' },
        { "TYPE_MULT", '*' },
        { "TYPE_DIV", '/' },
    };

    public static void Main(string[] args)
    {
        // do math
        float number1 = handleNumberInput();
        char evalType = handleMathTypeInput();
        float number2 = handleNumberInput(true);

        float result = evalType switch
        {
            '+' => doAdd(number1, number2),
            '-' => doSubtract(number1, number2),
            '*' => doMultiply(number1, number2),
            '/' => doDivision(number1, number2),
        };

        Console.WriteLine($"Answer: {result}");
    }

    private static char handleMathTypeInput()
    {
        Console.WriteLine("""
            Would you like to Add, Subtract, Divide, or Multiply?
            Please enter:
                '+' for Addition
                '-' for Subtraction
                '*' for Multiplication
                '/' for Division
            """);

        // Could use char but due to the timeframe, no need to rewrite
        char input = Console.ReadKey().KeyChar;

        if (!TYPE_MAP.ContainsValue(input))
        {
            Console.WriteLine("\nOops! The operation you entered is not valid, please try again.\n");
            handleMathTypeInput();
        }

        return input;
    }

    private static float handleNumberInput(bool isSecondNumber = false)
    {
        // Ideally I'd add try/catches to ensure types and whatnot
        if (isSecondNumber)
        {
            Console.WriteLine("\nPlease enter another number");
        }
        else
        {
            Console.WriteLine("Please enter a number, this number can be a decimal");
        }

        string? input = Console.ReadLine();
        float number = float.Parse(input);

        if (number == 0.0)
        {
            Console.WriteLine("\nOops! The number you entered is not valid, please try again.\n");
            handleNumberInput();
        }

        return number;
    }

    // Could use double but do not need the precision
    private static float doAdd(float number1, float number2)
    {
        return number1 + number2;
    }

    private static float doSubtract(float number1, float number2)
    {
        return number1 - number2;
    }

    private static float doMultiply(float number1, float number2)
    {
        return number1 * number2;
    }

    private static float doDivision(float number1, float number2)
    {
        return (number1 / number2);
    }
}
