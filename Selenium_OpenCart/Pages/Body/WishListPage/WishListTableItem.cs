﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using Selenium_OpenCart.Tools;

namespace Selenium_OpenCart.Pages.Body.WishListPage
{
    public class WishListTableItem
    {
        protected IWebElement Image { get; private set; }
        protected IWebElement ProductName { get; private set; }
        protected IWebElement Model { get; private set; }
        protected IWebElement Stock { get; private set; }
        protected IWebElement UnitPrice { get; private set; }
        protected IWebElement AddToCartButton { get; private set; }
        protected IWebElement RemoveFromWishlistButton { get; private set; }


        public WishListTableItem(IWebElement element)
        {
            Image = element.FindElement(By.XPath("//td[@class='text-center']//img"));
            ProductName = element.FindElement(By.CssSelector(".text-left >a"));
            Model = element.FindElement(By.XPath("//td[@class='text-left' and string-length(text()) > 0]"));
            Stock = element.FindElement(By.XPath("//td[@class='text-right' and string-length(text()) > 0]"));
            UnitPrice = element.FindElement(By.XPath("//div[@class='price']"));
            AddToCartButton = element.FindElement(By.XPath("//button[@data-original-title='Add to Cart']"));
            RemoveFromWishlistButton = element.FindElement(By.XPath("//a[@data-original-title='Remove']"));
        }

        #region AtomicOperations
        public void ImageClick()
        {
            Image.Click();
        }

        public string GetProductName()
        {
            return this.ProductName.Text;
        }
        public void ClickProductName()
        {
            ProductName.Click();
        }
        public string GetProductModel()
        {
            return this.Model.Text;
        }
        public string GetProductAvailability()
        {
            return this.Stock.Text;
        }
        public string GetProductPrice()
        {
            return this.UnitPrice.Text;
        }
        public WishListPage ClickAddToCartButton()
        {
            AddToCartButton.Click();
            return new WishListPage();
        }
        public WishListPage ClickRemoveFromWishListButton()
        {
            RemoveFromWishlistButton.Click();
            return new WishListPage();
        }

        #endregion 

    }
}