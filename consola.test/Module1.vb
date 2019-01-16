Imports System
Imports data = [lib].test

Module Module1

    Sub Main()
        Dim sResult As String
        Dim oData As New data.Class1

        sResult = oData.Connection()

        Console.WriteLine("Result : " + sResult)
        Console.ReadKey()
    End Sub

End Module
