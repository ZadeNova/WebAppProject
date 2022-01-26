<%@ Page Title="" Language="C#" MasterPageFile="~/Afterlogin.master" AutoEventWireup="true" CodeFile="ProfilePage.aspx.cs" Inherits="ProfilePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!DOCTYPE html>
    <html>
        <head>
            <style>
                .form-control:focus {
    box-shadow: none;
    border-color: #BA68C8
}

.profile-button {
    background: rgb(99, 39, 120);
    box-shadow: none;
    border: none
}

.profile-button:hover {
    background: #682773
}

.profile-button:focus {
    background: #682773;
    box-shadow: none
}

.profile-button:active {
    background: #682773;
    box-shadow: none
}

.back:hover {
    color: #682773;
    cursor: pointer
}

.labels {
    font-size: 11px
}

.add-experience:hover {
    background: #BA68C8;
    color: #fff;
    cursor: pointer;
    border: solid 1px #BA68C8
}


            </style>
            <title></title>


        </head>
        <body>
            <div class="container rounded bg-white mt-5 mb-5">
    <div class="row">
        <div class="col-md-3 border-right">
            <%--<div class="d-flex flex-column align-items-center text-center p-3 py-5"><img class="rounded-circle mt-5" width="150px" src="https://st3.depositphotos.com/15648834/17930/v/600/depositphotos_179308454-stock-illustration-unknown-person-silhouette-glasses-profile.jpg"><span class="font-weight-bold">Edogaru</span><span class="text-black-50">edogaru@mail.com.my</span><span> </span></div>--%>
        </div>
        <div class="col-md-5 border-right">
            <div class="p-3 py-5">
                <div class="d-flex justify-content-between align-items-center mb-3">
                    <h4 class="text-right">Profile Settings</h4>
                </div>
                <div class="row mt-2">
                    <div class="col-md-6"><label class="labels">Name</label><asp:TextBox ID="FirstNameTxt" class="form-control" placeholder="First Name" runat="server"></asp:TextBox></div>
                    
                    <div class="col-md-6"><label class="labels">Surname</label><asp:TextBox ID="LastNameTxt" class="form-control" placeholder="Last Name" runat="server"></asp:TextBox></div>
                </div>
                <div class="row mt-3">
                    
                    
                    <div class="col-md-12"><label class="labels">Address</label><asp:TextBox ID="AddressTxt" class="form-control" placeholder="Address" runat="server"></asp:TextBox></div>
                    <div class="col-md-12"><label class="labels">Zip Code</label><asp:TextBox ID="ZipcodeTxt" class="form-control" placeholder="ZipCode" runat="server"></asp:TextBox></div>
                    
                    
                    
                    <div class="col-md-12"><label class="labels">Email</label><asp:TextBox ID="EmailTxtBox" class="form-control" placeholder="Email" runat="server"></asp:TextBox></div>
                    
                </div>
                <div class="row mt-3">
                    
                    
                </div>
                <div class="mt-5 text-center"><asp:Button ID="SubmitBtn" OnClick="SubmitBtn_Click" runat="server" Text="Update profile" class="btn btn-primary profile-button" /></div>
            </div>
        </div>
        
    </div>
</div>
</div>
</div>



        </body>
    </html>




</asp:Content>

