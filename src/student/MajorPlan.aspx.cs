using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RecommendationSystem
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Course> courseList = GetCourseList();
            GenerateCourseCards(courseList);

            ScriptManager.RegisterClientScriptInclude(this, GetType(), "jQuery", "jQuery/jquery-3.7.0.js");
            string script = @"
                <script>
                    document.getElementById('defaultOpen').click();
                    function openCourseModal(courseId) {
                        var modal = document.getElementById('ModalID');

                        $.ajax({
                            type: 'POST',
                            url: 'adminMajorPlan.aspx/OpenCourseModal',
                            data: JSON.stringify({ courseId: courseId }),
                            contentType: 'application/json; charset=utf-8',
                            dataType: 'json',
                            success: function (response) {
                                var course = response.d;

                                var modalTitle = document.querySelector('.modal-header h2');
                                modalTitle.textContent = course.CourseName;

                                var modalDescription = document.querySelector('.modal-content p');
                                modalDescription.textContent = course.CourseDescription;

                                var syllabusButton = document.getElementById('btnSyllabus');
                                    syllabusButton.onclick = function () {
                                        if (course.CourseSyllabus.trim() !== '') {
                                            var link = document.createElement('a');
                                            link.href = course.CourseSyllabus;
                                            link.target = '_blank';
                                            link.click();
                                            }
                                        };

                                var modalHours = document.querySelector('.modal-footer h3');
                                modalHours.textContent = course.CreditHours;

                                modal.style.display = 'block';
                            },
                            error: function (xhr, status, error) {
                                console.log(error);
                            }
                        });
                    }

                    var modal = document.getElementById('ModalID');
                    var closeButton = document.querySelector('.modal-header .close');

                    closeButton.onclick = function () {
                        modal.style.display = 'none';
                    }

                    window.onclick = function (event) {
                        if (event.target === modal) {
                            modal.style.display = 'none';
                        }
                    }
                </script>";


            Page.ClientScript.RegisterStartupScript(this.GetType(), "StartupScript", script);
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
                LiteralControl cardContainer = new LiteralControl();
                cardContainer.Text = "<li class='card col-md-2' onclick='openCourseModal(" + course.CourseID + ")'>";
                cardContainer.Text += "<span>" + course.CourseName + "</span><br />";
                cardContainer.Text += "<p>" + GetShortDescription(course.CourseDescription) + "</p>";
                cardContainer.Text += "</li>";

                string targetulId = GetTargetulId(course.GroupID);
                Control targetul = FindControlRecursive(this, targetulId);
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
        private string GetTargetulId(int groupCode)
        {
            switch (groupCode)
            {
                case 1:
                    return "ul1";
                case 2:
                    return "ul2";
                case 3:
                    return "ul3";
                case 4:
                    return "ul4";
                case 5:
                    return "ul5";
                case 6:
                    return "ul6";
                default:
                    return string.Empty;
            }
        }
        private string GetShortDescription(string fullDescription)
        {
            const int MaxLength = 50;
            if (fullDescription.Length <= MaxLength)
            {
                return fullDescription;
            }
            else
            {
                return fullDescription.Substring(0, MaxLength) + "...";
            }
        }
        [System.Web.Services.WebMethod]
        public static Course OpenCourseModal(int courseId)
        {
            Course course = GetCourseById(courseId);

            return course;
        }

        private static Course GetCourseById(int courseId)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                string query = "SELECT COURSE_ID, GROUP_CODE, COURSE_NAME, COURSE_DESCRIPTIONS FROM RES_MAJOR_PLAN WHERE COURSE_ID = @CourseID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CourseID", courseId);
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    Course course = new Course
                    {
                        CourseID = (int)rd["COURSE_ID"],
                        GroupID = (int)rd["GROUP_CODE"],
                        CourseName = (string)rd["COURSE_NAME"],
                        CourseDescription = (string)rd["COURSE_DESCRIPTIONS"]
                    };

                    rd.Close();
                    return course;
                }
            }

            return null;
        }
    }
}