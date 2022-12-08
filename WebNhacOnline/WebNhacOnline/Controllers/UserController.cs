using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebNhacOnline.Models;

namespace WebNhacOnline.Controllers
{
    public class UserController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();
   
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.UploadUserFile != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(user.UploadUserFile.FileName);
                    string exten = Path.GetExtension(user.UploadUserFile.FileName);
                    if(exten == "jpg" || exten == "png" || exten == "jpeg")
                    {
                        filename = filename + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + exten;
                        user.Userimage = filename;
                        user.UploadUserFile.SaveAs(Path.Combine(Server.MapPath("~/assets/media/section3/"), filename));
                    }    
                    else
                    {
                        user.ErrorMessage = "File Extension Is InValid - Only Upload jpg/png/jpeg File";
                        ViewBag.ResultErrorMessage = user.ErrorMessage;
                        return View();
                    }    
                }
                var check = db.Users.FirstOrDefault(s => s.UserName == user.UserName);
                var check_mail = db.Users.FirstOrDefault(s => s.Gmail == user.Gmail);
                if (check == null && check_mail == null)
                {
                    user.Status = 1;
                    var change_p = user.Password;
                    user.Password = GetMD5(change_p);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("~/Home/Index");
                }
                else if (check != null || check_mail != null)
                {
                    ViewBag.error = "Tên đăng nhập hoặc email đã được sử dụng";
                    return View(user);
                }
            }
            
            return View(user);
        }
        
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
