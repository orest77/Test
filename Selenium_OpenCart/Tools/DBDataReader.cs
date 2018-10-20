﻿using System;
using System.Collections.Generic;
using Selenium_OpenCart.Data.Product;
using Selenium_OpenCart.Data.Currency;
using Selenium_OpenCart.Data.ProductReview;
using Selenium_OpenCart.Data.User;
using MySql.Data.MySqlClient;
using Selenium_OpenCart.Data.ProductReview.Rating;
using Selenium_OpenCart.Data.Category;
using Selenium_OpenCart.Data.Cart;
using Selenium_OpenCart.Data.Address;

namespace Selenium_OpenCart
{
    class DBDataReader : DBAdapter
    {
        /// <summary>
        /// Get list of products from database
        /// </summary>
        /// <param name="whereString">sql string contain 'where' params. Ex: "name LIKE '%Apple%'"</param>
        /// <returns>List of Product objects</returns>
        public List<IProduct> GetProducts(string whereString = "")
        {

            List<IProduct> list = new List<IProduct>();
            DBAdapter adapter = new DBAdapter();
            MySqlDataReader products;
            try
            {
                adapter.OpenConnection();
                if (whereString == "")
                {
                    products = adapter.GetSelectReader("oc_product", join: adapter.GetJoinedTableString("oc_product_description", "LEFT", "product_id"));
                }
                else
                {
                    products = adapter.GetSelectReader("oc_product", where: whereString, join: adapter.GetJoinedTableString("oc_product_description", "LEFT", "product_id"));
                }
                while (products.Read())
                {

                    list.Add(Product.Get()
                        .SetName(products["name"].ToString())
                        .SetDescription(products["description"].ToString())
                        .SetID(Int32.Parse(products["product_id"].ToString()))
                        .SetImage(products["image"].ToString())
                        .SetPrice(Convert.ToDouble(products["price"].ToString()))
                        .SetQuantity(Int32.Parse(products["quantity"].ToString()))
                        .Build()
                        );
                }

            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                adapter.CloseConnection();
            }
            return list;
        }

        /// <summary>
        /// Get list of products review from database
        /// </summary>
        /// <param name="whereString">sql string contain 'where' params. Ex: "name LIKE '%name%'"</param>
        /// <returns>List of ProductReview objects</returns>
        public List<IProductReview> GetProductsReview(string whereString = "")
        {
            List<IProductReview> list = new List<IProductReview>();
            DBAdapter adapter = new DBAdapter();
            MySqlDataReader products;
            try
            {
                
                adapter.OpenConnection();
                if (whereString == "")
                {
                    products = adapter.GetSelectReader("oc_review",join: adapter.GetJoinedTableString("oc_product_description", "LEFT", "product_id"));
                }
                else
                {
                    products = adapter.GetSelectReader("oc_review", where: whereString, join: adapter.GetJoinedTableString("oc_product_description", "LEFT", "product_id"));
                }
                while (products.Read())
                {
                    list.Add(ProductReview.Get()
                        .SetProductName(products["name"].ToString())
                        .SetReviewerName(products["author"].ToString())
                        .SetReviewText(products["text"].ToString())
                        .SetRating((Int32.Parse(products["raiting"].ToString())).ToRating())
                        .SetDate(products["date_added"].ToString())
                        .Build());
                }

            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                adapter.CloseConnection();
            }
            return list;
        }

        /// <summary>
        /// Get list of users from database
        /// </summary>
        /// <param name="whereString">sql string contain 'where' params. Ex: "name LIKE '%name%'"</param>
        /// <returns>List of User objects</returns>
        public List<IUser> GetUsers(string whereString = "")
        {

            List<IUser> list = new List<IUser>();
            DBAdapter adapter = new DBAdapter();
            MySqlDataReader products;
            try
            {
                adapter.OpenConnection();
                if (whereString == "")
                {
                    products = adapter.GetSelectReader("oc_customer");
                }
                else
                {
                    products = adapter.GetSelectReader("oc_customer", where: whereString);
                }
                while (products.Read())
                {

                    list.Add(User.Get()
                        .SetUsername(products["email"].ToString())
                        .SetPassword(products["password"].ToString())
                        .SetSault(products["salt"].ToString())
                        .SetID(Int32.Parse(products["customer_id"].ToString()))
                        .SetEmail(products["email"].ToString())
                        .SetFirstName(products["firstname"].ToString())
                        .SetLastName(products["lastname"].ToString())
                        .SetSubscribe(Boolean.Parse(products["newsletter"].ToString()))
                        .SetTelephone(products["telephone"].ToString())
                        .Build()
                        );
                }

            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                adapter.CloseConnection();
            }
            return list;
        }

