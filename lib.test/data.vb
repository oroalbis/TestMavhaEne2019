﻿Imports System.Configuration
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

                Dim Sql As String = "INSERT INTO personas(nombre_apellido, fecha_nacimiento, edad, sexo, sn_activo) VALUES(LTRIM(RTRIM(@nombre_apellido)),@fecha_nacimiento,@edad, @sexo,1); SELECT SCOPE_IDENTITY()"
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


    Public Function Update(model As persona)

        Using con As New SqlConnection(sConn)
            Try
                con.Open()

                Dim Sql As String = "update personas set nombre_apellido = LTRIM(RTRIM(@nombre_apellido)), fecha_nacimiento = @fecha_nacimiento , edad = @edad, sexo = @sexo where id =@id"
                Dim cmd As SqlCommand = New SqlCommand(Sql, con)

                cmd.Parameters.Add("@nombre_apellido", SqlDbType.VarChar, 150).Value = model.nombre
                cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.Date, 50).Value = model.fecha
                cmd.Parameters.Add("@edad", SqlDbType.Int, 50).Value = model.edad
                cmd.Parameters.Add("@sexo", SqlDbType.VarChar, 1).Value = model.sexo
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = model.id


                cmd.CommandType = CommandType.Text
                Dim rowsAffected As Integer
                rowsAffected = cmd.ExecuteNonQuery()

                Return True

            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

    Public Function Delete(id As Int16)

        Using con As New SqlConnection(sConn)
            Try
                con.Open()

                Dim Sql As String = "update personas set sn_activo = 0 where id = @id"
                Dim cmd As SqlCommand = New SqlCommand(Sql, con)

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id

                cmd.CommandType = CommandType.Text
                Dim rowsAffected As Integer
                rowsAffected = cmd.ExecuteNonQuery()

                Return True

            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

    Public Function DeletePermanent(id As Int16)

        Using con As New SqlConnection(sConn)
            Try
                con.Open()

                Dim Sql As String = "delete from personas where id = @id"
                Dim cmd As SqlCommand = New SqlCommand(Sql, con)

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id

                cmd.CommandType = CommandType.Text
                Dim rowsAffected As Integer
                rowsAffected = cmd.ExecuteNonQuery()

                Return True

            Catch ex As Exception
                Return False
            End Try
        End Using
    End Function

    Public Function GetItems() As DataSet

        Using con As New SqlConnection(sConn)
            Try
                con.Open()

                Dim Sql As String = "select id,nombre_apellido,FORMAT(fecha_nacimiento,'dd/MM/yyyy', 'en-us') fecha_nacimiento,edad,sexo from personas where sn_activo = 1"
                Dim cmd As SqlCommand = New SqlCommand(Sql, con)

                'cmd.Parameters.Add("@id", SqlDbType.Int).Value = id

                Dim oDa = New SqlDataAdapter(cmd)
                Dim oDt = New DataSet
                oDa.Fill(oDt)

                Return oDt

            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

    Public Function GetOne(id As Integer) As DataSet

        Using con As New SqlConnection(sConn)
            Try
                con.Open()

                Dim Sql As String = "select id,nombre_apellido,FORMAT(fecha_nacimiento,'dd/MM/yyyy', 'en-us') fecha_nacimiento,edad,sexo from personas where id = @id"
                Dim cmd As SqlCommand = New SqlCommand(Sql, con)

                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id

                Dim oDa = New SqlDataAdapter(cmd)
                Dim oDt = New DataSet
                oDa.Fill(oDt)

                Return oDt

            Catch ex As Exception
                Return Nothing
            End Try
        End Using
    End Function

End Class
