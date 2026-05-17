<%@ Page Title="" Language="C#" MasterPageFile="~/Logedin.Master" AutoEventWireup="true" CodeBehind="adminHome.aspx.cs" Inherits="RecommendationSystem.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--CSS Style Sheet--%>
    <link href="StyleSheets/Majorstyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Reco">
        <div class="container">
            <div class="col-md-12 card card-body">
                <h1>Graduate student Conflicting Courses</h1>
                <ul>
                    <asp:Literal ID="CoursesLiteral" runat="server"></asp:Literal>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
