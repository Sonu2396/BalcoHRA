<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="BalcoHRA.UserManagement.UserRegistration" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <!-- Mainly scripts -->
    <script src="../../js/jquery-3.1.1.min.js"></script>
    <script src="../../js/popper.min.js"></script>
    <script src="../../js/bootstrap.js"></script>
    <script src="../../js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="../../js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
     <link href="../../css/plugins/ladda/ladda-themeless.min.css" rel="stylesheet">

    <!-- Custom and plugin javascript -->
    <script src="../../js/inspinia.js"></script>
    <script src="../../js/plugins/pace/pace.min.js"></script>
    <!-- Sweet Alert -->
    <link href="../../css/plugins/sweetalert/sweetalert.css" rel="stylesheet">

    <!-- iCheck -->
    <script src="../../js/plugins/iCheck/icheck.min.js"></script>
        <script>
            $(document).ready(function () {
                $('.i-checks').iCheck({
                    checkboxClass: 'icheckbox_square-green',
                    radioClass: 'iradio_square-green',
                });
            });
        </script>
     <!-- Table Script -->
    <link href="../../css/plugins/dataTables/datatables.min.css" rel="stylesheet">
     <script src="../../js/plugins/dataTables/datatables.min.js"></script>
    <script src="../../js/plugins/dataTables/dataTables.bootstrap4.min.js"></script>

    <script>
        $(document).ready(function(){
            $('.dataTables-example').DataTable({
                pageLength: 10,
                responsive: true,
                dom: '<"html5buttons"B>lTfgitp',
                buttons: [
                    { extend: 'copy'},
                    {extend: 'csv'},
                    {extend: 'excel', title: 'Ladle'},
                    {extend: 'pdf', title: 'Ladle'},

                    {extend: 'print',
                     customize: function (win){
                            $(win.document.body).addClass('white-bg');
                            $(win.document.body).css('font-size', '10px');

                            $(win.document.body).find('table')
                                    .addClass('compact')
                                    .css('font-size', 'inherit');
                    }
                    }
                ]

            });

        });

    </script>


    <link href="../../css/plugins/iCheck/custom.css" rel="stylesheet"/>
    <link href="../../css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet" />
    <link href="../../css/plugins/ladda/ladda-themeless.min.css" rel="stylesheet">
    <!-- Custom and plugin javascript -->
    <script src="../../js/inspinia.js"></script>
    <script src="../../js/plugins/pace/pace.min.js"></script>

    <!-- Ladda -->
    <script src="../../js/plugins/ladda/spin.min.js"></script>
    <script src="../../js/plugins/ladda/ladda.min.js"></script>
    <script src="../../js/plugins/ladda/ladda.jquery.min.js"></script>

<script>

    $(document).ready(function (){

        // Bind normal buttons
        Ladda.bind( '.ladda-button',{ timeout: 2000 });

        // Bind progress buttons and simulate loading progress
        Ladda.bind( '.progress-demo .ladda-button',{
            callback: function( instance ){
                var progress = 0;
                var interval = setInterval( function(){
                    progress = Math.min( progress + Math.random() * 0.1, 1 );
                    instance.setProgress( progress );

                    if( progress === 1 ){
                        instance.stop();
                        clearInterval( interval );
                    }
                }, 200 );
            }
        });


        var l = $( '.ladda-button-demo' ).ladda();

        l.click(function(){
            // Start loading
            l.ladda( 'start' );

            // Timeout example
            // Do something in backend and then stop ladda
            setTimeout(function(){
                l.ladda('stop');
            },12000)


        });

    });

   

