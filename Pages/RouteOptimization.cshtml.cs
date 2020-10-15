using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;

namespace IOTA.Pages
{
    public class RouteOptimizationModel : PageModel
    {

        public string a = "";
        [BindProperty]
        public DataTable IoTData { get; set; }

        [BindProperty]
        public string council { get; set; }

        [BindProperty]
        public double lat { get; set; }

        [BindProperty]
        public double lng { get; set; }

        [BindProperty]
        public string embed { get; set; }



        public IActionResult OnPost()
        {
            if (council != null)
            {
                getRouteData(council);

            }
            return Page();
        }

        public void getRouteData(String owner)
        {
            SqlConnection sqlc = new SqlConnection("Server=tcp:smartcitysqlserverg.database.windows.net,1433;Initial Catalog=SmartCityDataBaseG;Persist Security Info=False;User ID=teamg;Password=Cti30862020;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(@"select lat,lng

                                                    from [BinData] t

                                                    inner join (

                                                    select tag_number, max(data_date) as MaxDate

                                                    from [BinData]

                                                    group by tag_number, owner

                                                    ) tm on t.tag_number = tm.tag_number and t.data_date = tm.MaxDate and ((data_val /1250)*100) > 70 and lat <-30 and lng > 140 and t.owner = '" + owner + "'", sqlc);
            DataTable dataTable = new DataTable();
            string inPos = "";
            string fiPos = "";
            string waypoints = "";
            adapter.Fill(dataTable);


            if (owner == "banyule")
            {
                inPos = "-37.704335,145.105047";
                fiPos = "-37.704335,145.105047";
            }
            else if (owner == "mitchell")
            {
                inPos = "-37.202905, 145.048919";
                fiPos = "-37.202905, 145.048919";
            }
            else if (owner == "nillumbik")
            {
                inPos = "-37.688330, 145.112644";
                fiPos = "-37.688330, 145.112644";
            }
            else if (owner == "whittlesea")
            {
                inPos = "-37.645266, 145.068126";
                fiPos = "-37.645266, 145.068126";
            }




            foreach (DataRow row in dataTable.Rows)
            {
                waypoints = waypoints + row.ItemArray[0] + "," + row.ItemArray[1] + '|';
            }
            int len = waypoints.Length;

            waypoints = waypoints.Substring(0, len - 1);



            IoTData = dataTable;


            embed = "https://www.google.com/maps/embed/v1/directions?key=AIzaSyAGUsNyQYyJ2YpC_1Fl8V9tnQrmGeozxWQ&zoom=11"
                           + "&origin= " + inPos + "&destination= " + fiPos + "&waypoints= " + waypoints;

            ViewData["a"] = embed;
        }

    }
}
