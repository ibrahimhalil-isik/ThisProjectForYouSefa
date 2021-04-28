/*********************************************************************************
**                               SAKARYA ÜNİVERSİTESİ
**                     BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**                      BİLİŞİM SİSTEMLERİ MÜHENDİSLİĞİ BÖLÜMÜ
**                         NESNEYE DAYALI PROGRAMLAMA DERSİ
**                              2020-2021 BAHAR DÖNEMİ
**
**                     ÖDEV NUMARASI..........:
**                     ÖĞRENCİ ADI............:
**                     ÖĞRENCİ NUMARASI.......:
**                     DERSİN ALINDIĞI GRUP...:
*********************************************************************************/

using System;

namespace ThisProjectForYouSefa
{
    public class Program
    {
        // Programımız buradan çalışmaya başlıyor.
        static void Main(string[] args)
        {
            Console.Title = "Sefa Çiftçi";

            Operations operations = new Operations();
            operations.Operation(); // Giriş sayfamız olacak classı çağırıp programımızı başlatıyoruz. 
        }
    }

    // Karşımıza ilk çıkan ekran burası. Gidiş yolumuzu seçiyoruz.
    public class Operations
    {
        public void Operation()
        {
            Console.Clear();
            Console.WriteLine("\n ..:: İşlemler ::.. ");
            Console.WriteLine(" 1 - Matris İşlemleri ");
            Console.WriteLine(" 2 - String İşlemleri ");
            Console.WriteLine(" 3 - Çıkış ");
            Console.Write(" Seçiminiz : ");

            int path;
            path = Convert.ToInt16(Console.ReadLine());

            if (path == 1)
            {
                MatrixOperations matrixOperations = new MatrixOperations();
                matrixOperations.Matrix();
            }
            else
            {
                if (path == 2)
                {
                    StringOperations stringOperations = new StringOperations();
                    stringOperations.String();
                }
                else
                {
                    if (path == 3)
                    {
                        Exit exit = new Exit();
                        exit.LogOut();
                    }
                    else
                    {
                        ErrorMessage errorMessage = new ErrorMessage();
                        errorMessage.ErrorText();
                        Operation();
                    }
                }
            }
        }
    }

    // Giriş ekranında 1'e basarsak bu class çalışmaya başlıyor.
    public class MatrixOperations
    {
        // Bu classda kullanacağımız değişkenleri tanımlıyoruz. 
        int row;
        int value;
        int[,] matrix = new int[0, 0];


        //Bu Fonksiyon ile oluşturulacak matrisin boyutunu belirlemesi için kullanıcıdan değer alıyoruz.
        public void Matrix()
        {
            Console.Clear();
            Console.WriteLine("\n ..:: Matris İşlemleri ::.. ");


            Console.Write(" Matris satır sayısını giriniz(1-10 arasında) : ");

            row = Convert.ToInt16(Console.ReadLine());

            NumberCheck();

            Operations operations = new Operations();
            operations.Operation();
        }

        // Bu fonksiyon ile kullanıcıdan aldığımız değerin 1 ile 10 arasında olup olmadığını kontrol ediyoruz.
        public void NumberCheck()
        {
            if (row >= 1 && row <= 10)
            {
                ValueAssignmentMenu();
            }
            else // Eğer 1 ile 10 arasında değilse hata mesajı verip tekrar giriş sayfasına yönlendiriyoruz.
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.ErrorText();

                Operations operations = new Operations();
                operations.Operation();
            }
        }