</script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>User Registration</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../../Home.aspx">Home</a>
                        </li>
                        
                         <li class="breadcrumb-item">
                            <a>User Management</a>
                        </li>
                        <li class="breadcrumb-item active">
                            <strong>User Registration</strong>
                        </li>
                    </ol>
                </div>
                <div class="col-lg-2">

                </div>
            </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlEntry" Visible="false">
                <div class="row wrapper wrapper-content animated fadeInRight">
           
            <div class="col-lg-12">
                <div class="ibox ">
                        <div class="ibox-title">
                            <h5>User Registration<asp:Label runat="server" ID="lbltransid" Visible="false"></asp:Label></h5>
                            <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                            
                        </div>
                        </div>
                        <div class="ibox-content">
                            
                                <div class="  form-group" style="color:red;text-align:right">*marks are mandatory fields.</div>
                            <div class="row form-group">
                                 <div class="col-lg-4">
                                     <label>User Type</label><label style="color:red">*</label>  
                                     <asp:DropDownList runat="server" ID="ddlusertype" TabIndex="1"  class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlusertype_SelectedIndexChanged">
                                         <asp:ListItem Value="0">Select</asp:ListItem>
                                          <asp:ListItem Value="1">Employee</asp:ListItem>
                                          <asp:ListItem Value="2">Business Partner</asp:ListItem>
                                     </asp:DropDownList>
                                 </div>
                                <div class="col-lg-4">
                                    <label>Employee Id</label><label style="color:red">*</label>  
                                    <asp:TextBox runat="server" ID="txtempid"  placeholder="Enter Employee Id" class="form-control" TabIndex="2" AutoPostBack="true" OnTextChanged="txtempid_TextChanged"></asp:TextBox>
                                </div>
                                 <div class="col-lg-4">
                                    <label>Employee Name</label><label style="color:red">*</label>  
                                    <asp:TextBox runat="server" ID="txtempname"  placeholder="Enter Employee Name" class="form-control" TabIndex="3" ></asp:TextBox>
                                </div>
                                
                               
                            </div>
                            

                            <div class="row form-group">
                                 <div class="col-lg-3">
                                     <label>Mobile Number</label><label style="color:red">*</label>  
                                      <asp:TextBox runat="server" ID="txtmob"  placeholder="Enter Mobile No " class="form-control" TabIndex="5" MaxLength="20"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"  FilterType="Custom"    
                                     FilterMode="ValidChars"  ValidChars="+0123456789"    TargetControlID="txtmob" />
                                 </div>
                                <div class="col-lg-3">
                                    <label>Email Id</label><label style="color:red">*</label>  
                                    <asp:TextBox runat="server" ID="txtemail"  placeholder="Enter Emil Id" class="form-control" TabIndex="6" ></asp:TextBox>
                                </div>
                                <div class="col-lg-3">
                                    <label>Password</label><label style="color:red">*</label>  
                                   <asp:TextBox runat="server" ID="txtpassword"  placeholder="Enter Password" class="form-control" TabIndex="7" ></asp:TextBox>
                                </div>
                                 
                               
                            </div>
                            

                             <div class="row form-group">
                                 <div class="col-lg-12" style="overflow:scroll">
                                     <label>Assign Role</label>
                                     <asp:CheckBoxList runat="server" ID="chklistrole" RepeatDirection="Horizontal" CssClass="table table-responsive-lg table-bordered" ></asp:CheckBoxList>
                                 </div>
                                 </div>
                                    <div class="form-group" style="text-align:center">
                                        <asp:LinkButton runat="server" ID="btnsave"   data-style="expand-right" CssClass="ladda-button btn  btn-primary"   TabIndex="9" OnClick="btnsave_Click" ><i class="fa fa-save" > Save</i></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="btnupdate" data-style="expand-right" CssClass="ladda-button btn  btn-primary"  Visible="false" TabIndex="10" OnClick="btnupdate_Click"  ><i class="fa fa-save" > Update</i></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="btnreset"  CssClass="btn  btn-danger"  TabIndex="11" OnClick="btnreset_Click"><i class="fa fa-refresh"  > Reset</i></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="btnback"  CssClass="btn  btn-warning"    TabIndex="12" OnClick="btnback_Click"><i class="fa fa-backward"  > Back</i></asp:LinkButton>
                                        
                                    </div>
                             <div class="col-sm-12 form-group" style="text-align:center">
                                                                                    <asp:UpdateProgress ID="UpdWaitImage" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="true">
                                                                                <ProgressTemplate>
                                                                                   <i class="fa fa-spinner fa-spin" style="font-size:20px;color:blue"></i>
                                                                                <asp:Label ID="lbl" runat="server" Font-Bold="true" Font-Size="15px" Text="Processing Data, Please Wait......"> </asp:Label>
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>
                            
                        </div>
                     
                    </div>
            </div>

            
       
        </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnback" />
            <asp:PostBackTrigger ControlID="btnupdate" />
            <asp:PostBackTrigger ControlID="btnsave" />
            <asp:PostBackTrigger ControlID="btnreset" />
          
            <asp:PostBackTrigger ControlID="txtempid" />
        
        </Triggers>
        </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="PnlView" Visible="true">
                 <div class="row wrapper wrapper-content animated fadeInRight">
                     <div class="col-lg-12">
                <div class="ibox ">
                        <div class="ibox-title">
                            <h5>User List</h5>
                            <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                            
                        </div>
                        </div>
                    <div class="ibox-content">
                         
                            <div class="form-group" ><asp:LinkButton ID="lnkbtnaddnew"  runat="server" ToolTip="Add new" OnClick="lnkbtnaddnew_Click" ><i class="btn btn-primary fa fa-plus"> Add New</i></asp:LinkButton></div>
                                 <div class="table-responsive">
                                     <asp:Repeater ID="Repeater1" runat="server" >
                <HeaderTemplate>
                    <table id="dummyHeader" class="table table-hover  table-bordered  dataTables-example" >
                        <thead>
                            <tr>
                                
                                <th>Id</th>
                                <th>User Type</th>
                                <th>Employee Id</th>
                                <th>Employee Name</th>
                                <th>Role Name</th>
                                <th>Email Id</th>
                                <th>Mobile No</th>
                                <th>Department</th>
                                <th>Edit</th>
                                <th>Delete</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                         
                        <td style="width:5%">
                            <asp:Label ID="lblID" runat="server"  Text='<%# Eval("Id") %>'></asp:Label>
                        </td>
                         <td style="width:10%">
                            <asp:Label ID="lblpotline" runat="server" Text='<%# Eval("USERTYPE") %>'></asp:Label>
                        </td>
                        <td style="width:10%">
                            <asp:Label ID="lblladlename" runat="server" Text='<%# Eval("EMPID") %>'></asp:Label>
                        </td>
                        <td style="width:15%">
                            <asp:Label ID="lblcapacity" runat="server" Text='<%# Eval("USERNAME") %>'></asp:Label>
                        </td>
                         <td style="width:10%">
                            <asp:Label ID="lblemptycapacity" runat="server" Text='<%# Eval("ROLENAME") %>'></asp:Label>
                        </td>
                         <td style="width:15%">
                            <asp:Label ID="lbltarewt" runat="server" Text='<%# Eval("EMAILID") %>'></asp:Label>
                        </td>
                         <td style="width:10%">
                            <asp:Label ID="lblslipno" runat="server" Text='<%# Eval("MOBILENO") %>'></asp:Label>
                        </td>
                        
                         <td style="width:10%">
                            <asp:Label ID="lbldept" runat="server" Text='<%# Eval("USERLOCATION") %>'></asp:Label>
                        </td>
                        
                     
                        <td style="width:5%">
                           
                            <asp:LinkButton ID="lnkbtnedit" CommandName="Edit" CommandArgument='<%# Eval("ID") %>'  runat="server" ToolTip="Edit" OnClick="lnkbtnedit_Click" ><i class="btn btn-primary fa fa-edit"> </i></asp:LinkButton>
                            
                        </td>
                        <td style="width:5%">
                           
                            <asp:LinkButton ID="lnkbtndelete" CommandName="Delete" CommandArgument='<%# Eval("ID") %>'  runat="server" ToolTip="Delete" OnClick="lnkbtndelete_Click" OnClientClick="javascript:return confirm('Are you sure you want to delete this?');"><i class="btn btn-danger fa fa-trash"></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

                                     
                                     </div>
                                        
                         </div>
                    </div>
                         </div>
                     </div>
            </asp:Panel>
        </ContentTemplate>
         <Triggers>
             <asp:PostBackTrigger ControlID="lnkbtnaddnew" />
         </Triggers>
        </asp:UpdatePanel>
        
   <!-- Custom and plugin javascript -->
    <script src="../../js/inspinia.js"></script>
    <script src="../../js/plugins/pace/pace.min.js"></script>
     <!-- Sweet alert -->
    <script src="../../js/plugins/sweetalert/sweetalert.min.js"></script>
   
    <script type="text/javascript">
        function successalert(Title,Msg,SType ) {
            swal({
               title: Title,
                text: Msg,
                type: SType
            });
        };
        
    </script>
</asp:Content>

