<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="WebApplication1.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class ="container">
        <div class="row">

            <div class ="col-md-6 mx-auto">

                <div class ="card">


                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/general-user.png" width ="150px"/>
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
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

                                <div class ="form-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox1" runat="server" placeholder ="Member ID"></asp:TextBox>

                                </div>

                            </div>

                    </div>


                </div>

            </div>

        </div>

    </div>


</asp:Content>
