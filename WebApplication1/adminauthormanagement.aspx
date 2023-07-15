<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminauthormanagement.aspx.cs" Inherits="WebApplication1.adminauthormanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();


        });

    </script>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br /><br /><div class ="container">
        <div class="row">

            <div class ="col-md-5">

                <div class="card border shadow-sm rounded-4">


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


                        <br /><div class="row">
                            <div class="col-md-4">
                                <label>Author ID</label>
                                <div class ="form-group">
                                    <div class ="input-group">
                                    <asp:TextBox CssClass ="form-control" ID="TextBox3" runat="server" placeholder ="ID"></asp:TextBox>
                                    <asp:Button class="btn btn-primary hover:-translate-y-0.5 transition-all duration-200 btn-slide" ID="Button21" runat="server" Text="Go" OnClick="Button21_Click"/>
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






                     




                        <br /><br /><br /><br /><div class="row">
                            <div class="col-4">
                                <asp:Button class="btn btn-success btn-lg btn-block"  ID="Button2" runat="server" Text="Add" OnClick="Button2_Click" />

                            </div>

                            <div class="col-4">
                                <asp:Button class="btn btn-primary btn-lg btn-block"  ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" />

                            </div>

                            <div class="col-4">
                                <asp:Button class="btn btn-danger btn-lg btn-block"  ID="Button5" runat="server" Text="Delete" OnClick="Button5_Click"/>

                            </div>

                    </div>

                        

                     


                </div>

                    

            </div>
                <a href="homepage.aspx"><< Back to Home</a>
                

        </div>


            <div class="col-md-7">


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
                                    <h4>Author List</h4>
                        
                                </center>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>

                        </div>



                         <div class="row">
                             <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString2 %>" SelectCommand="SELECT * FROM [author_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                
                            
                             <asp:GridView class ="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="author_id" DataSourceID="SqlDataSource1">
                                 <Columns>
                                     <asp:BoundField DataField="author_id" HeaderText="author_id" ReadOnly="True" SortExpression="author_id" />
                                     <asp:BoundField DataField="author_name" HeaderText="author_name" SortExpression="author_name" />
                                 </Columns>
                             </asp:GridView>
                             </div>

                        </div>

                    


                </div>

                    

            </div>

            </div>


    </div>


        </div><br /><br /><br /><br /><br /><br />


</asp:Content>
