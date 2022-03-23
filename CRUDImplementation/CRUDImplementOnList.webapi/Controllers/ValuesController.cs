using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRUDImplementOnList.webapi.Controllers
{
    public class ValuesController : ApiController
    {


        static List<LibrarySubscription> subscriptions = new List<LibrarySubscription>();
       

        
        // POST api/values
        [HttpPost]
        [Route("api/values/newsubs")]
        public HttpResponseMessage SubscriptionsEntry([FromBody] LibrarySubscription subscription)
        {
            
            subscriptions.Add(subscription);
            return Request.CreateResponse(HttpStatusCode.OK,$"New subscription information is added");
            
        }

        // PUT api/values/5
        [HttpPut]
        
        public HttpResponseMessage UpdatingSubscriptions(int id, [FromBody] LibrarySubscription librarysubscription)
        {
            LibrarySubscription updatesub = subscriptions.Find(subscriptions => subscriptions.SubscriptionID == id);
          
            if(updatesub == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                updatesub.FirstPersonsName = librarysubscription.FirstPersonsName;
                updatesub.LastPersonsName = librarysubscription.LastPersonsName;
                return Request.CreateResponse(HttpStatusCode.Found);
            }
            

           
        }

        // DELETE api/values/5
        [HttpDelete]
        
        public HttpResponseMessage RemovingSubscription(int id,[FromBody] LibrarySubscription librarysubscription)
        {
            LibrarySubscription deletesub = subscriptions.Find(subscriptions => subscriptions.SubscriptionID == id);
            if (deletesub == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound,$"Cannot find ID");
            }
            else
            {
                subscriptions.Remove(deletesub);
                return Request.CreateResponse(HttpStatusCode.Found,$"Subscribction is deleted. ");
            }
            
        }

        public class LibrarySubscription //definiranje atributa pretplate
        {
            public int SubscriptionID { get; set; }

            public string FirstPersonsName { get; set; }

            public string LastPersonsName { get; set; }
        }

         


        [HttpGet]

        [Route("api/values/getsubs")]
        public List<LibrarySubscription> AddingSubs()
        {
            LibrarySubscription librarysubscription1 = new LibrarySubscription(); // objekt liste
            
            librarysubscription1.SubscriptionID = 12345;
            librarysubscription1.FirstPersonsName = "John";
            librarysubscription1.LastPersonsName = "Doe";
            subscriptions.Add(librarysubscription1);

            LibrarySubscription librarysubscription2 = new LibrarySubscription();
           
            librarysubscription2.SubscriptionID = 54321;
            librarysubscription2.FirstPersonsName = "Edgar Allan";
            librarysubscription2.LastPersonsName = "Poe";

            subscriptions.Add(librarysubscription2);

            return subscriptions;
        }

    }
}
