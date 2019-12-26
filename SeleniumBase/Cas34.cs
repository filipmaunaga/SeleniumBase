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
            this.FindElement(By.XPath("HP OMEN Z7Y57AA TN"))?.Click();
            DoWait(2);
            IWebElement price = this.FindElement(By.XPath("//div[@class='price']"));
            string cena = price.Text.Trim();
            Assert.AreEqual("29.990", cena);
        }

         [Test]
        public void Test2()
        {
            this.Navigate("http://shop.qa.rs/");
            DoWait(2);
            IWebElement small = this.FindElement(By.XPath("(//select[@name='quantity'])[2]"));
            var selection = new SelectElement(small);
            selection.SelectByValue("6");
            DoWait(1);
            this.FindElement(By.XPath("(//input[@type='submit' and @value='ORDER NOW'])[2]"))?.Click();
            IWebElement total1 = this.FindElement(By.XPath("//div[@class='panel-footer'])[2]"));
            DoWait(2);
           

            IWebElement total2 = this.FindElement(By.XPath("//tbody//tr[1]/td[4]"));
            DoWait(2);
            string t1 = total1.Text.Substring(1);

            string t2 = total2.Text.Substring(1);

            int m1 = Convert.ToInt32(t1);

            int m2 = Convert.ToInt32(t2);

            Assert.AreEqual(6*m1, m2);


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