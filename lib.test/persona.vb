Public Class persona
    Private idValue As Int16
    Public Property id() As Int16
        Get
            Return idValue
        End Get
        Set(ByVal value As Int16)
            idValue = value
        End Set
    End Property

    Private nombreValue As String
    Public Property nombre() As String
        Get
            Return nombreValue
        End Get
        Set(ByVal value As String)
            nombreValue = value
        End Set
    End Property

    Private fechaValue As Date
    Public Property fecha() As Date
        Get
            Return fechaValue
        End Get
        Set(ByVal value As Date)
            fechaValue = value
        End Set
    End Property

    Private edadValue As Int16
    Public Property edad() As Int16
        Get
            Return edadValue
        End Get
        Set(ByVal value As Int16)
            edadValue = value
        End Set
    End Property

    Private sexoValue As String
    Public Property sexo() As String
        Get
            Return sexoValue
        End Get
        Set(ByVal value As String)
            sexoValue = value
        End Set
    End Property

End Class
