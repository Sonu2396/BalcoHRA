<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" EnableEventValidation ="false" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="BalcoHRA.Reports.Report" %>
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
                    <h2>Report</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../../Home.aspx">Home</a>
                        </li>
                        
                         <li class="breadcrumb-item">
                            <a>Report</a>
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
                            <h5>Report</h5>
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
                                          <asp:GridView ID="GridView1"  CssClass="table  table-responsive-lg table-hover" runat="server" AllowSorting="True" AutoGenerateColumns="False"  ShowFooter="false"   TabIndex="14" DataKeyNames="TransID" EmptyDataText="No records found......"   >
                                          <Columns>
                                               <asp:BoundField DataField="TransID" HeaderText="ID" />
                                               <asp:BoundField DataField="SBU" HeaderText="SBU" />
                                               <asp:BoundField DataField="Area" HeaderText="Area" />
                                               <asp:BoundField DataField="SUBArea" HeaderText="Sub Area" />
                                               <asp:BoundField DataField="JobType" HeaderText="Type of Job" />
                                               <asp:BoundField DataField="JobExecutor" HeaderText="Job Executor Name" />
                                               <asp:BoundField DataField="JobDateTime" HeaderText="Date and Time of Job" />
                                               <asp:BoundField DataField="JobDescription" HeaderText="Job Description" />
                                               <asp:BoundField DataField="Auditor" HeaderText="Auditor Name" />
                                               <asp:BoundField DataField="Rescuer" HeaderText="Rescuer Name" />
                                               <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                               <asp:BoundField DataField="Checklist" HeaderText="Checklist" />
                                               <asp:BoundField DataField="CriticalControl" HeaderText="Critical Control" />
                                               <asp:BoundField DataField="Objective" HeaderText="Objective" />
                                               <asp:BoundField DataField="Points" HeaderText="Points" />
                                               <asp:BoundField DataField="Score" HeaderText="Score" />
                                               <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                                               

                                             
                                          </Columns>
                                          <HeaderStyle CssClass="bg-primary" />
                                              <FooterStyle BackColor="LightYellow" Font-Bold="true"/>
                                       </asp:GridView>
                                    </div> 
                                </div>

                             
                            </asp:Panel>
                            </asp:Panel>
                                    
                           
                     <%-- <asp:Panel runat="server" ID="pnlviewfile" Visible="false">
                                        <div class="row">
                                        <div class="col-lg-12 bg-info" style="text-align:right">
                                            
                                           <asp:LinkButton runat="server" ID="btnclosewindow"  OnClick="bntclosewindow_Click"  ToolTip="Close Window">Close Window<i class="btn btn-warning fa  fa-close"></i></asp:LinkButton>
                                        </div>
                                    </div>


                                        <div class="row">
                                        <div class="col-lg-12">
                                            
                                            <iframe runat="server" id="ifrmfile"  style="height:500px;width:100%"></iframe>
                                        </div>
                                    </div>

                                      </asp:Panel>--%>
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