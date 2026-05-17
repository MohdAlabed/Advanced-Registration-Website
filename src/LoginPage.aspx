<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RecommendationSystem.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recommendation System | Login</title>

    <%--BootStrap CSS--%>
    <link href="BootStrap/CSS/bootstrap.min.css" rel="stylesheet" />
    <%--DataTable CSS--%>
    <link href="DataTables/CSS/jquery.dataTables.min.css" rel="stylesheet" />
    <%--FontAwesome CSS--%>
    <link href="FontAwesome/css/all.css" rel="stylesheet" />

    <%--BootStrap JavaScript--%>
    <script src="BootStrap/JavaScript/jquery-3.3.1.slim.min.js"></script>
    <script src="BootStrap/JavaScript/popper.min.js"></script>
    <script src="BootStrap/JavaScript/bootstrap.min.js"></script>

    <%--CSS Style Sheet--%>
    <link href="StyleSheets/Logpage.css" rel="stylesheet" />

</head>
<body>

    <div class="container">
        <div class="col-md-12 mx-auto">
            <div class="card">
                <div class="row">
                    <div class="col-md-6">
                        <img src="Images/UJ_Main.jpg" class="left-img d-none d-md-flex" />
                    </div>
                    <div class="card-body col-md-6">
                        <center>
                            <img src="Images/University_of_Jordan_Logo.png" width="75" /><br />
                            <h5>Log In</h5>
                            <br />
                        </center>
                        <div class="form-group">

                            <form id="form1" runat="server">
                                <center>
                                    <div class="input_container">
                                        <i class="fa-solid fa-user icon"></i>
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="User ID"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ID="usernameValidator" runat="server" ErrorMessage="Please enter your username." ControlToValidate="TextBox1" Display="Dynamic" ValidationGroup="Login" CssClass="validation-error" ></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Invalid username entry." ControlToValidate="TextBox1" ValidationExpression="^[A-Za-z]{3}[0-9]{7}|[A-Za-z0-9._%+-]+@ju\.edu\.jo$" Display="Dynamic" CssClass="validation-error" ValidationGroup="Login" ></asp:RegularExpressionValidator>

                                    <div class="input_container">
                                        <i class="fa-solid fa-lock icon"></i>
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ErrorMessage="Please enter your password." ControlToValidate="TextBox2" Display="Dynamic" ValidationGroup="Login" CssClass="validation-error"></asp:RequiredFieldValidator>

                                    <br />
                                    <asp:Label ID="errorLabel" runat="server" Visible="false" CssClass="errorlabel"></asp:Label>
                                    <br />
                                </center>

                                <div class="checkbox">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="&nbsp; Remember me" />
                                </div>

                                <asp:Button CssClass="btn" ID="Button1" runat="server" Text="Login" ValidationGroup="Login" OnClick="Button1_Click" />
                            </form>
                        </div>
                        <br />
                        <hr />

                        <a href="Home.aspx"><< Back to Home</a>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <p class="copy">&copy 2023 Jordan University, All Rights Reverved.</p>

</body>
</html>
