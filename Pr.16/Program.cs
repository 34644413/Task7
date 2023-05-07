using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Відкриваємо файли для читання та запису
        StreamReader reader = new StreamReader("input.txt");
        StreamWriter writer = new StreamWriter("output.txt");

        // Зчитуємо значення і трансформуємо їх у масив рядків
        string input = reader.ReadToEnd();
        string[] surnames = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        // Запитуємо користувача про номер прізвища для обробки
        Console.Write("Введіть номер прізвища для обробки: ");
        int i = int.Parse(Console.ReadLine()) - 1;

        // Запитуємо користувача про номер j-того прізвища
        Console.Write("Введіть номер j-того прізвища: ");
        int j = int.Parse(Console.ReadLine()) - 1;

        // Визначаємо символи, які входять у j-те прізвище
        string jSurname = surnames[j];
        bool[] jChars = new bool[256];
        foreach (char c in jSurname)
        {
            jChars[c] = true;
        }

        // Виводимо і-те прізвище, якщо всі його символи входять у j-те прізвище
        string iSurname = surnames[i];
        bool allCharsFound = true;
        foreach (char c in iSurname)
        {
            if (!jChars[c])
            {
                allCharsFound = false;
                break;
            }
        }

        if (allCharsFound)
        {
            writer.WriteLine(iSurname);
            Console.WriteLine("Прізвище записано у файл output.txt");
        }
        else
        {
            Console.WriteLine("Не всі символи прізвища входять у j-те прізвище");
        }

        // Закриваємо файли
        reader.Close();
        writer.Close();
    }
}
