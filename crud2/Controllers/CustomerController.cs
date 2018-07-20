using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud2.Context;
using crud2.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud2.Controllers
{
    public class CustomerController : Controller
    {
        //4
        private EntityContext _context;

        public CustomerController(EntityContext context)
        {
            this._context = context;
        }
        
        public IActionResult Index()
        {
            var model = this._context.Customers.ToList(); // context in içindeki customers kullanılıyor. db set içindeki
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = this._context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(model);
        }

        public IActionResult Create() => View();


        [HttpPost] //POST metodu ise URL’de görünmesini istemediğimiz veriler olduğunda, dosya yükleyeceğimiz zaman, querystring’in çok büyük olduğu durumlarda kullanılır.İstek yaparken gönderdiğimiz parametreler tarayıcıların desteklediği formatlarda olmayabilir.Örneğin Japonca bir kelimeyi ya da Arapça’da bir harfi parametre olarak gönderirken tarayıcılar bu karakterleri anladıkları formata çevirirler
        [ValidateAntiForgeryToken] // anatetion
        public IActionResult Create([Bind("Name","Email")] Customer customer)
        {
            this._context.Customers.Add(customer);
            this._context.SaveChanges();
            return RedirectToAction(nameof(Index));// Bu, MVC'ye, global.asax dosyasında tanımlanmış olan Rota tablosuna rotaları bakmasını ve ardından o rotada tanımlanan kontrol / eyleme yönlendirmesini söyler. Bu ayrıca RedirectToAction () gibi yeni bir istekte bulunur.
        }

        public IActionResult Edit(int id)
        {
            var model = this._context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind("Id","Name","Email")]Customer customer)
        {
            try
            {
                this._context.Customers.Update(customer);
                this._context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            var model = this._context.Customers.Where(c => c.Id == id).FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, [Bind("Id", "Name", "Email")]Customer customer)
        {
            try
            {
                var model = this._context.Customers.Where(c => c.Id == id).FirstOrDefault();
                this._context.Customers.Remove(model);
                this._context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}