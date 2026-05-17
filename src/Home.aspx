<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="RecommendationSystem.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--CSS Style Sheet--%>
    <link href="StyleSheets/blok.css" rel="stylesheet" />
    <link href="StyleSheets/Homesheet.css" rel="stylesheet" />
    <link href="StyleSheets/Help.css" rel="stylesheet" />
    <link rel="icon" href="./images/icon.ico" />
    <link href="StyleSheets/style.css" rel="stylesheet" />
        <%--JavaScript--%>
    <script src='https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <center>
		   <!-- Start Section -->
  <div class="container section" >

        <div class="info">
            <div class="title">
                <h2>Jordan University Recommendation </h2>
            </div>
            <p>This Jordan University Recommendation System</p>
            <div class="yourEmail d-flex">
                <form>
             
                   

                </form>
            </div>
        </div>
        <div>
            <img src="./images/University_of_jordan_logo.png" />
        </div>
       
    </div>
 
    <!-- ENd Section -->

<!-- Start How IT Works -->
       <div class="col-md-12 text-center" id="how">

          <h2  style ="user-select:none">How It Works</h2>
          
        </div>
  <section class="section-white" id="about">

    <!--begin container -->
    <div class="container" style="display: block;">

      <!--begin Boxs -->
      <div class="Boxs">

        <!--Box One -->
        <div class="box">
         
          <div class="main-services">

           <%--<i class="fa-solid fa-star fa-xl"></i>--%>
            <img src="Images/01.png" />
            <h4>Getting Your Data</h4>   <!--Exapmle-->

            <p>We will automatcley get your data from the system to process it with our AI system.</p>   <!--Exapmle-->
             
          </div>

        </div>
        <!--Box One -->

        <!--Box Two -->
        <div class="box">

          <div class="main-services">
               <img src="Images/02.png" />
           <%--<i class="fa-solid fa-circle-h fa-xl"></i>--%>

            <h4>Proccesing the Data</h4>  <!--Exapmle-->

            <p>Our AI will procees the data to provide you with best results.</p>  <!--Exapmle-->
            
          </div>

        </div>
        <!--Box Two -->

        <!--Box Three -->
        <div class="box">

          <div class="main-services">
               <img src="Images/03.png" />
            <%--<i class="fa-solid fa-clock-rotate-left fa-xl"></i>--%>

            <h4>Show the best schadule</h4>  <!--Exapmle-->

            <p>You will get the best study schedule, based on your data.</p>  <!--Exapmle-->
            
          </div>

        </div>
        <!--Box Three -->
     
      </div>
      <!--end row -->
  
    </div>
    <!--end container -->

  </section>
