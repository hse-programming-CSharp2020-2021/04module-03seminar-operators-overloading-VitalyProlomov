using System;

/*
Источник: https://metanit.com/

Класс Dollar представляет сумму в долларах, а Euro - сумму в евро.

Определите операторы преобразования от типа Dollar в Euro и наоборот.
Допустим, 1 евро стоит 1,14 долларов. При этом один оператор должен подразумевать явное,
и один - неявное преобразование. Обработайте ситуации с отрицательными аргументами
(в этом случае должен быть выброшен ArgumentException).

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки - количество долларов и количество евро.
10
100
Программа должна вывести на экран количество евро и долларов, соответственно,
с использованием перегруженных операторов (округлять до 2 знаков после запятой):
8,77
114,00

Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

namespace Task05
{
    public class Dollar
    {
        public decimal Sum { get; set; }

        public override string ToString()
        {
            return (string.Format("{0:F2}", Sum)).Replace('.', ',');
        }

        public static implicit operator Euro(Dollar d)
        {
            return new Euro { Sum = d.Sum * new decimal(1.14) };
        }
    }


    public static class DollarConverter
    {
        public static Euro ConvertToEuro(this Dollar d)
        {
            return new Euro { Sum = d.Sum * new decimal(1.14) };
        }
    }

    public class Euro
    {
        public decimal Sum { get; set; }

        public static explicit operator Dollar(Euro euro)
        {
            return new Dollar { Sum = euro.Sum / new decimal(1.14) };
        }

        public override string ToString()
        {
            return (string.Format("{0:F2}", Sum)).Replace('.', ',');
        }
    }

    public static class EuroConverter
    {
        public static Dollar ConvertToDollar(this Euro e)
        {
            return new Dollar { Sum = e.Sum / new decimal(1.14) };
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                Euro euro = new Euro { Sum = decimal.Parse(Console.ReadLine()) };
                Dollar dollar = new Dollar { Sum = decimal.Parse(Console.ReadLine()) };
                if (euro.Sum < 0 || dollar.Sum < 0)
                    throw new ArgumentException();

                Console.WriteLine((Dollar)euro);
                Console.WriteLine((Euro)dollar);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("error");
            }
        }
    }
}
