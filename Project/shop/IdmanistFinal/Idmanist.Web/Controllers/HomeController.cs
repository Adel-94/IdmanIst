using Idmanist.Web.ViewModels;
using IdmanistCore.Infrastructure;
using IdmanistCore.Repository;
using IdmanistData.DataContext;
using IdmanistData.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Idmanist.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
       // private readonly IWishRepository  _wishRepository;

        public HomeController(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }
        public ActionResult Index()
        {
            IdmanistDataContext db = new IdmanistDataContext();
            ProdInViewModel model = new ProdInViewModel();
             model.wishesss = db.Wishes.ToList();
            //var wishesss = db.Wishes.ToList();
            model.Categories = _categoryRepository.GetAll().ToList();
            model.Products = _productRepository.GetAll().OrderByDescending(n=> n.mywishes).Take(8).ToList();
            model.FeaturedProducts = _productRepository.GetAll().OrderByDescending(k => k.Product_date).Take(7).ToList();
            return View (model);
        }


        public string UnlikeThis(int id)
        {
            using (IdmanistDataContext db = new IdmanistDataContext())
            {
                Product prod = db.Product.FirstOrDefault(x => x.ProductId == id);
                if (User.Identity.IsAuthenticated || Session["user"] != null)
                {
                    Customer thisUser = (Customer)(Session["user"]);
                    Customer d = db.Customer.FirstOrDefault(x => x.Email == thisUser.Email);
                    Wishes l = db.Wishes.FirstOrDefault(x => x.product_id == id && x.customer_id == d.UserID);
                    prod.mywishes--;
                    db.Wishes.Remove(l);
                    db.SaveChanges();

                }
                return prod.mywishes.ToString();
            }

        }



        public string LikeThis(int id)
        {
            

            using (IdmanistDataContext db = new IdmanistDataContext())
            {
                dynamic mymodel = new ExpandoObject();
                Product prod = db.Product.FirstOrDefault(x => x.ProductId == id);
               
                if (User.Identity.IsAuthenticated || Session["user"] != null)
                {
                    Customer thisUser = (Customer)(Session["user"]);
                    Customer e = db.Customer.FirstOrDefault(x => x.Email == thisUser.Email);
                    prod.mywishes++;
                    
                    Wishes like = new Wishes();
                    like.product_id = id;
                    like.customer_id = e.UserID;
                    like.wished = true;
                    db.Wishes.Add(like);
                    db.SaveChanges();

                }

                return prod.mywishes.ToString();
            }
        

        }
    
    }
    }