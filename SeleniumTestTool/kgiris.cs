using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumTestTool
{
    public partial class kgiris : Form
    {
        public IWebDriver driver;
        public static string mail, sifre;


        public kgiris()
        {
            InitializeComponent();
        }


        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            mail = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            sifre = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdresKaydı ak = new AdresKaydı();
            ak.Show();

        }
    }
}
