using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // để in được tiếng Việt

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

        Console.WriteLine("\n=== Bài 6 ===");
        Bai6();
    }

    // Bài 1: Tính S(n) = 1 + 2 + 3 + ... + (n-1) + n
    static void Bai1()
    {
        int n = 5; // Ví dụ n = 5
        Console.WriteLine($"Kết quả S({n}) = {TinhBai1(n)}");
    }
    static int TinhBai1(int n)
    {
        if (n == 1) return 1; // Trường hợp suy biến
        return TinhBai1(n - 1) + n; // Trường hợp đệ quy
    }

    // Bài 2: Tính S(n) = 1 + 2^2 + 3^2 + ... + (n-1)^2 + n^2
    static void Bai2()
    {
        int n = 4; // Ví dụ n = 4
        Console.WriteLine($"Kết quả S({n}) = {TinhBai2(n)}");
    }
    static int TinhBai2(int n)
    {
        if (n == 1) return 1;
        return TinhBai2(n - 1) + n * n;
    }

    // Bài 3: Tính S(n) = 1 + 1/2 + 1/3 + ... + 1/(n-1) + 1/n
    static void Bai3()
    {
        int n = 4; // Ví dụ n = 4
        Console.WriteLine($"Kết quả S({n}) = {TinhBai3(n):F4}");
    }
    static double TinhBai3(int n)
    {
        if (n == 1) return 1.0;
        return TinhBai3(n - 1) + 1.0 / n;
    }

    // Bài 4: Tính S(x, n) = x^n
    static void Bai4()
    {
        double x = 2.0;
        int n = 3; // Ví dụ 2^3
        Console.WriteLine($"Kết quả S({x}, {n}) = {TinhBai4(x, n)}");
    }
    static double LuyThua(double x, int n)
    {
        if (n == 0) return 1;
        if (n > 0) return LuyThua(x, n - 1) * x;
        return 1.0 / LuyThua(x, -n);
    }
    static double TinhBai4(double x, int n)
    {
        if (n < 0) return 1.0 / LuyThua(x, -n);
        else return LuyThua(x, n);
    }

    // Bài 5: Tìm ước số lẻ lớn nhất của số nguyên dương n
    static void Bai5()
    {
        int n = 100; // Ví dụ n = 100, kết quả phải là 25
        Console.WriteLine($"Ước số lẻ lớn nhất của {n} là: {UocLeMax(n)}");
    }
    static int UocLeMax(int n)
    {
        if (n % 2 == 1) return n;
        return UocLeMax(n / 2);
    }

    // Bài 6: Tìm ước chung lớn nhất của 2 số nguyên dương a, b (Thuật toán Euclid)
    static void Bai6()
    {
        int a = 24, b = 36; // Ví dụ UCLN của 24 và 36
        Console.WriteLine($"Ước chung lớn nhất của {a} và {b} là: {UCLN(a, b)}");
    }
    static int UCLN(int a, int b)
    {
        if (a % b == 0) return b;
        return UCLN(b, a % b);
    }
}