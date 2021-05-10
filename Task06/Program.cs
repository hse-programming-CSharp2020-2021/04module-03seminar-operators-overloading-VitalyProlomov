using System;

/*
Источник: https://docs.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/operator-overloading

Fraction - упрощенная структура, представляющая рациональное число.
Необходимо перегрузить операции:
+ (бинарный)
- (бинарный)
*
/ (в случае деления на 0, выбрасывать DivideByZeroException)

Тестирование приложения выполняется путем запуска разных наборов тестов, например,
на вход поступает две строки, содержацие числители и знаменатели двух дробей, разделенные /, соответственно.
1/3
1/6
Программа должна вывести на экран сумму, разность, произведение и частное двух дробей, соответственно,
с использованием перегруженных операторов (при необходимости, сокращать дроби):
1/2
1/6
1/18
2

Обратите внимание, если дробь имеет знаменатель 1, то он уничтожается (2/1 => 2). Если дробь в числителе имеет 0, то 
знаменатель также уничтожается (0/3 => 0).
Никаких дополнительных символов выводиться не должно.

Код метода Main можно подвергнуть изменениям, но вывод меняться не должен.
*/

public readonly struct Fraction
{
    private readonly int num;
    private readonly int den;

    public Fraction(int numerator, int denominator)
    {
        num = numerator;
        den = denominator;
    }

    public static int FindLargestCommonDemoninator(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);
        if (a == 0)
            return b;
        if (b == 0)
            return a;
        while (a != b)
        {
            if (a < b)
                b -= a;
            else
                a -= b;
        }
        return a;
    }

    static public int FindLeastCommonMultiplier(int a, int b)
    {
        int f = FindLargestCommonDemoninator(a, b);
        return a * b / f;
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        if (f1.den == 0 || f2.den == 0)
            throw new DivideByZeroException();
        int newDen = FindLeastCommonMultiplier(f1.den, f2.den);
        int GCD = FindLargestCommonDemoninator((f1.num * (newDen / f1.den) + f2.num * (newDen / f2.den)), newDen);
        return new Fraction((f1.num * (newDen / f1.den) + f2.num * (newDen / f2.den)) / GCD, newDen / GCD);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        Fraction fNew = new Fraction(-1 * f2.num, f2.den);
        return (f1 + fNew);
    }
    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        if (f1.den == 0 || f2.den == 0)
            throw new DivideByZeroException();
        int gcd = FindLargestCommonDemoninator(f1.num * f2.num, f1.den * f2.den);
        return new Fraction(f1.num * f2.num / gcd, f1.den * f2.den / gcd);

    }
    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        if (f2.num == 0)
            throw new DivideByZeroException();
        Fraction newF = new Fraction(f2.den, f2.num);
        return f1 * newF;
    }


    public override string ToString()
    {

        if (this.num == 0)
            return "0";
        if (den == 1)
        {
            return $"{num}";
        }
        if (den < 0)
        {
            return $"{-1 * num}/{-1 * den}";
        }
        return $"{num}/{den}";

    }
}

public static class OperatorOverloading
{
    public static void Main()
    {
        try
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            Fraction f1 = new Fraction(int.Parse(input1.Split('/')[0]), int.Parse(input1.Split('/')[1]));
            Fraction f2 = new Fraction(int.Parse(input2.Split('/')[0]), int.Parse(input2.Split('/')[1]));
            Console.WriteLine(f1 + f2);
            Console.WriteLine(f1 - f2);
            Console.WriteLine(f1 * f2);
            Console.WriteLine(f1 / f2);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("error");
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("zero");
        }
        catch (Exception)
        {
            Console.WriteLine("Make sure the input is correct");
        }
    }
}
