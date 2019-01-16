Imports System.Configuration
Imports System.Data.SqlClient

Public Class data

    Private sConn As String

    Public Sub New()
        sConn = ConfigurationManager.ConnectionStrings("db_cnn").ConnectionString
    End Sub

    Private Function Connection()

        Using con As New SqlConnection(sConn)
            Try
                con.Open()
                Return con
            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    Public Function Insert(model As persona)

        Using con As New SqlConnection(sConn)
            Try
                con.Open()

                Dim Sql As String = "INSERT INTO personas(nombre_apellido, fecha_nacimiento, edad, sexo) VALUES(@nombre_apellido,@fecha_nacimiento,@edad, @sexo); SELECT SCOPE_IDENTITY()"
                Dim cmd As SqlCommand = New SqlCommand(Sql, con)

                cmd.Parameters.Add("@nombre_apellido", SqlDbType.VarChar, 150).Value = model.nombre
                cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.Date, 50).Value = model.fecha
                cmd.Parameters.Add("@edad", SqlDbType.Int, 50).Value = model.edad
                cmd.Parameters.Add("@sexo", SqlDbType.VarChar, 1).Value = model.sexo


                cmd.CommandType = CommandType.Text
                Dim n As Integer
                n = CInt(cmd.ExecuteScalar())

                Return True

            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function


End Class
