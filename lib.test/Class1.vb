Imports System.Configuration
Imports System.Data.SqlClient

Public Class Class1

    Private sConn As String

    Public Sub New()
        sConn = ConfigurationManager.ConnectionStrings("db_cnn").ConnectionString
    End Sub

    Public Function Connection()

        Using con As New SqlConnection(sConn)
            Try
                con.Open()
                Return "Conection OK :)"
            Catch ex As Exception
                Return "Conection Failed :( " + ex.Message.ToString()
            End Try
        End Using
    End Function



End Class
