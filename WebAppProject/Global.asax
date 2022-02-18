<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Routing" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }

    static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("TwoFactorSettings", "TwoFactorSettings", "~/2FASettings.aspx");
        routes.MapPageRoute("ActivateAccount", "ActivateAccount", "~/AccountActivation.aspx");
        routes.MapPageRoute("AllProducts", "AllProducts", "~/Admin-BestSeller.aspx");
        routes.MapPageRoute("ProductCreation", "CreateProduct", "~/Admin-CreateProduct.aspx");
        routes.MapPageRoute("ManageOrdersAdmin", "ManageOrders", "~/Admin-Orders.aspx");
        routes.MapPageRoute("ManageUsers", "ManageUsers", "~/Admin-Users.aspx");
        routes.MapPageRoute("Anime", "Anime", "~/AnimeProducts.aspx");
        routes.MapPageRoute("Dashboard", "Dashboard", "~/Dashboard.aspx");
        routes.MapPageRoute("DC", "DC", "~/DCProducts.aspx");
        routes.MapPageRoute("EmailOTP", "EmailOTP", "~/EmailOTP.aspx");
        routes.MapPageRoute("ForgetPassword", "ForgetPassword", "~/ForgotPassword.aspx");
        
        routes.MapPageRoute("Home", "Home", "~/index.aspx");
        routes.MapPageRoute("Home2", "Home2", "~/index2.aspx");
       
        routes.MapPageRoute("Marvel", "Marvel", "~/MarvelProducts.aspx");
        routes.MapPageRoute("Payment", "Payment", "~/Payment.aspx");
        routes.MapPageRoute("TheProfilePage", "Profile", "~/ProfilePage.aspx");
        routes.MapPageRoute("ResetPassword", "ResetPassword", "~/ResetPassword.aspx");
        routes.MapPageRoute("Search", "Search", "~/Search.aspx");
        routes.MapPageRoute("StarWars", "StarWars", "~/StarWarsProducts.aspx");
        routes.MapPageRoute("ViewCart", "ViewCart", "~/ViewCart.aspx");

        
        routes.MapPageRoute("ProductDetails", "ProductDetails", "~/ProductDetails.aspx");
         
        
        
        
        

        //routes.MapPageRoute("ActivateAccount", "ActivateAccount", "~/.aspx");
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs


    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
