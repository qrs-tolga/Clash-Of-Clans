using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClashOfClans
{
    class ClashOfClans
    {
        int altin;
        int iksir;
        int karaIksir;
        int[] askerSayisi = new int[3];
        int[] binalar = new int[3];
        int[] yukseltmeFiyatlari = new int[5];
        int[] yukseltmeGucleri = new int[5];
        int guc;

        public ClashOfClans()
        {
            // Başlangıçta Verilecek Miktarlar
            altin = 10000;
            iksir = 10000;
            karaIksir = 1000;

            askerSayisi[0] = 100; // Barbar Sayısı
            askerSayisi[1] = 100; // Okçu Sayısı
            askerSayisi[2] = 50; // Büyücü Sayısı

            binalar[0] = 1; // Belediye Binası
            binalar[1] = 1; // Klan Binası
            binalar[2] = 1; // Kışla Binası

            yukseltmeFiyatlari[0] = 1000; // 1.Seviye Yükseltme Fiyatı
            yukseltmeFiyatlari[1] = 2000; // 2.Seviye Yükseltme Fiyatı
            yukseltmeFiyatlari[2] = 5000; // 3.Seviye Yükseltme Fiyatı
            yukseltmeFiyatlari[3] = 10000; // 4.Seviye Yükseltme Fiyatı
            yukseltmeFiyatlari[4] = 15000; // 5.Seviye Yükseltme Fiyatı

            yukseltmeGucleri[0] = 200; // 1.Seviye Yükseltme İle Kazanılacak Güç
            yukseltmeGucleri[1] = 500; // 2.Seviye Yükseltme İle Kazanılacak Güç
            yukseltmeGucleri[2] = 1000; // 3.Seviye Yükseltme İle Kazanılacak Güç
            yukseltmeGucleri[3] = 2000; // 4.Seviye Yükseltme İle Kazanılacak Güç
            yukseltmeGucleri[4] = 4000; // 5.Seviye Yükseltme İle Kazanılacak Güç
        }

        public void kaynakGoster()
        {
            Console.WriteLine("\n---------- Kaynak Miktarları ----------");
            Console.WriteLine("Altın Miktarı : " + altin);
            Console.WriteLine("İksir Miktarı : " + iksir);
            Console.WriteLine("Kara İksir Miktarı : " + karaIksir);
        }

        public void kaynakTopla()
        {
            Console.WriteLine("\n----------- Kaynak Toplama -----------");
            altin += 1000;
            iksir += 1000;
            karaIksir += 1000;
            Console.WriteLine("Altın Miktarı : " + altin);
            Console.WriteLine("İksir Miktarı : " + iksir);
            Console.WriteLine("Kara İksir Miktarı : " + karaIksir);

        }

        public void askerGoster()
        {
            Console.WriteLine("\n----------- Asker Miktarları -----------");
            Console.WriteLine("Barbar Miktarı : " + askerSayisi[0]);
            Console.WriteLine("Okçu Miktarı : " + askerSayisi[1]);
            Console.WriteLine("Büyücü Miktarı : " + askerSayisi[2]);
        }

        public void gucGoster()
        {
            Console.WriteLine("\n----------------- Güç -----------------");
            Console.WriteLine("Köyünüzün Gücü : " + guc);
        }
        public void askerUret(byte tur, int askerMiktar)
        {
            Console.WriteLine("\n------------- Asker Üretme -------------");
            int gerekenMiktar;

            switch(tur)
            {
                case 1: // Barbar Üretme
                    gerekenMiktar = askerMiktar * 10; // Barbar Üretmek İçin Gereken İksir
                    if(iksir >= gerekenMiktar)
                    {
                        iksir -= gerekenMiktar;
                        askerSayisi[0] += askerMiktar;
                        Console.WriteLine($"{askerMiktar} Tane Barbar Üretildi.");
                        askerGoster();
                        guc += askerMiktar*5;
                    }
                    else
                    {
                        Console.WriteLine($"İksiriniz Yetmiyor ,{gerekenMiktar - iksir} İksir Daha Lazım.");
                    }
                    break;

                case 2: // Okçu Üretme
                    gerekenMiktar = askerMiktar * 10; // Okçu Üretmek İçin Gereken İksir
                    if (iksir >= gerekenMiktar)
                    {
                        iksir -= gerekenMiktar;
                        askerSayisi[1] += askerMiktar;
                        Console.WriteLine($"{askerMiktar} Tane Okçu Üretildi.");
                        askerGoster();
                        guc += askerMiktar * 5;
                    }
                    else
                    {
                        Console.WriteLine($"İksiriniz Yetmiyor ,{gerekenMiktar - iksir} İksir Daha Lazım.");
                    }
                    break;

                case 3: // Büyücü Üretme
                    gerekenMiktar = askerMiktar * 25; // Büyücü Üretmek İçin Gereken İksir
                    if (iksir >= gerekenMiktar)
                    {
                        iksir -= gerekenMiktar;
                        askerSayisi[2] += askerMiktar;
                        Console.WriteLine($"{askerMiktar} Tane Büyücü Üretildi.");
                        askerGoster();
                        guc += askerMiktar * 10;
                    }
                    else
                    {
                        Console.WriteLine($"İksiriniz Yetmiyor , {gerekenMiktar - iksir} İksir Daha Lazım.");
                    }
                    break;

                default:
                    Console.WriteLine("Lütfen Doğru Seçim Yapınız !");
                    break;
            }

        }

        public void binaGelistir(byte tur)
        {
            Console.WriteLine("\n------------ Bina Geliştirme ------------");
            int gerekenMiktar;
            switch(tur)
            {
                case 1: // Belediye Binası
                    if (binalar[0] < 5)
                    {
                        gerekenMiktar = yukseltmeFiyatlari[binalar[0] - 1]; // Yükseltme Fiyatlarının İndexi 0'dan Başladığı İçin Bina Seviyesinin Değerini 1 Azaltıp Fiyatı Buluyoruz
                        if (altin >= gerekenMiktar)
                        {
                            altin -= gerekenMiktar;
                            binalar[0] += 1;
                            Console.WriteLine($"Belediye Binası Seviye Atladı. Yeni Seviye : {binalar[0]}");
                            guc += yukseltmeGucleri[binalar[0] - 1]; // İndex 0'dan Başladığı İçin Bina Seviyesini 1 Azaltıp Seviyeyi Buluyoruz.
                        }
                        else
                        {
                            Console.WriteLine($"Geliştirmek İçin Altın Yetmiyor. {gerekenMiktar - altin} Altın Gerekli");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Belediye Binanız Maksimum Seviyede");
                    }
                    break;


                case 2: // Klan Binası
                    if (binalar[1] < 5) // Maksimum Seviyeden Az İse Binayı Geliştir
                    {
                        gerekenMiktar = yukseltmeFiyatlari[binalar[1]]; // İndex 0'dan Başladığı İçin Bina Seviyesini 1 Azaltıp Seviyeyi Buluyoruz.
                        if (altin >= gerekenMiktar)
                        {
                            altin -= gerekenMiktar;
                            binalar[1] += 1;
                            Console.WriteLine($"Klan Binası Seviye Atladı. Yeni Seviye : {binalar[1]}");
                            guc += yukseltmeGucleri[binalar[1] - 1]; // İndex 0'dan Başladığı İçin Bina Seviyesini 1 Azaltıp Seviyeyi Buluyoruz.
                        }
                        else
                        {
                            Console.WriteLine($"Geliştirmek İçin Altın Yetmiyor. {gerekenMiktar - altin} Altın Gerekli");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Belediye Binanız Maksimum Seviyede");
                    }
                    break;

                case 3: // Kışla Binası
                    if (binalar[2] < 5) // Maksimum Seviyeden Az İse Binayı Geliştir
                    {
                        gerekenMiktar = yukseltmeFiyatlari[binalar[2]]; // İndex 0'dan Başladığı İçin Bina Seviyesini 1 Azaltıp Seviyeyi Buluyoruz.
                        if (altin >= gerekenMiktar)
                        {
                            altin -= gerekenMiktar;
                            binalar[2] += 1;
                            Console.WriteLine($"Kışla Binası Seviye Atladı. Yeni Seviye : {binalar[2]}");
                            guc += yukseltmeGucleri[binalar[2] - 1]; // İndex 0'dan Başladığı İçin Bina Seviyesini 1 Azaltıp Seviyeyi Buluyoruz.
                        }
                        else
                        {
                            Console.WriteLine($"Geliştirmek İçin Altın Yetmiyor. {gerekenMiktar - altin} Altın Gerekli");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Belediye Binanız Maksimum Seviyede");
                    }
                    break;

                default:
                    Console.WriteLine("Lütfen Doğru Seçim Yapınız !");
                    break;
            }
        }

        
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            ClashOfClans p1 = new ClashOfClans();

            p1.kaynakGoster();
            p1.askerUret(3, 100);
            p1.binaGelistir(1);
            p1.kaynakGoster();
            p1.binaGelistir(1);
            p1.binaGelistir(1);
            p1.kaynakGoster();
            p1.binaGelistir(1);
            p1.kaynakGoster();
            p1.gucGoster();
            p1.kaynakTopla();

            Console.ReadKey();
        }
    }
}
