<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="usersignup.aspx.cs" Inherits="WebApplication1.usersignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <div class ="container">
        <div class="row">

            <div class ="col-md-8 mx-auto">

                <div class="card rounded-lg">


                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/user-register.png" width="100px" />
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>User SignUp</h4>
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                </hr>
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                                <div class ="form-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox3" runat="server" placeholder ="Full Name"></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Date of birth</label>
                                <div class ="form-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox2" runat="server" placeholder ="Date of birth" TextMode="Date"></asp:TextBox>

                                </div>
                            </div>


                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                <label>Contact No</label>
                                <div class ="form-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox1" runat="server" placeholder ="Contact No" TextMode="Number" ></asp:TextBox>

                                </div>
                            </div>

                            <div class="col-md-6">
                                <label>Email ID</label>
                                <div class ="form-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox4" runat="server" placeholder ="Email ID" TextMode="Email"></asp:TextBox>

                                </div>
                            </div>


                        </div>

                         <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class ="form-group">
                                    <asp:DropDownList class="form-control" ID="DropDownList1" runat="server">
                                        
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="Punjab" Value="Punjab" />
                                        <asp:ListItem Text="Sindh" Value="Sindh" />
                                        <asp:ListItem Text="KPK" Value="KPK" />
                                        <asp:ListItem Text="Balochistan" Value="Balochistan" />
                                        <asp:ListItem Text="Gilgit-baltistan" Value="Gilgit-baltistan" />
                                        <asp:ListItem Text="Azad jammu and Kashmir" Value="Azad jammu and kashmir" />

                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Date of birth</label>
                                <div class ="form-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox6" runat="server" placeholder ="Date of birth" TextMode="Date"></asp:TextBox>

                                </div>
                            </div>

                             <div class="col-md-4">
                                <label>Date of birth</label>
                                <div class ="form-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox7" runat="server" placeholder ="Date of birth" TextMode="Date"></asp:TextBox>

                                </div>
                            </div>


                        </div>


                        <div class="row">
                            <div class="col">
                                

                                

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

                                <style>
                                    @keyframes pulse {
    0% {
      transform: scale(1);
    }
    50% {
      transform: scale(1.05);
    }
    100% {
      transform: scale(1);
    }
  }
  
  .btn-pulse {
    animation: pulse 1s infinite;
  }
  
  @keyframes slideInFromLeft {
    0% {
      transform: translateX(-100%);
      opacity: 0;
    }
    100% {
      transform: translateX(0);
      opacity: 1;
    }
  }
  
  .btn-slide {
    animation: slideInFromLeft 0.5s ease-out;
  }

                                </style>

                                 
                                <div class ="form-group">
    <button class="btn btn-primary btn-block btn-3d rounded-lg hover:-translate-y-0.5 transition-all duration-200 btn-slide" type="button">Login</button>
</div>

<div class ="form-group">
    <a href="usersignup.aspx"><input class="btn btn-info btn-block btn-3d hover:-translate-y-0.5 transition-all duration-200 btn-slide" id="Button2" type="button" value="Sign Up"/></a>
</div>


                            </div>

                    </div>


                </div>

                    

            </div>
                <a href="homepage.aspx"><< Back to Home</a></br></br></br>
                

        </div>

    </div>

        </div>



</asp:Content>
