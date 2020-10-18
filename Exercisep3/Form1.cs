using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercisep3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Connection String
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //https://www.ittutorialswithexample.com/2015/01/simple-windows-form-login-application-in-csharp.html
            //membuat validasi untuk login dan pindah ke form lannya
            string cs = "Data Source = localhost; Initial Catalog = ProdiTI; " + "Integrated Security = True;";
            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                MessageBox.Show("Please check your Username and Password");
                return;
            }
            try
            {
                //Create SqlConnection
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand("select * from HRD.UserMhs where NamaUser=@NamaUser and PassUser=@PassUser", con);
                cmd.Parameters.AddWithValue("@NamaUser", txt_UserName.Text);
                cmd.Parameters.AddWithValue("@PassUser", txt_Password.Text);
                con.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;
                //If count is equal to 1, than show frmMain form
                if (count == 1)
                {
                   
                    this.Hide();
                    menu fm = new menu();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Please check your Username and Password");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