        // Bu fonksiyon kullanıcıdan matrisdeki elemanların değerlerini almamızı sağlıyor.
        public void ValueAssignmentMenu()
        {
            matrix = new int[row, row]; //matrisi tanımlıyoruz.

            // İç içe döngü kullanarak kullanıcının sırası ile matrisin elemanlarını girmseini sağlıyoruz .
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    Console.Write("[" + i + "," + j + "] = ");
                    value = Convert.ToInt16(Console.ReadLine());
                    matrix[i, j] = value; // Kullanıcının girdiği değerleri matrise atıyoruz.
                }
            }

            Console.WriteLine();

            // İç içe döngü kullanarak kullanıcımızın oluşturduğu matrisi ekrana sırası ile yazdırıyoruz
            for (int i = 0; i <= matrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.GetUpperBound(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            MatrisOperationMenu();
        }

        // Bu fonksiyon matrisi listeledikten sonra ne yapacağımızı seçmek için önümüze iki seçenek koyuyor.
        public void MatrisOperationMenu()
        {
            string path1 = " 1-Satir En Buyuk ";
            string path2 = " 2-Satir Toplam ";
            Console.WriteLine();
            Console.WriteLine(path1);
            Console.WriteLine(path2);
            Console.Write(" Seçiminiz : ");

            int path;
            path = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();

            if (path == 1)
            {
                LargestNumber();
            }
            else if (path == 2)
            {
                RowTotal();
            }
            else  // Eğer 1 veya 2 dışında bir değer girilirse hata mesajı verip giriş sayfasına yönlendiriyoruz.
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.ErrorText();

                Operations operations = new Operations();
                operations.Operation();
            }
        }

        //Bu fonksiyon her bir satırdaki en büyük değeri bulmamızı sağlıyor. 
        public void LargestNumber()
        {
            int[] biggest = new int[row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (biggest[i] < matrix[i, j])
                    {
                        biggest[i] = matrix[i, j];
                    }
                }
            }

            Console.WriteLine();
            Console.Write("Sonuc : ");
            for (int i = 0; i < biggest.Length; i++)
            {
                Console.Write(biggest[i] + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        // Bu fonksiyon her bir satırdaki elemanları toplayıp ekrana yazdırıyor.
        public void RowTotal()
        {

            int[] rowTotal = new int[row];
            for (int i = 0; i < row; i++)
            {
                int total = 0;
                for (int j = 0; j < row; j++)
                {
                    total += matrix[i, j];
                }

                rowTotal[i] = total;
            }

            Console.WriteLine();
            Console.Write("Sonuc : ");
            for (int i = 0; i < rowTotal.Length; i++)
            {
                Console.Write(rowTotal[i] + " ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }

    // Giriş ekranında 2'e basarsak bu class çalışmaya başlıyor.
    public class StringOperations
    {
        // Bu classda kullanacağımız değişkenleri tanımlıyoruz. 
        string text;
        string search;
        int result1;
        int result2;

        // Bu fonksiyon ile kullanıcıdan işlem yapmak istediği kelime ve harfi alıyoruz
        public void String()
        {
            Console.Clear();
            Console.WriteLine("\n ..:: String İşlemleri ::.. ");


            Console.Write(" İşlem Yapılacak Stringi Giriniz : ");

            text = Console.ReadLine();

            Console.Write(" İstenen harf : ");

            search = Console.ReadLine();

            SearchCheck();

            Operations operations = new Operations();
            operations.Operation();  // Tüm işlemler bittikten sonra tekrar giriş sayfasına gitmemizi saülıyor.

        }

        // Bu fonksiyon kulanıcının girdiği kelimede, kullanıcıdan aldığımız harfin 2 tane olup olmadığını kontrol ediyor.
        public void SearchCheck()
        {
            result1 = text.IndexOf(search);
            result2 = text.LastIndexOf(search);

            if (result1 == result2 || result1 == -1)  // Eğer 2 tane yoksa hata mesajı verip giriş sayfasına yönlendiriyor.
            {
                Console.WriteLine(" Cümle içerisinde aranan harf bulunamamıştır ");
                Console.ReadLine();
                Operations operations = new Operations();
                operations.Operation();
            }
            else  // Eğer 2 tane varsa bir sonraki adıma geçiyor.
            {
                StringOperationMenu();
            }
        }

        // Bu fonksiyon kullanıcıya 2 seçenek sunup ne istediğini anlamamızı sağlıyor.
        public void StringOperationMenu()
        {
            string path1 = " 1-Ara metni tersten yaz ";
            string path2 = " 2-Ara metni tekrarlı yaz ";
            Console.WriteLine();
            Console.WriteLine(path1);
            Console.WriteLine(path2);
            Console.Write(" Seçiminiz : ");

            int path;
            path = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine();

            if (path == 1)
            {
                ReverseText();
            }
            else if (path == 2)
            {
                RepeatText();
            }
            else
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.ErrorText();
            }
        }

        // Bu fonksiyon eğer kullanıcı 1. seçeneği seçerse çalışıyor ve iki harf arasında kalan harfleri ekrana ters yazdırmamızı sağlıyor.
        public void ReverseText()
        {
            string reverse = text.Substring(result1 + 1, result2 - 1);
            for (int i = reverse.Length - 1; i >= 0; i--)
            {
                Console.Write(reverse[i]);
            }
            Console.ReadLine();
        }

        // Bu fonksiyon eğer kullanıcı 2. seçeneği seçerse çalışıyor ve iki harf arasında kalan harfleri ekrana 5 kere yazdırmamızı sağlıyor.
        public void RepeatText()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(text.Substring(result1 + 1, result2 - 1));
            }
            Console.ReadLine();
        }

    }

    // Giriş ekranında 3'e basarsak bu class çalışmaya başlıyor.
    public class Exit
    {
        public void LogOut()
        {
            string leave = "\n Çıkış Yapmak ";
            Console.WriteLine(leave);
            Console.WriteLine("\n Devam etmek için tıklayınız ");
            Console.ReadLine();
        }

    }

    // Giriş ekranında 1,2 ve 3 den farklı bi değer girersek bu class çalışmaya başlıyor.
    public class ErrorMessage
    {
        // Birden fazla yerde bu hata mesajını kullandığımız için fonksiyon haline getirip lazım olan yerlerde kullndık.
        public void ErrorText()  
        {
            Console.WriteLine("\n Hatalı Seçim");
            Console.WriteLine("\n Devam etmek için tıklayınız ");
            Console.ReadLine();
        }
    }

   

}
