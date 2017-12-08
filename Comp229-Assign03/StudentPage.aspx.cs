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
    public partial class StudentPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int studentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            String query = "SELECT * FROM Students WHERE StudentID = @studentID";

            //studentIDTxt.Text = studentID;
            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.Add("@studentID", System.Data.SqlDbType.Int);
            comm.Parameters["@studentID"].Value = studentID;
            conn.Open();

            SqlDataReader reader = comm.ExecuteReader();
            // if (reader.Read())
            {
                studentDetails.DataSource = reader;
                studentDetails.DataBind();
                
            }
            reader.Close();


            query = "SELECT Courses.Title, Courses.Credits, Enrollments.Grade FROM Courses " +
               "INNER JOIN Enrollments ON Enrollments.CourseID = Courses.CourseID WHERE Enrollments.StudentID = @studentID";


            comm = new SqlCommand(query, conn);
            comm.Parameters.Add("@studentID", System.Data.SqlDbType.Int);
            comm.Parameters["@studentID"].Value = studentID;

            SqlDataReader courseReader = comm.ExecuteReader();
            //if (courseReader.Read())
            {
                coursesDetailsGrid.DataSource = courseReader;
                coursesDetailsGrid.DataBind();
                
            }
            courseReader.Close();

            conn.Close();
        }
        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdatePage.aspx?StudentID="+ Request.QueryString["StudentID"]);
        }

    }
}