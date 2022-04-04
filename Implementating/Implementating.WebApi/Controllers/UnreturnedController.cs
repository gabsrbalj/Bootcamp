using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Implementating.Model;
using Implementating.Service;
using Implementating.Service.Common;

namespace Implementating.WebApi.Controllers
{
    public class UnreturnedController : ApiController
    {

        protected IUnreturnedBooksService Service { get; set; }

        public UnreturnedController(IUnreturnedBooksService service)
        {
            Service = service;
        }
        public class UnreturnedBooksRest
        {
            public int BookID { get; set; }

            public string AuthorsName { get; set; }

            public string BookName { get; set; }

        }

        //public class UnreturnedBooks
        //{
        //    public int BookID { get; set; }

        //    public string AuthorsName { get; set; }

        //    public string BookName { get; set; }
        //}

        static string constr = @"Data Source=DESKTOP-R80D4UH\SQLEXPRESS;Initial Catalog=SubscriptionManagement;Integrated Security=True"; // Connection String

        static List<UnreturnedBooks> unbooks = new List<UnreturnedBooks>();

        

        [HttpGet]
        [Route("api/values/bookinfo")]

        public async Task<HttpResponseMessage> GetAllBookInfoAsync()
        {

            UnreturnedBooksService service = new UnreturnedBooksService();

            List<UnreturnedBooks> unbooks = new List<UnreturnedBooks>();

             var getting = await service.GetAllBookInfoAsync();

            if (unbooks != null)
            {
                List<UnreturnedBooksRest> mappedbooks = new List<UnreturnedBooksRest>();

                foreach (UnreturnedBooks unreturnedbooks in unbooks)
                {
                    UnreturnedBooksRest unbooksrest = new UnreturnedBooksRest()
                    {
                        BookID = unreturnedbooks.BookID,
                        AuthorsName = unreturnedbooks.AuthorsName,
                        BookName = unreturnedbooks.BookName,
                       
                    };

                    mappedbooks.Add(unbooksrest);
                }
                return Request.CreateResponse(HttpStatusCode.OK, mappedbooks);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Books not found");
            }

        }

      

        [HttpPut]
        [Route("api/values/updatebook/{id}")]

        public async Task<HttpResponseMessage> UpdateBook(UnreturnedBooks unreturnedbooks, int id)
        {

            SqlConnection connection = new SqlConnection(constr);

            using (connection)
            {
                SqlCommand updatesub = new SqlCommand($"UPDATE subdetail SET BookName = '{unreturnedbooks.BookName} WHERE BookID = " + id);

                await connection.OpenAsync();
                updatesub.Connection = connection;
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.UpdateCommand = updatesub;
                await adapter.UpdateCommand.ExecuteNonQueryAsync();

            }
            return Request.CreateResponse(HttpStatusCode.OK, $"Book updated");
        }

        //[HttpPut]
        //[Route("api/UpdateDev")]
        //public async Task<HttpResponseMessage> UpdateBookInfoAsync(int BookdID)
        //{
        //    if (await Service.UpdateNewUserAsync() != null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, $"Developer updated!");
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, $"Not found");
        //    }
        //}

        [HttpDelete]
        [Route("api/values/delsub/{id}")]

        public async Task<HttpResponseMessage> DeleteBookAsync(int id,UnreturnedBooks unreturnedbooks)
        {
            UnreturnedBooksService service = new UnreturnedBooksService();

            if( service.DeleteBookAsync(id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, $"Book not found");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Found, $"Book is deleted");
            }
        }

  

    }

}