<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="WebApplication1.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="h-100">
    <img src="imgs/home-bg.png" class="img-fluid h-100" style="object-fit: cover;" />
</section>


    <section>

        <div class ="container">

            <div class ="row">

                <div class ="col-12">
                    <center>
                    <h2>Our Features</h2>
                    <p>Some primary features are as follow</p>
                    </center>
                </div>
            </div>

            <div class ="row">

                <div class ="col-md-4">
                    <center>
                    <img src="imgs/digital-inventory%20(2).png"  width= "150px" />
                    <h4>Digital Book Inventory</h4>
                    <p class ="text-justify" >Our Digital Book Inventory feature allows you to keep track of all your books in one place, making it easy to manage and organize your collection.
                    </p>
                    </center>
                </div>

                <div class ="col-md-4">
                    <center>
                    <img src="imgs/search-online.png"  width= "150px" />
                    <h4>Search Books</h4>
                    <p class ="text-justify" >Looking for a specific book? Our search feature makes it easy to find what you need. 
                    </p>
                    </center>
                </div>

                <div class ="col-md-4">
                    <center>
                    <img src="imgs/defaulters-list.png"  width= "150px" />
                    <h4>Defaulter List</h4>
                    <p class ="text-justify" >Our Defaulter List feature provides a comprehensive list of individuals and organizations who have defaulted on payments or commitments.
                    </p>
                    </center>
                </div>

            </div>


        </div>

    </section>

    <section>
        <img src="imgs/in-homepage-banner.png" style ="object-fit: cover; width: 100%; height: 100%;" />
    </section>

     <section>

        <div class ="container">

            <div class ="row">

                <div class ="col-12">
                    <center>
                    <h2>Our Process</h2>
                    <p>Streamlining your library experience through our proven process.</p>
                    </center>
                </div>
            </div>

            <div class ="row">

                <div class ="col-md-4">
                    <center>
                    <img src="imgs/signup-pic.png"  width= "150px" height ="150px" />
                    <h4>Sign Up</h4>
                    <p class ="text-justify" >Our Digital Book Inventory feature allows you to keep track of all your books in one place, making it easy to manage and organize your collection.
                    </p>
                    </center>
                </div>

                <div class ="col-md-4">
                    <center>
                    <img src="imgs/search-online.png"  width= "150px" />
                    <h4>Search Books</h4>
                    <p class ="text-justify" >Looking for a specific book? Our search feature makes it easy to find what you need. 
                    </p>
                    </center>
                </div>

                <div class ="col-md-4">
                    <center>
                    <img src="imgs/library.png"  width= "150px" />
                    <h4>Visit Us</h4>
                    <p class ="text-justify" >Our Defaulter List feature provides a comprehensive list of individuals and organizations who have defaulted on payments or commitments.
                    </p>
                    </center>
                </div>

            </div>it


        </div>

    </section>

</asp:Content>
