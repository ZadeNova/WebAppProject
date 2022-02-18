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
            <title>Profile Page</title>


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

                <hr />
                <h4>Update Password</h4>
                <label class="labels">Old Password</label>
                <asp:TextBox ID="OldPassword" class="form-control" placeholder="Old Password" runat="server"></asp:TextBox>
                <label class="labels">New Password</label>
                
                <asp:TextBox ID="NewPassword" class="form-control" placeholder="New Password" runat="server"></asp:TextBox>
                <p id="textCaps">WARNING! Caps lock is ON.</p>
                
                <label class="labels">Confirm Password</label>
                
                <asp:TextBox  ID="ConfirmPassword" class="form-control" placeholder="Confirm Password" runat="server"></asp:TextBox>
                <p id="textCaps2">WARNING! Caps lock is ON.</p>
                <asp:Button ID="PasswordUpdate" text="Update Password" class="btn btn-primary profile-button" OnClick="PasswordUpdate_Click" runat="server"/>

                <asp:CompareValidator
                                ID="CompareValidatorPW"
                                runat="server"
                                ErrorMessage="Passwords do not match!"
                                ControlToValidate="ConfirmPassword"
                                ControlToCompare="NewPassword"
                                Operator="Equal" Type="String"
                                ForeColor="Red">
               </asp:CompareValidator>
                <asp:RegularExpressionValidator ID="ValidatePassword" Display="Dynamic" runat="server" ErrorMessage="Does not fit password requirements!" CssClass="ValidationPasswordClass" ControlToValidate="NewPassword" ValidationExpression="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" ></asp:RegularExpressionValidator>
                <div id="message">
                              <h5>Password must contain the following:</h5>
                              <p id="letter" class="invalid">A <b>lowercase</b> letter</p>
                              <p id="capital" class="invalid">A <b>capital (uppercase)</b> letter</p>
                              <p id="number" class="invalid">A <b>number</b></p>
                              <p id="length" class="invalid">Minimum <b>8 characters</b></p>
                </div>



            </div>
        </div>
        
    </div>
</div>
            



        </body>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/materialize/1.0.0/js/materialize.min.js"></script>
            <script>
                var myInput = document.getElementById("ContentPlaceHolder1_NewPassword");
                var CfmPasswordInput = document.getElementById("ContentPlaceHolder1_ConfirmPassword");
                var letter = document.getElementById("letter");
                var capital = document.getElementById("capital");
                var number = document.getElementById("number");
                var length = document.getElementById("length");

                // When the user clicks on the password field, show the message box
                myInput.onfocus = function () {
                    document.getElementById("message").style.display = "block";
                }

                // When the user clicks outside of the password field, hide the message box
                myInput.onblur = function () {
                    document.getElementById("message").style.display = "none";
                }

                CfmPasswordInput.onfocus = function () {
                    document.getElementById("message").style.display = "block";
                }

                CfmPasswordInput.onblur = function () {
                    document.getElementById("message").style.display = "none";
                }


                // When the user starts to type something inside the password field
                myInput.onkeyup = function () {
                    // Validate lowercase letters
                    var lowerCaseLetters = /[a-z]/g;
                    if (myInput.value.match(lowerCaseLetters)) {
                        letter.classList.remove("invalid");
                        letter.classList.add("valid");
                    } else {
                        letter.classList.remove("valid");
                        letter.classList.add("invalid");
                    }

                    // Validate capital letters
                    var upperCaseLetters = /[A-Z]/g;
                    if (myInput.value.match(upperCaseLetters)) {
                        capital.classList.remove("invalid");
                        capital.classList.add("valid");
                    } else {
                        capital.classList.remove("valid");
                        capital.classList.add("invalid");
                    }

                    // Validate numbers
                    var numbers = /[0-9]/g;
                    if (myInput.value.match(numbers)) {
                        number.classList.remove("invalid");
                        number.classList.add("valid");
                    } else {
                        number.classList.remove("valid");
                        number.classList.add("invalid");
                    }

                    // Validate length
                    if (myInput.value.length >= 8) {
                        length.classList.remove("invalid");
                        length.classList.add("valid");
                    } else {
                        length.classList.remove("valid");
                        length.classList.add("invalid");
                    }
                }


                var text = document.getElementById("textCaps");
                var text2 = document.getElementById("textCaps2");
                myInput.addEventListener("keyup", function (event) {

                    if (event.getModifierState("CapsLock")) {
                        text.style.display = "block";
                    } else {
                        text.style.display = "none"
                    }
                });
                CfmPasswordInput.addEventListener("keyup", function (event) {

                    if (event.getModifierState("CapsLock")) {
                        text2.style.display = "block";
                    } else {
                        text2.style.display = "none"
                    }
                });





            </script>
    </html>




</asp:Content>