<!-- ENd How IT Works -->




    <!-- Start Servies -->

        <br /><br /><br /><br />

        <h2 id="servies"  style ="user-select:none">Servies</h2>
     <!-- intro blocks -->
  <section id="features" class="l-marketing-feature-briefs" data-url-path="features" >
  
  <!-- intro block1 -->
  <div class="marketing-feature-brief">
    <a href="login.html" class="marketing-feature-brief__graphic js-scroll-link" style="background-image: url(../images/reward.png)";>
           <img src="Images/reward.png" style="width:100px"/>
    </a>
    <h2 class="marketing-feature-brief__heading"><a href="login.html" class="js-scroll-link">Recommended Schedule</a></h2>
    <p class="marketing-feature-brief__description">When clicked Recommended Schedule, the callerThey can view their course plan.</p>
  </div>
  <!-- End of block1 -->
  
  
   <!-- intro block2 -->
   <div class="marketing-feature-brief ";>
    <a href="login.html" class="marketing-feature-brief__graphic js-scroll-link" style="background-image:url(Images/1.png)">
            <img src="./images/majority.png"/ style="width:100px">
    </a>
    <h2 class="marketing-feature-brief__heading"><a href="login.html" class="js-scroll-link" >MajorPlan</a></h2>
    <p class="marketing-feature-brief__description">When you click Master Plan on the navigation bar, the studentThey can view their course plan.</p>
   </div>
  <!-- End of block2 -->
  
  
   <!-- intro block3 -->
   <div class="marketing-feature-brief">
    <a " class="marketing-feature-brief__graphic js-scroll-link" style="background-image: url(Images/r3.png ">
            <img src="./images/folders.png"/ style="width:100px">

    </a>
    <h2 class="marketing-feature-brief__heading"><a href="login.html" class="js-scroll-link">Documentation For Everything</a></h2>
    <p class="marketing-feature-brief__description">We've written extensive documentation for our plans, so you never have to worry about anything.</p>
   </div>
   <!-- End of block3 -->
  
  
   <!-- intro block4 -->
   <div class="marketing-feature-brief">
    <a href="login.html" class="marketing-feature-brief__graphic js-scroll-link" style="background-image: url(Imges/r4.png)">
            <img src="./images/continuous-improvement.png"/ style="width:100px">

    </a>
    <h2 class="marketing-feature-brief__heading"><a href="login.html" class="js-scroll-link">Continuous Updates</a></h2>
    <p class="marketing-feature-brief__description">We continually deploy improvements and new updates to Recommendation System .</p>
   </div>
    <!-- End of block4 -->
  
</section>
  
<!-- End of intro blocks -->

   <!-- ENd Servies -->



<!-- Start About  -->
           <h2 id="abut-us"  style ="user-select:none" >About Us</h2>
       <div class="about-Us" style="background-color: #eee !important;">
           <div class="d-flex box" style="align-content:center;gap: 100px;">
               <br /><br />
              <div class="about-box" style="    box-shadow: inset -4px 1px 23px 4px #ddd;    "   >
                  <%--<img src="./images/m1.png"/>--%>
                  <img src="Images/excited.png" />

                  <br /><br />
                  <p>
                      It is a platform affiliated with the University of Jordan.
                      The platform markets services through its platform. The mission of our site is
                      to simplify and improve the lives of students and build a permanent organization that
                      is a source of inspiration. It was created Our services in March 2023.</p>
              </div>
                   <div class="about-box"  style="    box-shadow: inset -4px 1px 23px 4px #ddd;    "   >
                  <%--<img src="./images/m2.png"/>--%>
                       <img src="Images/partners.png" /><br />
                       <br />
                  <p>
                      This project is set to design and develop a recommendation system for the student
                      registration website at Jordan University to assist students in the registration process 
                      by analyzing the course schedule and preparing recommended compatible timed schedules for 
                      students each term using machine learning and data analysis technologies. The system will treat each student as
                      separate case, considering several factors, and use historical recording data that should make the Recommendations more accurate.</p>
              </div>
           </div>      
</div>

<!-- end About  -->


<!-- start Help Center -->
  <br />
<br />
<br />
<divs    role="main" id="help"   >
	<h1  style = "color: #b1c0cc ; user-select:none " >Hi,how can we help?   </h1>

<br />
	<div class="faq">
		<input type="search" value="" placeholder="Type some keywords (e.g. Why, How, What)" />
		<div class="box"  >
			<ul>
				<li id="faq-1">
					<h2 ><a  href ="#faq-1"    style = "color: #b1c0cc" > Why should I use your site?</a></h2>
					<div>
						<p>Artificial intelligence often uses machine learning and big analytics techniques to index and categorize information about the course materials to be downloaded. Data and information are collected from multiple sources and then this information is analyzed, classified and organized according to the student's need.</p>
					</div>
				</li>
				<li id="faq-2">			
						<h2><a href="#faq-5" style = "color: #b1c0cc" >Does this site support all university majors?</a></h2>
					<div>
                      <p>	Some university majors may be supported, but not all. We are working to support all university majors as soon as possible.</p>					
					</div>	
					
				</li>
				<li id="faq-3">
					<h2><a href="#faq-3" style = "color: #b1c0cc" >Is there any cost to use this site?</a></h2>
					<div>
                      <p>	No, it is completely free. It is affiliated with the University of Jordan, Department of Business Technology.</p>					
					</div>
				</li>
				
				<li id="faq-5" >
				<h2><a href="#faq-2" style = "color: #b1c0cc ">Can AI be used to facilitate the process of downloading university materials?</a></h2>
					<div>
                      <p>Not entirely reliable. Artificial intelligence can analyze and index university materials and provide links to download them, but the availability of these materials depends on their availability from official agencies and trusted sources. In addition, there may be legal or technical restrictions on the downloading of certain University materials.</p>		
				</div>
                        </li>
				
				
				
				
				
			</ul>
			<ul>
				<li id="faq-13">
					<h2><a href="#faq-13" style = "color: #b1c0cc">Are there prerequisites for registering for certain courses?</a></h2>
					<div>
						<p>Yes, enrollment in some courses may require the fulfillment of prerequisites, such as passing other courses or passing a specific test.Yes, enrollment in some courses may require the fulfillment of prerequisites, such as passing other courses or passing a specific test.</p>
					</div>
				</li>
				<li id="faq-15" >
					<h2><a href="#faq-15" style = "color: #b1c0cc" >Can I use this website on computers and smartphones?</a></h2>
					<div>
						<p>Yes, it supports all smart devices.</p>
					</div>
				</li>
				<li id="faq-16">
					<h2><a href="#faq-16" style = "color: #b1c0cc">What is the deadline for recording materials?</a></h2>
					<div>
						<p>Appointments are announced on the University of Jordan website.</p>
					</div>
				</li>
				<li id="faq-17">
					<h2><a href="#faq-17" style = "color: #b1c0cc">How can I find out which subjects are compatible with my study plan?
                        </a></h2>
					<div>
						<p>  The suggested plan is displayed on the Recommended Schedule page. </p>
					</div>
				</li>
				
				
				
				
				
			</ul>
		</div>
        </div>

           
		
		<div class="faq__notfound"><p>No matches were found&hellip; Try &ldquo;giza&rdquo;.</p></div>
	</divs>

	 
<script src="Scripts/Help.js"></script>
</div>
<!-- ENd Help Center -->



    </center> 
    <br />
</asp:Content>

