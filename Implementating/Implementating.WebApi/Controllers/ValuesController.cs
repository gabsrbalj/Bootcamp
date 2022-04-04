using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Implementating.Model;

namespace Implementating.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        static List<LibrarySubscription> subscriptions = new List<LibrarySubscription>();

        public class LibrarySubscriptionRest
        {
            public int SubscriptionID { get; set; }

            public string FirstPersonsName { get; set; }

            public string LastPersonsName { get; set; }

        }

        static string constr = @"Data Source=DESKTOP-R80D4UH\SQLEXPRESS;Initial Catalog=SubscriptionManagement;Integrated Security=True"; // Connection String

        // GET ALL INFORMATION

        [HttpGet]
        [Route("api/values/subinfo")]

        public async Task<HttpResponseMessage> GetAllSubInfo()
        {

            SqlConnection connection = new SqlConnection(constr);

            using (connection)
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM subscriptions");
                await connection.OpenAsync();
                cmd.Connection = connection;
                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while(await reader.ReadAsync())
                    {
                        LibrarySubscription subs = new LibrarySubscription();

                        subs.SubscriptionID = reader.GetInt32(0);
                        subs.FirstPersonsName = reader.GetString(1);
                        subs.LastPersonsName = reader.GetString(2);

                        subscriptions.Add(subs);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, subscriptions);
                    connection.Close();

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Fetching data not right.");
                    connection.Close();
                }


            }
        }

        // GET INFORMATION BY ID

        [HttpGet]
        [Route("api/values/subinfo/{id}")]

        public async Task<HttpResponseMessage> GetSubInfoById(int id)
        {

            SqlConnection connection = new SqlConnection(constr);

            using (connection)
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM subscriptions WHERE SubscriptionID = "+ id);
                await connection.OpenAsync();
                cmd.Connection = connection;
                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        LibrarySubscription subs = new LibrarySubscription();

                        subs.SubscriptionID = reader.GetInt32(0);
                        subs.FirstPersonsName = reader.GetString(1);
                        subs.LastPersonsName = reader.GetString(2);

                        subscriptions.Add(subs);
                    }

                    return Request.CreateResponse(HttpStatusCode.OK, subscriptions);
                    connection.Close();

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, $"Fetching data not right.");
                    connection.Close();
                }


            }
        }

        // INSERTING NEW SUB
        [HttpPost]
        [Route("api/values/insertsub")]

        public async Task<HttpResponseMessage> InsertNewUser()
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand insertcmd = new SqlCommand("INSERT INTO subscriptions " + "(SubscriptionID, FirstPersonsName, LastPersonsName) " + "VALUES(@SubscriptionID, @FirstPersonsName, @LastPersonsName)", connection);
                await connection.OpenAsync();
                

                insertcmd.Parameters.AddWithValue("@SubscriptionID", 2);
                insertcmd.Parameters.AddWithValue("@FirstPersonsName", "Marina");
                insertcmd.Parameters.AddWithValue("@LastPersonsName", "Crnac");

                return Request.CreateResponse(HttpStatusCode.OK, $"Sucessfully added!");

            }
        }

        // UPDATING USERS LAST NAME
        [HttpPut]
        [Route("api/values/updatesub/{id}")]

        public async Task<HttpResponseMessage> UpdateUser(LibrarySubscription librarysubscription,int id)
        {

            SqlConnection connection = new SqlConnection(constr);

            using (connection)
            {
                SqlCommand updatesub = new SqlCommand($"UPDATE subscriptions SET LastPersonsName = '{librarysubscription.LastPersonsName} WHERE SubscriptionID = " + id);

                await connection.OpenAsync();
                updatesub.Connection = connection;
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.UpdateCommand = updatesub;
                await adapter.UpdateCommand.ExecuteNonQueryAsync();

                return Request.CreateResponse(HttpStatusCode.OK, $"User updated");
            }
        }

        // DELETE USER BY ID
        

        [HttpDelete]
        [Route("api/values/delsub/{id}")]

        public async Task<HttpResponseMessage> DeleteUser(int id)
        {
            SqlConnection connection = new SqlConnection(constr);

            using (connection)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM subscriptions WHERE SubscriptionID ="+id);
                await connection.OpenAsync();
                cmd.Connection = connection;
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.DeleteCommand = cmd;
                await adapter.DeleteCommand.ExecuteNonQueryAsync();

                return Request.CreateResponse(HttpStatusCode.OK, $"User deleted.");
                
            }
        }


    }


}

