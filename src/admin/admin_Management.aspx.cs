using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RecommendationSystem
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private static string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void GObtn_Click(object sender, EventArgs e)
        {
            getUserByID();
        }

        protected void Activate_Click(object sender, EventArgs e)
        {
            updateUserStatus("Active");
        }

        protected void Pending_Click(object sender, EventArgs e)
        {
            updateUserStatus("Pending");
        }

        protected void Deactivate_Click(object sender, EventArgs e)
        {
            updateUserStatus("Deactive");
        }

        protected void DeleteUser_Click(object sender, EventArgs e)
        {
            deleteUser();
        }

        protected void ADDUserbtn_Click(object sender, EventArgs e)
        {
            if (checkUserExists())
            {
                Response.Write("<script>alert('User Already Exists');</script>");
            }
            else
            {
                addNewUser();
            }
            ADDUserID.Text = "";
            ADDUserName.Text = "";
            ADDPass.Text = "";
            ADDMajor.Text = "";
        }

        void getUserByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM RES_USER WHERE USERNAME = '" + UserID.Text.Trim() + "'", con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UserName.Text = dr.GetValue(1).ToString();
                        if (dr.GetValue(3).ToString() == "Student")
                        {
                            Major.Text = dr.GetValue(5).ToString();
                        }
                        else
                        {
                            Major.Text = dr.GetValue(3).ToString();
                        }
                        Status.Text = dr.GetValue(6).ToString();
                    }
                }
                else 
                {
                    UserID.Text = "";
                    UserName.Text = "";
                    Major.Text = "";
                    Status.Text = "";
                    Response.Write("<script>alert('Entry Not Found');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

        void updateUserStatus(string status)
        {
            try
            {
                if (Status.Text != "")
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("UPDATE RES_USER SET ACC_STATUS = '" + status + "' WHERE USERNAME = '" + UserID.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    Status.Text = status.ToString();
                    GridView1.DataBind();
                    UserID.Text = "";
                    UserName.Text = "";
                    Major.Text = "";
                    Status.Text = "";
                    Response.Write("<script>alert('Account Status Updated Successfully');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                con.Open();
                if (UserID.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM RES_USER WHERE USERNAME='" + UserID.Text.Trim() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (ADDUserID.Text != "")
                { 
                    SqlCommand cmd = new SqlCommand("SELECT * FROM RES_USER WHERE USERNAME='" + ADDUserID.Text.Trim() + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void deleteUser()
        {
            try
            {
                if (checkUserExists())
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM RES_USER WHERE USERNAME = '" + UserID.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();

                    con.Close();
                    UserID.Text = "";
                    UserName.Text = "";
                    Major.Text = "";
                    Status.Text = "";
                    GridView1.DataBind();
                    Response.Write("<script>alert('User Deleted Successfully');</script>");
                }
                else 
                {
                    Response.Write("<script>alert('Entry Not Found');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void addNewUser()
        {
            if (ADDUserID.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO RES_USER (USERNAME,PASSWORD,USER_TYPE,FULL_NAME,MAJOR,ACC_STATUS) values (@USERNAME,@PASSWORD,@USER_TYPE,@FULL_NAME,@MAJOR,@ACC_STATUS)", con);
                    cmd.Parameters.AddWithValue("@FULL_NAME", ADDUserName.Text.Trim());
                    cmd.Parameters.AddWithValue("@USERNAME", ADDUserID.Text.Trim());
                    cmd.Parameters.AddWithValue("@PASSWORD", ADDPass.Text.Trim());
                    cmd.Parameters.AddWithValue("@USER_TYPE", ADDUserType.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@MAJOR", ADDMajor.Text.Trim());
                    cmd.Parameters.AddWithValue("@ACC_STATUS", "Pending");
                    cmd.ExecuteNonQuery();

                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('User Added Successfully');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ADDUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ADDUserType.SelectedValue == "Student")
            {
                ADDMajor.Visible = true;
            }
            else if (ADDUserType.SelectedValue == "Admin")
            {
                ADDMajor.Visible = false;
            }
        }       
    }
}