using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11CrudWebForm
{
    public partial class AllRecordsGridview : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBEmployee"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                int row = Convert.ToInt32(e.CommandArgument);
                int id = int.Parse(GridView1.DataKeys[row].Value.ToString());

                Response.Redirect("~/EditEmployee.aspx?Id=" + id);
            }


        }

        public void LoadData()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getAllData", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter rdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                rdr.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();

                Session["empData"] = dt;


            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteById ", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();


            }
            LoadData();
        }
    }
}