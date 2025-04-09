using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SignalDashboard.Models;

namespace SignalDashboard.Pages
{
    public class IndexModel : PageModel
    {
        public List<SignalLog> Signals { get; set; } = new();

        public void OnGet()
        {
            string connStr = "Server=10.131.15.18;Database=EE;User Id=eeuser;Password=Amkor123!;Encrypt=False;TrustServerCertificate=True;";            
            using var conn = new SqlConnection(connStr);
            conn.Open();

            string sql = "SELECT Type, LineCode, Asset, SignalRed, SignalYellow, SignalGreen, SignalSpare, Remarks1, Remarks2 FROM K5EE_SignalLog ORDER BY Asset";
            
            using var cmd = new SqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                var row = new SignalLog
                {
                    Type = reader["Type"].ToString() ?? "",
                    LineCode = reader["LineCode"].ToString() ?? "",
                    Asset = reader["Asset"].ToString() ?? "",
                    SignalRed = Convert.ToInt32(reader["SignalRed"]),
                    SignalYellow = Convert.ToInt32(reader["SignalYellow"]),
                    SignalGreen = Convert.ToInt32(reader["SignalGreen"]),
                    SignalSpare = Convert.ToInt32(reader["SignalSpare"]),
                    Remarks1 = reader["Remarks1"].ToString() ?? "",
                    Remarks2 = reader["Remarks2"].ToString() ?? ""
                };

                Signals.Add(row);                
            }
        }
    }
}