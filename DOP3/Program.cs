using System;

// Интерфейс для базовых операций калькулятора
public interface ICalculatable
{
    double Add(double a, double b);
    double Subtract(double a, double b);
    double Multiply(double a, double b);
    double Divide(double a, double b);
}

// Реализация базового калькулятора
public class BasicCalculator : ICalculatable
{
    public double Add(double a, double b)
    {
        return a + b;
    }

    public double Subtract(double a, double b)
    {
        return a - b;
    }

    public double Multiply(double a, double b)
    {
        return a * b;
    }

    public double Divide(double a, double b)
    {
        if (b != 0)
        {
            return a / b;
        }
        else
        {
            Console.WriteLine("Ошибка: Деление на ноль");
            return double.NaN; // Не число
        }
    }
}

// Расширение базового калькулятора с добавлением возведения в степень и извлечения квадратного корня
public class AdvancedCalculator : BasicCalculator, ICalculatable
{
    public double Power(double baseValue, double exponent)
    {
        double result = Math.Pow(baseValue, exponent);
        Console.WriteLine($"{baseValue} ^ {exponent} = {result}");
        return result;
    }

    public double SquareRoot(double value)
    {
        if (value >= 0)
        {
            double result = Math.Sqrt(value);
            Console.WriteLine($"Квадратный корень из {value} = {result}");
            return result;
        }
        else
        {
            Console.WriteLine("Ошибка: Невозможно извлечь корень из отрицательного числа");
            return double.NaN;
        }
    }
}

class Program
{
    static void Main()
    {
        // Пример использования AdvancedCalculator
        AdvancedCalculator advancedCalculator = new AdvancedCalculator();

        // Базовые операции
        double sum = advancedCalculator.Add(5, 3);
        Console.WriteLine($"5 + 3 = {sum}");

        double difference = advancedCalculator.Subtract(8, 4);
        Console.WriteLine($"8 - 4 = {difference}");

        double product = advancedCalculator.Multiply(2, 6);
        Console.WriteLine($"2 * 6 = {product}");

        double quotient = advancedCalculator.Divide(9, 3);
        Console.WriteLine($"9 / 3 = {quotient}");

        // Дополнительные операции
        double resultPower = advancedCalculator.Power(2, 3);
        double resultSquareRoot = advancedCalculator.SquareRoot(9);
    }
}
