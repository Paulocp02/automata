Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO


Public Class formPDF

    Private Sub btLimpiarTexto_Click(sender As System.Object,
                 e As System.EventArgs) Handles btLimpiarTexto.Click
        txtTexto.Text = ""
    End Sub

    Private Sub btAbrirFicheroTexto_Click(sender As System.Object,
                 e As System.EventArgs) Handles btAbrirFicheroTexto.Click
        dlAbrir.CheckFileExists = True
        dlAbrir.CheckPathExists = True
        dlAbrir.Multiselect = False
        dlAbrir.DefaultExt = "txt"
        dlAbrir.FileName = ""
        dlAbrir.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        dlAbrir.Title = "Abrir fichero de texto para convertir a PDF"
        If dlAbrir.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim objFichero As New  _
                System.IO.StreamReader(dlAbrir.FileName, System.Text.Encoding.Default)
            txtTexto.Text = objFichero.ReadToEnd
        End If
    End Sub

    Private Sub btGenerarPDF_Click(sender As System.Object,
                 e As System.EventArgs) Handles btGenerarPDF.Click
        If txtTexto.Text = "" Then
            MsgBox("Debe introducir el texto a convertir a PDF.",
                   MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            txtTexto.Focus()
        Else
            If txtFicheroPDF.Text = "" Then
                MsgBox("Debe indicar el fichero PDF destino de la conversión del texto.",
                       MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                txtFicheroPDF.Focus()
            Else
                Try
                    'Creamos el objeto documento PDF
                    Dim documentoPDF As New Document
                    PdfWriter.GetInstance(documentoPDF,
                        New FileStream(txtFicheroPDF.Text, FileMode.Create))
                    documentoPDF.Open()

                    'Escribimos el texto en el objeto documento PDF
                    documentoPDF.Add(New Paragraph(txtTexto.Text,
                          FontFactory.GetFont(FontFactory.TIMES, 11,
                              iTextSharp.text.Font.NORMAL)))

                    '  documentoPDF.Add(New Paragraph("Documento generado por http://www.ajpdsoft.com",
                    '      FontFactory.GetFont(FontFactory.COURIER, 8,
                    '          iTextSharp.text.Font.NORMAL)))

                    'Añadimos los metadatos para el fichero PDF
                    documentoPDF.AddAuthor(txtAutor.Text)
                    documentoPDF.AddCreator("AjpdSoft Convertir texto a PDF - www.ajpdsoft.com")
                    documentoPDF.AddKeywords(txtPalabrasClave.Text)
                    documentoPDF.AddSubject(txtAsunto.Text)
                    documentoPDF.AddTitle(txtTitulo.Text)
                    documentoPDF.AddCreationDate()
                    'Cerramos el objeto documento, guardamos y creamos el PDF
                    documentoPDF.Close()
                    'Comprobamos si se ha creado el fichero PDF
                    If System.IO.File.Exists(txtFicheroPDF.Text) Then
                        If MsgBox("Texto convertido a fichero PDF correctamente " + _
                               "¿desea abrir el fichero PDF resultante?",
                               MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            'Abrimos el fichero PDF con la aplicación asociada
                            System.Diagnostics.Process.Start(txtFicheroPDF.Text)
                        End If
                    Else
                        MsgBox("El fichero PDF no se ha generado, " + _
                               "compruebe que tiene permisos en la carpeta de destino.",
                               MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
                    End If
                Catch ex As Exception
                    MsgBox("Se ha producido un error al intentar convertir el texto a PDF: " + _
                        vbCrLf + vbCrLf + ex.Message,
                        MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)
                End Try
            End If
        End If
    End Sub

    Private Sub btSeleccionarPDF_Click(sender As System.Object, _
                 e As System.EventArgs) Handles btSeleccionarPDF.Click
        dlGuardar.CheckFileExists = False
        dlGuardar.CheckPathExists = True
        dlGuardar.DefaultExt = "txt"
        dlGuardar.FileName = ""
        dlGuardar.Filter = "Archivos PDF (*.pdf)|*.pdf|Todos los archivos (*.*)|*.*"
        dlGuardar.Title = "Fichero PDF destino"
        If dlGuardar.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtFicheroPDF.Text = dlGuardar.FileName
        End If
    End Sub

    Private Sub formPDF_Load(sender As System.Object,
                e As System.EventArgs) Handles MyBase.Load
        txtFicheroPDF.Text =
            System.IO.Path.Combine(System.Environment.GetFolderPath(
                Environment.SpecialFolder.MyDocuments), "documento.pdf")
    End Sub
End Class
