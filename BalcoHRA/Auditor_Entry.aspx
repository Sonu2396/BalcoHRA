<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Auditor_Entry.aspx.cs" Inherits="BalcoHRA.Auditor_Entry" %>

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

    <%--<script>
        $(document).ready(function () {
            $('.dataTables-example').DataTable({
                pageLength: 10,
                responsive: true,
                dom: '<"html5buttons"B>lTfgitp',
                buttons: [
                    { extend: 'copy' },
                    { extend: 'csv' },
                    { extend: 'excel', title: 'Activity' },
                    { extend: 'pdf', title: 'Activity' },

                    {
                        extend: 'print',
                        customize: function (win) {
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

    </script>--%>


    <link href="../../css/plugins/iCheck/custom.css" rel="stylesheet" />
    <link href="../../css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet" />
    <link href="../../css/plugins/ladda/ladda-themeless.min.css" rel="stylesheet">
    <!-- Custom and plugin javascript -->
    <script src="../../js/inspinia.js"></script>
    <script src="../../js/plugins/pace/pace.min.js"></script>

    <!-- Ladda -->
    <script src="../../js/plugins/ladda/spin.min.js"></script>
    <script src="../../js/plugins/ladda/ladda.min.js"></script>
    <script src="../../js/plugins/ladda/ladda.jquery.min.js"></script>

    <%--<script>

        $(document).ready(function () {

            // Bind normal buttons
            Ladda.bind('.ladda-button', { timeout: 2000 });

            // Bind progress buttons and simulate loading progress
            Ladda.bind('.progress-demo .ladda-button', {
                callback: function (instance) {
                    var progress = 0;
                    var interval = setInterval(function () {
                        progress = Math.min(progress + Math.random() * 0.1, 1);
                        instance.setProgress(progress);

                        if (progress === 1) {
                            instance.stop();
                            clearInterval(interval);
                        }
                    }, 200);
                }
            });


            var l = $('.ladda-button-demo').ladda();

            l.click(function () {
                // Start loading
                l.ladda('start');

                // Timeout example
                // Do something in backend and then stop ladda
                setTimeout(function () {
                    l.ladda('stop');
                }, 12000)


            });

        });


    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Audit Plan</h2>
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <a href="../../Home.aspx">Home</a>
                </li>

            </ol>
        </div>

    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" ID="pnlEntry" Visible="true">
                <div class="row wrapper wrapper-content animated fadeInRight">

                    <div class="col-lg-12">
                        <div class="ibox ">
                            <div class="ibox-title">
                                <h5>Audit Plan<asp:Label runat="server" ID="lbltransid" Visible="true"></asp:Label></h5>
                                <div class="ibox-tools">
                                    <a class="collapse-link">
                                        <i class="fa fa-chevron-up"></i>
                                    </a>

                                </div>
                            </div>



                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" Visible="true">
                                <ContentTemplate>
                                    <div class="row form-group">
                                        <div class="col-lg-12">
                                            <asp:GridView ID="GridView1" CssClass="table  table-responsive-lg table-hover" runat="server" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="false" TabIndex="14" EmptyDataText="No records found..." OnRowDataBound="GridView1_RowDataBound1" >
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

                                                    <asp:TemplateField HeaderText="Checklist">
                                                        <ItemTemplate>

                                                            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:DropDownList runat="server" ID="ddlChecklist" TabIndex="1" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlChecklist_SelectedIndexChanged"></asp:DropDownList>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Checklist">
                                                        <ItemTemplate>

                                                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:Button runat="server" ID="btnsubmit" TabIndex="20" Text="Submit" CssClass="ladda-button btn  btn-primary" OnClick="btnsubmit_Click" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <HeaderStyle CssClass="bg-primary" />
                                                <FooterStyle BackColor="LightYellow" Font-Bold="true" />
                                            </asp:GridView>
                                        </div>
                                    </div>

                    <div class="row wrapper wrapper-content animated fadeInRight">

                    <div class="col-lg-12">
                        <div class="ibox ">
                            <div class="ibox-title">
                            <h5>Checklist Points : <asp:Label runat="server" ID="lblchcklistname" Visible="true"></asp:Label></h5>
                                <asp:Label runat="server" ID="lblchkid" Visible="true"></asp:Label>
                                <asp:Label runat="server" ID="lbljobid" Visible="true"></asp:Label>
                            </div>
                            </div> 
                        </div>
                        </div>

                     <asp:GridView ID="GridView2" runat="server" CssClass="table  table-responsive-lg table-hover" AllowSorting="True" AutoGenerateColumns="False" ShowFooter="false" TabIndex="15" EmptyDataText="No records found...">
                            <Columns>

                            <asp:BoundField DataField="CriticalControl" HeaderText="Critical Control" />
                            <asp:BoundField DataField="Objective" HeaderText="Objective" />
                            <asp:BoundField DataField="Points" HeaderText="Points" />


                            <asp:TemplateField HeaderText="Score" ItemStyle-Width="80px">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="ddlscore"  TabIndex="4" CssClass="form-control" >
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">Go</asp:ListItem>
                                     <asp:ListItem Value="2">No Go</asp:ListItem>
                                     <asp:ListItem Value="3">NA</asp:ListItem>
                                 
                                </asp:DropDownList>
                            </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Remarks" ItemStyle-Width="150px">
                            <ItemTemplate>

                                 <asp:TextBox runat="server" ID="txtremarks" TabIndex="3" CssClass="form-control"></asp:TextBox>
                          
                            </ItemTemplate>
                            </asp:TemplateField>


                            </Columns>
                         </asp:GridView>


                         <asp:Button runat="server" ID="btnscore" Text="Save" CssClass="ladda-button btn  btn-primary"   TabIndex="2" OnClick="btnscore_Click"/>       


               </ContentTemplate>
          
               </asp:UpdatePanel>
            </asp:Panel>
      </ContentTemplate>
        <Triggers>
        <asp:PostBackTrigger ControlID="btnscore" />
        </Triggers>
    </asp:UpdatePanel>



                           <%-- <Columns>

                                            <asp:BoundField DataField="CriticalControl" HeaderText="Critical Control" />
                                            <asp:BoundField DataField="Objective" HeaderText="Objective" />
                                            <asp:BoundField DataField="Points" HeaderText="Points" />


                                           <asp:TemplateField HeaderText="Score">
                                                <ItemTemplate>

                                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                        <ContentTemplate>
                                                            <asp:CheckBox runat="server" ID="chkyes" TabIndex="4" Text="Yes" CssClass="form-control" AutoPostBack="true" />
                                                            <asp:CheckBox runat="server" ID="chkno" TabIndex="5" Text="No" CssClass="form-control" AutoPostBack="true" />
                                                            <asp:CheckBox runat="server" ID="chkna" TabIndex="6" Text="NA" CssClass="form-control" AutoPostBack="true" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Remarks">
                                                <ItemTemplate>

                                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox runat="server" ID="txtremarks" TabIndex="3" CssClass="form-control" AutoPostBack="true"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                        <HeaderStyle CssClass="bg-primary" />

                                        <FooterStyle BackColor="LightYellow" Font-Bold="true" />--%>
                              

    <!-- Custom and plugin javascript -->
    <script src="../../js/inspinia.js"></script>
    <script src="../../js/plugins/pace/pace.min.js"></script>
    <!-- Sweet alert -->
    <script src="../../js/plugins/sweetalert/sweetalert.min.js"></script>

    <script type="text/javascript">
        function successalert(Title, Msg, SType) {
            swal({
                title: Title,
                text: Msg,
                type: SType
            });
        };

    </script>

</asp:Content>
