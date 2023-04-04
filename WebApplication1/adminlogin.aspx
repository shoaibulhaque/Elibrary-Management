<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminlogin.aspx.cs" Inherits="WebApplication1.adminlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <br /><br /><br /><div class ="container">
        <div class="row">

            <div class ="col-md-6 mx-auto">

                <div class="card ">


                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/adminuser.png" width ="150px"/>
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Admin Login</h3>
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                </hr>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                
                                </br><div class ="form-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox1" runat="server" placeholder ="Admin ID"></asp:TextBox>

                                </div>

                                 
                                <div class ="form-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox2" runat="server" placeholder ="password" TextMode="Password"></asp:TextBox>

                                </div></br>

                                <style>
                                    .btn-3d {
    position: relative;
    display: inline-block;
    padding: 10px 20px;
    border: none;
    border-radius: 5px;
    background-color: #395EAB;
    color: #fff;
    text-shadow: 0 1px 1px rgba(0,0,0,0.2);
    box-shadow: 0 4px 0 rgba(0,0,0,0.2), 0 6px 10px rgba(0,0,0,0.2);
    transition: transform 0.2s, box-shadow 0.2s;
    cursor: pointer;
  }
  
  .btn-3d:hover {
    transform: translateY(2px);
    box-shadow: 0 2px 0 rgba(0,0,0,0.2), 0 4px 6px rgba(0,0,0,0.2);
  }
  
  .btn-3d:active {
    transform: translateY(4px);
    box-shadow: 0 0 0 rgba(0,0,0,0.2), 0 2px 4px rgba(0,0,0,0.2);
  }
                                </style>


                                 
                                <div class ="form-group">
                                    <asp:Button ID="Button1" class="btn btn-primary btn-block btn-lg btn-3d" runat="server" Text="Login" />

                                </div>

                                

                            </div>

                    </div>


                </div>

                    

            </div>
                <a href="homepage.aspx"><< Back to Home</a></br></br></br></br><br /><br /><br />
                

        </div>

    </div>

        </div>

</asp:Content>
