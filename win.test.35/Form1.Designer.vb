﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPersonas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.dgvPersonas = New System.Windows.Forms.DataGridView()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.nombre_apellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_nacimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sexo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.lblObs2 = New System.Windows.Forms.Label()
        Me.lblObs = New System.Windows.Forms.Label()
        CType(Me.dgvPersonas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPersonas
        '
        Me.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPersonas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nombre_apellido, Me.fecha_nacimiento, Me.Edad, Me.Sexo})
        Me.dgvPersonas.Location = New System.Drawing.Point(2, 2)
        Me.dgvPersonas.Name = "dgvPersonas"
        Me.dgvPersonas.Size = New System.Drawing.Size(799, 360)
        Me.dgvPersonas.TabIndex = 0
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(350, 409)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(165, 23)
        Me.btnActualizar.TabIndex = 1
        Me.btnActualizar.Text = "Actualizar Datos"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'nombre_apellido
        '
        Me.nombre_apellido.DataPropertyName = "nombre_apellido"
        Me.nombre_apellido.HeaderText = "Nombre y Apellido"
        Me.nombre_apellido.Name = "nombre_apellido"
        Me.nombre_apellido.Width = 250
        '
        'fecha_nacimiento
        '
        Me.fecha_nacimiento.DataPropertyName = "fecha_nacimiento"
        Me.fecha_nacimiento.HeaderText = "Fecha Nacimiento"
        Me.fecha_nacimiento.Name = "fecha_nacimiento"
        Me.fecha_nacimiento.Width = 150
        '
        'Edad
        '
        Me.Edad.DataPropertyName = "edad"
        Me.Edad.HeaderText = "Edad"
        Me.Edad.Name = "Edad"
        '
        'Sexo
        '
        Me.Sexo.DataPropertyName = "sexo"
        Me.Sexo.HeaderText = "Sexo"
        Me.Sexo.Items.AddRange(New Object() {"M", "F"})
        Me.Sexo.Name = "Sexo"
        Me.Sexo.Width = 120
        '
        'lblObs2
        '
        Me.lblObs2.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblObs2.Location = New System.Drawing.Point(291, 384)
        Me.lblObs2.Name = "lblObs2"
        Me.lblObs2.Size = New System.Drawing.Size(276, 17)
        Me.lblObs2.TabIndex = 2
        Me.lblObs2.Text = "Esperando Actualizaciones"
        Me.lblObs2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblObs
        '
        Me.lblObs.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblObs.Location = New System.Drawing.Point(291, 364)
        Me.lblObs.Name = "lblObs"
        Me.lblObs.Size = New System.Drawing.Size(276, 17)
        Me.lblObs.TabIndex = 3
        Me.lblObs.Text = "Iniciando Carga...."
        Me.lblObs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPersonas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 438)
        Me.Controls.Add(Me.lblObs)
        Me.Controls.Add(Me.lblObs2)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.dgvPersonas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPersonas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Personas"
        CType(Me.dgvPersonas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvPersonas As DataGridView
    Friend WithEvents btnActualizar As Button
    Friend WithEvents nombre_apellido As DataGridViewTextBoxColumn
    Friend WithEvents fecha_nacimiento As DataGridViewTextBoxColumn
    Friend WithEvents Edad As DataGridViewTextBoxColumn
    Friend WithEvents Sexo As DataGridViewComboBoxColumn
    Friend WithEvents lblObs2 As Label
    Friend WithEvents lblObs As Label
End Class
