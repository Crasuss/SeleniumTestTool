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
    public partial class Form1 : Form
    {
        IWebDriver driver;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Uyegiris f1 = new Uyegiris();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Arama arama = new Arama();
            arama.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Favori fvr = new Favori();
            fvr.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SifreDegistir sifre = new SifreDegistir();
            sifre.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            driver = new FirefoxDriver();
            string link = @"https://www.1v1y.com/";
            driver.Navigate().GoToUrl(link);
            System.Threading.Thread.Sleep(10000);

            driver.FindElement(By.XPath("//*[@id='logo']")).Click();
            driver.FindElement(By.XPath(".//*[@Id='homepage']/ul/li[2]")).Click();

            driver.FindElement(By.XPath(" //*[@id='NavigationList']/li[1]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[1]/div/ul/li[1]/a/i")).Click();

            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[2]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[2]/div/ul/li[1]/ul/li[1]/a/i")).Click();

            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[3]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[3]/div/ul/li[1]/ul/li/a/i")).Click();

            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[4]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[4]/div/ul/li[1]/ul/li/a/i")).Click();

            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[5]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[5]/div/ul/li/a/i")).Click();

            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[6]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[6]/div/ul/li[1]/a/i")).Click();

            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[7]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[7]/div/ul/li[1]/a/i")).Click();

            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[8]/a")).Click();
            driver.FindElement(By.XPath("//*[@id='NavigationList']/li[8]/div/ul/li[1]/a/i")).Click();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hızlıbak hb = new Hızlıbak();
            hb.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            kgiris kg = new kgiris();
            kg.Show();
            
        }
    }
}
