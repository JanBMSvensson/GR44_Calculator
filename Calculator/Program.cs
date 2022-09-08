
using static System.Console;

ConsoleKeyInfo MenuInput;
do
{
    WriteLine();
    WriteLine("MAIN MENU");
    WriteLine("Press key 1-2 to select Calculator version or ESC to exit: ");

    MenuInput = Console.ReadKey(true);
    switch (MenuInput.Key)
    {
        case ConsoleKey.D1:
        case ConsoleKey.NumPad1:
            CalculatorV01();
            break;

        case ConsoleKey.D2:
        case ConsoleKey.NumPad2:
            Calculator02();
            break;

        case ConsoleKey.D3:
        case ConsoleKey.NumPad3:
            Calculator03();
            break;
    }
}
while (MenuInput.Key != ConsoleKey.Escape);


void CalculatorV01()
{
    WriteLine();
    WriteLine("---------- Basic Calculator ----------");

    while(true)
    {
        WriteLine();
        var value1 = GetNumericInputFromUser("Enter a number: ");
        if (!value1.HasValue) return;

        Write("Press an operator key [ + - * / ]:");
        var key = GetMathKeyFromUser();
        if (key == ConsoleKey.Escape) return;
        WriteLine();

        var value2 = GetNumericInputFromUser("Enter a second number: ");
        if (!value2.HasValue) return;

        decimal? CalcResult = null;

        switch (key)
        {
            case ConsoleKey.Add:
                CalcResult = value1.Value + value2.Value;
                break;

            case ConsoleKey.Subtract:
                CalcResult = value1.Value - value2.Value;
                break;

            case ConsoleKey.Multiply:
                CalcResult = value1.Value * value2.Value;
                break;

            case ConsoleKey.Divide:
                if (value2.Value != 0)
                {
                    CalcResult = value1.Value / value2.Value;
                }
                break;

            default:
                throw new Exception("Should not happen!");
        }

        WriteLine($"The result is {(CalcResult.HasValue ? CalcResult.Value : "not possible to calculate!")}");
    }

}


async void Calculator02()
{
    WriteLine();
    WriteLine("-------- Expression Calculator ---------");
    WriteLine();
    WriteLine("Methods/constants from the System.Math namespace can be included, i.e. Abs(Round(-123 * PI,3))");
    WriteLine();

    while (true)
    {
        WriteLine("Enter an expression to calculate: ");
        var expr = ReadLine();
        if (String.IsNullOrEmpty(expr))
        {
            return;
        }

        try
        {
            var result = await Microsoft.CodeAnalysis.CSharp.Scripting.CSharpScript.EvaluateAsync(expr, Microsoft.CodeAnalysis.Scripting.ScriptOptions.Default.WithImports("System.Math"));
            WriteLine($"{expr} = {result}");

        }
        catch (Exception ex)
        {
            WriteLine($"{expr} couldn't be calculated: '{ex.Message}'");
        }
        WriteLine();
    }
}

void Calculator03()
{
    //Console.CursorSize = 1;
    Console.SetCursorPosition(10, 10);
    Write("XYZ");
    ReadKey(true);
    Console.SetCursorPosition(11, 10);
    Write("1 ");
    Console.SetCursorPosition(12, 10);
    ReadKey(true);

}

//(decimal value, int op) GetUserInput2() 
//{
//    return new(1.2,2);

//}







ConsoleKey GetMathKeyFromUser ()
{
    while (true)
    {
        var keyinfo = ReadKey(true);
        switch(keyinfo.Key)
        {
            case ConsoleKey.OemPlus:
            case ConsoleKey.Add:
                Write("+");
                return ConsoleKey.Add;

            case ConsoleKey.OemMinus:
            case ConsoleKey.Subtract:
                Write("-");
                return ConsoleKey.Subtract;

            case ConsoleKey.Divide:
            case ConsoleKey.D7 when keyinfo.Modifiers == ConsoleModifiers.Shift:
                Write("/");
                return ConsoleKey.Divide;

            case ConsoleKey.Multiply:
            case ConsoleKey.Oem2 when keyinfo.Modifiers == ConsoleModifiers.Shift:
                Write("*");
                return ConsoleKey.Multiply;

            case ConsoleKey.Escape:
                return keyinfo.Key;
        }
    }
}

decimal? GetNumericInputFromUser(string userQuestion)
{
    Write(userQuestion);
    if (decimal.TryParse(ReadLine(), out decimal ParsedValue))
    {
        return ParsedValue;
    }

    return null;
}
