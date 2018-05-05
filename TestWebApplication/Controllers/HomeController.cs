using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestDataAccess;
using System.Text;

namespace TestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        Repository repository = new Repository();

        public ActionResult Index()
        {
            var model = repository.GetAllSentences();
            return View(model);

        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string searchString)
        {

            if (file != null && file.ContentLength > 0)
            {
                using (StreamReader reader = new StreamReader(file.InputStream, Encoding.Default))
                {
                    string text = reader.ReadToEnd();
                    string[] sentences = text.Split('.');
                    int count = 0;
                    foreach (var sentence in sentences)
                    {
                        string[] words = sentence.Split(' ',',','\n');

                        foreach (var word in words)
                        {
                            if (word.ToLower() == searchString.ToLower())
                            {
                                count++;
                            }
                        }
                        if (count > 0)
                        {
                            string reverse = Reverse(sentence);

                            repository.AddSentence(reverse, count);
                        }
                        count = 0;
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }


    }
}