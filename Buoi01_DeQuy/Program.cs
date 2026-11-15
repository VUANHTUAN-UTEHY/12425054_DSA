using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;  

        Console.WriteLine("=== Bài 1 ===");
        Bai1();

        Console.WriteLine("\n=== Bài 2 ===");
        Bai2();

        Console.WriteLine("\n=== Bài 3 ===");
        Bai3();

        Console.WriteLine("\n=== Bài 4 ===");
        Bai4();

        Console.WriteLine("\n=== Bài 5 ===");
        Bai5();
    }

    static void Bai1()
    {
        Random rand = new Random();
        int[] arr = new int[1000];
        
        for (int i = 0; i < 1000; i++)
        {
            arr[i] = rand.Next(0, 10000);
        }

        int maxVal = arr[0];
        int minVal = arr[0];

        foreach (int num in arr)
        {
            if (num > maxVal) maxVal = num;
            if (num < minVal) minVal = num;
        }

        Console.WriteLine("Đã tạo ngẫu nhiên 1000 số tự nhiên thành công.");
        Console.WriteLine($"a. Số lớn nhất trong mảng là: {maxVal}");
        Console.WriteLine($"b. Số nhỏ nhất trong mảng là: {minVal}");
    }

    static void Bai2()
    {
        Console.WriteLine("Kết quả bài toán FizzBuzz từ 1 đến 100:");
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.Write("FizzBuzz ");
            }
            else if (i % 3 == 0)
            {
                Console.Write("Fizz ");
            }
            else if (i % 5 == 0)
            {
                Console.Write("Buzz ");
            }
            else
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine();
    }

    static void Bai3()
    {
        Console.Write("Nhập vào một chuỗi bất kỳ: ");
        string input = Console.ReadLine();
        
        if (!string.IsNullOrEmpty(input))
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            string reversed = new string(charArray);
            Console.WriteLine($"Chuỗi đảo ngược là: {reversed}");
        }
        else
        {
            Console.WriteLine("Chuỗi nhập vào rỗng.");
        }
    }

    static void Bai4()
    {
        Random rand = new Random();
        int[] arr = new int[1000];

        for (int i = 0; i < 1000; i++)
        {
            arr[i] = rand.Next(0, 10000);
        }

        Console.WriteLine("a. In mảng ra màn hình (hiển thị 10 phần tử đầu tiên để dễ theo dõi):");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine("...");

        Array.Sort(arr);

        Console.WriteLine("b. Mảng sau khi sắp xếp tăng dần (hiển thị 10 phần tử đầu tiên):");
        for (int i = 0; i < 10; i++)
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine("...");
    }

    static void Bai5()
    {
        Console.Write("Nhập vào số nguyên dương n: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
        {
            long fib = GetFibonacci(n);
            Console.WriteLine($"Số Fibonacci thứ {n} là: {fib}");
        }
        else
        {
            Console.WriteLine("Vui lòng nhập một số nguyên dương hợp lệ.");
        }
    }

    static long GetFibonacci(int n)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;

        long a = 0, b = 1, c = 0;
        for (int i = 2; i <= n; i++)
        {
            c = a + b;
            a = b;
            b = c;
        }
        return c;
    }
}