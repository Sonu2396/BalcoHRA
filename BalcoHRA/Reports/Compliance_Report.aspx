<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" EnableEventValidation ="false" AutoEventWireup="true" CodeBehind="Compliance_Report.aspx.cs" Inherits="BalcoHRA.Reports.Compliance_Report" %>
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

     <style type="text/css">
         .auto-style1 {
             position: relative;
             width: 100%;
             min-height: 1px;
             -ms-flex: 0 0 100%;
             flex: 0 0 100%;
             max-width: 100%;
             left: 0px;
             top: 3px;
             padding-left: 15px;
             padding-right: 15px;
         }
     </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>Compliance Report</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../../Home.aspx">Home</a>
                        </li>
                        
                         <li class="breadcrumb-item">
                            <a>Compliance Report</a>
                        </li>
                        
                    </ol>
                </div>
                <div class="col-lg-2">

                </div>
            </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
 
            <div class="row wrapper wrapper-content animated fadeInRight">
           
            <div class="col-lg-12">
                <div class="ibox ">
                        <div class="ibox-title">
                            <h5>Compliance Report</h5>
                            <asp:Label runat="server" ID="lbluserid" Visible="false"></asp:Label>
                            
                            <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            </div>
                        </div>
                        <div class="ibox-content">
                            
                            <asp:Panel runat="server" ID="pnlreports">
                                <div class="row form-group">
                                 <div class="col-lg-4">
                                     <label>From</label><label style="color:red">*</label>  
                                     <asp:TextBox runat="server" ID="txtFromDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                      
                                 </div>
                                <div class="col-lg-4">
                                    <label>To</label><label style="color:red">*</label>  
                                    <asp:TextBox runat="server" ID="txtToDate" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                </div>
                                 <div class="col-lg-2">
                                     <br />
                                     <asp:LinkButton runat="server" ID="btnsearch"   data-style="expand-right" CssClass="ladda-button btn  btn-info"   TabIndex="9" OnClick="btnsearch_Click" ><i class="fa fa-search-plus" > Search</i></asp:LinkButton>
                                     <asp:LinkButton runat="server" ID="btnexcel"   data-style="expand-right" CssClass="ladda-button btn  btn-info"   TabIndex="9" OnClick="btnexcel_Click" ><i class="fa fa-file-excel-o" > Excel</i></asp:LinkButton>
                                 </div>
                               
                            </div>
                            
                            <asp:Panel runat="server" ID="pnlreport" Visible="false">
                              
                                <div class="row form-group">
                                    <div class="auto-style1" >
                                          <asp:GridView ID="GridView1"  CssClass="table  table-responsive-lg table-hover" runat="server" AllowSorting="True" AutoGenerateColumns="False"  ShowFooter="false"   TabIndex="14" DataKeyNames="TrDt" EmptyDataText="No records found......"   >
                                          <Columns>
                                               <asp:BoundField DataField="TrDt" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}" />
                                               <asp:BoundField DataField="Totalplan" HeaderText="No. of Plans" />
                                               <asp:BoundField DataField="PlanDone" HeaderText="Plans Completed" />
                                               <asp:BoundField DataField="PlanPending" HeaderText="Plans pending" />
                                               <asp:BoundField DataField="WAHPlan" HeaderText="WAH Planned" />
                                               <asp:BoundField DataField="StatusWAH" HeaderText="WAH Completed" />
                                               <asp:BoundField DataField="WAHPending" HeaderText="WAH Pending" />
                                               <asp:BoundField DataField="CSPlan" HeaderText="CS Planned" />
                                               <asp:BoundField DataField="StatusCS" HeaderText="CS Completed" />
                                               <asp:BoundField DataField="CSPending" HeaderText="CS Pending" />
                                               <asp:BoundField DataField="CLPlan" HeaderText="CL Planned" />
                                               <asp:BoundField DataField="StatusCL" HeaderText="CL Completed" />
                                               <asp:BoundField DataField="CLPending" HeaderText="CL Pending" />
                                               <asp:BoundField DataField="EXPlan" HeaderText="EX Planned" />
                                               <asp:BoundField DataField="StatusEX" HeaderText="EX Completed" />
                                               <asp:BoundField DataField="EXPending" HeaderText="EX Pending" />
                                               <asp:BoundField DataField="ISOPlan" HeaderText="ISO Planned" />
                                               <asp:BoundField DataField="StatusISO" HeaderText="ISO Completed" />
                                               <asp:BoundField DataField="ISOPending" HeaderText="ISO Pending" />
                                               <asp:BoundField DataField="VPIPlan" HeaderText="VPI Planned" />
                                               <asp:BoundField DataField="StatusVPI" HeaderText="VPI Completed" />
                                               <asp:BoundField DataField="VPIPending" HeaderText="VPI Pending" />
                                              
                                          </Columns>
                                          <HeaderStyle CssClass="bg-primary" />
                                              <FooterStyle BackColor="LightYellow" Font-Bold="true"/>
                                       </asp:GridView>
                                    </div> 
                                </div>

                             
                            </asp:Panel>
                            </asp:Panel>
       
        </div>
        </div>
        </div>
        </div>
            
        </ContentTemplate>
        <Triggers>
       
          <asp:PostBackTrigger ControlID="btnsearch" />
          <asp:PostBackTrigger ControlID="btnexcel" />
            
        
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