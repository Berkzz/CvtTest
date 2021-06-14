using CvtTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace CvtTest.Controllers
{
    public class ContactController : Controller
    {
        ContactContext db = new ContactContext();

        public ActionResult DeleteContact(int id) // удаление контакта по id
        {
            db.Contacts.Remove(db.Contacts.Where(m => m.Id == id).FirstOrDefault());
            db.SaveChanges();
            return MainPage();
        }

        public ActionResult ClearContact() // очистка базы данных
        {
            db.Database.Delete();
            return MainPage();
        }

        public ViewResult ContactList()
        {
            ViewBag.Title = "Contact List";
            return View(db);
        }

        public ActionResult MainPage() // возврат главной страницы 
        {
            return RedirectToRoute("default", new { controller = "Contact", action = "ContactList" });
        }

        [HttpGet]
        public ViewResult EditContact(int id)
        {
            ViewBag.Title = "Edit Contact";
            return View(db.Contacts.Where(m => m.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult EditContact(Contact contact)
        {
            if (contact == null) return MainPage();
            if (!ModelState.IsValid) // валидация
            {
                return View(contact);
            }
            if (contact.Id == 0) // если объект контакта свежий, то добавляем его в базу данных
            {
                db.Contacts.Add(contact);
            }
            else // ищем контакт и заменяем его / редактируем
            {
                var other = db.Contacts.Where(m => m.Id == contact.Id).FirstOrDefault();
                contact.Copy(other);
            }
            db.SaveChanges();
            return MainPage();
        }

        public ViewResult AddContact()
        {
            return View("EditContact", new Contact());
        }

        [HttpGet]
        public ViewResult SearchContact()
        {
            ViewBag.Title = "Search Contact";
            return View();
        }

        [HttpPost]
        public ViewResult SearchContact(string searchFor, string searchIn)
        {
            var searchList = new List<Contact>();
            if (searchFor == null)
                return View("SearchContact", searchList);
            foreach (var contact in db.Contacts)
            {
                foreach(var field in contact.GetType().GetProperties())
                {
                    if (searchIn != field.Name && searchIn != null) continue; // поиск по определенному полю, null = everywhere
                    var value = field.GetValue(contact);
                    if (value != null && value.ToString() != null)
                        if (value.ToString().ToLower().Contains(searchFor.ToLower()))
                        {
                            searchList.Add(contact);
                            break;
                        }
                }
            }
            ViewData["searchFor"] = searchFor;
            return View("SearchContact", searchList);
        }
    }
}
