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
                    <img src="imgs/digital-inventory%20(2).png"  width= "150px" />
                    <h4>Digital Book Inventory</h4>
                    <p>Our Digital Book Inventory feature allows you to keep track of all your books in one place, making it easy to manage and organize your collection.
                    </p>
                </div>
            </div>


        </div>

    </section>

    <section>
        <img src="imgs/in-homepage-banner.png" style ="object-fit: cover; width: 100%; height: 100%;" />
    </section>

</asp:Content>
