<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="WebApplication1.adminauthormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class ="container">
        <div class="row">

            <div class ="col-md-6">

                <div class="card shadow-sm rounded">


                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/adminauthor.png" width="100px" />
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Author Details</h4>

                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>

                        </div>


                        <div class="row">
                            <div class="col-md-4">
                                <label>Author ID</label>
                                <div class ="form-group">
                                    <div class ="input-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox3" runat="server" placeholder ="ID"></asp:TextBox>
                                    <asp:Button class="btn btn-primary hover:-translate-y-0.5 transition-all duration-200 btn-slide" ID="Button21" runat="server" Text="Go"/>
                                        </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Author Name</label>
                                <div class ="form-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox2" runat="server" placeholder ="Name"></asp:TextBox>

                                </div>
                            </div>


                        </div>






                     




                        <div class="row">
                            <div class="col-4">
                                <asp:Button class="btn btn-success btn-lg btn-block"  ID="Button2" runat="server" Text="Add" />

                            </div>

                            <div class="col-4">
                                <asp:Button class="btn btn-primary btn-lg btn-block"  ID="Button1" runat="server" Text="Update" />

                            </div>

                            <div class="col-4">
                                <asp:Button class="btn btn-danger btn-lg btn-block"  ID="Button5" runat="server" Text="Delete" />

                            </div>

                    </div>

                        

                     


                </div>

                    

            </div>
                <a href="homepage.aspx"><< Back to Home</a>
                

        </div>


            <div class="col-md-6">


                <div class="card border-0 bg-light shadow-sm rounded-3">

                    <style>
      .card {
        transition: transform 0.2s ease-in-out;
      }

      .card:hover {
        transform: translateY(-5px);
      }

      .card-body {
        padding: 1.5rem;
      }

      .card-title {
        font-size: 1.25rem;
        font-weight: 600;
        margin-bottom: 0.75rem;
      }

      .card-text {
        font-size: 1rem;
        color: #6c757d;
      }
    </style>


                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="imgs/library.png" width="100px" />
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Your Issued Books</h4>
                            
                                    <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="your books info"></asp:Label>


                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>

                        </div>



                         <div class="row">
                            <div class="col">
                                
                            </div>
                             <asp:GridView class ="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                             

                        </div>

                    


                </div>

                    

            </div>

            </div>


    </div>


        </div><br /><br /><br /><br /><br /><br />


</asp:Content>
