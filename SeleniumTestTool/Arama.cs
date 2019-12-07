using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
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
//using RelevantCodes.ExtentReports;

namespace SeleniumTestTool
{
    [TestFixture]
    public partial class Arama : Form
    {
        IWebDriver driver;
        public static ExtentReports report;
        public static ExtentTest test;
        
       
        [OneTimeSetUp]
        public void setUp()
        {
            var reportLocation = "./eReport/" + "TestReport.html";
            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(reportLocation);


            
            report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            Console.WriteLine("dir " + dir);
            Console.WriteLine("file name " + fileName);



        }
        [OneTimeTearDown]
        public void TearDown()
        {
            report.Flush();
        }
        [SetUp]
        public void BeforeTest()
        {
            
            test = report.CreateTest(TestContext.CurrentContext.Test.Name);
            
        }

        [TearDown]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            report.Flush();
        }
        public Arama()
        {
            InitializeComponent();
        }

        void takeScreenShot(string filename, IWebDriver driver)
        {
            ITakesScreenshot ss = (ITakesScreenshot)driver;
            Screenshot screenshot = ss.GetScreenshot();
            screenshot.SaveAsFile("C:\\Users\\LENOVO\\Desktop\\screenshot\\" + filename, ScreenshotImageFormat.Jpeg);
        }



        [Test]
        private void button1_Click(object sender, EventArgs e)
        {
            driver = new FirefoxDriver();
            string link = @"https://www.1v1y.com/";
            driver.Manage().Timeouts();
            driver.Navigate().GoToUrl(link);


            try
            {

                Assert.IsTrue(true);
                
                driver.FindElement(By.CssSelector("input[type='text']")).SendKeys(textArama.Text);
                driver.FindElement(By.ClassName("applysearch")).Click();
                test.Pass("Assertion passed");
                test.Log(Status.Pass, "Pass");
            }
            catch(AssertionException)
            {
                test.Fail("Assertion failed");
                test.Log(Status.Fail, "Fail");
                int i = 1;
                takeScreenShot("Error Screenshot " + i, driver);
                i++;
                throw;
            }
        }
    }
}
