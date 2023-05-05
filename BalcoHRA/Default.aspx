<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BalcoHRA.Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>

    <title> Login </title>

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet"/>

    <link href="css/animate.css" rel="stylesheet"/>
    <link href="css/style.css" rel="stylesheet"/>
     <!-- Sweet Alert -->
    <link href="css/plugins/sweetalert/sweetalert.css" rel="stylesheet"/>

        <!-- Text spinners style -->
    <link href="css/plugins/textSpinners/spinners.css" rel="stylesheet"/>

    <script type="text/javascript">
if (document.layers) {
    //Capture the MouseDown event.
    document.captureEvents(Event.MOUSEDOWN);
 
    //Disable the OnMouseDown event handler.
    document.onmousedown = function () {
        return false;
    };
}
else {
    //Disable the OnMouseUp event handler.
    document.onmouseup = function (e) {
        if (e != null && e.type == "mouseup") {
            //Check the Mouse Button which is clicked.
            if (e.which == 2 || e.which == 3) {
                //If the Button is middle or right then disable.
                return false;
            }
        }
    };
}
 
//Disable the Context Menu event.
document.oncontextmenu = function () {
    return false;
};
</script>

</head>
<body class="bg-primary" style="background:linear-gradient(#4b79a1,#283e51)">
     


    <div class="loginColumns animated fadeInDown "   >
        <div class="row">

            
            <div class="col-md-6">
                <div class="ibox-content">
                    
                    <form id="formlogin" runat="server" class="m-t" role="form" autocomplete="off" >
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server" ID="updatepanel1">
                            <ContentTemplate>

                                <div class="form-group" >
                                    <asp:Image runat="server" ID="imglogo" ImageUrl="~/img/balcoV-logo-new.png" Height="50px" Width="100%" />
                                    </div>

                                <div class="form-group" >
                                     <h1 class="text-body">Login</h1>
                                    </div>
                            
                       
                                 
                      
                        <div class="form-group">
                            
                            <asp:TextBox runat="server" ID="txtuserid"  AutoCompleteType="Disabled"   TabIndex="1" class="form-control" placeholder="Username" required="" ForeColor="#6B3074"></asp:TextBox>
                        </div>
                        <div class="form-group">
                             <asp:TextBox runat="server" ID="txtpwd" AutoCompleteType="Disabled" TextMode="Password"  TabIndex="2" class="form-control" placeholder="Password" required="" ForeColor="Black"></asp:TextBox>
                        </div>
                        <asp:Button runat="server" ID="btnlogin" TabIndex="3"   class="btn btn-primary block full-width m-b" Text="LogIn" OnClick="btnlogin_Click"  />
                       
                               
                        <a href="#">
                            <small>Forgot password?</small>
                        </a>

                               
                 

                        


                                 <!-- Sweet alert -->
    <script src="js/plugins/sweetalert/sweetalert.min.js"></script>

  
    <script type="text/javascript">
        function successalert(Title,Msg,SType ) {
            swal({
               title: Title,
                text: Msg,
                type: SType
            });
        };
       
       
             
        
    </script>
    


                                
                        </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnlogin" />
                            </Triggers>
                        </asp:UpdatePanel>



                          
                   

                        
              
                    </form>
                    
                </div>
            </div>
        </div>
        <hr/>
        <div class="row">
            <div class="col-md-6">
                Powered by BALCO IT (Version 1.0)
            </div>
            <div class="col-md-6 text-right">
               <small>HRA. © 2022, All Rights Reserved.</small> 
            </div>
        </div>
    </div>
   
     


   
    

       

</body>
</html>
