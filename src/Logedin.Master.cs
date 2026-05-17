using System;
using System.Web;

namespace RecommendationSystem
{
    public partial class Loged_in : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();
            try
            {
                if (Session != null && (Session["USER_TYPE"] != null) && ((string)Session["ACC_STATUS"] == "Active"))
                {
                    if (Session["USER_TYPE"].ToString() == "Student")
                    {
                        adminbtns.Visible = false;
                        studentbtns.Visible = true;
                        stdname.InnerText = Session["FULL_NAME"].ToString();
                        stdmajor.InnerText = Session["MAJOR"].ToString();
                    }
                    else
                    {
                        adminbtns.Visible = true;
                        studentbtns.Visible = false;
                        adname.InnerText = Session["FULL_NAME"].ToString();
                    }
                }
                else
                {
                    Response.Redirect("LoginPage.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LogoutS_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }

        protected void LogoutA_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("LoginPage.aspx");
        }
    }
}