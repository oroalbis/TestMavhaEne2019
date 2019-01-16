Imports System
Imports data = [lib].test

Module Module1

    Sub Main()
        Dim sResult As String
        Dim oData As New data.data
        Dim oModel As New data.persona

        oModel.nombre = "Tere C."
        oModel.edad = 42
        oModel.fecha = New DateTime(1974, 8, 27)
        oModel.sexo = "F"
        'oModel.id = 1

        'sResult = oData.Insert(oModel)
        'sResult = oData.Update(oModel)
        'sResult = oData.Delete(1)

        'Dim oDataTable As DataTable = oData.GetItems()
        'For Each row As DataRow In oDataTable.Rows
        '    Console.WriteLine("Nombre : " + row("nombre_apellido"))
        'Next row


        Dim oDataRow As DataRow = oData.GetOne(3)
        Console.WriteLine("Nombre: " + oDataRow("nombre_apellido"))



        'Console.WriteLine("Resultado: " + sResult)
        Console.ReadKey()
    End Sub

End Module
