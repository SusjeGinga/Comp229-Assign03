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

            String query = "SELECT Students.StudentID, Enrollments.CourseID, Students.LastName, Students.FirstMidName, Students.EnrollmentDate" +
                " FROM Students" +
               " INNER JOIN Enrollments ON Enrollments.StudentID = Students.StudentID WHERE Enrollments.CourseID = @courseID";
           

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
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

            ////display students not in the course
            //SqlDataAdapter ad = new SqlDataAdapter(commAdd);
            //DataSet ds = new DataSet();
            //ad.Fill(ds);
            //studentList.DataSource = ds.Tables[0];
            //studentList.DataTextField = ds.Tables[0].Columns["FullName"].ToString(); ;
            //studentList.DataBind();

            //DataBind();

            //SqlCommand commAdd = new SqlCommand
            //("Select distinct st.StudentID, FirstMidName + ' ' + LastName as FullName" +
            //                    " from Students st " +
            //"join Enrollments e on st.StudentID = e.StudentID " +
            //"join Courses c on e.CourseID = c.CourseID " +
            //"where not c.CourseID =  @courseID;", thisConnection);

            query = "SELECT Students.StudentID, " +
                "Students.FirstMidName + ' ' + LastName as FullName " +
                " FROM Students" +
                " WHERE Students.StudentID NOT IN (" +
                " SELECT Enrollments.StudentID FROM  Enrollments WHERE Enrollments.CourseID =  @courseID)";

            comm = new SqlCommand(query, conn);

            comm.Parameters.Add("@courseID", System.Data.SqlDbType.Int);
            comm.Parameters["@courseID"].Value = courseID;

            SqlDataReader studentReader = comm.ExecuteReader();

            nameList.DataSource = studentReader;
            //nameList.DataTextField = "Full Name";
            //nameList.DataValueField = "LastName" + " " + "FirstMidName";
            nameList.DataBind();
            conn.Close();
        }
        protected void AddStudentBnt_Click(object sender, EventArgs e)
        {
            String studentID = "a";
            String fullname = nameList.SelectedValue;
            //String name = fullname.Split(' ');

            String query = "UPDATE Enrollments SET LastName = @lastNameTxt, FirstMidName = @firstMidNameTxt" +
                    " WHERE StudentID = @studentID";

            String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand comm = new SqlCommand(query, conn);

            comm.Parameters.Add("@studentID", System.Data.SqlDbType.Int);
            comm.Parameters["@studentID"].Value = studentID;

            //comm.Parameters.Add("@lastNameTxt", System.Data.SqlDbType.NVarChar);
            //comm.Parameters["@lastNameTxt"].Value = lastNameTxt.Text;

            //comm.Parameters.Add("@firstMidNameTxt", System.Data.SqlDbType.NVarChar);
            //comm.Parameters["@firstMidNameTxt"].Value = firstMidNameTxt.Text;

            comm.Parameters.Add("@enrollmentDateTxt", System.Data.SqlDbType.NVarChar);
            comm.Parameters["@enrollmentDateTxt"].Value = enrollmentDateTxt.Text;

            conn.Open();
            comm.ExecuteNonQuery();

            conn.Close();
        }         

        protected void CourseStudentGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int studentID = Convert.ToInt32(CourseStudentGrid.DataKeys[e.RowIndex].Values["StudentID"]);
            int courseID = Convert.ToInt32(CourseStudentGrid.DataKeys[e.RowIndex].Values["CourseID"]);
             

                String query = "DELETE FROM Enrollments " +
                    "WHERE StudentID = @studentID and CourseID = @courseID";

                String connectionString = ConfigurationManager.ConnectionStrings["Comp229Assign03"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand comm = new SqlCommand(query, conn);

                comm.Parameters.Add("@studentID", System.Data.SqlDbType.Int);
                comm.Parameters["@studentID"].Value = studentID;
                conn.Open();
                comm.ExecuteNonQuery();

                conn.Close();
        }
    }
}