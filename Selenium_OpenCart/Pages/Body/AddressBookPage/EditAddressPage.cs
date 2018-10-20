﻿using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using Selenium_OpenCart.Tools.SearchWebElements;
using Selenium_OpenCart.Tools;
using Selenium_OpenCart.Data.Application;

namespace Selenium_OpenCart.Pages.Body.AddressBookPage
{
    public class EditAddressPage
    {
        //private IWebDriver driver;
        protected ISearch Search
        {
            get
            {
                return Application.Get().Search;
            }
        }

        IJavaScriptExecutor js;

        private const string PAGE_NAME = "Edit Address";

        protected IWebElement PageName { get; private set; }
        public AddressFormComponent AddressForm { get; private set; }        
        public IWebElement ContinueButton
        { get { return Search.ElementByCssSelector("input[type ='submit']"); } }

        public EditAddressPage()
        {            
            PageName = Search.ElementByCssSelector("#content  h2");
            AddressForm = new AddressFormComponent();
        }

        public EditAddressPage EditFirstName(string firstName)
        {
            AddressForm.FirstNameInput.Click();
            AddressForm.FirstNameInput.Clear();
            AddressForm.FirstNameInput.SendKeys(firstName);
            return this;
        }

        public EditAddressPage EditLastName(string firstName)
        {
            AddressForm.LastNameInput.Click();
            AddressForm.LastNameInput.Clear();
            AddressForm.LastNameInput.SendKeys(firstName);
            return this;
        }

        public EditAddressPage EditCompany(string company)
        {
            AddressForm.CompanyInput.Click();
            AddressForm.CompanyInput.Clear();
            AddressForm.CompanyInput.SendKeys(company);
            return this;
        }

        public EditAddressPage EditAddress2(string address2)
        {
            AddressForm.Address2Input.Click();
            AddressForm.Address2Input.Clear();
            AddressForm.Address2Input.SendKeys(address2);
            return this;
        }

        public EditAddressPage EditPostCode(string postCode)
        {
            AddressForm.PostCodeInput.Click();
            AddressForm.PostCodeInput.Clear();
            AddressForm.PostCodeInput.SendKeys(postCode);
            return this;
        }

        public EditAddressPage FillAllField(string firstName, string lastName, string company,
                string Address1, string Address2, string city, string postCode, string country,
                string regionState)
        {
            js = Application.Get().Browser.Driver as IJavaScriptExecutor;

            AddressForm.TypeInFirstName(firstName);
            AddressForm.TypeInLastNameInput(lastName);
            AddressForm.CompanyInput.Clear();
            AddressForm.CompanyInput.SendKeys(company);
            AddressForm.TypeInAddress1Input(Address1);
            AddressForm.Address2Input.Clear();
            AddressForm.Address2Input.SendKeys(Address2);

            js.ExecuteScript("window.scrollBy(0,100)"); //Moving scrollbar down

            AddressForm.TypeInCityInput(city);
            AddressForm.TypeInPostCodeInput(postCode);

            js.ExecuteScript("window.scrollBy(0,200)"); //Moving scrollbar down againe

            AddressForm.ChooseCountry(country);
            AddressForm.ChooseRegionState(regionState);
            return this;
        }

        public EditAddressPage FillAllNotRequareField(string company, string address2, string postCode)
        {
            js = Application.Get().Browser.Driver as IJavaScriptExecutor;

            EditCompany(company);
            EditAddress2(address2);
            
            js.ExecuteScript("window.scrollBy(0,100)"); //Moving scrollbar down

            EditPostCode(postCode);

            return this;
        }
                
        public AddressBookPage Continue()
        {
            ContinueButton.Click();
            return new AddressBookPage();
        }
    }
}
