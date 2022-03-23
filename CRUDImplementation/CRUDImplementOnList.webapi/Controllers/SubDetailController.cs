using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDImplementOnList.webapi.Controllers
{
    public class SubDetailController : ApiController
    {
        


        public class UnreturnedBooks
        {
            public string AuthorsName { get; set; }

            public string BookName { get; set; }

            public int BookID { get; set; }
        }

        static List<UnreturnedBooks> bookinfo = new List<UnreturnedBooks>
        {
            new UnreturnedBooks {AuthorsName = "Anne Frank", BookName = "Diary", BookID = 1},
            new UnreturnedBooks {AuthorsName = "Fjodor Dostojevski", BookName = "Idiot", BookID= 2},
            new UnreturnedBooks {AuthorsName = "Mato Lovrak", BookName = "Vlak u snijegu", BookID= 3},
        };

        [HttpGet]

        [Route("api/values/getallinfo")]
        public IEnumerable<UnreturnedBooks> GetUserInfoForDetails()
        {
            return bookinfo;
        }

        [HttpGet]
        [Route("api/values/get/{id}")]
        public HttpResponseMessage GetBookInfoByID(int id, UnreturnedBooks unbooks)
        {
            UnreturnedBooks bookidfind = bookinfo.Find(bookinfo => bookinfo.BookID == id);
            if(bookidfind == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else{
                return Request.CreateResponse(HttpStatusCode.OK, $"Book Author: {unbooks.AuthorsName} Book Name : {unbooks.BookName} ");
            }
        }

        [HttpPost]
        [Route("api/values/updatebook")]
        public HttpResponseMessage AddNewBook(UnreturnedBooks unbooks)
        {
            
            bookinfo.Add(unbooks);
            return Request.CreateResponse(HttpStatusCode.OK, $"New book is added.");
        }

        [HttpDelete]
        [Route("api/values/remove/{id}")]
        public HttpResponseMessage  RemoveUnreturnedBooks(int id,UnreturnedBooks unbooks)
        {
            UnreturnedBooks deletebook = bookinfo.Find(bookinfo => bookinfo.BookID == id);
            if(deletebook == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else {
                bookinfo.Remove(deletebook);
                return Request.CreateResponse(HttpStatusCode.Found, $"Book is deleted.");
            }
          
        }

       
    }
}
