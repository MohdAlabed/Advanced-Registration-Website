using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;

namespace RecommendationSystem
{
    public partial class LoginPage : System.Web.UI.Page
    {
        private static string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            if (Session["username"] != null)
            {
                Session.Abandon();
                Response.Redirect("LoginPage.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        string query = "SELECT * FROM RES_USER WHERE USERNAME=@USERNAME AND PASSWORD=@PASSWORD";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@USERNAME", TextBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@PASSWORD", TextBox2.Text.Trim());

                            using (SqlDataReader dr = cmd.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        Session["USERNAME"] = dr[4].ToString();
                                        Session["USER_TYPE"] = dr[3].ToString();
                                        Session["FULL_NAME"] = dr[1].ToString();
                                        Session["MAJOR"] = dr[5].ToString();
                                        Session["ACC_STATUS"] = dr[6].ToString();
                                    }

                                    if ((string)Session["ACC_STATUS"] != "Active")
                                    {
                                        errorLabel.Visible = true;
                                        DisplayAlertL("Access Denied");
                                    }
                                    else if (Session["USER_TYPE"].Equals("Student"))
                                    {
                                        Response.Redirect("Recommended.aspx");
                                    }
                                    else
                                    {
                                        Response.Redirect("adminRecommended.aspx");
                                    }
                                }
                                else
                                {
                                    errorLabel.Visible = true;
                                    DisplayAlertL("Invalid username or password.");
                                }
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch
            {
                DisplayAlert("An error occurred. Please try again later.");
                // Log the error using a logging framework like log4net or NLog.
            }
        }

        private void DisplayAlertL(string message)
        {
            errorLabel.Text = message;
        }
        private void DisplayAlert(string message)
        {
            string script = "<script>alert('" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", script);
        }
    }
}