
internal class Program
{
    static List<long> results = new List<long>();

    private static void Main(string[] args)
    {

        for (int i = 1; i < 10; i++)
        {
            Traverse(i, 0);
        }

        results.ForEach(r => Console.WriteLine(r));

        Console.WriteLine("Sum = " + results.Sum());
    }

    public static void Traverse(long num, int pow)
    {
        if (num > 100000000)
            return;

        if (IsPrime(num) && IsValidReverse(num))
        {
            if (IsValidForward(num))
            {
                long leftNumber = num / ((long)Math.Pow(10, pow));

                if (leftNumber != 1 && leftNumber != 9 && pow >= 1 && !results.Contains(num))
                {
                    results.Add(num);
                }
            }

            Traverse(num * 10 + 1, pow + 1);
            Traverse(num * 10 + 3, pow + 1);
            Traverse(num * 10 + 7, pow + 1);
            Traverse(num * 10 + 9, pow + 1);
        }
    }

    public static bool IsValidReverse(long number)
    {
        while (number > 0)
        {
            if (!IsPrime(number))
            {
                return false;
            }

            number /= 10;
        }

        return true;
    }

    public static bool IsValidForward(long number)
    {
        long digit = 10000000;
        while (digit >= 10)
        {

            long leftNumber = number / digit;

            if (leftNumber != 0)
            {
                number -= leftNumber * digit;

                if (!IsPrime(number))
                {
                    return false;
                }
            }


            digit /= 10;
        }

        return true;
    }



    public static bool IsPrime(long number)
    {
        if (number <= 1) return false;
        if (number <= 3) return true;
        if (number % 2 == 0 || number % 3 == 0) return false;

        var boundary = (long)Math.Floor(Math.Sqrt(number));

        for (long i = 5; i <= boundary; i += 6)
            if (number % i == 0 || number % (i + 2) == 0)
                return false;

        return true;
    }
}