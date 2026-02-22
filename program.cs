using System;

class Program
{
    static void Main()
    {
        bool cikis = false;

        while (!cikis)
        {
            Console.Clear();
            Console.WriteLine("=== GELİŞMİŞ HESAP MAKİNESİ ===");
            Console.WriteLine("1. Toplama (+)");
            Console.WriteLine("2. Çıkarma (-)");
            Console.WriteLine("3. Çarpma (*)");
            Console.WriteLine("4. Bölme (/)");
            Console.WriteLine("5. Üs Alma (^)");
            Console.WriteLine("6. Karekök (√)");
            Console.WriteLine("7. Çıkış");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1": IslemiGerceklestir("+"); break;
                case "2": IslemiGerceklestir("-"); break;
                case "3": IslemiGerceklestir("*"); break;
                case "4": IslemiGerceklestir("/"); break;
                case "5": IslemiGerceklestir("^"); break;
                case "6": IslemiGerceklestir("√"); break;
                case "7": cikis = true; Console.WriteLine("Hesap makinesinden çıkılıyor..."); break;
                default: Console.WriteLine("Geçersiz seçim! Enter'a basın."); Console.ReadLine(); break;
            }
        }
    }

    static void IslemiGerceklestir(string islem)
    {
        Console.Clear();
        double sayi1 = 0, sayi2 = 0;

        if (islem != "√")
        {
            Console.Write("Birinci sayıyı girin: ");
            if (!double.TryParse(Console.ReadLine(), out sayi1)) { Hata(); return; }

            Console.Write("İkinci sayıyı girin: ");
            if (!double.TryParse(Console.ReadLine(), out sayi2)) { Hata(); return; }
        }
        else
        {
            Console.Write("Karekökü alınacak sayıyı girin: ");
            if (!double.TryParse(Console.ReadLine(), out sayi1)) { Hata(); return; }
        }

        double sonuc = islem switch
        {
            "+" => sayi1 + sayi2,
            "-" => sayi1 - sayi2,
            "*" => sayi1 * sayi2,
            "/" => sayi2 != 0 ? sayi1 / sayi2 : double.NaN,
            "^" => Math.Pow(sayi1, sayi2),
            "√" => sayi1 >= 0 ? Math.Sqrt(sayi1) : double.NaN,
            _ => 0
        };

        if (islem == "/" && sayi2 == 0) Console.WriteLine("Bir sayı sıfıra bölünemez!");
        else if (islem == "√" && sayi1 < 0) Console.WriteLine("Negatif sayının karekökü alınamaz!");
        else Console.WriteLine($"Sonuç: {sonuc}");

        Console.WriteLine("Enter'a basın.");
        Console.ReadLine();
    }

    static void Hata()
    {
        Console.WriteLine("Geçersiz sayı! Enter'a basın.");
        Console.ReadLine();
    }
}