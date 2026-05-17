using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace RecommendationSystem
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        private static string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptInclude(this, GetType(), "jQuery", "jQuery/jquery-3.7.0.js");
            if (!IsPostBack)
            {
                ReloadCourseCardsAndRegisterScript();
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
                string query = "SELECT COURSE_ID, GROUP_CODE, COURSE_NAME, COURSE_DESCRIPTIONS FROM RES_MAJOR_PLAN";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Course course = new Course
                    {
                        CourseID = (int)rd["COURSE_ID"],
                        GroupID = (int)rd["GROUP_CODE"],
                        CourseName = (string)rd["COURSE_NAME"],
                        CourseDescription = (string)rd["COURSE_DESCRIPTIONS"]
                    };

                    courseList.Add(course);
                }
                rd.Close();
            }
            return courseList;
        }

        private void ReloadCourseCardsAndRegisterScript()
        {
            List<Course> courseList = GetCourseList();
            GenerateCourseCards(courseList);

            string script = @"
    <script>
        document.getElementById('defaultOpen').click();
        function openCourseModal(courseId) {
            var modal = document.getElementById('ModalID');
            var hiddenCourseId = document.getElementById('hiddenCourseId');
            if (hiddenCourseId) {
                hiddenCourseId.value = courseId;
            } else {
                console.log('The element with ID \'hiddenCourseId\' was not found.');
            }

            $.ajax({
                type: 'POST',
                url: 'adminMajorPlan.aspx/OpenCourseModal',
                data: JSON.stringify({ courseId: courseId }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (response) {
                    var course = response.d;

                    var modalTitle = document.getElementById('modalName');
                    modalTitle.value = course.CourseName;

                    var modalDescription = document.getElementById('modalDec');
                    modalDescription.value = course.CourseDescription;

                    var modalSyllabus = document.getElementById('UploadSyllabus');
                    modalSyllabus.value = course.CourseSyllabus;

                    var modalHours = document.getElementById('modalCredit');
                    modalHours.value = course.CreditHours;

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
        };

        window.onclick = function (event) {
            if (event.target === modal) {
                modal.style.display = 'none';
            }
        };
    </script>";


            Page.ClientScript.RegisterStartupScript(this.GetType(), "StartupScript", script);
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
                string query = "SELECT COURSE_ID, GROUP_CODE, COURSE_NAME, COURSE_DESCRIPTIONS, PDF_LINK, Contact_Hourss FROM RES_MAJOR_PLAN WHERE COURSE_ID = @CourseID";
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
                        CourseDescription = (string)rd["COURSE_DESCRIPTIONS"],
                        CourseSyllabus = (string)rd["PDF_LINK"],
                        CreditHours = (int)rd["Contact_Hourss"]
                    };
                    rd.Close();
                    return course;
                }
            }

            return null;
        }

        protected void EditDescription_Click(object sender, EventArgs e)
        {
            string courseId = hiddenCourseId.Value;
            string modalNamex = modalName.Value;
            string modalDecx = modalDec.Value;
            string UploadSyllabusx = UploadSyllabus.Value;
            string modalCreditx = modalCredit.Value;
            int creditHours = int.Parse(modalCreditx);

            if (int.TryParse(courseId, out int courseIdInt))
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand cmd = new SqlCommand("UPDATE RES_MAJOR_PLAN SET COURSE_NAME = @CourseName, COURSE_DESCRIPTIONS = @CourseDescription, PDF_LINK = @PDFLink, Contact_Hourss = @ContactHours WHERE COURSE_ID = @CourseID", con);
                cmd.Parameters.AddWithValue("@CourseName", modalNamex);
                cmd.Parameters.AddWithValue("@CourseDescription", modalDecx);
                cmd.Parameters.AddWithValue("@PDFLink", UploadSyllabusx);
                cmd.Parameters.AddWithValue("@ContactHours", creditHours);
                cmd.Parameters.AddWithValue("@CourseID", courseIdInt);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            else
            {
                Response.Write("<script>alert('Invalid course ID: " + courseId + "');</script>");
            }
            ReloadCourseCardsAndRegisterScript();
        }

        protected void RemoveCourse_Click(object sender, EventArgs e)
        {
            string courseId = hiddenCourseId.Value;
            if (int.TryParse(courseId, out int courseIdInt))
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM RES_MAJOR_PLAN WHERE COURSE_ID = @CourseID", con);
                    cmd.Parameters.AddWithValue("@CourseID", courseIdInt);
                    cmd.ExecuteNonQuery();
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid course ID: " + courseId + "');</script>");
            }
            ReloadCourseCardsAndRegisterScript();
        }

        protected void addCourse_Click(object sender, EventArgs e)
        {
            string groupID = hiddenCourseId.Value;
            string creditHourx = modalCreditAdd.Value;
            int creditHours = int.Parse(creditHourx);
            SqlConnection con = new SqlConnection(strcon);
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO RES_MAJOR_PLAN (GROUP_CODE,GROUP_NAME,COURSE_NAME,COURSE_DESCRIPTIONS,PDF_LINK,Contact_Hourss) values (@GROUP_CODE,@GROUP_NAME,@COURSE_NAME,@COURSE_DESCRIPTIONS,@PDF_LINK,@Contact_Hourss)", con);

            if (groupID == "AddCard1")
            {
                cmd.Parameters.AddWithValue("@GROUP_CODE", 1);
                cmd.Parameters.AddWithValue("@GROUP_NAME", "Obligatory University Requirements");
            }
            else if (groupID == "AddCard2")
            {
                cmd.Parameters.AddWithValue("@GROUP_CODE", 2);
                cmd.Parameters.AddWithValue("@GROUP_NAME", "Elective University Requirements");
            }
            else if (groupID == "AddCard3")
            {
                cmd.Parameters.AddWithValue("@GROUP_CODE", 3);
                cmd.Parameters.AddWithValue("@GROUP_NAME", "Obligatory Faculty Requirements");
            }
            else if (groupID == "AddCard4")
            {
                cmd.Parameters.AddWithValue("@GROUP_CODE", 4);
                cmd.Parameters.AddWithValue("@GROUP_NAME", "Obligatory Specialization Requirements");
            }
            else if (groupID == "AddCard5")
            {
                cmd.Parameters.AddWithValue("@GROUP_CODE", 5);
                cmd.Parameters.AddWithValue("@GROUP_NAME", "Obligatory Specialization Requirements");
            }
            else if (groupID == "AddCard6")
            {
                cmd.Parameters.AddWithValue("@GROUP_CODE", 6);
                cmd.Parameters.AddWithValue("@GROUP_NAME", "General Requirements");
            }
            else
            {
                Response.Write("<script>alert('Invalid Group ID: " + groupID + "');</script>");
            }
            cmd.Parameters.AddWithValue("@COURSE_NAME", courseNameAdd.Value.Trim());
            cmd.Parameters.AddWithValue("@COURSE_DESCRIPTIONS", courseDecAdd.Value.Trim());
            cmd.Parameters.AddWithValue("@PDF_LINK", UploadSyllabusAdd.Value.Trim());
            cmd.Parameters.AddWithValue("@Contact_Hourss", creditHours);

            cmd.ExecuteNonQuery();
            con.Close();
            ReloadCourseCardsAndRegisterScript();
            courseNameAdd.Value = "";
            courseDecAdd.Value = "";
            UploadSyllabusAdd.Value = "";
            modalCreditAdd.Value = "";
        }
    }
}