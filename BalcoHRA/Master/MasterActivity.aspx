<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MasterActivity.aspx.cs" Inherits="BalcoHRA.Master.MasterActivity" %>

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
                    {extend: 'excel', title: 'Activity'},
                    {extend: 'pdf', title: 'Activity'},

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
                    <h2>Activity Master</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../../Home.aspx">Home</a>
                        </li>
                        
                         <li class="breadcrumb-item">
                            <a>Master</a>
                        </li>
                        <li class="breadcrumb-item active">
                            <strong>Activity</strong>
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
                            <h5>Activity Master<asp:Label runat="server" ID="lbltransid" Visible="false"></asp:Label></h5>
                            <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                            
                        </div>
                        </div>
                        <div class="ibox-content">
                            
                                <div class="  form-group" style="color:red;text-align:right">*marks are mandatory fields.</div>
                            <div class=" row form-group"> 
                                <div class="col-lg-2"></div>
                                <div class="col-lg-2"><label>Activity Name</label><label style="color:red">*</label> </div>
                                 <div class="col-lg-6">
                                     <asp:TextBox runat="server" ID="txtname"  placeholder="Activity Name" class="form-control" TabIndex="2"></asp:TextBox>
                                 </div>
                             
                                </div>
                            
                            
                            
                                    
                            
                                 <div class="form-group" style="text-align:center">
                                        <asp:LinkButton runat="server" ID="btnsave"   data-style="expand-right" CssClass="ladda-button btn  btn-primary" OnClick="btnsave_Click"  TabIndex="5" ><i class="fa fa-save" > Save</i></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="btnupdate" data-style="expand-right" CssClass="ladda-button btn  btn-primary" OnClick="btnupdate_Click"  Visible="false" TabIndex="6"  ><i class="fa fa-save" > Update</i></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="btnreset"  CssClass="btn  btn-danger"  OnClick="btnreset_Click" TabIndex="7"><i class="fa fa-refresh"  > Reset</i></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="btnback"  CssClass="btn  btn-warning"  OnClick="btnback_Click"  TabIndex="8"><i class="fa fa-backward"  > Back</i></asp:LinkButton>
                                        
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
           
        </Triggers>
        </asp:UpdatePanel>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="PnlView" Visible="true">
                 <div class="row wrapper wrapper-content animated fadeInRight">
                     <div class="col-lg-12">
                <div class="ibox ">
                        <div class="ibox-title">
                            <h5>Activity Master</h5>
                            <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                            
                        </div>
                        </div>
                    <div class="ibox-content">
                         
                            <div class="form-group" ><asp:LinkButton ID="lnkbtnaddnew"  runat="server" ToolTip="Add new" OnClick="btnadd_Click"><i class="btn btn-primary fa fa-plus"> Add New</i></asp:LinkButton></div>
                                 <div class="table-responsive">
                                     <asp:Repeater ID="Repeater1" runat="server" >
                <HeaderTemplate>
                    <table id="dummyHeader" class="table table-hover  table-bordered  dataTables-example" >
                        <thead>
                            <tr>
                                
                                <th>Id</th>
                                <th>Activity Name</th>
                                <th>Action</th>
                                
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        
                        <td style="width:10%">
                            <asp:Label ID="lblID" runat="server"  Text='<%# Eval("ActivityID") %>'></asp:Label>
                        </td>
                        <td style="width:80%">
                            <asp:Label ID="Labelname" runat="server" Text='<%# Eval("ActivityName") %>'></asp:Label>
                        </td>
                        >
                       
                        
                        <td style="width:10%">
                           <div class="btn-group">
                               <asp:LinkButton ID="lnkbtnedit" CommandName="Edit" CommandArgument='<%# Eval("ActivityID") %>'  runat="server" ToolTip="Edit" OnClick="lnkbtnedit_Click"><i class="btn btn-primary fa fa-edit"> </i></asp:LinkButton>
                               <asp:LinkButton ID="lnkbtndelete" CommandName="Delete" CommandArgument='<%# Eval("ActivityID") %>'  runat="server" ToolTip="Delete" OnClick="lnkbtndelete_Click" OnClientClick="javascript:return confirm('Are you sure you want to delete this?');"><i class="btn btn-danger fa fa-trash"></i></asp:LinkButton>
                           </div>
                            
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


