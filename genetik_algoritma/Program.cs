using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genetik_algoritma
{
    class Program
    {
      
        struct gen
        {
            public int x;
            public int y;
            public int f;
        }
        static int a, b,ans;
        static gen[] dizi,dizi2;
        static int f(int x,int y)
        {
            return x * x + y;
        }
        static void sort(gen[] K)
        {
            gen temp;
            if (ans == 1)
            {
                for (int i = 0; i < K.Length - 1; i++)
                {
                    for (int j = i + 1; j < K.Length; j++)
                    {
                        if (K[i].f > K[j].f)
                        {
                            temp = K[i];
                            K[i] = K[j];
                            K[j] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < K.Length - 1; i++)
                {
                    for (int j = i + 1; j < K.Length; j++)
                    {
                        if (K[i].f < K[j].f)
                        {
                            temp = K[i];
                            K[i] = K[j];
                            K[j] = temp;
                        }
                    }
                }
            }
           
        }
        static void ilk_nesil()
        {
            Random r = new Random();
            dizi = new gen[100];
            for (int i = 0; i < dizi.Length; i++)
            {
                dizi[i].x = r.Next(a, b + 1);
                dizi[i].y = r.Next(a, b + 1);
                dizi[i].f = f(dizi[i].x, dizi[i].y);
            }
            Console.WriteLine("Birinci nesil oluştu...");
        }//Create first generation
        static void crossing()
        {
            dizi2 = new gen[50];
            int s = 0;
            for (int i = 0; i < dizi.Length/2; i+=2)
            {
                dizi2[s].x = dizi[i].x;
                dizi2[s].y = dizi[i + 1].y;
                dizi2[s].f = f(dizi2[s].x, dizi2[s].y);
                s++;
                dizi2[s].x = dizi[i+1].x;
                dizi2[s].y = dizi[i].y;
                dizi2[s].f = f(dizi2[s].x, dizi2[s].y);
                s++;
            }
        }//crossing the generation
        static void selection()
        {
            int ana_sayac = 0,dizi1_sayac=0,dizi2_sayac=0;
            gen[] dizi3 = new gen[100];
            sort(dizi);
            sort(dizi2);
            do
            {

                if (dizi2_sayac==49)
                {
                    do
                    {
                        dizi3[ana_sayac] = dizi[dizi1_sayac];
                        dizi1_sayac++;
                        ana_sayac++;
                    } while (ana_sayac!=99);
                    break;
                }


                if (ans == 1)
                {
                    if (dizi[dizi1_sayac].f < dizi2[dizi2_sayac].f)
                    {
                        dizi3[ana_sayac] = dizi[dizi1_sayac];
                        dizi1_sayac++;
                    }
                    else
                    {
                        dizi3[ana_sayac] = dizi2[dizi2_sayac];
                        dizi2_sayac++;
                    }
                }
                else
                {
                    if (dizi[dizi1_sayac].f > dizi2[dizi2_sayac].f)
                    {
                        dizi3[ana_sayac] = dizi[dizi1_sayac];
                        dizi1_sayac++;
                    }
                    else
                    {
                        dizi3[ana_sayac] = dizi2[dizi2_sayac];
                        dizi2_sayac++;
                    }
                }
                ana_sayac++;
            } while (ana_sayac!=99);
            dizi = dizi3;
        }//select the best values between crossed array and generation
        static void yeni_nesil()
        {
            sort(dizi);
            crossing();
            selection();
            Console.WriteLine("Yeni nesil Üretildi");
        }//Create new generation
        static void Main(string[] args)
        {
            int cvp;
            Console.WriteLine("f=x^2+y için [a,b] aralığını giriniz");
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Minimum mu Maksimum mu?1/0");
            ans= Convert.ToInt32(Console.ReadLine());
            ilk_nesil();
            do
            {
                Console.WriteLine("Yeni nesil yaratılsın mı?1/0");
                cvp= int.Parse(Console.ReadLine());
                yeni_nesil();

            } while (cvp==1);
            sort(dizi);
            Console.WriteLine("En iyi sonuc="+dizi[0].f);
            Console.WriteLine("x="+dizi[0].x+"\n"+"y="+dizi[0].y);
            Console.Read();
        }
    }
}
