using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _01_DovizOfisiUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Global değişkenler
        double tl = 10000;
        double dolar = 10000;
        double euro = 10000;
        double sterlin = 10000;
        double riyal = 10000;

        // Döviz kurlarının verisini çekeceğimiz xml adresi
        string yol = "https://www.tcmb.gov.tr/kurlar/today.xml";
       
        // Kurları ekrana yazdıran metot
        private void KurlariGetir()
        {
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(yol);

            string dolarAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lblDolarAlis.Text = dolarAlis + " TL";
            string dolarSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDolarSatis.Text = dolarSatis + " TL";

            string euroAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEuroAlis.Text = euroAlis + " TL";
            string euroSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroSatis.Text = euroSatis + " TL";

            string sterlinAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
            lblSterlinAlis.Text = sterlinAlis + " TL";
            string sterlinSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            lblSterlinSatis.Text = sterlinSatis + " TL";

            string riyalAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='SAR']/BanknoteBuying").InnerXml;
            lblRiyalAlis.Text = riyalAlis + " TL";
            string riyalSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='SAR']/BanknoteSelling").InnerXml;
            lblRiyalSatis.Text = riyalSatis + " TL";
        }

        // Toplam varlıkları yazdıran metot
        private void VarliklariGetir()
        {
            lblToplamTürkLirasi.Text = tl.ToString("0.00") + " TL";
            lblToplamDolar.Text = dolar.ToString("0.00") + " $";
            lblToplamEuro.Text = euro.ToString("0.00") + " €";
            lblToplamSterlin.Text = sterlin.ToString("0.00") + " £";
            lblToplamRiyal.Text = riyal.ToString("0.00") + " هللة";
            double tlDolar = DolarAlis() * dolar;
            double tlEuro = EuroAlis() * euro;
            double tlSterlin = SterlinAlis() * sterlin;
            double tlRiyal = RiyalAlis() * riyal;
            lblToplamDeger.Text = (tl + tlDolar + tlEuro + tlSterlin + tlRiyal).ToString("0.00") + " TL";
        }

        // Dolar'ın alış fiyatını döndüren metot
        private double DolarAlis()
        {
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(yol);

            string dolarAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            dolarAlis = dolarAlis.Replace(".", ",");
            double dolar = Convert.ToDouble(dolarAlis);
            return Math.Round(dolar, 2);
        }

        // Euro'nun alış fiyatını döndüren metot
        private double EuroAlis()
        {
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(yol);

            string euroAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            euroAlis = euroAlis.Replace(".", ",");
            double euro = Convert.ToDouble(euroAlis);
            return Math.Round(euro, 2);
        }

        // Sterlin'in alış fiyatını döndüren metot
        private double SterlinAlis()
        {
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(yol);

            string sterlinAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteBuying").InnerXml;
            sterlinAlis = sterlinAlis.Replace(".", ",");
            double sterlin = Convert.ToDouble(sterlinAlis);
            return Math.Round(sterlin, 2);
        }

        // Riyal'in alış fiyatını döndüren metot
        private double RiyalAlis()
        {
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(yol);

            string riyalAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='SAR']/BanknoteBuying").InnerXml;
            riyalAlis = riyalAlis.Replace(".", ",");
            double riyal = Convert.ToDouble(riyalAlis);
            return Math.Round(riyal, 2);
        }

        // Dolar'ın satış fiyatını döndüren metot
        private double DolarSatis()
        {
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(yol);

            string dolarSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            dolarSatis = dolarSatis.Replace(".", ",");
            double dolar = Convert.ToDouble(dolarSatis);
            return Math.Round(dolar, 2);
        }

        // Euro'nun satış fiyatını döndüren metot
        private double EuroSatis()
        {
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(yol);

            string euroSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            euroSatis = euroSatis.Replace(".", ",");
            double euro = Convert.ToDouble(euroSatis);
            return Math.Round(euro, 2);
        }

        // Sterlin'in satış fiyatını döndüren metot
        private double SterlinSatis()
        {
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(yol);

            string sterlinSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            sterlinSatis = sterlinSatis.Replace(".", ",");
            double sterlin = Convert.ToDouble(sterlinSatis);
            return Math.Round(sterlin, 2);
        }

        // Riyal'in satış fiyatını döndüren metot
        private double RiyalSatis()
        {
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(yol);

            string riyalSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='SAR']/BanknoteSelling").InnerXml;
            riyalSatis = riyalSatis.Replace(".", ",");
            double riyal = Convert.ToDouble(riyalSatis);
            return Math.Round(riyal, 2);
        }

        // Textbox'ları temizleyen metot
        private void Temizle()
        {
            tbxMiktar.Text = "";
            tbxTutar.Text = "";
        }

        // Form yüklenirken gerçekleşmesi gereken işlemler
        private void Form1_Load(object sender, EventArgs e)
        {
            KurlariGetir();
            VarliklariGetir();
        }

        // Döviz bürosundan döviz verilirken yapılacak işlemler
        private void btnSatis_Click(object sender, EventArgs e)
        {
            try
            {
                int lira = Convert.ToInt32(tbxMiktar.Text);
                if (radioDolar.Checked == true)
                {
                    double doviz = Math.Round(lira / DolarSatis(), 2);
                    if (dolar >= doviz)
                    {
                        tl += lira;
                        dolar -= doviz;
                        VarliklariGetir();
                        MessageBox.Show("İşlem gerçekleşti." + "\n" + "Verilen dolar tutarı: " + doviz + "\n" + "Alınan TL tutarı: " + lira, "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kasada yeteri kadar dolar miktarı yok.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (radioEuro.Checked == true)
                {
                    double doviz = Math.Round(lira / EuroSatis(), 2);
                    if (euro >= doviz)
                    {
                        tl += lira;
                        euro -= doviz;
                        VarliklariGetir();
                        MessageBox.Show("İşlem gerçekleşti." + "\n" + "Verilen euro tutarı: " + doviz + "\n" + "Alınan TL tutarı: " + lira, "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kasada yeteri kadar dolar miktarı yok.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (radioSterlin.Checked == true)
                {
                    double doviz = Math.Round(lira / SterlinSatis(), 2);
                    if (sterlin >= doviz)
                    {
                        tl += lira;
                        sterlin -= doviz;
                        VarliklariGetir();
                        MessageBox.Show("İşlem gerçekleşti." + "\n" + "Verilen sterlin tutarı: " + doviz + "\n" + "Alınan TL tutarı: " + lira, "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kasada yeteri kadar dolar miktarı yok.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (radioRiyal.Checked == true)
                {
                    double doviz = Math.Round(lira / RiyalSatis(), 2);
                    if (riyal >= doviz)
                    {
                        tl += lira;
                        riyal -= doviz;
                        VarliklariGetir();
                        MessageBox.Show("İşlem gerçekleşti." + "\n" + "Verilen riyal tutarı: " + doviz + "\n" + "Alınan TL tutarı: " + lira, "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kasada yeteri kadar dolar miktarı yok.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen tam değerler giriniz.", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Temizle();
        }

        // Döviz bürosu müşterisinden döviz alınırken yapılacak işlemler
        private void btnAlis_Click(object sender, EventArgs e)
        {
            try
            {
                int doviz = Convert.ToInt32(tbxTutar.Text);
                if (radioDolar.Checked == true)
                {
                    double lira = doviz * DolarAlis();
                    if (tl >= lira)
                    {
                        tl -= lira;
                        dolar += doviz;
                        VarliklariGetir();
                        MessageBox.Show("İşlem gerçekleşti." + "\n" + "Alınan dolar tutarı: " + doviz + "\n" + "Verilen TL tutarı: " + lira, "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kasada yeteri kadar TL miktarı yok.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (radioEuro.Checked == true)
                {
                    double lira = doviz * EuroAlis();
                    if (tl >= lira)
                    {
                        tl -= lira;
                        euro += doviz;
                        VarliklariGetir();
                        MessageBox.Show("İşlem gerçekleşti." + "\n" + "Alınan euro tutarı: " + doviz + "\n" + "Verilen TL tutarı: " + lira, "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kasada yeteri kadar TL miktarı yok.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (radioSterlin.Checked == true)
                {
                    double lira = doviz * SterlinAlis();
                    if (tl >= lira)
                    {
                        tl -= lira;
                        sterlin += doviz;
                        VarliklariGetir();
                        MessageBox.Show("İşlem gerçekleşti." + "\n" + "Alınan sterlin tutarı: " + doviz + "\n" + "Verilen TL tutarı: " + lira, "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kasada yeteri kadar TL miktarı yok.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (radioRiyal.Checked == true)
                {
                    double lira = doviz * RiyalAlis();
                    if (tl >= lira)
                    {
                        tl -= lira;
                        riyal += doviz;
                        VarliklariGetir();
                        MessageBox.Show("İşlem gerçekleşti." + "\n" + "Alınan riyal tutarı: " + doviz + "\n" + "Verilen TL tutarı: " + lira, "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kasada yeteri kadar TL miktarı yok.", "Bilgi Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen tam değerler giriniz.", "Uyarı Mesajı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Temizle();
        }

        // Verileri temizleyen işlemler
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
