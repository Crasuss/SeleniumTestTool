using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
using RelevantCodes.ExtentReports;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Drawing.Imaging;
using NUnit.Framework;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace SeleniumTestTool
{
    [TestFixture]
   public class Program
    {
        public ExtentReports extent;
        public ExtentTest test;
       // ExtentReports report;
        //ExtentHtmlReporter htmlReporter;
        public IWebDriver driver;
        

        [OneTimeSetUp]
        public void StartReport()
        {

            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualpath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualpath).LocalPath;
            string reportpath = projectPath + "rapor\\report.html";
            extent = new ExtentReports(reportpath, true);

            extent.AddSystemInfo("host name", "brhn");

            extent.LoadConfig(projectPath + "extent-confing.xml");
        }
        /*[OneTimeSetUp]
        public void setUpOnce(){
            htmlReporter = new ExtentHtmlReporter(@"C:\\Users\\LENOVO\\Desktop\\rapor\\report.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            test = extent.CreateTest("Login Test");
        }*/
        [SetUp]
        public void setUp()
        {
            driver = new FirefoxDriver();
            string link = @"https://www.1v1y.com/";
            driver.Manage().Timeouts();


            driver.Navigate().GoToUrl(link);
            
        }
        
        public void takeScreenShot(string filename, IWebDriver driver)
        {
            ITakesScreenshot ss = (ITakesScreenshot)driver;
            Screenshot screenshot = ss.GetScreenshot();
            screenshot.SaveAsFile("C:\\Users\\LENOVO\\Desktop\\screenshot\\" + filename, ScreenshotImageFormat.Jpeg);
        }
       public static List<string> GetUsername(){
            
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3IURO6N;Initial Catalog=selenium;Integrated Security=True");
            con.Open();
            Console.WriteLine("db connected");
            SqlCommand kmt = new SqlCommand("Select kisi from uye_giris", con);
            
            SqlDataReader dr = kmt.ExecuteReader();
            
           
            List<string> account=new List<string>();  
            while (dr.Read())
            {
                account.Add(Convert.ToString(dr[0])); 
            }
            foreach (string i in account)
            {
                Console.WriteLine(i);
            }
            return account;
           
        }
        public static List<string> Getpassword()
        {

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-3IURO6N;Initial Catalog=selenium;Integrated Security=True");
            con.Open();
            Console.WriteLine("db connected");
            SqlCommand kmt = new SqlCommand("Select sifre from uye_giris", con);
            SqlDataReader dr = kmt.ExecuteReader();
            //Dictionary
            List<string> account1 = new List<string>();

            while (dr.Read())
            {

                
                account1.Add(Convert.ToString(dr[0]));
                
            }
            foreach (var i in account1)
            {
                Console.WriteLine(i);
            }

            return account1;
            
        }


        [Test]
        public void aramavesıralama()
        {
            try
            {

                List<Dictionary<List<string>, List<string>>> dicList = new List<Dictionary<List<string>, List<string>>>();

               List<string> username = GetUsername();
                List<string> password = Getpassword();

                //dicList.Add( username, password);

                    driver.FindElement(By.Id("AuthenticationNavigation")).Click();
                //foreach(var u in username)
                //{
                    
                //}
             
                //foreach(var p in username)
                //{
                   
                    
                //}


                
                foreach (var item in username.Zip(password, (a, b) => new { A = a, B = b }))
                {
                    var a = item.A;
                    var b = item.B;

                    driver.FindElement(By.Id("loginmail")).SendKeys(a);
                    driver.FindElement(By.Id("loginpassword")).SendKeys(b);
                    driver.FindElement(By.CssSelector("button[type='submit']")).Click();
                    driver.FindElement(By.XPath("/html/body/div[8]/div[2]/div/div[1]/div[3]/a")).Click();
                    driver.FindElement(By.Id("loginmail")).Clear();
                    driver.FindElement(By.Id("loginpassword")).Clear();
                }







                /* driver.FindElement(By.CssSelector("input[type='text']")).SendKeys("adidas");
                  driver.FindElement(By.ClassName("applysearch")).Click();
                  driver.FindElement(By.Id("SearchSortTypeId")).Click();
                  driver.FindElement(By.CssSelector("option[value='/ara?q=adidas&sort=4']")).Click();

                 driver.FindElement(By.XPath("//*[@id='catalogcontent']/ul/li[2]/div/div[2]/span")).Click();

                 driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/section[2]/div[2]/div[2]/div[2]/div[4]/a")).Click();
                 driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/section[2]/div[2]/div[2]/div[3]/a[2]")).Click();
                 driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/section[2]/div[2]/div[2]/div[2]/div[4]/a")).Click();
                 driver.FindElement(By.XPath("/html/body/div[5]/div[2]/div/div[1]/section[2]/div[2]/div[2]/div[3]/a[2]")).Click();


                 driver.FindElement(By.XPath("/html/body/div[1]/section/section[1]/div[3]/aside/form/a")).Click();


                 test.Log(LogStatus.Pass, "Test Passed");*/

            }
            catch (AssertionException)
            {
                Console.WriteLine("hata var");
                int i=1;
                takeScreenShot("Error Screenshot "+i, driver);
                i++;
              //test.Log(LogStatus.Info, "Screenshot - " + test.AddScreenCapture("C:\\Users\\LENOVO\\Desktop"));
            }

        }
        [TearDown]
        public void getResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
            var errorMessage = TestContext.CurrentContext.Result.Message;
            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Log(LogStatus.Fail, stackTrace + errorMessage);

            }         
        }

        
  
        [OneTimeTearDown]
        public void GenereateReport()
        {
            extent.EndTest(test);
            extent.Flush();
            driver.Quit();
        }

       static void Main(string[] args)
        {
           
            Application.Run(new Form1());
            //GetUsername();
            //Getpassword();
            
        }


    }
}
