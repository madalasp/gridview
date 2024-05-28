using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Gridview
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private void Getdata()
        {
            //declare name space
            //create connection
            SqlConnection con = new SqlConnection("data source=CYBERSP;database=employee;Integrated security=yes");
            SqlCommand cmd = new SqlCommand("select * from Table_1", con);
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Getdata();
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow rows = GridView1.Rows[e.RowIndex];
            Label lbl = (Label)rows.FindControl("Label1");
            SqlConnection con = new SqlConnection("data source=CYBERSP;database=employee;Integrated security=yes;");
            con.Open();
            var query = "delete from Table_1 where Id='" + lbl.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            Getdata();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex=e.NewEditIndex;
            Getdata();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row= GridView1.Rows[e.RowIndex];
            TextBox t1=(TextBox)row.FindControl("TextBox1");
            TextBox t2 = (TextBox)row.FindControl("TextBox2");
            TextBox t3 = (TextBox)row.FindControl("TextBox3");
            TextBox t4 = (TextBox)row.FindControl("TextBox4");
            TextBox t5 = (TextBox)row.FindControl("textBox5");
            TextBox t6 = (TextBox)row.FindControl("textbox6");
            SqlConnection con = new SqlConnection("data source=CYBERSP;database=employee;Integrated security=yes");
            con.Open();
            var query="update Table_1 set Name='"+t2.Text+"',Adress='"+t3.Text+ "',Email='"+t4.Text+ "',Phno='"+t5.Text+ "',Course='"+t6.Text+ "' where Id='"+t1.Text + "'";
            SqlCommand cmd= new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            Getdata() ;
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Getdata();
        }
    }
}