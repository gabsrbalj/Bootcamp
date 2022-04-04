using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Implementating.Model;
using System.Net;
using Implementating.Common;
using Implementating.Repository.Common;

namespace Implementating.Repository
{
    public class UnreturnedBooksRepository : IUnreturnedBooksRepository
    {
        static string constr = @"Data Source=DESKTOP-R80D4UH\SQLEXPRESS;Initial Catalog=SubscriptionManagement;Integrated Security=True"; // Connection String

        static List<UnreturnedBooks> bookinfo = new List<UnreturnedBooks>();

        public async Task<List<UnreturnedBooks>> GetAllBookInfoAsync(int id)
        {
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM subdetails WHERE BookID = " + id, connection);
                await connection.OpenAsync();

                SqlDataReader reader = await cmd.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        UnreturnedBooks unbooks = new UnreturnedBooks();
                        unbooks.BookID = reader.GetInt32(0);
                        unbooks.AuthorsName = reader.GetString(1);
                        unbooks.BookName = reader.GetString(2);

                        bookinfo.Add(unbooks);

                    }
                   
                }
                return bookinfo;
                connection.Close();
            }
        }

        public async Task<List<UnreturnedBooks>> InsertNewUserAsync(UnreturnedBooks unreturnedbooks)
        {
            UnreturnedBooks unbooks = new UnreturnedBooks();
            SqlConnection connection = new SqlConnection(constr);
            using (connection)
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO subdetail (BookID, AuthorsName, BookName) VALUES ('{unbooks.BookID}','{unbooks.AuthorsName}','{unbooks.BookName}')");
                connection.Open();
                cmd.Connection = connection;
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();
            }
            return bookinfo;
        }

      

        public async Task<List<UnreturnedBooks>> DeleteBookAsync(int id)
        {
            SqlConnection connection = new SqlConnection(constr);
            
            using (connection)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM subdetail WHERE BookID =" + id);
                await connection.OpenAsync();
                cmd.Connection = connection;
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.DeleteCommand = cmd;
                await adapter.DeleteCommand.ExecuteNonQueryAsync();

            }
            return bookinfo;
        }

        
    }
}
