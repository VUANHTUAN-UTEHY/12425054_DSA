using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;  

        Console.WriteLine(" ♥ Bài 1 ♥ ");
        Bai1();

        Console.WriteLine("\n ♥ Bài 2 ♥ ");
        Bai2();

        Console.WriteLine("\n ♥ Bài 3 ♥ ");
        Bai3();

        Console.WriteLine("\n ♥ Bài 4 ♥ ");
        Bai4();

        Console.WriteLine("\n ♥ Bài 5 ♥ ");
        Bai5();
    }

    // Bai 1
    static void Bai1()
    {
        Console.Write("Nhập số lượng phần tử n: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0) return;

        int[] a = new int[n];
        Console.WriteLine("Nhập các phần tử của mảng:");
        for (int i = 0; i < n; i++)
        {
            Console.Write($"a[{i}] = ");
            a[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("b. Mảng vừa nhập: ");
        Console.WriteLine(string.Join(" ", a));

        Console.Write("Nhập giá trị x cần chèn: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write($"Nhập vị trí k cần chèn (0 đến {n}): ");
        int k = int.Parse(Console.ReadLine());

        if (k < 0 || k > n)
        {
            Console.WriteLine("Vị trí k không hợp lệ!");
            return;
        }

        // chen x vao k dung trung gian tmp
        int[] tmp = new int[n + 1];
        for (int i = 0; i < k; i++)
        {
            tmp[i] = a[i];
        }
        tmp[k] = x;
        for (int i = k; i < n; i++)
        {
            tmp[i + 1] = a[i];
        }
        a = tmp;

        Console.Write("Mảng sau khi chèn: ");
        Console.WriteLine(string.Join(" ", a));
    }

    //Bai 2
    struct NhanVien
    {
        public string MaNV;
        public string Hoten;
        public int Namsinh;
        public string Phongban;
        public int LuongCB;
        public int Thuong;
        public int ThucLinh => LuongCB + Thuong;
    }

    static void Bai2()
    {
        NhanVien[] ds = new NhanVien[]
        {
            new NhanVien { MaNV = "NV03", Hoten = "Nguyễn Văn A", Namsinh = 2000, Phongban = "IT", LuongCB = 5000000, Thuong = 1500000 },
            new NhanVien { MaNV = "NV01", Hoten = "Trần Thị B", Namsinh = 2001, Phongban = "HR", LuongCB = 4500000, Thuong = 1000000 },
            new NhanVien { MaNV = "NV02", Hoten = "Lê Văn C", Namsinh = 1999, Phongban = "IT", LuongCB = 4500000, Thuong = 1200000 },
            new NhanVien { MaNV = "NV04", Hoten = "Phạm Thị D", Namsinh = 2002, Phongban = "Accounting", LuongCB = 6000000, Thuong = 2000000 }
        };

        //tong thuc linh
        long tongThucLinh = ds.Sum(nv => (long)nv.ThucLinh);
        Console.WriteLine($"a. Tổng thực lĩnh của tất cả nhân viên: {tongThucLinh:N0} VNĐ");

        int minLuongCB = ds.Min(nv => nv.LuongCB);
        Console.WriteLine($"b. Nhân viên có mức lương cơ bản thấp nhất ({minLuongCB:N0} VNĐ):");
        foreach (var nv in ds.Where(nv => nv.LuongCB == minLuongCB))
        {
            Console.WriteLine($"   - Mã: {nv.MaNV}, Tên: {nv.Hoten}, Phòng: {nv.Phongban}");
        }

        int demThuong = ds.Count(nv => nv.Thuong >= 1200000);
        Console.WriteLine($"c. Số lượng nhân viên có mức thưởng >= 1.200.000: {demThuong}");

        var sortedDs = ds.OrderBy(nv => nv.Phongban).ThenByDescending(nv => nv.MaNV).ToArray();
        Console.WriteLine("d. Danh sách sau khi sắp xếp (Tăng theo phòng ban, giảm theo mã NV):");
        foreach (var nv in sortedDs)
        {
            Console.WriteLine($"   - Phòng: {nv.Phongban}, Mã: {nv.MaNV}, Tên: {nv.Hoten}");
        }

        Console.WriteLine("e. Cập nhật tăng lương cơ bản thêm 5% cho nhân viên:");
        for (int i = 0; i < ds.Length; i++)
        {
            ds[i].LuongCB = (int)(ds[i].LuongCB * 1.05);
            Console.WriteLine($"   - {ds[i].Hoten}: Lương cơ bản mới = {ds[i].LuongCB:N0} VNĐ");
        }
    }

    // Bai 3 
    static void Bai3()
    {
        int n = 3;
        int[,] a = new int[,]
        {
            { 2, 5, 1 },
            { 4, 3, 6 },
            { 7, 8, 9 }
        };

        Console.WriteLine("Ma trận vuông hiện tại:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"{a[i, j]} ");
            }
            Console.WriteLine();
        }

        int tongTatCa = 0;
        foreach (int val in a) tongTatCa += val;
        Console.WriteLine($"a. Tổng tất cả các phần tử: {tongTatCa}");

        int minDuong = int.MaxValue;
        foreach (int val in a)
        {
            if (val > 0 && val < minDuong) minDuong = val;
        }
        if (minDuong == int.MaxValue) Console.WriteLine("b. Không có số dương trong ma trận.");
        else Console.WriteLine($"b. Giá trị dương nhỏ nhất: {minDuong}");

        int tongCheoPhu = 0;
        for (int i = 0; i < n; i++)
        {
            tongCheoPhu += a[i, n - 1 - i];
        }
        Console.WriteLine($"c. Tổng các phần tử trên đường chéo phụ: {tongCheoPhu}");

        bool tangDan = true;
        for (int i = 0; i < n - 1; i++)
        {
            if (a[i, i] > a[i + 1, i + 1])
            {
                tangDan = false;
                break;
            }
        }
        Console.WriteLine($"d. Các phần tử trên đường chéo chính có sắp xếp tăng dần không? {tangDan}");
    }
    //Bai 4
    class Node
    {
        public int Data;
        public Node Link;
        public Node(int data)
        {
            Data = data;
            Link = null;
        }
    }

    static void PrintList(Node head)
    {
        Node p = head;
        while (p != null)
        {
            Console.Write($"{p.Data} ");
            p = p.Link;
        }
        Console.WriteLine();
    }

    static void Bai4()
    {
        // Mau : 5 2 8 2 3 
        Node phead = new Node(5);
        phead.Link = new Node(2);
        phead.Link.Link = new Node(8);
        phead.Link.Link.Link = new Node(2);
        phead.Link.Link.Link.Link = new Node(3);

        Console.Write("Danh sách liên kết hiện tại: ");
        PrintList(phead);

        int x = 2;
        int demX = 0;
        Node p = phead;
        while (p != null)
        {
            if (p.Data == x) demX++;
            p = p.Link;
        }
        Console.WriteLine($"a. Số lượng phần tử có giá trị bằng {x}: {demX}");

        int minDuong = int.MaxValue;
        p = phead;
        while (p != null)
        {
            if (p.Data > 0 && p.Data < minDuong) minDuong = p.Data;
            p = p.Link;
        }
        if (minDuong == int.MaxValue) Console.WriteLine("b. Không có phần tử dương.");
        else Console.WriteLine($"b. Phần tử dương nhỏ nhất: {minDuong}");

        int xXoa = 2;
        Console.WriteLine($"c. Xóa phần tử có giá trị {xXoa} xuất hiện đầu tiên:");
        p = phead;
        Node t = null;
        bool found = false;
        while (p != null)
        {
            if (p.Data == xXoa)
            {
                if (t == null) phead = phead.Link; // xoa nut dau
                else t.Link = p.Link;              // Xóa nút giua & cuoi
                found = true;
                break;
            }
            t = p;
            p = p.Link;
        }

        if (found)
        {
            Console.Write("Danh sách sau khi xóa: ");
            PrintList(phead);
        }
        else
        {
            Console.WriteLine("Không tìm thấy giá trị cần xóa.");
        }
    }

    //Bai 5
    static void Bai5()
    {
        // Mau -3 0 5 2 7 11
        Node l = new Node(-3);
        l.Link = new Node(0);
        l.Link.Link = new Node(5);
        l.Link.Link.Link = new Node(2);
        l.Link.Link.Link.Link = new Node(7);
        l.Link.Link.Link.Link.Link = new Node(11);

        Console.Write("Danh sách l hiện tại: ");
        PrintList(l);

        int maxVal = int.MinValue;
        Node p = l;
        while (p != null)
        {
            if (p.Data > maxVal) maxVal = p.Data;
            p = p.Link;
        }
        Console.WriteLine($"a. Phần tử lớn nhất trong danh sách: {maxVal}");

        int tong = 0;
        p = l;
        while (p != null)
        {
            tong += p.Data;
            p = p.Link;
        }
        Console.WriteLine($"b. Tổng các phần tử: {tong}");

        int demSNT = 0;
        p = l;
        while (p != null)
        {
            if (IsPrime(p.Data)) demSNT++;
            p = p.Link;
        }
        Console.WriteLine($"c. Số lượng số nguyên tố: {demSNT}");

        int demAm = 0, demKhong = 0, demDuong = 0;
        p = l;
        while (p != null)
        {
            if (p.Data < 0) demAm++;
            else if (p.Data == 0) demKhong++;
            else demDuong++;
            p = p.Link;
        }
        Console.WriteLine($"d. Thống kê: Số âm = {demAm}, Số 0 = {demKhong}, Số dương = {demDuong}");

        int x = 5;
        int demX = 0;
        p = l;
        while (p != null)
        {
            if (p.Data == x) demX++;
            p = p.Link;
        }
        Console.WriteLine($"e. Số lượng phần tử bằng {x}: {demX}");

        int minDuong = int.MaxValue;
        p = l;
        while (p != null)
        {
            if (p.Data > 0 && p.Data < minDuong) minDuong = p.Data;
            p = p.Link;
        }
        if (minDuong == int.MaxValue) Console.WriteLine("f. Không có phần tử dương.");
        else Console.WriteLine($"f. Phần tử dương nhỏ nhất: {minDuong}");
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true; 
    } //vat
}