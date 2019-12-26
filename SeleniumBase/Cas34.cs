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
    class Cas34 : SeleniumBaseClass
    {


        [Test]
        public void Test()
        {
            this.Navigate("https://www.emmi.rs/naslovna_stranica.1.html");
            DoWait(2);
            /*
             * Posetiti emmi.rs, na njoj locirati odeljak "Monitori", kliknuti, i u pretrazi 
             izabrati "HP" proizvodjaca, tip "TN", kliknuti "trazi". Iz rezultata pretrage, 
             izabrati model OMEN, i na stranici sa detaljima, verifikovati da je cena 29990.
 */

            this.FindElement(By.LinkText("Monitori"))?.Click();
            DoWait(2);
            IWebElement brend = this.FindElement(By.Name("brandId"));
            var selection = new SelectElement(brend);

            selection.SelectByValue("448");
            DoWait(2);
            IWebElement tip = this.FindElement(By.Name("tip"));
            var selection2 = new SelectElement(tip);
            selection2.SelectByValue("34878");
            this.FindElement(By.XPath("//div[@id='searchBottom']/input[@type='submit']"))?.Click();

            DoWait(2);
            this.FindElement(By.LinkText("HP OMEN Z7Y57AA TN"))?.Click();
            DoWait(2);
            IWebElement price= this.FindElement(By.XPath("//div[@class='price']"));
            string cena = price.Text.Remove(2, 1);
            Assert.AreEqual(29990, cena);
         



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