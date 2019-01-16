Imports System
Imports data = [lib].test

Module Module1

    Sub Main()
        Dim sResult As String
        Dim oData As New data.data
        Dim oModel As New data.persona

        oModel.nombre = "Albis Oro Castillo"
        oModel.edad = 42
        oModel.fecha = New DateTime(1977, 8, 27)
        oModel.sexo = "M"
        oModel.id = 1

        'sResult = oData.Insert(oModel)
        sResult = oData.Update(oModel)

        Console.WriteLine("Result : " + sResult)
        Console.ReadKey()
    End Sub

End Module
