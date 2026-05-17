<%@ Page Title="" Language="C#" MasterPageFile="~/Logedin.Master" AutoEventWireup="true" CodeBehind="adminRecommended.aspx.cs" Inherits="RecommendationSystem.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--CSS Style Sheet--%>
    <link href="StyleSheets/Majorstyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Reco">
        <div class="container">
            <div class="col-md-12 card card-body">
                <h1>Upload Registration Schedule</h1>
                <p>Please upload the registration schedule to get the student course recommendations. The uploaded schedule should follow these instructions:-<br /><br />
                    1. The uploaded file must be in a .csv excel format.<br />
                    2. The uploaded file must include the following columns:<br /> "Course Name", "Course Section", "Capacity", "Day", "Orientation Days", "Time","Hall Name", "Instructor Name","Credit Hours" <br />
                        exactly as written.<br />
                    3. The image below shows the general excel cells format that is good to follow:
                </p>
                <img src="Images/excelformat.JPG" class="excelimg" /><br />
                <div class="reco-form">
                    <asp:FileUpload ID="UploadSchedule" runat="server" CssClass="form-control" accept=".csv"/>
                    <asp:CustomValidator ID="UploadScheduleValidator" runat="server" ErrorMessage="Please upload a .csv file" ControlToValidate="UploadSchedule" OnServerValidate="UploadScheduleValidator_ServerValidate" ValidationGroup="upload" Display="None"></asp:CustomValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please Upload a Schedule" ControlToValidate="UploadSchedule" ValidationGroup="upload" Display="none"></asp:RequiredFieldValidator>
                </div>
                <br />
                <asp:Button ID="Upload" OnClick="Upload_Click" CssClass="btnA" runat="server" Text="Upload" ValidationGroup="upload" />
            </div>
        </div>
        <asp:ValidationSummary ID="validationSummary" runat="server" ValidationGroup="upload" CssClass="validation-error" DisplayMode="List" />
        <asp:Label ID="validationMessage" runat="server" CssClass="validation-message" ForeColor="Red"></asp:Label>
    </div>

</asp:Content>
