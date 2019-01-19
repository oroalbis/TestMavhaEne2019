Imports System
Imports data = [lib].test

Module Module1

    Sub Main()
        TestDll()
    End Sub

    Private Sub TestDll()
        Dim bStop As Boolean = False

        Do
            Console.WriteLine("Escriba la primera letra de la operación a realizar:")
            Console.WriteLine("O la letra x para salir.")
            Dim iKey = Console.Read()

            Dim sOption As String = Convert.ToChar(iKey)

            Select Case sOption.ToUpper()
                Case "I"
                    Insert()
                Case "U"
                    Update()
                Case "D"
                    Delete()
                Case "T"
                    GetItems()
                Case "O"
                    GetOne()
                Case "X"
                    End
                Case Else
                    Console.WriteLine("La opción no existe.")
            End Select

        Loop Until bStop


    End Sub

    Private Sub Insert()
        Dim sResult As String
        Dim oData As New data.data
        Dim oModel As New data.persona

        oModel.nombre = "Tere C."
        oModel.edad = 42
        oModel.fecha = New DateTime(1974, 8, 27)
        oModel.sexo = "F"
        oModel.snactivo = 1

        sResult = oData.Insert(oModel)

        Console.WriteLine("Resultado: " + sResult)
    End Sub

    Private Sub Update()
        Dim sResult As String
        Dim oData As New data.data
        Dim oModel As New data.persona

        oModel.nombre = "Tere C. Modificado"
        oModel.edad = 42
        oModel.fecha = New DateTime(1974, 8, 27)
        oModel.sexo = "F"
        oModel.id = 1
        oModel.snactivo = 1

        sResult = oData.Update(oModel)

        Console.WriteLine("Resultado: " + sResult)
    End Sub

    Private Sub Delete()
        Dim oData As New data.data
        Dim sResult As String
        Dim oModel As New data.persona

        sResult = oData.Delete(2)
        sResult = oData.Delete(3)

        Console.WriteLine("Resultado: " + sResult)
    End Sub

    Private Sub GetItems()
        Dim oData As New data.data
        Dim sResult As String
        Dim oModel As New data.persona

        Dim oDataTable As DataSet = oData.GetItems()
        For Each row As DataRow In oDataTable.Tables(0).Rows
            Console.WriteLine("Nombre : " + row("nombre_apellido"))
        Next row

    End Sub

    Private Sub GetOne()
        Dim oData As New data.data
        Dim sResult As String
        Dim oModel As New data.persona


        Dim oDs As DataSet = oData.GetOne(3)
        Console.WriteLine("Nombre: " + oDs.Tables(0).Rows(0)("nombre_apellido"))

    End Sub

End Module
