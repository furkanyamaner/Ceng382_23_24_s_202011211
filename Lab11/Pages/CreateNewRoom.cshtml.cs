using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;
using Microsoft.AspNetCore.Authorization;
using MyApp.Models;

namespace MyApp.Namespace
{
    [Authorize] 
    public class CreateNewRoomModel : PageModel
    {
        public Room rooms = new Room();
        public string errorMessage = "";

        public void OnGet()
        {
        }

        public void OnPost()
        {
            if (!string.IsNullOrEmpty(Request.Form["RoomName"]))
            {
                rooms.RoomName = Request.Form["RoomName"];
            }

            if (!string.IsNullOrEmpty(Request.Form["Capacity"]) && int.TryParse(Request.Form["Capacity"], out int capacity))
            {
                rooms.Capacity = capacity;
            }

            try
            {
                string connectionString = "Server=.\\SQLEXPRESS;Database=WebAppDataBase;Trusted_Connection=True;TrustServerCertificate=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Rooms (RoomName, Capacity) VALUES (@RoomName, @Capacity);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@RoomName", rooms.RoomName);
                        command.Parameters.AddWithValue("@Capacity", rooms.Capacity);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }
            Response.Redirect("/ListRooms");
        }
    }
}
