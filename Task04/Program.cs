using System;

/*
Источник: https://metanit.com/

Класс Celcius представляет градусник по Цельсию, а Fahrenheit - градусник по Фаренгейту.
Определите операторы преобразования от типа Celcius и наоборот.
Преобразование температуры по шкале Фаренгейта (Tf) в температуру по шкале Цельсия (Tc): Tc = 5/9 * (Tf - 32).
Преобразование температуры по шкале Цельсия в температуру по шкале Фаренгейта: Tf = 9/5 * Tc + 32.

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки - количество градусов в Фаренгейтах и количество градусов в Цельсиях.
50
50
Программа должна вывести на экран число градусов в Цельсиях и Фаренгейтах, соответственно
с использованием перегруженных операторов (округлять до 2 знаков после запятой):
10,00
122,00

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task04
{
    public class Celcius
    {
        public double Gradus { get; set; }

        static public Fahrenheit ConvertToFr(Celcius celcius)
        {
            Fahrenheit retFr = new Fahrenheit() { Gradus = celcius.Gradus * 9 / 5 + 32 };
            return retFr;
        }

        public override string ToString()
        {
            //return String.Format("{0:0,00}", Gradus);

            return (string.Format("{0:F2}", Gradus)).Replace('.',',');
        }
    }

    public class Fahrenheit
    {
        public double Gradus { get; set; }

        static public Celcius ConvertToCelcius(Fahrenheit fahrenheit)
        {
            Celcius retCel = new Celcius { Gradus = (fahrenheit.Gradus - 32) * 5 / 9 };
            return retCel;
        }
        public override string ToString()
        {
            return (string.Format("{0:F2}", Gradus)).Replace('.', ',');
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            double fahrenheits = double.Parse(Console.ReadLine());
            double celcius = double.Parse(Console.ReadLine());
            Console.WriteLine(Fahrenheit.ConvertToCelcius(new Fahrenheit { Gradus = fahrenheits }));
            Console.WriteLine(Celcius.ConvertToFr(new Celcius { Gradus = celcius }));
        }
    }
}
