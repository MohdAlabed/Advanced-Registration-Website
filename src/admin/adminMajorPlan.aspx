<%@ Page Title="" Language="C#" MasterPageFile="~/Logedin.Master" AutoEventWireup="true" CodeBehind="adminMajorPlan.aspx.cs" Inherits="RecommendationSystem.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--CSS Style Sheet--%>
    <link href="StyleSheets/Majorstyle.css" rel="stylesheet" />

    <%--jQuery Script--%>
    <script src="jQuery/jquery-3.7.0.js"></script>

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


                        <li id="AddCard1" class="card col-md-2 addCard">
                            <i class="fa-solid fa-plus fa-2xl"></i>
                        </li>
                    </ul>
                </div>

                <!-- *** Second Panal *** -->
                <div id="ElectiveU" class="col-lg-12 mx-auto">
                    <h3>Elective University Requirements</h3>
                    <ul id="ul2" class="col-lg-11" runat="server">

                        <li id="AddCard2" class="card col-md-2 addCard">
                            <i class="fa-solid fa-plus fa-2xl"></i>
                        </li>
                    </ul>
                </div>

                <!-- *** Third Panal *** -->
                <div id="ObligatoryF" class="col-lg-12 mx-auto">
                    <h3>Obligatory Faculty Requirements</h3>
                    <ul id="ul3" class="col-lg-11" runat="server">

                        <li id="AddCard3" class="card col-md-2 addCard">
                            <i class="fa-solid fa-plus fa-2xl"></i>
                        </li>
                    </ul>
                </div>

                <!-- *** Fourth Panal *** -->
                <div id="ObligatoryS" class="col-lg-12 mx-auto">
                    <h3>Obligatory Specialization Requirements</h3>
                    <ul id="ul4" class="col-lg-11" runat="server">

                        <li id="AddCard4" class="card col-md-2 addCard">
                            <i class="fa-solid fa-plus fa-2xl"></i>
                        </li>
                    </ul>
                </div>

                <!-- *** Fifth Panal *** -->
                <div id="ElectiveS" class="col-lg-12 mx-auto">
                    <h3>Elective Specialization Requirements</h3>
                    <ul id="ul5" class="col-lg-11" runat="server">
                        
                        <li id="AddCard5" class="card col-md-2 addCard">
                            <i class="fa-solid fa-plus fa-2xl"></i>
                        </li>
                    </ul>
                </div>

                <!-- *** Sixth Panal *** -->
                <div id="General" class="col-lg-12 mx-auto">
                    <h3>General Requirements</h3>
                    <ul id="ul6" class="col-lg-11" runat="server">

                        <li id="AddCard6" class="card col-md-2 addCard">
                            <i class="fa-solid fa-plus fa-2xl"></i>
                        </li>
                    </ul>
                </div>

            </div>

            <!-- *** The Modal *** -->
            <div id="ModalID" class="modal">
                <div class="modal-content">
                    <div class="modal-header">
                        <span class="close">&times;</span>
                        <input class="form-control upload" ClientIDMode="Static" id="modalName" runat="server" type="text" />
                    </div>
                    <textarea class="form-control" ClientIDMode="Static" id="modalDec" runat="server" rows="10"></textarea>
                    <div class="modal-footer">
                        <input class="form-control upload" ClientIDMode="Static" type="text" id="UploadSyllabus" runat="server" placeholder="Please enter syllabus link URL:" />
                        <input id="modalCredit" class="form-control CRA" ClientIDMode="Static" runat="server" type="text" />
                        <input type="hidden" id="hiddenCourseId" ClientIDMode="Static" runat="server" />
                        <asp:Button ID="EditDescription" runat="server" Text="Edit Information" CssClass="btnA" OnClick="EditDescription_Click" />
                        <asp:Button ID="RemoveCourse" runat="server" Text="Remove Course" CssClass="btnA" OnClick="RemoveCourse_Click" />
                    </div>
                </div>
            </div>

            <div id="ModalAdd" class="modal">
                <div class="modal-content">
                    <div class="modal-header">
                        <span id="closeAdd" class="close">&times;</span>
                        <input id="courseNameAdd" class="form-control upload" clientidmode="Static" runat="server" type="text" placeholder="Course Name" />
                        <asp:RequiredFieldValidator ID="courseNameAddValidator" runat="server" ErrorMessage="Please Fill Course Name" ControlToValidate="courseNameAdd" ValidationGroup="ADDcourse" Display="none"></asp:RequiredFieldValidator>
                    </div>
                    <textarea class="form-control" clientidmode="Static" id="courseDecAdd" runat="server" rows="10" placeholder="Course Description"></textarea>
                    <div class="modal-footer">
                        <input id="UploadSyllabusAdd" class="form-control upload" clientidmode="Static" type="text" runat="server" placeholder="Please enter syllabus link URL:" />

                        <input id="modalCreditAdd" class="form-control" clientidmode="Static" runat="server" type="text" placeholder="CH" pattern="[0-9]+" title="Please enter a numerical value"/>
                        <asp:RequiredFieldValidator ID="modalCreditAddValidator" runat="server" ErrorMessage="Please Enter Course Credit Hours" ControlToValidate="modalCreditAdd" ValidationGroup="ADDcourse" Display="none"></asp:RequiredFieldValidator>
                        <asp:ValidationSummary ID="validationSummary" runat="server" ValidationGroup="ADDcourse" CssClass="validation-error" DisplayMode="List" />
                        <asp:Button ID="addCourse" runat="server" Text="Add Course" CssClass="btnA" OnClick="addCourse_Click" ValidationGroup="ADDcourse" />
                    </div>
                </div>
            </div>

        </div>
    </div>

    <script>
        document.getElementById('AddCard1').onclick = function () {
            openAddModal('AddCard1');
        };

        document.getElementById('AddCard2').onclick = function () {
            openAddModal('AddCard2');
        };

        document.getElementById('AddCard3').onclick = function () {
            openAddModal('AddCard3');
        };

        document.getElementById('AddCard4').onclick = function () {
            openAddModal('AddCard4');
        };

        document.getElementById('AddCard5').onclick = function () {
            openAddModal('AddCard5');
        };

        document.getElementById('AddCard6').onclick = function () {
            openAddModal('AddCard6');
        };

        function openAddModal(courseId) {
            var modal = document.getElementById('ModalAdd');
            var hiddenCourseId = document.getElementById('hiddenCourseId');

            if (hiddenCourseId) {
                hiddenCourseId.value = courseId;
            } else {
                console.log('The element with ID \'hiddenCourseId\' was not found.');
            }

            modal.style.display = 'block';

            var closeButton = document.getElementById('closeAdd');

            closeButton.onclick = function () {
                modal.style.display = 'none';
            };

            window.onclick = function (event) {
                if (event.target === modal) {
                    modal.style.display = 'none';
                }
            };
        }
    </script>

</asp:Content>