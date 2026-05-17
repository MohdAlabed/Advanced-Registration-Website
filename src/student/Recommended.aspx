<%@ Page Title="" Language="C#" MasterPageFile="~/Logedin.Master" AutoEventWireup="true" CodeBehind="Recommended.aspx.cs" Inherits="RecommendationSystem.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--CSS Style Sheet--%>
    <link href="StyleSheets/Majorstyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Reco row">
        <div class="container">
            <div class="col-md-12 card card-body">
                <center>
                    <h1>Recommended Schedule</h1>
                    <ul>
                        <asp:Literal ID="CoursesLiteral" runat="server"></asp:Literal>
                    </ul>
                    <br />
                    <asp:LinkButton ID="Addbtn" CssClass="btnN btn-lg btn-block" OnClick="Addbtn_Click" runat="server">Replace Schedule</asp:LinkButton>
                </center>
            </div>
        </div>
    </div>

</asp:Content>
