using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_AkaryakitTakipSistemi
{
    internal class Program
    {
        // Kullanıcının girdiği string veri tipinin pozitif tam sayı olup olmadığını kontrol eden metot
        private static bool PozitifTamSayiMi(string veri)
        {
            try
            {
                int sayi = Convert.ToInt32(veri);
                if (sayi > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Kullanıcı tarafından girilen ifadenin pozitif olup olmadığını kontrol eden metot
        private static bool PozitifSayiMi(string veri)
        {
            try
            {
                double sayi = Convert.ToDouble(veri);
                if (sayi > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Kullanıcının ana menüdeki seçimini kontrol eden metot
        private static bool AnaMenuSecimKontrol(string veri)
        {
            try
            {
                int sayi = Convert.ToInt32(veri);
                if (sayi >= 1 && sayi <= 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Kullanıcının yan menüde iken seçimini kontrol eden metot
        private static bool YanMenuSecimKontrol(string veri)
        {
            try
            {
                int sayi = Convert.ToInt32(veri);
                if (sayi >= 1 && sayi <= 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Kullanıcının yakıt tipi seçimini kontrol eden metot
        private static bool YakitTipiSecimi(string veri)
        {
            try
            {
                int sayi = Convert.ToInt32(veri);
                if (sayi >= 1 && sayi <= 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Main metodu
        static void Main(string[] args)
        {
            // Depolar
            int dizelDepo = 1000;
            int benzinDepo = 1000;
            int lpgDepo = 1000;

            // Fiyatlar
            double dizelFiyat = 30.41;
            double benzinFiyat = 26.65;
            double lpgFiyat = 10.35;

            // Satılan yakıt miktarları
            int satilanDizel = 0;
            int satilanBenzin = 0;
            int satilanLpg = 0;

            // Toplam satışlardan elde edilen tutar
            double toplamDizelTutar = 0;
            double toplamBenzinTutar = 0;
            double toplamLpgTutar = 0;

            // Toplam tutar
            double toplamTutar = 0;

            // Seçimleri tutan değişkenler
            string veri, ekle, satis;
            int secim, hesap;

            Console.WriteLine("---------------> Akaryakıt Takip Sistemine Hoşgeldiniz <---------------");
        MENU:
            Console.WriteLine("1-) Birim Fiyatları Göster" + "\n" + "2-) Birim Fiyatları Güncelle" + "\n" + "3-) Akaryakıt Satışı Yap" + "\n" + "4-) Depo Durumunu Güncelle" + "\n" + 
                "5-) Depo Durumunu Görüntüle" + "\n" + "6-) Satışları Göster" + "\n" + "7-) Çıkış");
            Console.Write("Lütfen seçim yapınız: [ 1, 2, 3, 4, 5, 6, 7 ] : ");
            veri = Console.ReadLine();
            if (!AnaMenuSecimKontrol(veri))
            {
                Console.Clear();
                Console.WriteLine("Lütfen istenilen değer aralıklarında seçim yapınız.");
                goto MENU;
            }
            secim = Convert.ToInt32(veri);
            Console.Clear();
            switch (secim)
            {
                // Birim fiyatlarını gösterir.
                case 1:
                    Console.WriteLine("---------------> Akaryakıt Birim Fiyatları Ekranı <---------------");
                    Console.WriteLine("Dizel Birim Fiyatı: " + dizelFiyat.ToString("0.00") + "\n" + "Benzin Birim Fiyatı: " + benzinFiyat.ToString("0.00") + "\n" + "LPG Birim Fiyatı: " + lpgFiyat.ToString("0.00"));
                    break;
                // Birim fiyatları güncellenir.
                case 2:
                    Console.WriteLine("---------------> Akaryakıt Birim Fiyatları Güncelleme Ekranı <---------------");
                    Console.WriteLine("1-) Dizel" + "\n" + "2-) Benzin" + "\n" + "3-) LPG");
                CONTROL1:
                    Console.Write("Lütfen birim fiyatı güncellenecek yakıt tipini seçiniz: [ 1, 2, 3 ] : ");
                    veri = Console.ReadLine();
                    if (!YakitTipiSecimi(veri))
                    {
                        Console.WriteLine("Lütfen istenilen değer aralıklarında seçim yapınız.");
                        goto CONTROL1;
                    }
                    secim = Convert.ToInt32(veri);
                    switch (secim)
                    {
                        // Dizel fiyatı güncelleme
                        case 1:
                        CONTROL11:
                            Console.WriteLine("Şu anki anlık dizel birim fiyatı: " + dizelFiyat);
                            Console.Write("Yeni dizel birim fiyatını giriniz: ");
                            veri = Console.ReadLine();
                            if (!PozitifSayiMi(veri))
                            {
                                Console.WriteLine("Lütfen pozitif bir değer giriniz");
                                goto CONTROL11;
                            }
                            dizelFiyat = Convert.ToDouble(veri);
                            break;
                        // Benzin fiyatı güncelleme
                        case 2:
                        CONTROL12:
                            Console.WriteLine("Şu anki anlık benzin birim fiyatı: " + benzinFiyat);
                            Console.Write("Yeni benzin birim fiyatını giriniz: ");
                            veri = Console.ReadLine();
                            if (!PozitifSayiMi(veri))
                            {
                                Console.WriteLine("Lütfen pozitif bir değer giriniz");
                                goto CONTROL12;
                            }
                            benzinFiyat = Convert.ToDouble(veri);
                            break;
                        // LPG fiyatı güncelleme
                        case 3:
                        CONTROL13:
                            Console.WriteLine("Şu anki anlık LPG birim fiyatı: " + lpgFiyat);
                            Console.Write("Yeni LPG birim fiyatını giriniz: ");
                            veri = Console.ReadLine();
                            if (!PozitifSayiMi(veri))
                            {
                                Console.WriteLine("Lütfen pozitif bir değer giriniz");
                                goto CONTROL13;
                            }
                            lpgFiyat = Convert.ToDouble(veri);
                            break;
                        default:
                            Console.WriteLine("Ana Menüye Yönlendiriliyorsunuz.");
                            goto MENU;
                    }
                    Console.WriteLine("Başarılı bir şekilde birim fiyat güncellendi.");
                    break;
                // Akaryakıt satışı yapılır.
                case 3:
                    Console.WriteLine("---------------> Akaryakıt Satış Ekranı <---------------");
                    Console.WriteLine("1-) Dizel" + "\n" + "2-) Benzin" + "\n" + "3-) LPG");
                CONTROL2:
                    Console.Write("Lütfen satılacak yakıt tipini seçiniz: [ 1, 2, 3 ] : ");
                    veri = Console.ReadLine();
                    if (!YakitTipiSecimi(veri))
                    {
                        Console.WriteLine("Lütfen istenilen değer aralıklarında seçim yapınız.");
                        goto CONTROL2;
                    }
                    secim = Convert.ToInt32(veri);
                    switch (secim)
                    {
                        // Dizel satma işlemi
                        case 1:
                        CONTROL21:
                            Console.Write("Kaç litre dizel satılacak: ");
                            satis = Console.ReadLine();
                            if (!PozitifTamSayiMi(satis))
                            {
                                Console.WriteLine("Girilecek değer bir pozitif tam sayı olmalıdır.");
                                goto CONTROL21;
                            }
                            hesap = Convert.ToInt32(satis);
                            if (dizelDepo > hesap)
                            {
                                dizelDepo -= hesap;
                                satilanDizel += hesap;
                                toplamDizelTutar += hesap * dizelFiyat;
                                toplamTutar += hesap * dizelFiyat;
                                Console.WriteLine("Yapılan satıştan elde edilen tutar: " + (hesap * dizelFiyat) + " TL'dir. Alınan dizel miktarı: " + hesap);
                            }
                            else
                            {
                                Console.WriteLine("Depoda yeteri kadar dizel yok.");
                                goto CONTROL21;
                            }
                            break;
                        // Benzin satma işlemi
                        case 2:
                        CONTROL22:
                            Console.Write("Kaç litre dizel satılacak: ");
                            satis = Console.ReadLine();
                            if (!PozitifTamSayiMi(satis))
                            {
                                Console.WriteLine("Girilecek değer bir pozitif tam sayı olmalıdır.");
                                goto CONTROL22;
                            }
                            hesap = Convert.ToInt32(satis);
                            if (benzinDepo > hesap)
                            {
                                benzinDepo -= hesap;
                                satilanBenzin += hesap;
                                toplamBenzinTutar += hesap * benzinFiyat;
                                toplamTutar += hesap * benzinFiyat;
                                Console.WriteLine("Yapılan satıştan elde edilen tutar: " + (hesap * benzinFiyat) + " TL'dir. Alınan dizel miktarı: " + hesap);
                            }
                            else
                            {
                                Console.WriteLine("Depoda yeteri kadar benzin yok.");
                                goto CONTROL22;
                            }
                            break;
                        // LPG satma işlemi
                        case 3:
                        CONTROL23:
                            Console.Write("Kaç litre dizel satılacak: ");
                            satis = Console.ReadLine();
                            if (!PozitifTamSayiMi(satis))
                            {
                                Console.WriteLine("Girilecek değer bir pozitif tam sayı olmalıdır.");
                                goto CONTROL23;
                            }
                            hesap = Convert.ToInt32(satis);
                            if (lpgDepo > hesap)
                            {
                                lpgDepo -= hesap;
                                satilanLpg += hesap;
                                toplamLpgTutar += hesap * lpgFiyat;
                                toplamTutar += hesap * lpgFiyat;
                                Console.WriteLine("Yapılan satıştan elde edilen tutar: " + (hesap * lpgFiyat) + " TL'dir. Alınan dizel miktarı: " + hesap);
                            }
                            else
                            {
                                Console.WriteLine("Depoda yeteri kadar dizel yok.");
                                goto CONTROL23;
                            }
                            break;
                        // Geçersiz işlemlerde yapılacak işlemler
                        default:
                            Console.WriteLine("Ana Menüye Yönlendiriliyorsunuz.");
                            goto MENU;
                    }
                    Console.WriteLine("Satış gerçekleşti.");
                    break;
                // Depo durumu güncellenir.
                case 4:
                    Console.WriteLine("---------------> Akaryakıt Depo Durumu Güncelleme Ekranı <---------------");
                    Console.WriteLine("1-) Dizel" + "\n" + "2-) Benzin" + "\n" + "3-) LPG");
                CONTROL3:
                    Console.Write("Depoya eklemek istediğiniz yakıt tipini seçiniz: [ 1, 2, 3 ] : ");
                    veri = Console.ReadLine();
                    if (!YakitTipiSecimi(veri))
                    {
                        Console.WriteLine("Lütfen istenilen değer aralıklarında seçim yapınız.");
                        goto CONTROL3;
                    }
                    secim = Convert.ToInt32(veri);
                    switch (secim)
                    {
                        // Dizel depo güncelleme
                        case 1:
                        CONTROL31:
                            Console.Write("Depoya eklenecek dizel miktarını giriniz: ");
                            ekle = Console.ReadLine();
                            if (!PozitifTamSayiMi(ekle))
                            {
                                Console.WriteLine("Girilecek değer bir pozitif tam sayı olmalıdır.");
                                goto CONTROL31;
                            }
                            dizelDepo += Convert.ToInt32(ekle);
                            break;
                        // Benzin depo güncelleme
                        case 2:
                        CONTROL32:
                            Console.Write("Depoya eklenecek benzin miktarını giriniz: ");
                            ekle = Console.ReadLine();
                            if (!PozitifTamSayiMi(ekle))
                            {
                                Console.WriteLine("Girilecek değer bir pozitif tam sayı olmalıdır.");
                                goto CONTROL32;
                            }
                            benzinDepo += Convert.ToInt32(ekle);
                            break;
                        // LPG depo güncelleme
                        case 3:
                        CONTROL33:
                            Console.Write("Depoya eklenecek LPG miktarını giriniz: ");
                            ekle = Console.ReadLine();
                            if (!PozitifTamSayiMi(ekle))
                            {
                                Console.WriteLine("Girilecek değer bir pozitif tam sayı olmalıdır.");
                                goto CONTROL33;
                            }
                            lpgDepo += Convert.ToInt32(ekle);
                            break;
                        // Geçersiz işlemlerde yapılacak işlemler
                        default:
                            Console.WriteLine("Ana Menüye Yönlendiriliyorsunuz.");
                            goto MENU;
                    }
                    Console.WriteLine("Başarılı bir şekilde depoya istenilen miktar eklendi.");
                    break;
                // Depo durumu görüntülenir.
                case 5:
                    Console.WriteLine("---------------> Akaryakıt Depo Durum Ekranı <---------------");
                    Console.WriteLine("Dizel Depo Durumu: " + dizelDepo + "\n" + "Benzin Depo Durumu: " + benzinDepo + "\n" + "LPG Depo Durumu: " + lpgDepo);
                    break;
                // Satışlar gösterilir.
                case 6:
                    Console.WriteLine("---------------> Akaryakıt Toplam Satış İstatistikleri Ekranı <---------------");
                    Console.WriteLine("\n" + "***** Satılan Litreler *****" + "\n");
                    Console.WriteLine("Satılan Dizel Litresi: " + satilanDizel + "\n" + "Satılan Benzin Litresi: " + satilanBenzin + "\n" + "Satılan LPG Litresi: " + satilanLpg);
                    Console.WriteLine("\n" + "***** Akaryakıt Bazlı Satışlardan Elde Edilen Tutar *****" + "\n");
                    Console.WriteLine("Dizelden Elde Edilen Toplam Tutar: " + toplamDizelTutar.ToString("0.00") + "\n" + "Benzinden Elde Edilen Toplam Tutar: " + toplamBenzinTutar.ToString("0.00") + "\n" + "LPG'den Elde Edilen Toplam Tutar: " + toplamLpgTutar.ToString("0.00"));
                    Console.WriteLine("\n" + "***** Toplam Tutar *****" + "\n");
                    Console.WriteLine("Toplam Tutar: " + toplamTutar.ToString("0.00"));
                    break;
                // Çıkış yapılır.
                case 7:
                    Environment.Exit(0);
                    break;
                // Olası bir if bloğundan kaçan işlemler buradan yönlendirilir.
                default:
                    Console.WriteLine("Geçersiz işlem yapıldı. Ana menüye yönlendiriliyorsunuz.");
                    goto MENU;
            }
            // Yapılacak işlemler bittikten sonra yapılacak yan menü işlemleri
            Console.WriteLine("\n" + "*************************" + "\n");
        SIDEMENU:
            Console.WriteLine("1-) Ana Menüye Dön" + "\n" + "2-) Çıkış");
            Console.Write("Lütfen seçim yapınız: [ 1, 2 ] : ");
            veri = Console.ReadLine();
            if (!YanMenuSecimKontrol(veri))
            {
                Console.WriteLine("Lütfen istenilen değer aralıklarında seçim yapınız.");
                goto SIDEMENU;
            }
            secim = Convert.ToInt32(veri);
            switch (secim)
            {
                // Ana menüye yönlendirir.
                case 1:
                    Console.Clear();
                    goto MENU;
                // Çıkış yapar
                case 2:
                    Environment.Exit(0);
                    break;
                // Geçersiz işlemler için uygulanak işlemler
                default:
                    Console.WriteLine("Ana Menüye Yönlendiriliyorsunuz.");
                    goto MENU;
            }
            Console.ReadKey();
        }
    }
}
