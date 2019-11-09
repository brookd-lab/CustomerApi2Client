using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Net;
using Newtonsoft.Json;
using System.Configuration;

namespace CustomerApi2Client
{
    public partial class Update : System.Web.UI.Page
    {
        string url = ConfigurationManager.AppSettings["ServerUrl"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.DisplayGrid(sender, e);
            }
        }

        public void Search(object sender, EventArgs e)
        {
            this.DisplayGrid(sender, e);
        }
        
        public void DisplayGrid(object sender, EventArgs e)
        {
            var client = new WebClient();

            string name = txtSearch.Text;
            if (name != "")
                url = url + String.Format("/{0}", name);
                                               
            var result = client.DownloadString(url); //URI  
            Console.WriteLine(Environment.NewLine + result);

            CustomerTable[] customers;
            try
            {
                //more than one element in json
                //deserialize to an array
                customers = new JavaScriptSerializer().Deserialize<CustomerTable[]>(result);
                if (customers.Count() == 1)
                {
                    txtCustomerID.Text = customers[0].CustomerID.ToString();
                    txtName.Text = customers[0].Name;
                    txtAge.Text = customers[0].Age.ToString();
                }
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
                txtCustomerID.Text = c1.CustomerID.ToString();
                txtName.Text = c1.Name;
                txtAge.Text = c1.Age.ToString();
            }

            gvSimpleTable.DataBind();
        }

        protected void EditTable(object sender, EventArgs e)
        {
            this.DisplayGrid(sender,e);
        }

        protected void UpdateTable(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(txtCustomerID.Text);
            CustomerTable customer = new CustomerTable(txtName.Text, Convert.ToInt32(txtAge.Text));
            customer.CustomerID = key;

            var client = new WebClient();

            client.Headers.Add("Content-Type:application/json");
            client.Headers.Add("Accept:application/json");
            string jsonString = JsonConvert.SerializeObject(customer);

            var result = client.UploadString(url + "/" + key, "PUT", jsonString);

            Console.WriteLine(Environment.NewLine + result);

            this.DisplayGrid(sender, e);
        }
    }
}