Option Explicit On
Option Strict On

Imports System.Data.SqlClient
Imports System.Data
Imports System.Linq
Imports System.Collections.Generic

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim objCustomer As CustomerCls
    Dim oData As New dataService.data

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            FillCustomerInGrid()
        End If
    End Sub

    Protected Sub FillCustomerInGrid()

        Dim dtCustomer As DataSet = oData.GetItems()
        Try

            If dtCustomer.Tables(0).Rows.Count > 0 Then
                GridView1.DataSource = dtCustomer.Tables(0)
                GridView1.DataBind()
            Else
                dtCustomer.Tables(0).Rows.Add(dtCustomer.Tables(0).NewRow())
                Me.GridView1.DataSource = dtCustomer
                GridView1.DataBind()

                Dim TotalColumns As Integer
                TotalColumns = GridView1.Rows(0).Cells.Count
                GridView1.Rows(0).Cells.Clear()
                GridView1.Rows(0).Cells.Add(New TableCell())
                GridView1.Rows(0).Cells(0).ColumnSpan = TotalColumns
                GridView1.Rows(0).Cells(0).Style.Add("text-align", "center")
                GridView1.Rows(0).Cells(0).Text = "No customer records in the database!"

            End If

        Catch ex As Exception
            Throw New Exception(ex.Message.ToString(), ex)
        End Try

    End Sub

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) _
        Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        FillCustomerInGrid()
    End Sub

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs)
        If e.CommandName.Equals("AddNew") Then
            Dim txtNewName As TextBox
            txtNewName = CType(GridView1.FooterRow.FindControl("txtNewName"), TextBox)
            Dim cmbNewGender As DropDownList
            cmbNewGender = CType(GridView1.FooterRow.FindControl("cmbNewGender"), DropDownList)
            Dim txtNewFecha As TextBox
            txtNewFecha = CType(GridView1.FooterRow.FindControl("txtNewFecha"), TextBox)
            Dim txtNewEdad As TextBox
            txtNewEdad = CType(GridView1.FooterRow.FindControl("txtNewEdad"), TextBox)

            objCustomer = New CustomerCls
            oData.Insert(txtNewName.Text, Convert.ToInt16(txtNewEdad.Text), Convert.ToDateTime(txtNewFecha.Text), Convert.ToChar(cmbNewGender.SelectedValue))
            FillCustomerInGrid()

        ElseIf e.CommandName.Equals("Delete") Then

            Dim index As Integer
            index = Convert.ToInt32(e.CommandArgument)
            oData.Delete(Convert.ToInt16(GridView1.DataKeys(index).Values(0).ToString()))
            FillCustomerInGrid()
        End If

    End Sub

    'this is the edit mode event
    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)

        Try
            If e.Row.RowType = DataControlRowType.DataRow Then

                Dim cmbGender As DropDownList
                cmbGender = CType(e.Row.FindControl("cmbGender"), DropDownList)

                If Not cmbGender Is Nothing Then
                    cmbGender.SelectedValue = "M"
                End If
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message.ToString(), ex)
        End Try

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs)
       
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs)
        GridView1.EditIndex = e.NewEditIndex
        FillCustomerInGrid()
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs)

        If (GridView1.EditIndex <> -1) Then
            Dim id As Short
            id = Convert.ToInt16(GridView1.DataKeys(e.RowIndex).Values(0))

            Dim txtName As TextBox
            txtName = CType(GridView1.Rows(e.RowIndex).FindControl("txtName"), TextBox)

            Dim txtFecha As TextBox
            txtFecha = CType(GridView1.Rows(e.RowIndex).FindControl("txtfecha"), TextBox)

            Dim txtEdad As TextBox
            txtEdad = CType(GridView1.Rows(e.RowIndex).FindControl("txtedad"), TextBox)

            Dim cmbGender As DropDownList
            cmbGender = CType(GridView1.Rows(e.RowIndex).FindControl("cmbGender"), DropDownList)
            Dim sexo = cmbGender.SelectedValue

            oData.Update(id, txtName.Text, Convert.ToInt16(txtEdad.Text), Convert.ToDateTime(txtFecha.Text), Convert.ToChar(sexo))
            GridView1.EditIndex = -1
            FillCustomerInGrid()
        End If

    End Sub

End Class
