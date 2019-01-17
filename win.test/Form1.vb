Public Class frmPersonas
    Dim oDs As DataSet
    Dim oService As New dataService.data()

    Private Sub frmPersonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()

        oDs = oService.GetItems()

        dgvPersonas.AutoGenerateColumns = False
        dgvPersonas.DataSource = oDs.Tables(0)

    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click

        Crud(DataRowState.Added)
        Crud(DataRowState.Modified)
        Crud(DataRowState.Deleted)

        LoadData()
    End Sub

    Private Sub Crud(oEstado As DataRowState)
        If oDs.HasChanges(oEstado) Then
            Dim oDsNew = oDs.GetChanges(oEstado)
            If (Not oDsNew.HasErrors) Then
                For Each dr As DataRow In oDsNew.Tables(0).Rows
                    Select Case oEstado
                        Case DataRowState.Deleted
                            oService.Delete(oDsNew.Tables(0).Rows(0)(0, DataRowVersion.Original))
                        Case DataRowState.Added
                            oService.Insert(dr("nombre_apellido"), dr("edad"), dr("fecha_nacimiento"), dr("sexo"))
                        Case DataRowState.Modified
                            oService.Update(dr("id"), dr("nombre_apellido"), dr("edad"), dr("fecha_nacimiento"), dr("sexo"))
                    End Select
                Next
            End If
        End If
    End Sub

End Class
