using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Diagnostics;

namespace RecommendationSystem
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected int currentGroup
        {
            get { return ViewState["currentGroup"] as int? ?? 0; }
            set { ViewState["currentGroup"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
            }
        }

        protected void Addbtn_Click(object sender, EventArgs e)
        {

            currentGroup = (currentGroup == 0) ? 1 : 0;

            LoadCourses();
        }

        private void LoadCourses()
        {
            if (Session["USERNAME"] != null)
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Final_Filtered_Frame.csv");

                if (File.Exists(filePath))
                {
                    using (var reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                    {
                        csv.Read();
                        csv.ReadHeader();
                        string[] headers = csv.HeaderRecord;
                        int studentIndex = Array.IndexOf(headers, "Student");
                        int courseIndex = Array.IndexOf(headers, "Course");
                        int roundIndex = Array.IndexOf(headers, "Round");

                        StringBuilder sb = new StringBuilder();
                        bool allValuesZero = true;

                        while (csv.Read())
                        {
                            string student = csv.GetField(studentIndex);
                            string courseInfo = csv.GetField(courseIndex);
                            int round = Convert.ToInt32(csv.GetField(roundIndex));

                            if (string.Equals(student, Session["USERNAME"].ToString(), StringComparison.OrdinalIgnoreCase) && round == currentGroup)
                            {
                                var courseDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(courseInfo);
                                string courseName = courseDict["Course Name"];
                                string courseSection = courseDict["Course Section"];
                                string days = courseDict["Days"];
                                string orientationDays = courseDict["Orientation Days"];
                                string time = courseDict["Time"];
                                string hall = courseDict["Hall"];
                                string instructor = courseDict["Instructor Name"];

                                // Append the course card HTML to the StringBuilder
                                sb.Append("<li class='card'>");
                                sb.Append($"<h3 class='course-name'>{courseName}</h3>");
                                sb.Append("<div class='details'>");
                                sb.Append($"<span class='course-section'>Section {courseSection}</span>");
                                if (!string.IsNullOrEmpty(days) && days != "0")
                                    sb.Append($"<span class='course-days'>{days}</span>");
                                if (!string.IsNullOrEmpty(orientationDays) && orientationDays != "0")
                                    sb.Append($"<span class='orientation-days'>Orientation Days: {orientationDays}</span>");
                                if (!string.IsNullOrEmpty(time) && time != "0")
                                    sb.Append($"<span class='course-time'>{time}</span>");
                                if (!string.IsNullOrEmpty(hall) && hall != "0")
                                    sb.Append($"<span class='course-hall'>{hall}</span>");
                                if (!string.IsNullOrEmpty(instructor) && instructor != "0")
                                    sb.Append($"<span class='instructor-name'>{instructor}</span>");
                                sb.Append("</div>");
                                sb.Append("</li>");
                            }
                        }
                        CoursesLiteral.Text = sb.ToString();
                    }
                }
            }
        }
    }
}