Public Class frmPersonas
    Dim oDs As DataSet
    Dim oService As New dataService.data()

    Private Sub frmPersonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try


            oDs = oService.GetItems()

            dgvPersonas.AutoGenerateColumns = False
            dgvPersonas.DataSource = oDs.Tables(0)

            lblObs.ForeColor = Color.DarkBlue
            lblObs.Text = "Datos Cargados Correctamente"
        Catch ex As Exception
            lblObs.ForeColor = Color.Red
            lblObs.Text = "Error al cargar los datos"
        End Try


    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim bOk As Boolean

        lblObs2.ForeColor = Color.Yellow
        lblObs2.Text = "Actualizando los datos... Favor espere."

        bOk = Crud(DataRowState.Added)
        bOk = bOk And Crud(DataRowState.Modified)
        bOk = bOk And Crud(DataRowState.Deleted)

        If bOk Then
            lblObs2.ForeColor = Color.DarkBlue
            lblObs2.Text = "Datos Actualizados Correctamente."
        Else
            lblObs2.ForeColor = Color.Red
            lblObs2.Text = "Sugieron algunos errores al hacer la actualización."
        End If

        LoadData()
    End Sub

    Private Function Crud(oEstado As DataRowState)
        Try
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

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function


    Private Sub dgvPersonas_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvPersonas.CellValidating
        'If String.IsNullOrEmpty(e.FormattedValue.ToString()) Then
        '    Dim headerText As String = dgvPersonas.Columns(e.ColumnIndex).HeaderText
        '    dgvPersonas.Rows(e.RowIndex).ErrorText = headerText + " es un campo obligatorio."
        '    e.Cancel = True
        'End If
    End Sub

    Private Sub dgvPersonas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPersonas.CellEndEdit
        dgvPersonas.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub dgvPersonas_RowValidating(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgvPersonas.RowValidating
        dgvPersonas.EndEdit()

        'If dgvPersonas.CurrentRow Is Nothing And dgvPersonas.CurrentRow.Index < 1 Then
        '    Exit Sub
        'End If

        For index = 0 To 3
            If dgvPersonas.CurrentRow.Cells(index).Value IsNot Nothing Then
                If dgvPersonas.CurrentRow.Cells(index).Value.ToString().Length < 1 Then
                    Dim headerText As String = dgvPersonas.Columns(dgvPersonas.CurrentRow.Cells(index).ColumnIndex).HeaderText
                    dgvPersonas.CurrentRow.Cells(index).ErrorText = headerText + " es un campo obligatorio."
                    e.Cancel = True
                Else
                    dgvPersonas.CurrentRow.Cells(index).ErrorText = ""
                End If
            End If
        Next

    End Sub

End Class
