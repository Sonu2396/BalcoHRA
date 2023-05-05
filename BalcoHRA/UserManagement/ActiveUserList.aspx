<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ActiveUserList.aspx.cs" Inherits="BalcoHRA.UserManagement.ActiveUserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/bootstrap.min.css" rel="stylesheet">
    <link href="../../font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="../../css/animate.css" rel="stylesheet">
    <link href="../../css/style.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row wrapper wrapper-content animated fadeInRight">
     <div class="row">
                                            <div class="col-lg-12">
                                                
                                                <asp:DataList ID="DataList1" runat="server" HorizontalAlign="Left" RepeatColumns="3" Width="100%" OnItemCommand="DataList1_ItemCommand">
                                                    <ItemTemplate>

                                                      

                                                         <div class="col-lg-12">
                <div class="contact-box center-version">

                    <asp:LinkButton runat="server" ID="btnview"  >

                        <img alt="image" class="rounded-circle" src="../img/profile_small.png">


                        <h3 class="m-b-xs"><strong><%# Eval("USERNAME")  %></strong></h3>
                        <div class="font-bold"><asp:Label runat="server" ID="lbllogiid" Text='<%# Eval("LOGINID")  %>'></asp:Label> </div>
                        <div class="font-bold">Role: <%# Eval("ROLENAME")  %></div>
                        <address class="m-t-md">
                            <strong>Location: <%# Eval("USERLOCATION")  %></strong><br>
                           
                           
                        </address>

                    </asp:LinkButton>
                    <div class="contact-box-footer">
                        <div class="m-t-xs btn-group">
                            <a href=""  class="btn btn-xs btn-white"><i class="fa fa-phone"></i> <%# Eval("MOBILENO")  %> </a>
                            <a href=""  class="btn btn-xs btn-white"><i class="fa fa-envelope"></i> <%# Eval("EMAILID")  %></a>
                            <a href=""  class="btn btn-xs btn-white"><i class="fa fa-user-plus"></i> Follow</a>
                        </div>
                    </div>

                </div>
            </div>
                                                         

                                                        
                                                    </ItemTemplate>
                                                    
                                                </asp:DataList>
                                                   


                                            </div>
                                        
                                                   

                                        </div>
         </div>


      
</asp:Content>
