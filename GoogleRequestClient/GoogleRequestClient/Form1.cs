using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleRequestClient
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();

        public Form1()
        {
            client.BaseAddress = new Uri("https://localhost:44384/api/request/");
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            HttpResponseMessage response = await client.GetAsync(textBox1.Text);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Website> webs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Website>>(responseBody);
            ResultForm resForm = new ResultForm(webs);
            resForm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
