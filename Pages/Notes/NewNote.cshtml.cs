using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;

namespace NoteBoard.Pages.Notes
{
    public class NewNoteModel : PageModel
    {
        public NoteInfo noteInfo = new NoteInfo();
        public String errorMessage = "";
        public String successMessage = "";
        public void OnGet()
        {

        }
        public void OnPost()
        {
            noteInfo.category = Request.Form["category"];
            noteInfo.title = Request.Form["title"];
            noteInfo.note = Request.Form["notes"];

           /* if (noteInfo.category.Length == 0 || noteInfo.title.Length == 0 ||
                noteInfo.note.Length == 0)
            {
                errorMessage = "All the fields are required";
                return;
            }*/

            try
            {
                String connectionString = "Server=localhost; Initial Catalog=Notes;Trusted_Connection=true;";
                using(SqlConnection connection=new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO Notes" +
                                  "(category, title, note) VALUES" +
                                  "(@category, @title, @note);";

                    using(SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@category", noteInfo.category);
                        command.Parameters.AddWithValue("@title", noteInfo.title);
                        command.Parameters.AddWithValue("@note", noteInfo.note);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage=ex.Message;
                return;
            }

            noteInfo.category = ""; noteInfo.title = ""; noteInfo.note = "";
            successMessage = "New Note Added Correctly";

            Response.Redirect("/Notes/Index");
        }
    }

}