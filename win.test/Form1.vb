Public Class frmPersonas
    Private Sub frmPersonas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim oService As New dataService.data()
        Dim oDs As DataSet

        oDs = oService.GetItems()

        dgvPersonas.AutoGenerateColumns = False
        dgvPersonas.DataSource = oDs.Tables(0)

    End Sub
End Class
