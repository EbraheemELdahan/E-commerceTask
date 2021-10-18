﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityTask.Models;

namespace IdentityTask.Controllers
{
    
    public class CartController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
             ViewBag.order = Session["order"] as CartViewModel;
            return View();
        }
        //Buy
        [HttpPost]
        public ActionResult checkout(Shipped_Data shipped_Data)
        {
            int count = 0;
            string userID = User.Identity.GetUserId();
            var CurrentCustomer = db.Users.FirstOrDefault(a => a.Id == userID);
            CartViewModel cart = Session["order"] as CartViewModel; //for changing quantity after
            DateTime orderdate = DateTime.Now;
            var shippedData = new Shipped_Data()
            {
                UserID=userID,
                Country= shipped_Data.Country,
                City=shipped_Data.City,
                BuildingNumber=shipped_Data.BuildingNumber,
                Street=shipped_Data.Street
            };
            db.SaveChanges();
            Order order = new Order()
            {
                UserID = userID,
                OrderDate = orderdate,
                OrderNumber = count++,
                Status = OrderStatus.Waiting,
                shippedData = userID
            };// Tax will be determined later by admin
            db.Orders.Add(order);
            db.SaveChanges();
            foreach (var item in cart.ProductsQuantities)
            {
                for (int i = 0; i < item.Quantity; i++)
                {
                    OrderDetails orderdetails = new OrderDetails()
                    {
                        ProductID = item.Product.ID,
                        UnitPrice = item.Product.Price,
                        OrderID = order.ID,
                        Discount = (float)((item.Product.Price) * .05)
                    };
                    db.OrderDetails.Add(orderdetails);
                    
                }
            }
            db.SaveChanges();
            Session.Remove("order");
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public ActionResult AddtoCart(int id)
        {
            //if ((!User.Identity.IsAuthenticated || !User.IsInRole("UserCustomer")))
            //{
            ////    if (Request.IsAjaxRequest())
            ////        return Content(Url.Action("Login", "Account"));
            ////    else
            //        return RedirectToAction("Login", "Account");
            //}
            CartViewModel order;
            var product = db.Products.FirstOrDefault(a => a.ID == id);
            if (Session["order"] != null)
            {
                order = Session["order"] as CartViewModel;
                int index = IsAddedToCart(id);
                if (index == -1)
                {
                    order.ProductsQuantities.Add(new ProductsQuantityViewModel() { Product = product, Quantity = 1 });
                }
                order.ProductsQuantities[index].Quantity++;
                //order.ProductsQuantities.Add(new ProductsQuantityViewModel() { Product = product, Quantity = 1 });
                order.TotalPrice += product.Price;
                order.TotalQuantities++;

            }
            else
            {
                order = new CartViewModel();
                order.TotalQuantities = 1;
                order.TotalPrice = product.Price;
                order.ProductsQuantities = new List<ProductsQuantityViewModel>();
                order.ProductsQuantities.Add(new ProductsQuantityViewModel() { Product = product, Quantity = 1 });
                //for (int i = 0; i < order.ProductsQuantities.Count; i++)
                //{
                //    order.TotalPrice += order.ProductsQuantities[i].Quantity * product.Price;
                //}
                //order.TotalPrice = order.ProductsQuantities[0].Quantity *product.Price;
            }
            order.TotalPrice = (float)(Math.Round(order.TotalPrice, 2));
            Session["order"] = order;
            
            return RedirectToAction("Index", "cart");
        }

        public int IsAddedToCart(int productId)
        {
           CartViewModel cart = Session["order"] as CartViewModel;
            var Products = cart.ProductsQuantities;
            for (int i = 0; i < Products.Count; i++)
            
                if (Products[i].Product.ID == productId)
                    return i;
                return -1;
        }
        public ActionResult ChangeQuantity(int ChangedQuantity,int ChangedId)
        {
            int TotalQuantity = 0;
            float TotalPrice = 0;
            CartViewModel order = Session["order"]as CartViewModel;
            order.ProductsQuantities[ChangedId].Quantity = ChangedQuantity;
            foreach (var item in order.ProductsQuantities)
            {
                TotalQuantity += item.Quantity;
                TotalPrice += (item.Product.Price) *item.Quantity;
            }
            order.TotalPrice = TotalPrice;
            order.TotalQuantities = TotalQuantity;
            Session["order"] = order;
            return View("~/Views/Cart/Index");
        }
        public ActionResult RemoveFromCart(int id)
        {
            CartViewModel cart = Session["order"] as CartViewModel;
            ProductsQuantityViewModel product = cart.ProductsQuantities.Where(a => a.Product.ID == id).FirstOrDefault();
            cart.TotalQuantities -= product.Quantity;
            cart.TotalPrice = cart.TotalPrice - (product.Quantity * product.Product.Price);
            cart.ProductsQuantities.Remove(product);
            Session["order"] = cart;
            return RedirectToAction("index", "home");
        }
    }
    
}