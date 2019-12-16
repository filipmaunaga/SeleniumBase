using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumBase
{
    class Cas31:SeleniumBaseClass
    {
        [Test]
        public void Test1()
        {
            this.Navigate("https://www.toolsqa.com/automation-practice-form");
            IWebElement firstName= this.FindElement(By.XPath("//input[@name='firstname']"));
            this.SendKeys("Ime", false, firstName);
            IWebElement lastName = this.FindElement(By.Id("lastname"));
            this.SendKeys("Prezime", false, lastName);
            DoWait(1);
            //IWebElement gender = this.FindElement(By.Id("sex-0"));
            //gender.Click();
            //DoWait(1);
            //IWebElement experience = this.FindElement(By.Id("exp-6"));
            //experience.Click();
            DoWait(1);
            IWebElement datepick = this.FindElement(By.Id("datepicker"));
            this.SendKeys(DateTime.Today.ToString(), false, datepick);
            
            DoWait(1);
            IWebElement profession = this.FindElement(By.XPath("//input[@name='profession' and @value='Automation Tester']"));
            profession.Click();
            DoWait(1);
            //IWebElement tool = this.FindElement(By.Id("tool-2"));
            //tool.Click();
            DoWait(1);
            IWebElement continent = this.FindElement(By.Id("continents"));
            var selection = new SelectElement(continent);
            selection.SelectByText("Europe");
            DoWait(2);
        }
        [Test]
        public void Test2()
        {
            this.Navigate("http://test.qa.rs/");
            this.FindElement(By.LinkText("Kreiraj novog korisnika"))?.Click();
            this.FindElement(By.Name("ime"))?.SendKeys("Dragan");
            this.FindElement(By.Name("prezime"))?.SendKeys("Jovic");
            this.FindElement(By.Name("korisnicko"))?.SendKeys("draganjovic1990");
            this.FindElement(By.Name("email"))?.SendKeys("draganjovic@gmail.com");
            this.FindElement(By.Name("telefon"))?.SendKeys("063/9090000");
            IWebElement zemlja = this.FindElement(By.Name("zemlja"));
            var selection = new SelectElement(zemlja);
            selection.SelectByValue("bih");
            DoWait(2);
            this.FindElement(By.XPath("//input[@name='pol' and @value='m']"))?.Click();
            this.FindElement(By.Name("obavestenja"))?.Click();
            this.FindElement(By.Name("promocije"))?.Click();
            this.FindElement(By.Name("register"))?.Click();
            DoWait(2);

            IWebElement success= this.FindElement(By.XPath("//div[@class='alert alert-success' and @role='alert']"));
            if (success != null)
            {
                Assert.Pass("Korisnik je uspesno registrovan i test je prosao");
            } else
            {
                Assert.Fail("Korisnik nije mogao da bude registrovan i test nije prosao");


            }





            
        }
        [SetUp]
        public void SetUpTests()
        {
            this.Driver = new ChromeDriver();
        }
        [TearDown]
        public void TearDownTests()
        {
            this.Close();
        }
    }
}
