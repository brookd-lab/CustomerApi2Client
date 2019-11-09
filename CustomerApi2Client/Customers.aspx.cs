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
    public partial class Customers : System.Web.UI.Page
    {
        string url = ConfigurationManager.AppSettings["ServerUrl"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                Select();               
                //insert
                Customer customer = new Customer();
                customer.Name = "Tony";
                customer.Age = 53;
                int id = Insert(customer);

                customer.CustomerID = id;
                customer.Name = "Jake";
                customer.Age = 21;
                Update(id, customer);
                Delete(id);
                
            }
        }

        protected void Search(object sender, EventArgs e)
        {
            this.PopulateGridView();
        }

        private void Select()
        {
            var client = new WebClient();

            string name = txtName.Text;
            if (name != "")
                url = url + String.Format("/{0}", name);

            var result = client.DownloadString(url); //URI  
            Console.WriteLine(Environment.NewLine + result);

            Customer[] customers;
            try
            {
                //more than one element in json
                //deserialize to an array
                customers = new JavaScriptSerializer().Deserialize<Customer[]>(result);
                gvSimpleTable.DataSource = customers;

            }
            catch (Exception ex)
            {
                //one element in json
                //deserialize to an object
                //add to a list
                Customer c1 = new JavaScriptSerializer().Deserialize<Customer>(result);
                List<Customer> list = new List<Customer>();
                list.Add(c1);
                gvSimpleTable.DataSource = list;
            }

            gvSimpleTable.DataBind();
        }

        private int Insert(Customer customer)
        {
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
            
            this.Select();

            return id;            
        }

        private void Update(int key, Customer customer)
        {
            var client = new WebClient();
           
            client.Headers.Add("Content-Type:application/json");
            client.Headers.Add("Accept:application/json");
            string jsonString = JsonConvert.SerializeObject(customer);

            var result = client.UploadString(url + "/" + key, "PUT", jsonString);

            Console.WriteLine(Environment.NewLine + result);

            this.Select();
        }

        private void Delete(int key)
        {
            var client = new WebClient();

            client.Headers.Add("Content-Type:application/json");
            client.Headers.Add("Accept:application/json");

            var result = client.UploadString(url + "/" + key, "DELETE", "");

            Console.WriteLine(Environment.NewLine + result);

            this.Select();
        }

        private void PopulateGridView()
        {
            var client = new WebClient();

            string name = txtName.Text;
            if (name != "")
                url = url + String.Format("/{0}", name);

            var result = client.DownloadString(url); //URI  
            Console.WriteLine(Environment.NewLine + result);

            Customer[] customers;
            try
            {
                //more than one element in json
                //deserialize to an array
                customers = new JavaScriptSerializer().Deserialize<Customer[]>(result);
                gvSimpleTable.DataSource = customers;

            }
            catch (Exception ex)
            {
                //one element in json
                //deserialize to an object
                //add to a list
                Customer c1 = new JavaScriptSerializer().Deserialize<Customer>(result);
                List<Customer> list = new List<Customer>();
                list.Add(c1);
                gvSimpleTable.DataSource = list;
            }

            gvSimpleTable.DataBind();
        }



        public class Customer
        {
            public int CustomerID { get; set; }
            public string Name { get; set; }
            public int? Age { get; set; }
        }

    }
}