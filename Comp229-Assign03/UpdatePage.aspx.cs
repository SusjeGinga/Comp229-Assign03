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
            String query = "SELECT * FROM Students WHERE StudentID = 300000";

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            if (reader.Read())
            {
                // studentIDTxt.Text = Convert.ToInt32(reader["StudentID"]);
                lastNameTxt.Text = (String)reader["LastName"];
                firstMidNameTxt.Text = (String)reader["FirstMidName"];
                enrollmentDateTxt.Text = Convert.ToString(reader["EnrollmentDate"]);
            }


        }


        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            String query = "UPDATE Students SET LastName = @lastNameTxt, FirstMidName = @firstMidNameTxt" +
                " WHERE StudentID = 300000";

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.Add("@lastNameTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@lastNameTxt"].Value = lastNameTxt.Text;

            comm.Parameters.Add("@firstMidNameTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@firstMidNameTxt"].Value = firstMidNameTxt.Text;

            comm.Parameters.Add("@enrollmentDateTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@enrollmentDateTxt"].Value = enrollmentDateTxt.Text;

            conn.Open();
            comm.ExecuteNonQuery();

            conn.Close();

        }
    }
}