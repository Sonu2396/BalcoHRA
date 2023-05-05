<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Job_Entry.aspx.cs" Inherits="BalcoHRA.Job_Entry" %>

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
                    <h2>Daily Plan - Job Entry</h2>
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
                            <h5>Job Entry<asp:Label runat="server" ID="lbltransid" Visible="true"></asp:Label></h5>
                            <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                           
                            
                        </div>
                        </div>

                    </asp:Panel>
          
       <div class="row wrapper wrapper-content animated fadeInRight">
           
       <div class="col-lg-12">
       <div class="ibox ">

        <div>
            <asp:Panel runat="server" ID="pnlproceed" >   
                <div class="row form-group">
                <div class="col-lg-6">
                <label>SBU</label><label style="color:red">*</label>  
                <asp:DropDownList runat="server" ID="ddlSBU" TabIndex="1" class="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlSBU_SelectedIndexChanged"></asp:DropDownList>
                </div>

                <div class="col-lg-6">
                <label>Area</label><label style="color:red">*</label>  
                <asp:DropDownList runat="server" ID="ddlArea" TabIndex="2" class="form-control" ></asp:DropDownList>
                </div>
                </div>

                <div class="row form-group">
                <div class="col-lg-6">
                <label>Sub Area</label><label style="color:red">*</label>  
                <asp:DropDownList runat="server" ID="ddlSUBArea" TabIndex="3" CssClass="form-control"></asp:DropDownList>
                </div>

                <div class="col-lg-6">
                <label>Job Type</label><label style="color:red">*</label>  
                    <asp:CheckBoxList runat="server" ID="chkjobtype" CssClass="form-control" RepeatDirection="Horizontal"    >
                        <asp:ListItem Value="0">Work At Height</asp:ListItem>
                        <asp:ListItem Value="1">Confined Space</asp:ListItem>
                        <asp:ListItem Value="1">Critical Lift</asp:ListItem>
                        <asp:ListItem Value="1">Excavation</asp:ListItem>
                        <asp:ListItem Value="1">Isolation</asp:ListItem>
                        <asp:ListItem Value="1">Vehicle & Pedestrain</asp:ListItem>
                    </asp:CheckBoxList>
               
                </div>
                </div>


                <div class="row form-group">
                <div class="col-lg-6">
                <label>Job Executor Name</label><label style="color:red">*</label>
                <%--<asp:DropDownList runat="server" ID="ddlExecutor" TabIndex="30" CssClass="form-control"></asp:DropDownList>--%>
                <asp:TextBox runat="server" ID="TextBoxExecutor" TabIndex="4" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-lg-6">
                <label>Executor Phone</label>
                <asp:TextBox runat="server" ID="TextBoxExecPhone" TabIndex="5" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-lg-6">
                <label>Date and Time of Job</label><label style="color:red">*</label>  
                <asp:TextBox runat="server" ID="TextBoxTime" TabIndex="6" TextMode="DateTimeLocal" CssClass="form-control"></asp:TextBox>
                </div>

                </div>

                <div class="row form-group">
                <div class="col-lg-6">
                <label>Job Description</label><label style="color:red">*</label>  
                <asp:TextBox runat="server" ID="TextBoxJobDes" TabIndex="7" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                </div>


                <div class="col-lg-6">
                <label>Auditor</label><label style="color:red">*</label>  
                <asp:DropDownList runat="server" ID="ddlAuditor" TabIndex="8" CssClass="form-control"></asp:DropDownList>
                </div>
                </div>

                <div class="row form-group">
                <div class="col-lg-6">
                <label>Rescuer Name and Contact</label> 
                <asp:TextBox runat="server" ID="TextBoxRescuer" TabIndex="9" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="col-lg-6">
                <label>Remarks</label> 
                <asp:TextBox runat="server" ID="TextBoxRemarks" TabIndex="14" CssClass="form-control"></asp:TextBox>
                </div>
                </div>

                <br />

                <div class="row form-group">
                <div class="col-lg-12" style="text-align:center">
                  <asp:LinkButton runat="server" ID="btnsave"   data-style="expand-right" CssClass="ladda-button btn  btn-primary" OnClick="btnsave_Click"  TabIndex="10" ><i class="fa fa-save" > Save</i></asp:LinkButton>
                  <asp:LinkButton runat="server" ID="btnreset"  CssClass="btn  btn-danger"  OnClick="btnreset_Click" TabIndex="11"><i class="fa fa-refresh"  > Reset</i></asp:LinkButton>
                </div>
                </div>
                               
                            
        </asp:Panel>
        </div>

     
            </div>

            </div>
       
        </div>
            
        </ContentTemplate>
        <Triggers>
           
            <asp:PostBackTrigger ControlID="btnsave" />
            <asp:PostBackTrigger ControlID="btnreset" />
            <asp:PostBackTrigger ControlID="ddlSBU" />
<%--            <asp:PostBackTrigger ControlID="btnsearch" />--%>
          
            
        
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


