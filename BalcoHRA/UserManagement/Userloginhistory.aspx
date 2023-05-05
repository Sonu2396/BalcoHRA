<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Userloginhistory.aspx.cs" Inherits="BalcoHRA.UserManagement.Userloginhistory" %>
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
                    <h2>Login History</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../../Home.aspx">Home</a>
                        </li>
                        
                         <li class="breadcrumb-item">
                            <a>User Management</a>
                        </li>
                        <li class="breadcrumb-item active">
                            <strong>Login History</strong>
                        </li>
                    </ol>
                </div>
                <div class="col-lg-2">

                </div>
            </div>

   
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="PnlView" Visible="true">
                 <div class="row wrapper wrapper-content animated fadeInRight">
                     <div class="col-lg-12">
                <div class="ibox ">
                        <div class="ibox-title">
                            <h5>Login History</h5>
                            <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                            
                        </div>
                        </div>
                    <div class="ibox-content">
                         
                            <div class="row form-group">
                                <div class="col-lg-1">
                                    <label>Date</label>
                                </div>
                                <div class="col-lg-2">
                                    
                                                   <asp:TextBox runat="server" ID="txtdate" CssClass="form-control" TabIndex="1" AutoPostBack="true" OnTextChanged="txtdate_TextChanged" ></asp:TextBox>
                                                  
                                            <cc1:CalendarExtender ID="CalendarExtender" runat="server" Format="yyyy-MM-dd" PopupButtonID="imgPopup" TargetControlID="txtdate" PopupPosition="BottomRight">
                                                    </cc1:CalendarExtender>
                                </div>
                            </div>

                        <div class="row form-group">
                                            <div class="col-lg-12">
                                                
                                                <asp:GridView ID="GridView1" CssClass="table table-responsive-lg table-hover" runat="server" AllowSorting="True" AutoGenerateColumns="False"    TabIndex="14" DataKeyNames="LoginId"   >
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Slno">
                                                                        <ItemTemplate>
                                                                            <%#Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="Employee Name"  DataField="UserName"     />
                                                                    <asp:BoundField HeaderText="User Id"  DataField="LoginId"     />
                                                                    <asp:BoundField HeaderText="Times of Login"  DataField="LOGINTIMES"     />
                                                                </Columns>                               
                                                     <HeaderStyle Height="30px" CssClass="bg-primary" />
                                                 </asp:GridView>
                                                   


                                            </div>
                                        
                                                   

                                        </div>
                                        
                         </div>
                    </div>
                         </div>
                     </div>
            </asp:Panel>
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

