using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static RecommendationSystem.WebForm5;

namespace RecommendationSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Course> courseList = GetCourseList();
                GenerateCourseCards(courseList);
            }
        }
        public class Course
        {
            public int CourseID { get; set; }
            public int GroupID { get; set; }
            public string CourseName { get; set; }
            public string CourseDescription { get; set; }
            public string CourseSyllabus { get; set; }
            public int CreditHours { get; set; }
        }
        public List<Course> GetCourseList()
        {
            List<Course> courseList = new List<Course>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "SELECT COURSE_ID, GROUP_CODE, COURSE_NAME, COURSE_DESCRIPTIONS, PDF_LINK, Contact_Hourss FROM RES_MAJOR_PLAN";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Course course = new Course
                    {
                        CourseID = (int)rd["COURSE_ID"],
                        GroupID = (int)rd["GROUP_CODE"],
                        CourseName = (string)rd["COURSE_NAME"],
                        CourseDescription = (string)rd["COURSE_DESCRIPTIONS"],
                        CourseSyllabus = (string)rd["PDF_LINK"],
                        CreditHours = (int)rd["Contact_Hourss"]
                    };

                    courseList.Add(course);
                }
                rd.Close();
            }
            return courseList;
        }
        protected void GenerateCourseCards(List<Course> courseList)
        {
            foreach (Course course in courseList)
            {
                HtmlGenericControl cardContainer = new HtmlGenericControl("li");
                cardContainer.Attributes["class"] = "card col-md-2";

                Literal courseNameLiteral = new Literal();
                courseNameLiteral.Text = "<span>" + course.CourseName + "</span><br />";
                cardContainer.Controls.Add(courseNameLiteral);

                HtmlGenericControl courseDescriptionLink = new HtmlGenericControl("a");
                courseDescriptionLink.Attributes["href"] = "#";
                courseDescriptionLink.InnerText = course.CourseDescription;
                cardContainer.Controls.Add(courseDescriptionLink);

                Control targetul = FindControlRecursive(this, "ul1");
                if (targetul != null && targetul is HtmlGenericControl ul)
                {
                    ul.Controls.Add(cardContainer);
                }
            }
        }
        public static Control FindControlRecursive(Control control, string id)
        {
            if (control.ID == id)
            {
                return control;
            }

            foreach (Control childControl in control.Controls)
            {
                Control foundControl = FindControlRecursive(childControl, id);
                if (foundControl != null)
                {
                    return foundControl;
                }
            }
            return null;
        }
    }
}