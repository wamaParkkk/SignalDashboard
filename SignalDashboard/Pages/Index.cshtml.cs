using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using SignalDashboard.Models;

namespace SignalDashboard.Pages
{
    public class IndexModel : PageModel
    {
        public List<SignalLog> SignalList { get; set; }
        
        public void OnGet()
        {
            string _connectionString = "Server=10.131.15.18;Database=EE;User Id=eeuser;Password=Amkor123!;Encrypt=False;TrustServerCertificate=True;";
            using var conn = new SqlConnection(_connectionString);
            conn.Open();
            string sql = "SELECT * FROM K5EE_SignalLog ORDER BY UpdatedAt DESC";
            SignalList = conn.Query<SignalLog>(sql).ToList();
        }
    }
}