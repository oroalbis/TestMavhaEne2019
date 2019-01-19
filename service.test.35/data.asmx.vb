Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports libdata = [lib].test

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
Public Class data
    Inherits System.Web.Services.WebService

    <WebMethod()>
    Public Function Insert(nombre As String, edad As Int16, fecha_nac As Date, sexo As Char) As String
        Dim sResult As String
        Dim oData As New libdata.data
        Dim oModel As New libdata.persona

        oModel.nombre = nombre.ToUpper()
        oModel.edad = edad
        oModel.fecha = fecha_nac
        oModel.sexo = sexo

        sResult = oData.Insert(oModel)

        Return sResult
    End Function

    <WebMethod()>
    Function Update(id As Int16, nombre As String, edad As Int16, fecha_nac As Date, sexo As Char) As String
        Dim sResult As String
        Dim oData As New libdata.data
        Dim oModel As New libdata.persona

        oModel.nombre = nombre.ToUpper()
        oModel.edad = edad
        oModel.fecha = fecha_nac
        oModel.sexo = sexo
        oModel.id = id

        sResult = oData.Update(oModel)

        Return sResult
    End Function

    <WebMethod()>
    Function Delete(id As Int16)
        Dim oData As New libdata.data
        Dim sResult As String
        Dim oModel As New libdata.persona

        sResult = oData.Delete(id)

        Console.WriteLine("Resultado: " + sResult)
    End Function

    <WebMethod()>
    Function GetItems() As DataSet
        Dim oData As New libdata.data
        Dim sResult As String
        Dim oModel As New libdata.persona

        Dim oDataTable As DataSet = oData.GetItems()
        Return oDataTable

    End Function

    <WebMethod()>
    Function GetOne(id As Int16) As DataSet
        Dim oData As New libdata.data
        Dim sResult As String
        Dim oModel As New libdata.persona


        Dim oDataRow As DataSet = oData.GetOne(id)
        Return oDataRow

    End Function

End Class