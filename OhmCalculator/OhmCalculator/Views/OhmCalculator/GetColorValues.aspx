<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<OhmCalculator.Models.CalculatorModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	GetColorValues
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
    <h2>
        <%: ViewData["Message"] %></h2>
    <form asp-action="GetColorValues" asp-controller="OhmCalculator" method=post>
        <%= Html.DropDownList("BandColorA", Model.ColorList)%>
        <%= Html.DropDownList("BandColorB", Model.ColorList)%>
        <%= Html.DropDownList("Multiplier", Model.MultiplierColorList)%>
        <%= Html.DropDownList("Tolerance", Model.ToleranceColorList)%>
        <br /><br />
        <input type="submit" value="Calculate Ohm" />
    </form>
  <br />
  <h2> Result:    <%: ViewData["Result"]%></h2>
</asp:Content>
