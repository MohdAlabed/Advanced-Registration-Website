using CsvHelper;
using System;
using System.IO;
using System.Text;

namespace RecommendationSystem
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "graduates_conflicting_courses.csv");

            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
                {
                    csv.Read();

                    while (csv.Read())
                    {
                        string student = csv.GetField<string>(0); 
                        string course1 = csv.GetField<string>(1);
                        string course2 = csv.GetField<string>(2);

                        student = RemoveSpecialCharacters(student);
                        course1 = RemoveSpecialCharacters(course1);
                        course2 = RemoveSpecialCharacters(course2);

                        StringBuilder sb = new StringBuilder();
                        sb.Append("<li class='card'>");
                        sb.Append($"<h3 class='course-name'>{student}</h3>");
                        sb.Append($"<div class='details'>");
                        sb.Append($"<span class='course-time'>First Course: {course1}</span>");
                        sb.Append($"<span class='course-time'>With Course: {course2}</span>");
                        sb.Append($"</div>");
                        sb.Append("</li>");
                        CoursesLiteral.Text = sb.ToString();
                    }  
                }
            }
        }
        private string RemoveSpecialCharacters(string input)
        {
            input = input.Replace("[", "").Replace("']", "").Replace("'", "").Trim();
            return input;
        }
    }
}