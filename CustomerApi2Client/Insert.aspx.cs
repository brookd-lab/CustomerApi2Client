using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Net;
using Newtonsoft.Json;

namespace CustomerApi2Client
{
    public partial class Insert : System.Web.UI.Page
    {
        public string url = "https://localhost:44375/api/customers";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DisplayGrid();
        }

        public void InsertIntoTable(object sender, EventArgs e)
        {
            CustomerTable customer = new CustomerTable(txtName.Text, Convert.ToInt32(txtAge.Text));
            var client = new WebClient();
            client.Headers.Add("Content-Type:application/json");
            client.Headers.Add("Accept:application/json");
            string jsonString = JsonConvert.SerializeObject(customer);
            //test a post!!!! an insert
            var result = client.UploadString(url, jsonString); //POST: note don't specify POST!!
            Console.WriteLine(Environment.NewLine + result);

            var str = JsonConvert.DeserializeObject(result);

            var table = JsonConvert.DeserializeObject<dynamic>(result);
            Int32 id = Convert.ToInt32(table["CustomerID"]);

            this.DisplayGrid();

            //return id;
        }

        private void DisplayGrid()
        {
            var client = new WebClient();

            //string name = txtName.Text;
            //if (name != "")
            //    url = url + String.Format("/{0}", name);

            var result = client.DownloadString(url); //URI  
            Console.WriteLine(Environment.NewLine + result);

            CustomerTable[] customers;
            try
            {
                //more than one element in json
                //deserialize to an array
                customers = new JavaScriptSerializer().Deserialize<CustomerTable[]>(result);
                gvSimpleTable.DataSource = customers;

            }
            catch (Exception ex)
            {
                //one element in json
                //deserialize to an object
                //add to a list
                CustomerTable c1 = new JavaScriptSerializer().Deserialize<CustomerTable>(result);
                List<CustomerTable> list = new List<CustomerTable>();
                list.Add(c1);
                gvSimpleTable.DataSource = list;
            }

            gvSimpleTable.DataBind();
        }
    }
}