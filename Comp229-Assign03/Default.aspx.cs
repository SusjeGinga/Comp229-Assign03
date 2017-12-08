using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Comp229_Assign03
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String query = "SELECT * FROM Students";

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            //if (reader.Read())
            {
                StudentsGrid.DataSource = reader;
                StudentsGrid.DataBind();
                reader.Close();
            }
            conn.Close();
        }

        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            String query = "INSERT INTO Students(LastName, FirstMidName, EnrollmentDate)" +
                "VALUES(@lastNameTxt, @firstMidNameTxt, @enrollmentDateTxt)";

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.Add("@lastNameTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@lastNameTxt"].Value = lastNameTxt.Text;

            comm.Parameters.Add("@firstMidNameTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@firstMidNameTxt"].Value = firstMidNameTxt.Text;

            comm.Parameters.Add("@enrollmentDateTxt", System.Data.SqlDbType.Date);
            comm.Parameters["@enrollmentDateTxt"].Value = Convert.ToDateTime(enrollmentDateTxt.Text);

            conn.Open();
            comm.ExecuteNonQuery();

            conn.Close();
            Response.Redirect(Request.Path);
        }
    }
}