using System;
using System.IO;
using System.Linq;

class Program
{
    // Путь к входному и выходному файлам
    private const string inputFilePath = "C:\\Users\\Admin\\Desktop\\text.txt";
    private const string outputFilePath = "C:\\Users\\Admin\\Desktop\\result.txt";

    static void Main(string[] args)
    {
        // Попытка выполнения основных операций считывания и анализа файла
        try
        {
            // Получение текста из входного файла
            string text = File.ReadAllText(inputFilePath);

            // Подсчет общего количества символов
            int totalCharacters = text.Length;

            // Подсчет количества символов без пробелов
            int nonWhitespaceCharacters = text.Count(c => !char.IsWhiteSpace(c));

            // Подсчет количества слов
            int wordCount = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;

            // Формирование строки с результатами
            string results = FormatResults(totalCharacters, nonWhitespaceCharacters, wordCount);

            // Вывод результатов на экран
            Console.WriteLine(results);

            // Запись результатов в выходной файл
            File.WriteAllText(outputFilePath, results);
        }
        catch (FileNotFoundException ex)
        {
            // Обработка ошибки отсутствия файла
            Console.WriteLine("Ошибка: файл не найден.");
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            // Обработка других ошибок ввода-вывода
            Console.WriteLine("Ошибка при чтении файла.");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            // Обработка любых других исключений
            Console.WriteLine("Произошла ошибка.");
            Console.WriteLine(ex.Message);
        }
    }

    // Метод для форматирования результатов в виде строки
    private static string FormatResults(int totalChars, int nonWhitespaceChars, int wordCount)
    {
        return $"Количество символов: {totalChars}\n" +
               $"Количество символов без пробелов: {nonWhitespaceChars}\n" +
               $"Количество слов: {wordCount}";
    }
}