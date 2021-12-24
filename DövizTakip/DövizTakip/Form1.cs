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

namespace DövizTakip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {



           
                String bugun = "https://tcmb.gov.tr/kurlar/today.xml";
                var xmldosya = new XmlDocument();
                xmldosya.Load(bugun);


                //////DOLAR ALIŞ//////////
                string dolarAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerText;

                decimal dolaral = Convert.ToDecimal(dolarAlis);
                decimal dolaralyazi = Convert.ToDecimal(dolarAlisText.Text);
                if (dolaral > dolaralyazi) { dolarAlisText.ForeColor = Color.Green; }
                else if (dolaral < dolaralyazi) { dolarAlisText.ForeColor = Color.Red; }

                dolarAlisText.Text = dolarAlis;


                //////DOLAR SATIŞ//////////
                string dolarSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerText;

                decimal dolarsat = Convert.ToDecimal(dolarSatis);
                decimal dolarsattext = Convert.ToDecimal(dolarSatisText.Text);
                if (dolarsat > dolarsattext) { dolarSatisText.ForeColor = Color.Green; }
                else if (dolarsat < dolarsattext) { dolarSatisText.ForeColor = Color.Red; }


                dolarSatisText.Text = dolarSatis;

                //////EURO ALIŞ//////////
                string euroAlis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerText;
                decimal euroal = Convert.ToDecimal(euroAlis);
                decimal euroaltext = Convert.ToDecimal(euroAlisText.Text);
                if (euroal > euroaltext) { euroAlisText.ForeColor = Color.Green; }
                else if (euroal < euroaltext) { euroAlisText.ForeColor = Color.Red; }

                euroAlisText.Text = euroAlis;
                //////EURO SATIŞ//////////
               string euroSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerText;
                decimal eurosat = Convert.ToDecimal(euroSatis);
                decimal eurosattext = Convert.ToDecimal(euroSatisText.Text);
                if (eurosat > eurosattext) { euroSatisText.ForeColor = Color.Green; }
                else if (eurosat < eurosattext) { euroSatisText.ForeColor = Color.Red; }
                euroSatisText.Text = euroSatis;
            


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
           
        }

        private void dolarAlisText_Click(object sender, EventArgs e)
        {
        }
    }
}
