using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using MyApp.Models;
using System;
using System.Collections.Generic;

namespace MyApp.Namespace
{
    public class ListRoomsModel : PageModel
    {
        public List<Room> ListRooms { get; set; } = new List<Room>();
        public string SearchTerm { get; set; }
        //public int? CapacityTerm { get; set; }

        public void OnGet(string searchTerm, int capacityTerm)
        {
            SearchTerm = searchTerm;
            //CapacityTerm = capacityTerm;
            try
            {
                string connectionString = "Server=.\\SQLEXPRESS;Database=WebAppDataBase;Trusted_Connection=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Rooms";
                    if (!string.IsNullOrEmpty(SearchTerm))
                    {
                        sql += " WHERE RoomName LIKE @SearchTerm";
                    }

                    /*if (CapacityTerm.HasValue)
                    {
                        sql += " AND Capacity = @CapacityTerm";
                    }*/

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        if (!string.IsNullOrEmpty(SearchTerm))
                        {
                            command.Parameters.AddWithValue("@SearchTerm", "%" + SearchTerm + "%");
                        }

                        /* if (CapacityTerm.HasValue)
                        {
                            command.Parameters.AddWithValue("@CapacityTerm", CapacityTerm.Value);
                        } */

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Room room = new Room
                                {
                                    Id = reader.GetInt32(0),
                                    RoomName = reader.GetString(1),
                                    Capacity = reader.GetInt32(2)
                                };
                                ListRooms.Add(room);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }
}
