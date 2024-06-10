using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using USCarCare.Models;

namespace USCarCare.Controllers
{
    public class HomeController : Controller
    {
        private Model1 db = new Model1();
        private Model2 db1 = new Model2();
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Home");
        }
        // GET: Home/Login
        public ActionResult Login()
        {
            return View(); 
      
        }

        // POST: Home/Login
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "email,password")] tbl_user tbl_user)
        {
            try
            {
                using (Model1 db = new Model1())
                {
                    var user = db.tbl_user
                .Where(e => e.email.Equals(tbl_user.email) && e.password.Equals(tbl_user.password))
                .FirstOrDefault();

                    if (user != null)
                    {
                        Session["firstname"] = user.first_name;
                        Session["lastname"] = user.last_name;
                        if (Session["firstname"] != null)
                        {
                            if (user.user_type == "Admin")
                            {
                                // User is an admin
                                return RedirectToAction("Home_admin");
                            }
                            else if (user.user_type == "Customer")
                            {
                                // User is a customer
                                return RedirectToAction("Home_customer");
                            }

                        }
                        else
                        {
                            return RedirectToAction("Login");
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid User");
                    }
                }
          
            }
            catch (Exception)
            {
                Response.Redirect("Error.cshtml");
            }


            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Contact_admin()
        {
            return View();
        }
        public ActionResult Home_admin()
        {
            return View();
        }
        public ActionResult About_admin()
        {
            return View();
        }
        public ActionResult Services_admin()
        {
            return View();
        }
        public ActionResult Contact_customer()
        {
            return View();
        }
        public ActionResult Home_customer()
        {
            return View();
        }
        public ActionResult About_customer()
        {
            return View();
        }
        public ActionResult Services_customer()
        {
            return View();
        }

        // GET: Home
        public ActionResult Index()
        {
           
            return View(db.tbl_user.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user);
        }

        // GET: Home/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Home/Register
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "user_id,first_name,last_name,email,password,confirm_password")] tbl_user tbl_user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.tbl_user.Add(tbl_user);
                    db.SaveChanges();
                    ViewBag.Message = "Registered Successfully!";
                    return RedirectToAction("Login");
                }
                catch(Exception)
                {
                    Response.Redirect("Error.cshtml");
                }
               
            }

            return View();
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,first_name,last_name,email,password,confirm_password,user_type")] tbl_user tbl_user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(tbl_user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    Response.Redirect("Error.cshtml");
                }
                
            }
            return View(tbl_user);
        }

        // GET: tbl_user/Delete/5
        public ActionResult Delete(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return HttpNotFound();
            }
            return View(tbl_user);
        }

        // POST: tbl_user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_user tbl_user = db.tbl_user.Find(id);
            db.tbl_user.Remove(tbl_user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: tbl_service/Booking
        public ActionResult Booking()
        {
            return View();
        }

        // POST: tbl_service/Booking
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Booking([Bind(Include = "id,Car_Brand,Car_Model,Car_Type,Car_Registration_Number,Service_Type,Special_Request")] tbl_service tbl_service)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db1.tbl_service.Add(tbl_service);
                    db1.SaveChanges();
                    ViewBag.Message = "Booked Successfully!";
                    return RedirectToAction("Home_customer");
                }
                catch (Exception)
                {
                    Response.Redirect("Error.cshtml");
                }
                
                
            }

            return View(tbl_service);
        }

        // GET: tbl_service
        public ActionResult Service_Request()
        {
            return View(db1.tbl_service.ToList());
        }
        // GET: tbl_service/Details/5
        public ActionResult Details_service(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_service tbl_service = db1.tbl_service.Find(id);
            if (tbl_service == null)
            {
                return HttpNotFound();
            }
            return View(tbl_service);
        }
        // GET: tbl_service/Delete/5
        public ActionResult Delete_service(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_service tbl_service = db1.tbl_service.Find(id);
            if (tbl_service == null)
            {
                return HttpNotFound();
            }
            return View(tbl_service);
        }

        // POST: tbl_service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed_service(int id)
        {
            tbl_service tbl_service = db1.tbl_service.Find(id);
            db1.tbl_service.Remove(tbl_service);
            db1.SaveChanges();
            return RedirectToAction("Service_Request");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
