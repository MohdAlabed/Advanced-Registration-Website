<%@ Page Title="Recommendation System | Major Plan" Language="C#" MasterPageFile="~/Logedin.Master" AutoEventWireup="true" CodeBehind="MajorPlan.aspx.cs" Inherits="RecommendationSystem.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--CSS Style Sheet--%>
    <link href="StyleSheets/Majorstyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="major">
        <div class="container">

            <div class="row back-image" style="background-image: url('Images/majorbackground.jpg');">
                <h2 class="majorName">Business Information System</h2>
            </div>

            <div class="row">
                <nav class="navbar navbar-expand-lg navbar-light">
                    <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>

                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav mr-auto">
                            <li class="nav-item">
                                <a class="nav-link" onclick="showPanel(event, 'ObligatoryU')" id="defaultOpen">Obligatory University Requirements</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" onclick="showPanel(event, 'ElectiveU')">Elective University Requirements</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" onclick="showPanel(event, 'ObligatoryF')">Obligatory Faculty Requirements</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" onclick="showPanel(event, 'ObligatoryS')">Obligatory Specialization Requirements</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" onclick="showPanel(event, 'ElectiveS')">Elective Specialization Requirements</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" onclick="showPanel(event, 'General')">General Requirements</a>
                            </li>
                        </ul>
                    </div>

                </nav>
            </div>

            <div class="row">
                <!-- *** First Panal *** -->
                <div id="ObligatoryU" class="col-lg-12 mx-auto">
                    <h3>Obligatory University Requirements</h3>
                    <ul id="ul1" class="col-lg-11" runat="server">

                    </ul>
                </div>

                <!-- *** Second Panal *** -->
                <div id="ElectiveU" class="col-lg-12 mx-auto">
                    <h3>Elective University Requirements</h3>
                    <ul id="ul2" class="col-lg-11" runat="server">

                    </ul>
                </div>

                <!-- *** Third Panal *** -->
                <div id="ObligatoryF" class="col-lg-12 mx-auto">
                    <h3>Obligatory Faculty Requirements</h3>
                    <ul id="ul3" class="col-lg-11" runat="server">

                    </ul>
                </div>

                <!-- *** Fourth Panal *** -->
                <div id="ObligatoryS" class="col-lg-12 mx-auto">
                    <h3>Obligatory Specialization Requirements</h3>
                    <ul id="ul4" class="col-lg-11" runat="server">

                    </ul>
                </div>

                <!-- *** Fifth Panal *** -->
                <div id="ElectiveS" class="col-lg-12 mx-auto">
                    <h3>Elective Specialization Requirements</h3>
                    <ul id="ul5" class="col-lg-11" runat="server">
                        

                    </ul>
                </div>

                <!-- *** Sixth Panal *** -->
                <div id="General" class="col-lg-12 mx-auto">
                    <h3>General Requirements</h3>
                    <ul id="ul6" class="col-lg-11" runat="server">

                    </ul>
                </div>

            </div>

            <!-- *** The Modal *** -->
            <div id="ModalID" class="modal">
                <div class="modal-content">
                    <div class="modal-header">
                        <span class="close">&times;</span>
                        <h2></h2>
                    </div>
                    <p></p>
                    <div class="modal-footer">
                        <h3 class="CHSTD"></h3>
                        <button id="btnSyllabus" class="btnM">Syllabus</button>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
