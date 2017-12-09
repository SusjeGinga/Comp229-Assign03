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
    public partial class UpdatePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) BindData();

        }

        private void BindData()
        {
            int studentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            String query = "SELECT * FROM Students WHERE StudentID = @studentID";

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.Add("@studentID", System.Data.SqlDbType.Int);
            comm.Parameters["@studentID"].Value = studentID;

            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                studentIDTxt.Text = Convert.ToString(reader["StudentID"]);
                lastNameTxt.Text = (String)reader["LastName"];
                firstMidNameTxt.Text = (String)reader["FirstMidName"];
                enrollmentDateTxt.Text = ((DateTime)reader["EnrollmentDate"]).ToString("yyyy-MM-dd");
            }
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            
            int studentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            String query = "UPDATE Students SET LastName = @lastNameTxt, FirstMidName = @firstMidNameTxt " +
                " WHERE StudentID = @studentID";

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.Add("@studentID", System.Data.SqlDbType.Int);
            comm.Parameters["@studentID"].Value = studentID;

            comm.Parameters.Add("@lastNameTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@lastNameTxt"].Value = lastNameTxt.Text;

            comm.Parameters.Add("@firstMidNameTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@firstMidNameTxt"].Value = firstMidNameTxt.Text;

            comm.Parameters.Add("@enrollmentDateTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@enrollmentDateTxt"].Value = enrollmentDateTxt.Text;
            try
            {
                conn.Open(); //comm.
                comm.ExecuteNonQuery();
            } 
            finally
            {

                conn.Close();
            }
        }
    }
}