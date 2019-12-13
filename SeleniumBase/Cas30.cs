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
    class Cas30:SeleniumBaseClass
    {
        [Test]
        public void Test1()
        {
            this.Navigate("https://www.seleniumeasy.com/test/basic-first-form-demo.html");
            IWebElement tekstUnos = this.FindElement(By.Id("user-message"));
            this.SendKeys("neki tekst", false, tekstUnos);
            DoWait(2);
            IWebElement showMessage = this.FindElement(By.XPath("//button[@onclick='showInput();']"));
            showMessage.Click();
            IWebElement actualMessage = this.FindElement(By.Id("display"));
          
            DoWait(2);
            Assert.AreEqual(actualMessage.Text, "neki tekst");
        }
        [SetUp]
        public void SetUpTests()
        {
            this.Driver = new ChromeDriver();
            this.Wait = 2;
        }
        [TearDown]
        public void TearDownTests()
        {
            this.Close();
        }
    }
}
