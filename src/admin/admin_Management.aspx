<%@ Page Title="" Language="C#" MasterPageFile="~/Logedin.Master" AutoEventWireup="true" CodeBehind="admin_Management.aspx.cs" Inherits="RecommendationSystem.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--CSS Style Sheet--%>
    <link href="StyleSheets/MangementStyles.css" rel="stylesheet" />

    <%--DataTables CSS--%>
    <link href="DataTables/CSS/jquery.dataTables.min.css" rel="stylesheet" />

    <%--DataTables JS--%>
    <script src="DataTables/JavaScript/jquery-3.5.1.js"></script>
    <script src="DataTables/JavaScript/jquery.dataTables.min.js"></script>

    <%--DataTables--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">

            <!-- User Management Window Start -->

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2>User Management</h2>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150" src="Images/management_pic.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <!-- Fetch Account Details Start -->

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Account Details</h4>
                                </center>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="UserID" runat="server" placeholder="User ID" CssClass="form-control"></asp:TextBox>
                                        <asp:Button ID="GObtn" runat="server" Text="GO" CssClass="btn btn-primary" OnClick="GObtn_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class=" col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class=" col-md-2">
                                <div class="form-group">
                                    <asp:TextBox ID="Major" runat="server" CssClass="form-control" placeholder="Major" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>

                            <div class=" col-md-4">
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="Status" runat="server" CssClass="form-control" placeholder="Status" ReadOnly="True"></asp:TextBox>
                                        <asp:LinkButton ID="Activate" runat="server" CssClass="btn btn-success" data-toggle="tooltip" title="Activate" OnClick="Activate_Click"><i class="fa-solid fa-person-circle-check"></i></asp:LinkButton>
                                        <asp:LinkButton ID="Pending" runat="server" CssClass="btn btn-warning" data-toggle="tooltip" title="Pend" OnClick="Pending_Click"><i class="fa-solid fa-circle-pause" style=" color:white;"></i></asp:LinkButton>
                                        <asp:LinkButton ID="Deactivate" runat="server" CssClass="btn btn-danger" data-toggle="tooltip" title="Deactivate" OnClick="Deactivate_Click"><i class="fa-solid fa-ban"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button ID="DeleteUser" runat="server" CssClass="btn btn-block btn-danger" Text="Delete User" OnClick="DeleteUser_Click" />
                            </div>
                        </div>

                        <!-- Fetch Account Details End -->
                        <!-- Add New User Start -->

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Add New User</h4>
                                </center>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class=" col-md-3">
                                <div class="form-group">
                                    <asp:DropDownList ID="ADDUserType" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ADDUserType_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="Student"> Student </asp:ListItem>
                                        <asp:ListItem Value="Admin"> Admin </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class=" col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="ADDUserName" runat="server" CssClass="form-control" placeholder="User Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ADDUserNameValidator" runat="server" ErrorMessage="*" ControlToValidate="ADDUserName" ValidationGroup="ADDUser" Display="Dynamic" CssClass="required_field"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="ADDUserID" runat="server" placeholder="User ID" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ADDUserIDValidator" runat="server" ErrorMessage="*" ControlToValidate="ADDUserID" ValidationGroup="ADDUser" Display="Dynamic" CssClass="required_field"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularADDUserIDValidator" runat="server" ErrorMessage="Invalid username entry." ControlToValidate="ADDUserID" ValidationExpression="^[A-Za-z]{3}[0-9]{7}|[A-Za-z0-9._%+-]+@ju\.edu\.jo$" Display="Dynamic" CssClass="regular_exp" ValidationGroup="ADDUser" ></asp:RegularExpressionValidator>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="ADDPass" runat="server" placeholder="Password" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ADDPassValidator" runat="server" ErrorMessage="*" ControlToValidate="ADDPass" ValidationGroup="ADDUser" Display="Dynamic" CssClass="required_field"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="form-group">
                                    <asp:TextBox ID="ADDMajor" runat="server" placeholder="Major" CssClass="form-control" Visible="true"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-8 mx-auto">
                                <asp:Button ID="ADDUserbtn" runat="server" CssClass="btn btn-block btn-success" Text="Add User" ValidationGroup="ADDUser" OnClick="ADDUserbtn_Click" />
                            </div>
                        </div>

                        <!-- Add New User End -->

                    </div>
                </div>
            </div>

            <!-- User Management Window End -->
            <!-- Data view Window Start -->

            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h2>User List</h2>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RecommendationSystemDBConnectionString %>" SelectCommand="SELECT [USERNAME], [USER_TYPE], [FULL_NAME], [ACC_STATUS], [MAJOR] FROM [RES_USER]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="USERNAME" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="USERNAME" HeaderText="User ID" ReadOnly="True" SortExpression="USERNAME" />
                                        <asp:BoundField DataField="FULL_NAME" HeaderText="Full Name" SortExpression="FULL_NAME" />
                                        <asp:BoundField DataField="USER_TYPE" HeaderText="User Type" SortExpression="USER_TYPE" />
                                        <asp:BoundField DataField="MAJOR" HeaderText="Student Major" SortExpression="MAJOR" />
                                        <asp:BoundField DataField="ACC_STATUS" HeaderText="Status" SortExpression="ACC_STATUS" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Data view Window End -->

        </div>
    </div>

</asp:Content>
