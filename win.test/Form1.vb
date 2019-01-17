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

End Class
