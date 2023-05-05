<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserProfile1.aspx.cs" Inherits="BalcoHRA.UserManagement.UserProfile1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
    <!-- Mainly scripts -->
    <script src="../../js/jquery-3.1.1.min.js"></script>
    <script src="../../js/popper.min.js"></script>
    <script src="../../js/bootstrap.js"></script>
    <script src="../../js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="../../js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

    <!-- Custom and plugin javascript -->
    <script src="../../js/inspinia.js"></script>
    <script src="../../js/plugins/pace/pace.min.js"></script>

    <!-- ChartJS-->
    <script src="../../js/plugins/chartJs/Chart.min.js"></script>
    <script src="../../js/demo/chartjs-demo.js"></script>

    
    <link href="../../css/bootstrap.min.css" rel="stylesheet">
    <link href="../../font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="../../css/animate.css" rel="stylesheet">
    <link href="../../css/style.css" rel="stylesheet">
    
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     <div class="row wrapper border-bottom white-bg page-heading">
                <div class="col-lg-10">
                    <h2>Profile</h2>
                    <ol class="breadcrumb">
                        <li class="breadcrumb-item">
                            <a href="../Home.aspx">Home</a>
                        </li>
                       
                        <li class="breadcrumb-item active">
                            <strong>Profile</strong>
                        </li>
                    </ol>
                </div>
                <div class="col-lg-2">

                </div>
            </div>
     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
         <ContentTemplate>
        <div class="wrapper wrapper-content">
            <div class="row animated fadeInRight">
                <div class="col-md-4">
                    <div class="ibox ">
                        <div class="ibox-title">
                            <h5>Profile Detail</h5>
                        </div>
                        <div>
                            <div class="ibox-content no-padding border-left-right">
                                <asp:Image runat="server" ID="imageprofile" alt="image" class="img-fluid" />
                            </div>
                            <div class="ibox-content profile-content">
                                <h4><strong><asp:Label runat="server" ID="lblusername" ForeColor="LightBlue"></asp:Label></strong></h4>
                                <p><i class="fa fa-user-o"></i>  Role : <asp:Label runat="server" ID="lblrole"></asp:Label></p>
                                <p><i class="fa fa-mobile"></i>    Mobile : <asp:Label runat="server" ID="lblmobile"></asp:Label></p>
                                <p><i class="fa fa-envelope"></i>  Email : <asp:Label runat="server" ID="lblemail"></asp:Label></p>
                               
                           
                                
                               
                               
                            </div>
                    </div>
                </div>
                    </div>
                <div class="col-md-8">
                    <div class="ibox ">
                        <div class="ibox-title">
                            <h5>Activites</h5>
                            <div class="ibox-tools">
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                                <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu dropdown-user">
                                    <li><a href="#" class="dropdown-item">Config option 1</a>
                                    </li>
                                    <li><a href="#" class="dropdown-item">Config option 2</a>
                                    </li>
                                </ul>
                                <a class="close-link">
                                    <i class="fa fa-times"></i>
                                </a>
                            </div>
                        </div>
                        <div class="ibox-content">

                            <div>
                                <div class="feed-activity-list" style="height:300px;overflow:auto">
                               <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="table table-hover table-responsive table-bordered" Width="100%" >
                                            <Columns>
                                               
                                                <asp:BoundField DataField="row_num" SortExpression="row_num"  HeaderText="Slno"  ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" ItemStyle-Width="10%"  />
                                                <asp:BoundField DataField="LASTLOGIN" SortExpression="LASTLOGIN"  HeaderText="Last Login" DataFormatString="{0:dd-MM-yyyy hh:mm:ss}" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" ItemStyle-Width="60%"  />
                                                <asp:BoundField DataField="LOGINIP" SortExpression="LOGINIP"  HeaderText="LogIn IP"  ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" ItemStyle-Width="30%"  />
                                               
                                                
                                                 
                                            </Columns>
                                        </asp:GridView>
                                   </div>

                                 <asp:LinkButton runat="server" ID="btnshowmore" class="btn btn-primary btn-block m" OnClick="btnshowmore_Click" Visible="true"><i class="fa fa-arrow-down"></i> Show More</asp:LinkButton>
                                <asp:LinkButton runat="server" ID="bntshowless" class="btn btn-primary btn-block m" OnClick="bntshowless_Click" Visible="false"><i class="fa fa-arrow-up"></i> Show Less</asp:LinkButton>

                            </div>

                        </div>
                    </div>

                </div>
                <div class="col-lg-12">
                    <div class="ibox ">
                        <div class="ibox-title">
                            <h5>LogIn History</h5>
                            <asp:Label runat="server" ID="lbluserid" Visible="false"></asp:Label>
                        </div>
                        <div class="ibox-content">
                            <div style="overflow:auto">
                                <canvas id="ChartloginDetails"  style="height:150px;"></canvas>

                            </div>
                             
                        </div>
                    </div>
                </div>
            </div>
        </div>
             </ContentTemplate>
         <Triggers>
             
             <asp:PostBackTrigger ControlID="btnshowmore" />
             <asp:PostBackTrigger ControlID="bntshowless" />
         </Triggers>
         </asp:UpdatePanel>
    



        <!-- Mainly scripts -->
    <script src="../../js/jquery-3.1.1.min.js"></script>
    <script src="../../js/popper.min.js"></script>
    <script src="../../js/bootstrap.js"></script>
    <script src="../../js/plugins/metisMenu/jquery.metisMenu.js"></script>
    <script src="../../js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

    <!-- Morris -->
    <script src="../../js/plugins/morris/raphael-2.1.0.min.js"></script>
    <script src="../../js/plugins/morris/morris.js"></script>

    <!-- Custom and plugin javascript -->
    <script src="../../js/inspinia.js"></script>
    <script src="../../js/plugins/pace/pace.min.js"></script>

    <!-- Morris demo data-->
    <script src="../../js/demo/morris-demo.js"></script>

    <!-- ChartJS-->
    <script src="../../js/plugins/chartJs/Chart.min.js"></script>
    <script src="../../js/demo/chartjs-demo.js"></script>


        <script>
             var lineData = {
        labels: <%=Newtonsoft.Json.JsonConvert.SerializeObject(Labels)%>,
        datasets: [
            {
                label: "Times of Login",
               
                borderColor: "#2F7FF3",
                pointBorderColor: "#2F7FF3",
                data:  <%=Newtonsoft.Json.JsonConvert.SerializeObject(Data1)%>,
            }
        ]
    };
    var lineOptions = {
        responsive: true,
        maintainAspectRatio: false
    };
    var ctx = document.getElementById("ChartloginDetails").getContext("2d");
    new Chart(ctx, {type: 'line', data: lineData, options:lineOptions});
        </script>
    

    
</asp:Content>