        /// <summary>
        /// Get list of category from database
        /// </summary>
        /// <param name="whereString">sql string contain 'where' params. Ex: "name LIKE '%name%'"</param>
        /// <returns>List of Category objects</returns>
        public List<ICategory> GetCategories(string whereString = "")
        {

            List<ICategory> list = new List<ICategory>();
            DBAdapter adapter = new DBAdapter();
            MySqlDataReader products;
            try
            {
                adapter.OpenConnection();
                if (whereString == "")
                {
                    products = adapter.GetSelectReader("oc_category", join: adapter.GetJoinedTableString("oc_category_description", "LEFT", "category_id"));
                }
                else
                {
                    products = adapter.GetSelectReader("oc_category", where: whereString, join: adapter.GetJoinedTableString("oc_category_description", "LEFT", "category_id"));
                }
                while (products.Read())
                {

                    list.Add(Category.Get()
                        .SetName(products["name"].ToString())
                        .SetDescription(products["description"].ToString())
                        .SetID(Int32.Parse(products["category_id"].ToString()))
                        .SetParent(Int32.Parse(products["parent_id"].ToString()))
                        .Build()
                        );
                }

            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                adapter.CloseConnection();
            }
            return list;
        }

        /// <summary>
        /// Get list of cart from database
        /// </summary>
        /// <param name="whereString">sql string contain 'where' params. Ex: "name LIKE '%name%'"</param>
        /// <returns>List of Cart objects</returns>
        public List<ICart> GetCart(string whereString = "")
        {

            List<ICart> list = new List<ICart>();
            DBAdapter adapter = new DBAdapter();
            MySqlDataReader products;
            try
            {
                adapter.OpenConnection();
                if (whereString == "")
                {
                    products = adapter.GetSelectReader("oc_cart");
                }
                else
                {
                    products = adapter.GetSelectReader("oc_cart", where: whereString);
                }
                while (products.Read())
                {

                    list.Add(Cart.Get()
                        .SetID(Int32.Parse(products["cart_id"].ToString()))
                        .SetCustomerID(Int32.Parse(products["customer_id"].ToString()))
                        .SetDate(products["date_added"].ToString())
                        .SetProductID(Int32.Parse(products["product_id"].ToString()))
                        .Build()
                        );
                }

            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                adapter.CloseConnection();
            }
            return list;
        }

        /// <summary>
        /// Get list of currency from database
        /// </summary>
        /// <param name="whereString">sql string contain 'where' params. Ex: "name LIKE '%name%'"</param>
        /// <returns>List of Currency objects</returns>
        public List<ICurrency> GetCurrency(string whereString = "")
        {

            List<ICurrency> list = new List<ICurrency>();
            DBAdapter adapter = new DBAdapter();
            MySqlDataReader products;
            try
            {
                adapter.OpenConnection();
                if (whereString == "")
                {
                    products = adapter.GetSelectReader("oc_currency");
                }
                else
                {
                    products = adapter.GetSelectReader("oc_currency", where: whereString);
                }
                while (products.Read())
                {

                    list.Add(Currency.Get()
                        .SetValue(Double.Parse(products["value"].ToString()))
                        .SetID(Int32.Parse(products["currency_id"].ToString()))
                        .SetTitle(products["title"].ToString())
                        .SetCode(products["code"].ToString())
                        .Build()
                        );
                }

            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                adapter.CloseConnection();
            }
            return list;
        }

        /// <summary>
        /// Get list of address from database
        /// </summary>
        /// <param name="whereString">sql string contain 'where' params. Ex: "name LIKE '%name%'"</param>
        /// <returns>List of Address objects</returns>
        public List<IAdress> GetAddress(string whereString = "")
        {

            List<IAdress> list = new List<IAdress>();
            DBAdapter adapter = new DBAdapter();
            MySqlDataReader products;
            try
            {

                adapter.OpenConnection();
                if (whereString == "")
                {
                    products = adapter.GetSelectReader("oc_address", 
                        columns: "oc_customer.firstname,oc_customer.lastname,company,address_1,address_2,city,postcode,oc_country.name as country,oc_zone.name as zone ", 
                        join:
                        String.Concat(
                            GetJoinedTableString("oc_customer","LEFT","customer_id"),
                            GetJoinedTableString("oc_country", "LEFT", "country_id"),
                            GetJoinedTableString("oc_zone", "LEFT", "zone_id")
                            )
                        );
                }
                else
                {
                    products = adapter.GetSelectReader("oc_address",
                        columns: "oc_customer.firstname,oc_customer.lastname,company,address_1,address_2,city,postcode,oc_country.name as country,oc_zone.name as zone ",
                        where: whereString,
                        join:
                        String.Concat(
                            GetJoinedTableString("oc_customer", "LEFT", "customer_id"),
                            GetJoinedTableString("oc_country", "LEFT", "country_id"),
                            GetJoinedTableString("oc_zone", "LEFT", "zone_id")
                            )
                        );
                }
                while (products.Read())
                {

                    list.Add(Adress.Get()
                        .SetFirstName(products["firstname"].ToString())
                        .SetLastName(products["lastname"].ToString())
                        .SetAddress1(products["address_1"].ToString())
                        .SetCity(products["city"].ToString())
                        .SetPostCode(products["postcode"].ToString())
                        .SetCountry(products["country"].ToString())
                        .SetRegion(products["zone"].ToString())
                        .SetAddress2(products["address_2"].ToString())
                        .SetCompany(products["company"].ToString())
                        .Build()
                        );
                }

            }
            catch
            {
                throw new Exception();
            }
            finally
            {
                adapter.CloseConnection();
            }
            return list;
        }
    }

}
