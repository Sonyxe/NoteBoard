using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace NoteBoard.Pages.Notes
{
    public class IndexModel : PageModel
    {
        public List<NoteInfo> listNotes = new List<NoteInfo>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Server=localhost; Initial Catalog=Notes;Trusted_Connection=true;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM Notes";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                NoteInfo noteInfo = new NoteInfo();
                                noteInfo.id = "" + reader.GetInt32(0);
                                noteInfo.category = reader.GetString(1);
                                noteInfo.title = reader.GetString(2);
                                noteInfo.note = reader.GetString(3);

                                listNotes.Add(noteInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex )
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class NoteInfo
    {
        public String id;
        public String category;
        public String title;
        public String note;
    }
}
