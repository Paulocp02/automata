<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMenuPrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _1
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.bDesconectar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtODBC = New System.Windows.Forms.ComboBox()
        Me.lInfo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMotor = New System.Windows.Forms.ComboBox()
        Me.bConectar = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.bCargar = New System.Windows.Forms.Button()
        Me.bGuardar = New System.Windows.Forms.Button()
        Me.bEjecutar = New System.Windows.Forms.Button()
        Me.txtSQL = New System.Windows.Forms.TextBox()
        Me.txtResultado = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bGuardarResultado = New System.Windows.Forms.Button()
        Me.bLimpiar = New System.Windows.Forms.Button()
        Me.bSeleccionarTodo = New System.Windows.Forms.Button()
        Me.bCopiar = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.bDesconectar)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtODBC)
        Me.GroupBox1.Controls.Add(Me.lInfo)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtContrasena)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtUsuario)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtMotor)
        Me.GroupBox1.Controls.Add(Me.bConectar)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(583, 109)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos de conexión"
        '
        'bDesconectar
        '
        Me.bDesconectar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bDesconectar.Enabled = False
        Me.bDesconectar.Location = New System.Drawing.Point(496, 74)
        Me.bDesconectar.Name = "bDesconectar"
        Me.bDesconectar.Size = New System.Drawing.Size(82, 25)
        Me.bDesconectar.TabIndex = 17
        Me.bDesconectar.Text = "&Desconectar"
        Me.bDesconectar.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(343, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "ODBC"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtODBC
        '
        Me.txtODBC.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtODBC.FormattingEnabled = True
        Me.txtODBC.Location = New System.Drawing.Point(383, 18)
        Me.txtODBC.Name = "txtODBC"
        Me.txtODBC.Size = New System.Drawing.Size(193, 21)
        Me.txtODBC.TabIndex = 15
        '
        'lInfo
        '
        Me.lInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lInfo.Location = New System.Drawing.Point(6, 78)
        Me.lInfo.Name = "lInfo"
        Me.lInfo.Size = New System.Drawing.Size(482, 17)
        Me.lInfo.TabIndex = 14
        Me.lInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(319, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Contraseña"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtContrasena
        '
        Me.txtContrasena.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtContrasena.Location = New System.Drawing.Point(383, 48)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.Size = New System.Drawing.Size(105, 20)
        Me.txtContrasena.TabIndex = 12
        Me.txtContrasena.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Usuario"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(68, 45)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(122, 20)
        Me.txtUsuario.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Motor BD"
        '
        'txtMotor
        '
        Me.txtMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.txtMotor.FormattingEnabled = True
        Me.txtMotor.Items.AddRange(New Object() {"Estándar", "Microsoft Access", "MySQL", "Oracle", "SQL Server"})
        Me.txtMotor.Location = New System.Drawing.Point(69, 18)
        Me.txtMotor.Name = "txtMotor"
        Me.txtMotor.Size = New System.Drawing.Size(121, 21)
        Me.txtMotor.Sorted = True
        Me.txtMotor.TabIndex = 8
        '
        'bConectar
        '
        Me.bConectar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bConectar.Location = New System.Drawing.Point(496, 46)
        Me.bConectar.Name = "bConectar"
        Me.bConectar.Size = New System.Drawing.Size(82, 24)
        Me.bConectar.TabIndex = 7
        Me.bConectar.Text = "&Conectar"
        Me.bConectar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.bCargar)
        Me.GroupBox2.Controls.Add(Me.bGuardar)
        Me.GroupBox2.Controls.Add(Me.bEjecutar)
        Me.GroupBox2.Controls.Add(Me.txtSQL)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(583, 113)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SQL a ejecutar "
        '
        'bCargar
        '
        Me.bCargar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCargar.Location = New System.Drawing.Point(309, 79)
        Me.bCargar.Name = "bCargar"
        Me.bCargar.Size = New System.Drawing.Size(56, 28)
        Me.bCargar.TabIndex = 13
        Me.bCargar.Text = "C&argar"
        Me.bCargar.UseVisualStyleBackColor = True
        '
        'bGuardar
        '
        Me.bGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardar.Location = New System.Drawing.Point(522, 79)
        Me.bGuardar.Name = "bGuardar"
        Me.bGuardar.Size = New System.Drawing.Size(56, 28)
        Me.bGuardar.TabIndex = 12
        Me.bGuardar.Text = "&Guardar"
        Me.bGuardar.UseVisualStyleBackColor = True
        '
        'bEjecutar
        '
        Me.bEjecutar.Enabled = False
        Me.bEjecutar.Location = New System.Drawing.Point(6, 78)
        Me.bEjecutar.Name = "bEjecutar"
        Me.bEjecutar.Size = New System.Drawing.Size(56, 28)
        Me.bEjecutar.TabIndex = 11
        Me.bEjecutar.Text = "&Ejecutar"
        Me.bEjecutar.UseVisualStyleBackColor = True
        '
        'txtSQL
        '
        Me.txtSQL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSQL.Location = New System.Drawing.Point(6, 17)
        Me.txtSQL.Multiline = True
        Me.txtSQL.Name = "txtSQL"
        Me.txtSQL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtSQL.Size = New System.Drawing.Size(572, 57)
        Me.txtSQL.TabIndex = 9
        Me.txtSQL.Text = "select * from documentos"
        '
        'txtResultado
        '
        Me.txtResultado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtResultado.Location = New System.Drawing.Point(12, 237)
        Me.txtResultado.Multiline = True
        Me.txtResultado.Name = "txtResultado"
        Me.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtResultado.Size = New System.Drawing.Size(516, 140)
        Me.txtResultado.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 380)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(310, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "El resultado se muestra con los campos separados por tabulador"
        '
        'bGuardarResultado
        '
        Me.bGuardarResultado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bGuardarResultado.Location = New System.Drawing.Point(534, 237)
        Me.bGuardarResultado.Name = "bGuardarResultado"
        Me.bGuardarResultado.Size = New System.Drawing.Size(61, 28)
        Me.bGuardarResultado.TabIndex = 14
        Me.bGuardarResultado.Text = "Guardar"
        Me.bGuardarResultado.UseVisualStyleBackColor = True
        '
        'bLimpiar
        '
        Me.bLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bLimpiar.Location = New System.Drawing.Point(534, 349)
        Me.bLimpiar.Name = "bLimpiar"
        Me.bLimpiar.Size = New System.Drawing.Size(61, 28)
        Me.bLimpiar.TabIndex = 15
        Me.bLimpiar.Text = "Limpiar"
        Me.bLimpiar.UseVisualStyleBackColor = True
        '
        'bSeleccionarTodo
        '
        Me.bSeleccionarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bSeleccionarTodo.Location = New System.Drawing.Point(534, 270)
        Me.bSeleccionarTodo.Name = "bSeleccionarTodo"
        Me.bSeleccionarTodo.Size = New System.Drawing.Size(61, 28)
        Me.bSeleccionarTodo.TabIndex = 16
        Me.bSeleccionarTodo.Text = "Sel. Todo"
        Me.bSeleccionarTodo.UseVisualStyleBackColor = True
        '
        'bCopiar
        '
        Me.bCopiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.bCopiar.Location = New System.Drawing.Point(534 , 305)
        Me.bCopiar.Name = "bCopiar"
        Me.bCopiar.Size = New System.Drawing.Size(61 , 28)
        Me.bCopiar.TabIndex = 17
        Me.bCopiar.Text = "Copiar"
        Me.bCopiar.UseVisualStyleBackColor = True
        '
        'formMenuPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(606 , 397)
        Me.Controls.Add(Me.bCopiar)
        Me.Controls.Add(Me.bSeleccionarTodo)
        Me.Controls.Add(Me.bLimpiar)
        Me.Controls.Add(Me.bGuardarResultado)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtResultado)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "formMenuPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AjpdSoft Conexión BD Visual Basic .Net"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtContrasena As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMotor As System.Windows.Forms.ComboBox
    Friend WithEvents bConectar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtODBC As System.Windows.Forms.ComboBox
    Friend WithEvents lInfo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents bGuardar As System.Windows.Forms.Button
    Friend WithEvents bEjecutar As System.Windows.Forms.Button
    Friend WithEvents txtSQL As System.Windows.Forms.TextBox
    Friend WithEvents bCargar As System.Windows.Forms.Button
    Friend WithEvents bDesconectar As System.Windows.Forms.Button
    Friend WithEvents txtResultado As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents bGuardarResultado As System.Windows.Forms.Button
    Friend WithEvents bLimpiar As System.Windows.Forms.Button
    Friend WithEvents bSeleccionarTodo As System.Windows.Forms.Button
    Friend WithEvents bCopiar As System.Windows.Forms.Button

End Class
