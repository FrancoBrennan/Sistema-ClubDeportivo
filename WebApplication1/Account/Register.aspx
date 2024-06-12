<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
        <p class="text-danger">
            <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <h4>Crear una nueva cuenta</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        
        <!-- Nombre -->
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="Nombre" CssClass="col-md-2 col-form-label">Nombre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Nombre" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Nombre"
                    CssClass="text-danger" ErrorMessage="El campo de nombre es obligatorio." />
            </div>
        </div>
        
        <!-- Fecha de Nacimiento -->
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="FechaNacimiento" CssClass="col-md-2 col-form-label">Fecha de Nacimiento</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="FechaNacimiento" CssClass="form-control" TextMode="Date" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="FechaNacimiento"
                    CssClass="text-danger" ErrorMessage="El campo de fecha de nacimiento es obligatorio." />
            </div>
        </div>
        
        <!-- Dirección -->
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="Direccion" CssClass="col-md-2 col-form-label">Dirección</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Direccion" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Direccion"
                    CssClass="text-danger" ErrorMessage="El campo de dirección es obligatorio." />
            </div>
        </div>
        
        <!-- Correo electrónico -->
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 col-form-label">Correo electrónico</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="El campo de correo electrónico es obligatorio." />
            </div>
        </div>
        
        <!-- Contraseña -->
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 col-form-label">Contraseña (DNI)</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Number" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
            </div>
        </div>
        
        <!-- Confirmar contraseña -->
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 col-form-label">Confirmar contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Number" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="El campo de confirmación de contraseña es obligatorio." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="La contraseña y la contraseña de confirmación no coinciden." />
            </div>
        </div>
        
        <!-- Es Socio Club -->
        <div class="row">
            <asp:Label runat="server" AssociatedControlID="EsSocio" CssClass="col-md-2 col-form-label">Es Socio</asp:Label>
            <div class="col-md-10">
                <asp:CheckBox runat="server" ID="EsSocio" AutoPostBack="true" OnCheckedChanged="EsSocio_CheckedChanged" />
            </div>
        </div>
        
        <!-- Cuota Social -->
        <div class="row" id="divCuotaSocial" runat="server" visible="false">
            <asp:Label runat="server" AssociatedControlID="CuotaSocial" CssClass="col-md-2 col-form-label">Cuota Social</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="CuotaSocial" CssClass="form-control" TextMode="Number" />
            </div>
        </div>
        
        <!-- Botón de Registro -->
        <div class="row">
            <div class="offset-md-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrarse" CssClass="btn btn-outline-dark" />
            </div>
        </div>
    </main>
</asp:Content>

