using FluentAssertions;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Configuration;
using TechTalk.SpecFlow;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using Gherkin.Ast;
using System.Collections.Immutable;
using System.Globalization;
using System.Runtime.Serialization;
using Dynamitey.DynamicObjects;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System.Text;
using NUnit.Framework;

namespace Spec_WebTesting.StepDefinitions
{
    [Binding]
   
    public class KatalonTestStepDefinitions
    {

        IWebDriver driver;

        public  KatalonTestStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }


        
        [Given(@"I add four random items to my cart")]
        public void GivenIAddFourRandomItemsToMyCart()
        {
            
                       
              driver.FindElement(By.XPath("//li[@class='product type-product post-25 status-publish first instock product_cat-clothing product_cat-t-shirts has-post-thumbnail taxable shipping-taxable purchasable product-type-simple']//img[@class='attachment-woocommerce_thumbnail size-woocommerce_thumbnail']")).Click();
                driver.FindElement(By.XPath("//button[normalize-space()='Add to cart']")).Click();
                driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");
                driver.FindElement(By.XPath("//li[@class='product type-product post-15 status-publish last instock product_cat-albums product_cat-music has-post-thumbnail virtual taxable purchasable product-type-simple']")).Click();
                driver.FindElement(By.XPath("//button[normalize-space()='Add to cart']")).Click();
                driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");
                driver.FindElement(By.XPath("//li[@class='product type-product post-66 status-publish last instock product_cat-clothing product_cat-hoodies has-post-thumbnail taxable shipping-taxable purchasable product-type-simple']")).Click();
                driver.FindElement(By.XPath("//button[normalize-space()='Add to cart']")).Click();
                driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");
                driver.FindElement(By.XPath("//li[@class='product type-product post-57 status-publish instock product_cat-posters has-post-thumbnail taxable shipping-taxable purchasable product-type-simple']")).Click();
                driver.FindElement(By.XPath("//button[normalize-space()='Add to cart']")).Click();
            

        }

        
        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            Console.WriteLine("order 3");
            driver.FindElement(By.XPath("//a[normalize-space()='View cart']")).Click();
            
        }
        
       
        [Then(@"I found total four items listed my cart")]
        public void ThenIFoundTotalFourItemsListedMyCart()
        {
            Console.WriteLine("order 4");
            int tabRowCount = driver.FindElements(By.XPath("//table//tbody//tr[@class='woocommerce-cart-form__cart-item cart_item']")).Count;
             Console.WriteLine(tabRowCount);
        }

        

        [When(@"I search for lowest price item")]
        public void WhenISearcForLowestPriceItem()
        {
            
          int tableRowCount = driver.FindElements(By.XPath("//table//tbody//tr[@class='woocommerce-cart-form__cart-item cart_item']")).Count;
            int tableColumnCount = driver.FindElements(By.XPath("//tbody/tr[@class='woocommerce-cart-form__cart-item cart_item']/td")).Count;

            // IWebElement totalPrice = driver.FindElement(By.XPath("//tbody/tr/td[6]"));

            string firstpart = "//tbody/tr[";
            string secondpart = "]/td[6]";
           
            ArrayList arrOfDoubles = new ArrayList();

            for (int i = 1; i <= tableRowCount; i++)
            {
                string finalpart = firstpart + i + secondpart;               
                string price = driver.FindElement(By.XPath(finalpart)).Text;               

                double priceValue = double.Parse(price.Substring(1, price.Length - 1));
                arrOfDoubles.Add(priceValue);

            }
            arrOfDoubles.Sort();
            int skipValue = 0;
            double skipPrice = 0;
            foreach (Double arr in arrOfDoubles)
            {
                if (skipValue == 0)
                {
                    skipPrice = arr;
                    Console.WriteLine(skipPrice);
                }

            }


        }

        
        [When(@"I am able to remove the lowest price item from my cart")]
        public void WhenIAmAbleToRemoveTheLowestPriceItemFromMyCart()
        {
            int tableRowCount = driver.FindElements(By.XPath("//table//tbody//tr[@class='woocommerce-cart-form__cart-item cart_item']")).Count;
            int tableColumnCount = driver.FindElements(By.XPath("//tbody/tr[@class='woocommerce-cart-form__cart-item cart_item']/td")).Count;

            string firstpart = "//tbody/tr[";
            string secondpart = "]/td[6]";
            ArrayList arrayOfDoubles = new ArrayList();

            for (int i = 1; i <= tableRowCount; i++)
            {
                string finalpart = firstpart + i + secondpart;               
                string price = driver.FindElement(By.XPath(finalpart)).Text;  
                double priceValue = double.Parse(price.Substring(1, price.Length - 1));
                arrayOfDoubles.Add(priceValue);

            }
            arrayOfDoubles.Sort();

            int skipValue = 0;
            double skipPrice = 0;
             foreach(Double arr in arrayOfDoubles)
              {
                if (skipValue == 0)
                    skipPrice = arr;
                break;

            }

            for (int i = 1; i <=tableRowCount; i++)
            {
                String price = driver.FindElement(By.XPath("//table[@class='shop_table shop_table_responsive cart woocommerce-cart-form__contents']//tbody//tr[" + i + "]/td[6]")).Text;
                
                 double priceValue = double.Parse(price.Substring(1, price.Length - 1));
                if (priceValue == skipPrice)
                {
                    driver.FindElement(By.XPath("//table[@class='shop_table shop_table_responsive cart woocommerce-cart-form__contents']//tbody//tr[" + i + "]/td[1]/a[1]")).Click();         
                    break;
                }

            }

        }

       

        [Then(@"I am able to verify three items in my cart")]
        public void ThenIAmAbleToVerifyThreeItemsInMyCart()
        {            

          int tableRowCou = driver.FindElements(By.XPath("//table//tbody//tr[@class='woocommerce-cart-form__cart-item cart_item']")).Count;          

            Console.WriteLine(tableRowCou);
        }
    }
}
