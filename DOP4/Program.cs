using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public interface IStorable
{
    void SaveState(string fileName);
    void LoadState(string fileName);
}

[Serializable]
public class AdvancedCalculator : IStorable
{
    // Поля или свойства калькулятора
    private double result;

    public AdvancedCalculator()
    {
        // Инициализация калькулятора при необходимости
        result = 0;
    }

    // Методы калькулятора

    public double Add(double a, double b)
    {
        result = a + b;
        return result;
    }

    public double Subtract(double a, double b)
    {
        result = a - b;
        return result;
    }

    // Реализация методов интерфейса IStorable

    public void SaveState(string fileName)
    {
        try
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, this);
            }

            Console.WriteLine("Состояние калькулятора сохранено в файле: " + fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при сохранении состояния: " + ex.Message);
        }
    }

    public void LoadState(string fileName)
    {
        try
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                AdvancedCalculator loadedCalculator = (AdvancedCalculator)formatter.Deserialize(stream);

                // Копирование состояния из загруженного калькулятора в текущий
                this.result = loadedCalculator.result;
            }

            Console.WriteLine("Состояние калькулятора загружено из файла: " + fileName);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при загрузке состояния: " + ex.Message);
        }
    }
}

class Program
{
    static void Main()
    {
        // Пример использования
        AdvancedCalculator calculator = new AdvancedCalculator();

        // Выполнение операций с калькулятором
        calculator.Add(5, 3);
        Console.WriteLine("Результат: " + calculator.GetResult());

        // Сохранение состояния калькулятора
        calculator.SaveState("calculator_state.bin");

        // Изменение состояния калькулятора
        calculator.Subtract(10, 2);
        Console.WriteLine("Результат: " + calculator.GetResult());

        // Загрузка состояния калькулятора из файла
        calculator.LoadState("calculator_state.bin");
        Console.WriteLine("Результат после загрузки: " + calculator.GetResult());
    }
}
