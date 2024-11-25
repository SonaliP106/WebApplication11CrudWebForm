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
    public partial class EditEmployee : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["DBEmployee"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int Id = Convert.ToInt32(Request.QueryString["Id"]);

                LoadSingleData(Id);
            }
        }

        protected void updateButton1_Click1(object sender, EventArgs e)
        {
            int empId = Convert.ToInt32(IdLabel0.Text);

            string code = empcodeTextBox1.Text;

            if (DuplicateCodeExist(empId, code))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('code already exist');", true);
                return;
            }

            UpdateEmployee(empId);
        }



        public void LoadSingleData(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("getDataById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    IdLabel0.Text = rdr["Id"].ToString();
                    empcodeTextBox1.Text = rdr["employeeCode"].ToString();
                    empNameTextBox2.Text = rdr["name"].ToString();
                    DropDownList1.SelectedValue = rdr["gender"].ToString();
                    dojTextBox4.Text = Convert.ToDateTime(rdr["doj"]).ToString();
                    empAddressTextBox5.Text = rdr["address"].ToString();
                }




            }

        }

        private void UpdateEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@employeeCode", empcodeTextBox1.Text);
                cmd.Parameters.AddWithValue("@name", empNameTextBox2.Text);
                cmd.Parameters.AddWithValue("@gender", DropDownList1.SelectedValue);
                cmd.Parameters.AddWithValue("@doj", Convert.ToDateTime(dojTextBox4.Text));
                cmd.Parameters.AddWithValue("@address", empAddressTextBox5.Text);


                cmd.ExecuteNonQuery();
                Response.Redirect("~/AllRecordsGridview.aspx");

            }
        }

        public bool DuplicateCodeExist(int empId, string code)
        {
            DataTable dt = (DataTable)Session["empData"];

            foreach (DataRow row in dt.Rows)
            {
                if (row["employeeCode"].ToString() == code && Convert.ToInt32(row["Id"]) != empId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}