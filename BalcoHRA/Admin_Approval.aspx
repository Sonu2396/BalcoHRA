<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin_Approval.aspx.cs" Inherits="BalcoHRA.Admin_Approval" %>

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
                    <h2>Daily Plan - Admin Approval</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../../Home.aspx">Home</a>
                        </li>
                        
                    </ol>
                </div>
                <div class="col-lg-2">

                </div>
            </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlEntry" Visible="true">
                <div class="row wrapper wrapper-content animated fadeInRight">
           
            <div class="col-lg-12">
                <div class="ibox ">
                        <div class="ibox-title">
                            <h5>Admin Approval<asp:Label runat="server" ID="lbltransid" Visible="true"></asp:Label></h5>
                            <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                            </div>
                        </div>
             </asp:Panel>


    <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="true">
        <ContentTemplate>
            <div class="row form-group">
            <div class="col-lg-12" >
                <asp:GridView ID="GridView1"  CssClass="table  table-responsive-lg table-hover" runat="server" AllowSorting="True" AutoGenerateColumns="False"  ShowFooter="false"   TabIndex="14" EmptyDataText="No records found......" OnRowDataBound="GridView1_RowDataBound" >
                    <Columns>
                    <asp:BoundField DataField="TransID" HeaderText="ID" />
                    <asp:BoundField DataField="SBU" HeaderText="SBU"  />
                    <asp:BoundField DataField="Area" HeaderText="Area"   />
                    <asp:BoundField DataField="SUBArea" HeaderText="Sub Area"  />
                    <asp:BoundField DataField="JobType" HeaderText="Type of Job"   />
                    <asp:BoundField DataField="JobExecutor" HeaderText="Job Executor Name"   />
                    <asp:BoundField DataField="JobDateTime" HeaderText="Date and Time of Job"   />
                    <asp:BoundField DataField="JobDescription" HeaderText="Job Description"   />
                    

                       
                    <asp:TemplateField HeaderText="Auditor Name" >
                   <ItemTemplate>
                       <asp:Label ID="lblAudname" runat="server" Text='<%# Eval("Auditor") %>' Visible="false"></asp:Label>
                    <%-- <asp:TextBox runat="server" ID="lblAuditor"  Text='<%# Eval("Auditor") %>' ></asp:TextBox>--%>
                     <asp:DropDownList runat="server" ID="ddlAuditor" Width="80%">  
                     </asp:DropDownList>
                        </ItemTemplate>
                    
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="Approve" >
                    <ItemTemplate>

                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                       <ContentTemplate>
                           <asp:Button runat="server" ID="btnApprove" Text="Approve" CssClass="ladda-button btn  btn-primary"   TabIndex="2" OnClick="btnApprove_Click"/>
                           <asp:Button runat="server" ID="btnReject" Text="Reject" CssClass="ladda-button btn  btn-primary"   TabIndex="3" OnClick="btnReject_Click" />
                           
                       </ContentTemplate>
                    </asp:UpdatePanel>
                    </ItemTemplate>
                    </asp:TemplateField>
                                              
                    
                    </Columns>
                    <HeaderStyle CssClass="bg-primary" />
                    <FooterStyle BackColor="LightYellow" Font-Bold="true"/>
         </asp:GridView>
       </div> 
       </div>

        
    </ContentTemplate>
    </asp:UpdatePanel>

       </ContentTemplate>

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