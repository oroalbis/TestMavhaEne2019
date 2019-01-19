Imports System
Imports data = [lib].test

Module Module1

    Sub Main()

        Console.WriteLine("Desea depurar 1.dll o 2.Servicio Web:")
        Dim iKey = Console.Read()

        Dim sOption As String = Convert.ToChar(iKey)

        Select Case Convert.ToInt16(sOption)
            Case 1
                Test(True)
            Case 2
                Test(False)
            Case Else
                Console.WriteLine("La opción no existe.")
        End Select



    End Sub

    Private Sub Test(bDll As Boolean)
        Dim bStop As Boolean = False

        Do
            Console.WriteLine("Escriba la primera letra de la operación a realizar:")
            Console.WriteLine("O la letra x para salir.")
            Dim iKey = Console.Read()

            Dim sOption As String = Convert.ToChar(iKey)

            Select Case sOption.ToUpper()
                Case "I"
                    Insert(bDll)
                Case "U"
                    Update(bDll)
                Case "D"
                    Delete(bDll)
                Case "T"
                    GetItems(bDll)
                Case "O"
                    GetOne(bDll)
                Case "X"
                    End
                Case Else
                    Console.WriteLine("La opción no existe.")
            End Select

        Loop Until bStop


    End Sub

    Private Sub Insert(bDll As Boolean)
        Dim sResult As String

        If bDll Then
            Dim oData As New data.data
            Dim oModel As New data.persona

            oModel.nombre = "Tere C."
            oModel.edad = 42
            oModel.fecha = New DateTime(1974, 8, 27)
            oModel.sexo = "F"
            oModel.snactivo = 1

            sResult = oData.Insert(oModel)

        Else
            Dim oService As New dataService.data
            sResult = oService.Insert("Prueba", 35, New DateTime(1974, 8, 27), "M")
        End If

        Console.WriteLine("Resultado: " + sResult)
    End Sub

    Private Sub Update(bDll As Boolean)
        Dim sResult As String

        If bDll Then
            Dim oData As New data.data
            Dim oModel As New data.persona

            oModel.nombre = "Tere C. Modificado"
            oModel.edad = 42
            oModel.fecha = New DateTime(1974, 8, 27)
            oModel.sexo = "F"
            oModel.id = 1
            oModel.snactivo = 1

            sResult = oData.Update(oModel)
        Else
            Dim oService As New dataService.data
            sResult = oService.Update(1, "Prueba", 35, New DateTime(1974, 8, 27), "M")
        End If

        Console.WriteLine("Resultado: " + sResult)
    End Sub

    Private Sub Delete(bDll As Boolean)
        Dim sResult As String
        If bDll Then
            Dim oData As New data.data
            Dim oModel As New data.persona

            sResult = oData.Delete(1)

        Else
            Dim oService As New dataService.data
            sResult = oService.Delete(1)
        End If
        Console.WriteLine("Resultado: " + sResult)
    End Sub

    Private Sub GetItems(bDll As Boolean)
        Dim oData As New data.data
        Dim oDataTable As DataSet

        If bDll Then
            oDataTable = oData.GetItems()
        Else
            Dim oService As New dataService.data
            oDataTable = oService.GetItems()
        End If

        For Each row As DataRow In oDataTable.Tables(0).Rows
            Console.WriteLine("Nombre : " + row("nombre_apellido"))
        Next row

    End Sub

    Private Sub GetOne(bDll As Boolean)
        Dim oData As New data.data
        Dim oDs As DataSet

        If bDll Then
            oDs = oData.GetOne(3)
        Else
            Dim oService As New dataService.data
            oDs = oService.GetOne(1)
        End If
        Console.WriteLine("Nombre: " + oDs.Tables(0).Rows(0)("nombre_apellido"))
    End Sub

End Module
