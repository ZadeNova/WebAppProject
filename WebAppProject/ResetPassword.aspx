<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResetPassword.aspx.cs" Inherits="ResetPassword" MasterPageFile="~/Others.master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <!DOCTYPE html>

<html>
<head>
    <title></title>
</head>
<body>
    
        <div>

            <asp:Label ID="Label1" runat="server" Text="Reset your password"></asp:Label>
            <asp:Label ID="Notthesame" runat="server" Text="Passwords are not the same.Please try again" Visible="false"></asp:Label>
            <asp:TextBox ID="NewPass" runat="server"></asp:TextBox>
            <p id="textCaps">WARNING! Caps lock is ON.</p>
            <asp:TextBox ID="CfmNewPass" runat="server"></asp:TextBox>
            <p id="textCaps2">WARNING! Caps lock is ON.</p>
            <asp:Button ID="ResetPasswordBtn" runat="server" Text="Reset Password" OnClick="ResetPassword_Click"/>


            <asp:CompareValidator
                                ID="CompareValidatorPW"
                                runat="server"
                                ErrorMessage="Passwords do not match!"
                                ControlToValidate="CfmNewPass"
                                ControlToCompare="NewPass"
                                Operator="Equal" Type="String"
                                ForeColor="Red">
               </asp:CompareValidator>
            <asp:RegularExpressionValidator ID="ValidatePassword" Display="Dynamic" runat="server" ErrorMessage="Does not fit password requirements!" CssClass="ValidationPasswordClass" ControlToValidate="NewPass" ValidationExpression="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,}" ></asp:RegularExpressionValidator>
            <div id="message">
                              <h5>Password must contain the following:</h5>
                              <p id="letter" class="invalid">A <b>lowercase</b> letter</p>
                              <p id="capital" class="invalid">A <b>capital (uppercase)</b> letter</p>
                              <p id="number" class="invalid">A <b>number</b></p>
                              <p id="length" class="invalid">Minimum <b>8 characters</b></p>
                </div>






        </div>
    <script>
                var myInput = document.getElementById("ContentPlaceHolder2_NewPass");
                var CfmPasswordInput = document.getElementById("ContentPlaceHolder2_CfmNewPass");
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
</body>
</html>

</asp:Content>

