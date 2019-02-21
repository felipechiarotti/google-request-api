using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleRequestClient
{
    public partial class ResultForm : Form
    {
        private List<Website> _webs;

        public ResultForm(List<Website> webs)
        {
            InitializeComponent();
            this._webs = webs;

        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            Label label = null;
            LinkLabel linkLabel = null;
            int y = 10;
            foreach (Website web in _webs)
            {
                label = new Label();
                label.Text = web.Nome;
                label.ForeColor = Color.Gainsboro;
                label.AutoSize = true;
                label.Font = new Font(label.Font.Name, label.Font.Size + 2.0F, label.Font.Style, label.Font.Unit);
                label.Location = new Point(20, y);
                this.Controls.Add(label);

                linkLabel = new LinkLabel();
                linkLabel.Text = web.Url;
                linkLabel.LinkColor = Color.Ivory;
                linkLabel.Location = new Point(20, y + 20);
                linkLabel.AutoSize = true;
                linkLabel.Tag = web.Url;
                linkLabel.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkedLabelClicked);
                this.Controls.Add(linkLabel);
                y = y + 60;
            }
        }



        private void LinkedLabelClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string filepath = ((LinkLabel)sender).Tag.ToString();
            System.Diagnostics.Process.Start(filepath);
        }
    }
}
