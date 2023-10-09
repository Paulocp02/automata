Public Class formAccesoNativoMySQL

    Friend conexion As MySqlConnection

    Private Function numeroRegistrosConsulta( _
                ByVal dr As MySqlDataReader) As Integer
        Dim numeroRegistros As Integer = 0
        Do While dr.Read
            numeroRegistros = numeroRegistros + 1
        .10
        Loop
        numeroRegistrosConsulta = numeroRegistros
    End Function

    Private Function numeroTablas() As Integer
        Dim consultaSQL As MySqlCommand =
            New MySqlCommand("show tables", conexion)
        Dim dr As MySqlDataReader = consultaSQL.ExecuteReader()
        numeroTablas = numeroRegistrosConsulta(dr)
        dr.Close()
    End Function


    Private Function esquemasMySQL() As List(Of String)
        Dim listaEsquemas As List(Of String)

        listaEsquemas = New List(Of String)

        Dim consultaSQL As MySqlCommand =
            New MySqlCommand("SHOW DATABASES", conexion)

        Dim dr As MySqlDataReader = consultaSQL.ExecuteReader
        Do While dr.Read
            listaEsquemas.Add(dr.Item("Database"))
        Loop
        esquemasMySQL = listaEsquemas
    End Function

    Private Sub conectarServidorMySQL()
        Try
            conexion = New MySqlConnection()
            conexion.ConnectionString =
                "server=" & txtServidor.Text & ";" &
                "user id=" & txtUsuario.Text & ";" &
                "password=" & txtContrasena.Text & ";" &
                "port=" & txtPuerto.Text & ";" &
                "database=" & lsBD.Text & ";"
            conexion.Open()
            If lsBD.Text <> "" Then
                bePanelNumTablas.Text = CStr(numeroTablas())
            End If
            bePanel2.Text = "Conectado a servidor " &
                txtServidor.Text
        Catch ex As Exception
            MsgBox("Error al conectar al servidor MySQL " &
                   vbCrLf & vbCrLf & ex.Message,
                   MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btConectar_Click(sender As System.Object,
                 e As System.EventArgs) Handles btConectar.Click
        conectarServidorMySQL()

        Dim lista As List(Of String)
        Dim i As Integer

        lsBD.Items.Clear()

        If lsBD.Text <> "" Then
            bePanelNumTablas.Text =
                "| Nº tablas: " & CStr(numeroTablas())
        End If

        lista = esquemasMySQL()
        For i = 0 To lista.Count - 1
            lsBD.Items.Add(lista.Item(i).ToString)
        Next

    End Sub

    Private Sub btEjecutar_Click(sender As System.Object,
                e As System.EventArgs) Handles btEjecutar.Click
        Dim consultaSQL As MySqlCommand =
            New MySqlCommand(txtSQL.Text, conexion)

        'Consulta SQL que devuelve registros (SELECT)
        If opDatos.Checked Then
            Dim ds As DataSet = New DataSet()
            Dim DataAdapter1 As MySqlDataAdapter =
                New MySqlDataAdapter()

            Try
                DataAdapter1.SelectCommand = consultaSQL
                DataAdapter1.Fill(ds, "Tabla")
                DataGridView1.DataSource = ds
                DataGridView1.DataMember = "Tabla"

                bePanelNumRegistros.Text = "| Nº registros: " &
                    CStr(ds.Tables(0).Rows.Count)
            Catch ex As MySqlException
                MsgBox("Error al ejecutar consulta SQL: " &
                       vbCrLf & vbCrLf & ex.ErrorCode & " " &
                       ex.Message,
                       MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            End Try
        End If

        'Consulta SQL que no devuelve registros 
        '(INSERT, DELETE, UPDATE, CREATE, DROP)
        If opNoDatos.Checked Then
            Dim numRegistrosAfectados As Integer
            Dim comandoSQL As New MySqlCommand
            Try
                comandoSQL.Connection = conexion
                comandoSQL.CommandText = txtSQL.Text
                numRegistrosAfectados = comandoSQL.ExecuteNonQuery()
                bePanelNumRegistros.Text = "| Nº registros afectados: " &
                    CStr(numRegistrosAfectados)
                MsgBox("Consulta SQL ejecutada correctamente en " &
                     "servidor MySQL. Número de registros afectados: " &
                     CInt(numRegistrosAfectados),
                     MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
            Catch ex As MySqlException
                MsgBox("Error al ejecutar consulta SQL: " &
                       vbCrLf & vbCrLf & ex.ErrorCode & " " &
                       ex.Message,
                       MsgBoxStyle.OkOnly + MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub btUsarEsquema_Click(sender As System.Object,
             e As System.EventArgs) Handles btUsarEsquema.Click
        If lsBD.Text <> "" Then
            Try
                If conexion.State = ConnectionState.Open Then
                    conexion.Close()
                End If

                conexion.ConnectionString =
                    "server=" & txtServidor.Text & ";" &
                    "user id=" & txtUsuario.Text & ";" &
                    "password=" & txtContrasena.Text & ";" &
                    "port=" & txtPuerto.Text & ";" &
                    "database=" & lsBD.Text & ";"
                conexion.Open()
                If lsBD.Text <> "" Then
                    bePanelNumTablas.Text =
                        "| Nº tablas: " & CStr(numeroTablas())
                End If
                bePanel2.Text = "Conectado | " &
                    txtServidor.Text & "@" &
                    lsBD.Text & "@" & txtUsuario.Text
            Catch ex As Exception
                MsgBox("Error al conectar al servidor MySQL " &
                       vbCrLf & vbCrLf & ex.Message)
            End Try
        Else
            MsgBox("Debe seleccionar el esquema " &
                   "(base de datos) a usar.",
                MsgBoxStyle.OkOnly + MsgBoxStyle.Information)
            lsBD.Focus()
        End If
    End Sub
End Class
