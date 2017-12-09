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
    public partial class CoursePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int courseID = Convert.ToInt32(Request.QueryString["CourseID"]);

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            BindData(conn, courseID);

            if (IsPostBack) return;

            string query = "SELECT Students.StudentID, " +
                "Students.FirstMidName + ' ' + LastName as FullName " +
                " FROM Students" +
                " WHERE Students.StudentID NOT IN (" +
                " SELECT Enrollments.StudentID FROM  Enrollments WHERE Enrollments.CourseID =  @courseID)";

            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.Add("@courseID", System.Data.SqlDbType.Int);
            comm.Parameters["@courseID"].Value = courseID;

            SqlDataReader studentReader = comm.ExecuteReader();

            nameList.DataSource = studentReader;
            nameList.DataBind();
            conn.Close();
        }
        private void BindData(SqlConnection conn, int courseID)
        {
            String query = "SELECT Students.StudentID, Enrollments.CourseID, Students.LastName, Students.FirstMidName, Students.EnrollmentDate" +
                " FROM Students" +
               " INNER JOIN Enrollments ON Enrollments.StudentID = Students.StudentID WHERE Enrollments.CourseID = @courseID";
            SqlCommand comm = new SqlCommand(query, conn);



            comm.Parameters.Add("@courseID", System.Data.SqlDbType.Int);
            comm.Parameters["@courseID"].Value = courseID;


            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            //if (reader.Read())
            {
                CourseStudentGrid.DataSource = reader;
                CourseStudentGrid.DataBind();
                reader.Close();
            }
        }
        protected void AddStudentBnt_Click(object sender, EventArgs e)
        {
            String studentID = nameList.SelectedValue;
            int courseID = Convert.ToInt32(Request.QueryString["CourseID"]);

            String query = "INSERT INTO Enrollments(CourseID, StudentID, Grade)" +
                    " VALUES(@courseID, @studentID, @gradeTxt)";

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.Add("@studentID", System.Data.SqlDbType.Int);
            comm.Parameters["@studentID"].Value = studentID;

            comm.Parameters.Add("@courseID", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@courseID"].Value = courseID;

            comm.Parameters.Add("@gradeTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@gradeTxt"].Value = gradeTxt.Text;

            comm.Parameters.Add("@enrollmentDateTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@enrollmentDateTxt"].Value = enrollmentDateTxt.Text;

            conn.Open();
            comm.ExecuteNonQuery();

            conn.Close();

            BindData(conn, courseID);
        }

        protected void CourseStudentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int studentID = Convert.ToInt32(CourseStudentGrid.DataKeys[e.RowIndex].Values["StudentID"]);
            int courseID = Convert.ToInt32(CourseStudentGrid.DataKeys[e.RowIndex].Values["CourseID"]);


            String query = "DELETE FROM Enrollments " +
                "WHERE StudentID = @studentID AND CourseID = @courseID";

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.Add("@studentID", System.Data.SqlDbType.Int);
            comm.Parameters["@studentID"].Value = studentID;

            comm.Parameters.Add("@courseID", System.Data.SqlDbType.Int);
            comm.Parameters["@courseID"].Value = courseID;

            conn.Open();
            comm.ExecuteNonQuery();

            conn.Close();
            BindData(conn, courseID);
        }
    }
}