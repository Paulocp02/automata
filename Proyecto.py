import sys
import re
from PyQt5.QtWidgets import (QApplication,QMainWindow,QTextEdit,QLabel,QVBoxLayout,QHBoxLayout,QFileDialog,QTextBrowser,QWidget,QMessageBox,QScrollArea,QShortcut, QMenu, QMenuBar, QAction)
from PyQt5.QtCore import Qt
from PyQt5.QtGui import QFont, QKeySequence

class Window(QMainWindow):
    def __init__(self):
        super().__init__()
        self.left = 0
        self.top = 30
        self.width = 1920
        self.height = 1000
        self.initUI()
        

    def initUI(self):
        
        self.setWindowTitle("Proyecto Automatas y Lenguajes formales")
        self.setGeometry(self.left, self.top, self.width, self.height)
        self.initMenu()
        self.initFrames()
        self.currentePath = ""

        #Atajos de teclado
        #Atajo Abrir
        self.shortcutAbrir = QShortcut(QKeySequence('Ctrl+O'), self)
        self.shortcutAbrir.activated.connect(self.abrirArchivo)
        #Atajo Guardar
        self.shortcutGuardar = QShortcut(QKeySequence('Ctrl+S'), self)
        self.shortcutGuardar.activated.connect(self.guardarArchivo)
        #Atajo Guardar Como
        self.shortcutGuardarComo = QShortcut(QKeySequence('Ctrl+Shift+S'), self)
        self.shortcutGuardarComo.activated.connect(self.guardarComoArchivo)
        #Atajo Cerrar
        self.shortcutCerrar = QShortcut(QKeySequence('Ctrl+Q'), self)
        self.shortcutCerrar.activated.connect(self.closeEvent)
        #Atajo Minimizar
        self.shortcut_minimize = QShortcut(QKeySequence('Ctrl+M'), self)
        self.shortcut_minimize.activated.connect(self.showMinimized)
        #Atajo Separar tokens
        self.shortcut_separarTokens = QShortcut(QKeySequence('F1'), self)
        self.shortcut_separarTokens.activated.connect(self.separarEnTonkens)
        #Atajo clasificaar tokens
        self.shortcut_clasificarTokens = QShortcut(QKeySequence('F2'), self)
        self.shortcut_clasificarTokens.activated.connect(self.clasificarTokens)
        #Atajo Sistema Num
        self.shortcut_sistemaNum = QShortcut(QKeySequence('F3'), self)
        self.shortcut_sistemaNum.activated.connect(self.sistemaNum)

    def initMenu(self):
        MenuBar = self.menuBar()

        MenuFile = MenuBar.addMenu("Archivo")
        MenuFile.addAction("Abrir Ctrl+O", self.abrirArchivo)
        MenuFile.addAction("Guardar Ctrl+S", self.guardarArchivo)
        MenuFile.addAction("Guardar como Ctrl+Shift+S", self.guardarComoArchivo)
        MenuFile.addAction("Salir Ctrl+Q", self.closeEvent)

        MenuTokens = MenuBar.addMenu("Tokens")
        MenuTokens.addAction("Obtener F1", self.separarEnTonkens)
        MenuTokens.addAction("Clasificar F2", self.clasificarTokens)
        MenuTokens.addAction("Sistemas Numericos F3", self.sistemaNum)

        MenuBar.setStyleSheet("""
        QMenuBar {
            background-color: gray;
            color: white;
            font-size: 18px; 
        }
        QMenuBar::item {
            background-color: gray;
            color: white;
        }
        QMenuBar::item::selected {
            background-color: #2E2E2E;
        }
        QMenu {
            background-color: #2E2E2E;  
            color: white;  
            font-size: 18px;
        }
        QMenu::item {
            background-color: #2E2E2E;
        }
        QMenu::item::selected {
            background-color: gray;  
        }
        """)

    def initFrames(self):

        # Set Main widget y main canva
        mainWidget = QWidget(self)
        self.setCentralWidget(mainWidget)  # Indica que será el widget principal
        mainWidget.setStyleSheet("background-color: gray;")
        mainCanva = QVBoxLayout(mainWidget)

        # Marco1
        Marco1 = QWidget()
        Marco1.setFixedSize(900, 750)
        Marco1.setStyleSheet("background-color: white; border: none; padding: 0;")
        
        # Marco2
        Marco2 = QWidget()
        Marco2.setFixedSize(990, 750)
        Marco2.setStyleSheet("background-color: white; border: none; padding: 0;")

        canvaUno = QVBoxLayout(Marco1)
        canvaUno.setContentsMargins(0, 0, 0, 0)  # Establecer el margen en cero

        canvaDos = QVBoxLayout(Marco2)
        canvaDos.setContentsMargins(0, 0, 0, 0)  # Establecer el margen en cero


        tituloPrinUno = QLabel("Archivo .vb:")
        tituloPrinUno.setStyleSheet("background-color: gray; color: white;")
        tituloPrinUno.setFixedHeight(30)

        canvaUno.addWidget(tituloPrinUno)
        fuente = QFont("Arial", 18, QFont.Bold)
        tituloPrinUno.setFont(fuente)
        tituloPrinUno.setAlignment(Qt.AlignCenter)

        scroll_area1 = QScrollArea()
        scroll_area1.setWidgetResizable(True)
        self.cajaTexto1 = QTextEdit()
        self.cajaTexto1.setFixedSize(5000, 5000)
        self.cajaTexto1.setStyleSheet("font-size: 24px;")
        self.cajaTexto1.setVerticalScrollBarPolicy(Qt.ScrollBarAlwaysOff)
        scroll_area1.setWidget(self.cajaTexto1)
        
        canvaUno.addWidget(scroll_area1)

        tituloPrinDos = QLabel("Tokens:")
        tituloPrinDos.setStyleSheet("background-color: gray; color: white;")
        tituloPrinDos.setFixedHeight(30)
        canvaDos.addWidget(tituloPrinDos)
        tituloPrinDos.setFont(fuente)
        tituloPrinDos.setAlignment(Qt.AlignCenter)

        scroll_area2 = QScrollArea()
        scroll_area2.setWidgetResizable(True)
        self.cajaTexto2 = QTextBrowser()
        self.cajaTexto2.setFixedSize(5000, 5000)
        self.cajaTexto2.setStyleSheet("font-size: 24px;")
        self.cajaTexto2.setVerticalScrollBarPolicy(Qt.ScrollBarAlwaysOff)
        scroll_area2.setWidget(self.cajaTexto2)
        canvaDos.addWidget(scroll_area2)
        
        # Ventana de error debajo de las cajas de texto
        ventanaError = QScrollArea()
        ventanaError.setWidgetResizable(True)
        self.cajaError = QTextBrowser()
        self.cajaError.setFixedSize(1920, 1000)
        self.cajaError.setStyleSheet("background-color: white; font-size: 20px; color: red;")
        self.cajaError.setVerticalScrollBarPolicy(Qt.ScrollBarAlwaysOff)
        ventanaError.setWidget(self.cajaError)

        # Layout horizontal para colocar Marco1 y Marco2 uno al lado del otro
        layoutHorizontal = QHBoxLayout()
        layoutHorizontal.addWidget(Marco1)
        layoutHorizontal.addWidget(Marco2)

        # Agregar el layout horizontal y la ventana de error al layout vertical principal
        mainCanva.addLayout(layoutHorizontal)
        mainCanva.addWidget(ventanaError)

    def abrirArchivo(self):
        rutaArchivo, _ = QFileDialog.getOpenFileName(
            self, "Abrir Archivo .vb", "", "Archivos VB (*.vb)"
        )
        if rutaArchivo:
            with open(rutaArchivo, "r") as file:  # abre el archivo en modo lectura
                contenido = file.read()
                self.cajaTexto1.setPlainText(contenido)
                self.rutaArchivoActual = (
                    rutaArchivo  # Establecer la ruta del archivo actual
                )

    def guardarArchivo(self):
        # Se verifica si en la clase existe un atributo llamado rutaArchivoActual
        if hasattr(self, "rutaArchivoActual"):
            rutaArchivo = self.rutaArchivoActual
        else:
            rutaArchivo, _ = QFileDialog.getSaveFileName(
                self,
                "Guardar Archivo",
                "",
                "Archivos VB (*.vb);;Archivos de Texto (*.txt);;Todos los archivos (*)",
            )
            self.rutaArchivoActual = rutaArchivo  # Almacenar la ruta del archivo actual

        if rutaArchivo:
            contenido = self.cajaTexto1.toPlainText()
            with open(rutaArchivo, "w") as file:
                file.write(contenido)

            # Actualizar la ruta del archivo actual
            self.rutaArchivoActual = rutaArchivo

    def guardarComoArchivo(self):
        rutaArchivo, _ = QFileDialog.getSaveFileName(
            self,
            "Guardar Archivo",
            "",
            "Archivos VB (*.vb);;Archivos de Texto (*.txt);;Todos los archivos (*)",
        )
        if rutaArchivo:
            contenido = self.cajaTexto1.toPlainText()
            with open(rutaArchivo, "w") as file:
                file.write(contenido)

        # Actualizar la ruta del archivo actual
        self.rutaArchivoActual = rutaArchivo

    def closeEvent(self, event):
        if hasattr(self, "rutaArchivoActual") and self.cajaTexto1.toPlainText() != "":
            contenido_actual = self.cajaTexto1.toPlainText()
            with open(self.rutaArchivoActual, "r") as file:
                contenido_guardado = file.read()

            if contenido_actual != contenido_guardado:
                respuesta = QMessageBox.question(
                    self,
                    "Guardar Cambios",
                    "¿Deseas guardar los cambios antes de cerrar?",
                    QMessageBox.Yes | QMessageBox.No | QMessageBox.Cancel,
                )

                if respuesta == QMessageBox.Yes:
                    self.guardarArchivo()
                elif respuesta == QMessageBox.Cancel:
                    event.ignore()
                    return

        event.accept()

    def separarEnTonkens(self):
        self.cajaTexto2.clear()
        self.cajaError.clear()
        # Se borra cualquier contenido previo
        
        # Se separa el texto original en lineas tomando en cuenta los saltos de linea
        lineasSeparadas = self.cajaTexto1.toPlainText().upper().split("\n")
        numero_de_linea = 0
        
        # Se recorre cada linea
        for caracteres in lineasSeparadas:
            
            #tokens = caracteres.split()
            tokens = [token for token in re.split(r'(".*?"|\s+|(?<=\D)\.(?=\D)|\.(?=\w+\()|\.(?=\w+\.\w+)|\(|\))', caracteres) if token and not token.isspace()]
            lineasTokens = ""
            numero_de_linea += 1

            for token in tokens:
                lineasTokens += f" {token} , "
            
            self.cajaTexto2.append( f"{numero_de_linea} {lineasTokens[:-2]}")

    def clasificar_error(self, error, token, numero_de_linea):
        errores = {
            '0': (f"Error en la línea {numero_de_linea}:\n"
                  f"                     Revisa --->{token} no es reconocido"),
            '1': (f"Error en la línea {numero_de_linea}:\n"
                  f"                     Revisa --->{token} no es decimal, octal o hexadecimal válido"),
            '2': (f"Error en la línea {numero_de_linea}:\n"
                  f"                     Revisa --->{token} no es hexadecimal válido"),
            '3': (f"Error en la línea {numero_de_linea}:\n"
                  f"                     Revisa --->{token} no es hexadecimal válido"),
            '4': (f"Error en la línea {numero_de_linea}:\n"
                  f"                     Revisa --->{token} no es hexadecimal válido"),
            '5': (f"Error en la línea {numero_de_linea}:\n"
                  f"                     Revisa --->{token} no es decimal válido"),
            '6': (f"Error en la línea {numero_de_linea}:\n"
                  f"                     Revisa --->{token} no es decimal válido"),
            '7': (f"Error en la línea {numero_de_linea}:\n"
                  f"                     Revisa --->{token} no es decimal válido"),
            '8': (f"Error en la línea {numero_de_linea}:\n"
                  f"                     Revisa --->{token} no es octal válido"),
        }
        return errores.get(error, f"Error desconocido en la línea {numero_de_linea}: {token}")

    def sistemaNum(self):
        self.cajaTexto2.clear()
        self.cajaError.clear()
        # Se borra cualquier contenido previo
        
        # Se separa el texto original en lineas tomando en cuenta los saltos de linea
        lineasSeparadas = self.cajaTexto1.toPlainText().upper().split("\n")
        numero_de_linea = 0
        
        # Se recorre cada linea
        for caracteres in lineasSeparadas:
            
            tokens = caracteres.split()
            lineasTokens = ""
            numero_de_linea += 1

            for token in tokens:
                estadosAcepta, error = self.AutoSisNum(token)

                if estadosAcepta:
                    if re.match(r'0[Xx][0-9A-Fa-f]+',token):
                        lineasTokens += f"Hex: {token}, "
                    elif re.match(r'0[oO]?[0-7]+',token):
                        lineasTokens += f"Oct: {token}, "
                    elif re.match(r'-?\d+\.\d+|\d+\.\d+|-?\d+',token):
                        lineasTokens += f"Decimal{token}, "
                else:
                    if re.match(r'0[Xx][0-9A-Fa-f]+',token):
                        lineasTokens += f"Hex: {token}, "
                        mensaje_error = self.clasificar_error(error, token, numero_de_linea)
                        self.cajaError.append(mensaje_error)
                    elif re.match(r'0[oO]?[0-7]+',token):
                        lineasTokens += f"Oct: {token}, "
                        mensaje_error = self.clasificar_error(error, token, numero_de_linea)
                        self.cajaError.append(mensaje_error)
                    elif re.match(r'-?\d+\.\d+|\d+\.\d+|-?\d+',token):
                        lineasTokens += f"Decimal: {token}, "
                        mensaje_error = self.clasificar_error(error, token, numero_de_linea)
                        self.cajaError.append(mensaje_error)
                    else :
                        lineasTokens += f"No Identi: {token}, "
                        mensaje_error = self.clasificar_error(error, token, numero_de_linea)
                        self.cajaError.append(mensaje_error)

                                                        
            self.cajaTexto2.append( f"{numero_de_linea} {lineasTokens[:-2]}")

    def AutoSisNum(self,entrada):
        contador = 0
        estado=0 
        error=None
        continuar = True

        while contador < len(entrada) and (continuar==True) :

            simbolo = entrada[contador]

            if estado==0:
                if simbolo=='0':
                    estado = 1
                elif simbolo == '.':
                    estado = 6
                elif ('1' <= simbolo <= '9'):
                    estado =5
                else:
                    error='0'
                    continuar = False
            
            elif estado==1:
                if simbolo=='.':
                    estado = 6
                elif simbolo == 'X':
                    estado = 2
                elif ('0' <= simbolo <= '7'):
                    estado =8
                else:
                    error='1'
                    continuar = False

            elif estado==2:
                if (('A' <= simbolo <= 'F')  or ('0' <= simbolo <= '9')):
                    estado = 3
                else:
                    error='2'
                    continuar = False 

            elif estado==3:
                if (('A' <= simbolo <= 'F')  or ('0' <= simbolo <= '9')):
                    estado = 4
                else:
                    error='3'
                    continuar = False  

            elif estado==4:
                if (('A' <= simbolo <= 'F')  or ('0' <= simbolo <= '9')):
                    estado = 3
                else:
                    error='4'
                    continuar = False     

            elif estado==5:
                if simbolo == '.':
                    estado = 6
                elif ('0' <= simbolo <= '9'):
                    estado = 5
                else:
                    error='5'
                    continuar = False 

            elif estado==6:
                if ('0' <= simbolo <= '9'):
                    estado = 7
                else:
                    error='6'
                    continuar = False 

            elif estado==7:
                if ('0' <= simbolo <= '9'):
                    estado = 7
                else:
                    error='7'
                    continuar = False  

            elif estado==8:
                if ('0' <= simbolo <= '7'):
                    estado = 8
                else:
                    error='8'
                    continuar = False 

            contador+=1

        if estado == 2 and contador == len(entrada):
            error = '2'

        estadosAcepta =  estado in [3,4,5,7,8]
        return (estadosAcepta, error)

    def AutoNumeroReal(self, entrada):
        estado = 1
        conta = 0
        while conta < len(entrada):
            cadena = entrada[conta]

            if estado == 1:
                if cadena.isdigit():
                    estado = 2
                elif cadena =="-" or cadena =="+":
                    estado = 2 
                else:
                    return False

            elif estado == 2:
                if cadena.isdigit():
                    estado = 2
                elif cadena == '.' or cadena == ',':
                    estado = 3
                elif cadena == 'E':
                    estado = 5
                else:
                    return False

            elif estado == 3:
                if cadena.isdigit():
                    estado = 4
                
                else:
                    return False

            elif estado ==4:
                if cadena.isdigit():
                    estado = 4
                elif cadena == 'E':
                    estado = 5
                else:
                    return False

            elif estado == 5:
                if cadena.isdigit():
                    estado = 7
                elif cadena =="-" or cadena =="+":
                    estado = 6
                else:
                    return False
            
            elif estado == 6:
                if cadena.isdigit():
                    estado = 7
                
                else:
                    return False
            
            elif estado == 7:
                if cadena.isdigit():
                    estado = 7
                
                else:
                    return False

            conta += 1

        return estado in [2, 4, 7]

    def AutoIdenti(self,entrada):
        contador = 0
        estado=1 
        
        while contador < len(entrada):

            simbolo = entrada[contador]

            if estado==1:
                if (('A' <= simbolo <= 'Z')  or (simbolo == '_')):
                    estado = 3
                elif ('0'<= simbolo <= '9'):
                    estado = 2
                else:
                    return False
                
            elif estado==2:
                return False

            elif estado==3:
                if (('A' <= simbolo <= 'Z')  or (simbolo == '_') or ('0'<= simbolo <= '9')):
                    estado=3
                else:
                    return False
                    
            contador+=1

        return estado == 3

    def clasificarTokens(self):
        self.cajaTexto2.clear()
        self.cajaError.clear()

        # Almacena el código .vb y lo convierte en MAYÚSCULA
        # Separa en líneas el texto original como criterio el salto de línea
        saltoLinea = self.cajaTexto1.toPlainText().upper().split("\n")

        # Conjunto de palabras reservadas
        
        palabrasReservadas = [
            "ADDHANDLER", "ADDRESSOF", "ALIAS", "AND", "ANDALSO", "AS", "BOOLEAN", "BYREF",
            "BYTE", "BYVAL", "CALL", "CASE", "CATCH", "CBOOL", "CBYTE", "CCHAR", "CDATE",
            "CDBL", "CDEC", "CHAR", "CINT", "CLASS", "CLNG", "COBJ", "CONST", "CONTINUE",
            "CSBYTE", "CSHORT", "CSNG", "CSTR", "CTYPE", "CUINT", "CULNG", "CUSHORT", "DATE",
            "DECIMAL", "DECLARE", "DEFAULT", "DELEGATE", "DIM", "DIRECTCAST", "DO", "DOUBLE",
            "EACH", "ELSE", "ELSEIF", "END", "ENDIF", "ENUM", "ERASE", "ERROR", "EVENT",
            "EXIT", "FALSE", "FINALLY", "FOR", "FRIEND", "FUNCTION", "GET", "GETTYPE",
            "GOSUB", "GOTO", "HANDLES", "IF", "IMPLEMENTS", "IMPORTS", "IN", "INHERITS",
            "INTEGER", "INTERFACE", "IS", "LET", "LIB", "LIKE", "LONG", "LOOP", "ME", "MOD",
            "MODULE", "MUSTINHERIT", "MUSTOVERRIDE", "MYBASE", "MYCLASS", "NAMESPACE", "NARROWING",
            "NEW", "NEXT", "NOT", "NOTHING", "NOTINHERITABLE", "NOTOVERRIDABLE", "OBJECT", "OF",
            "ON", "OPERATOR", "OPTION", "OPTIONAL", "OR", "ORELSE", "OVERLOADS", "OVERRIDABLE",
            "OVERRIDES", "PARAMARRAY", "PARTIAL", "PRIVATE", "PROPERTY", "PROTECTED", "PUBLIC",
            "RAISEEVENT", "READONLY", "REDIM", "REM", "REMOVEHANDLER", "RESUME", "RETURN",
            "SBYTE", "SELECT", "SET", "SHADOWS", "SHARED", "SHORT", "SINGLE", "STATIC",
            "STEP", "STOP", "STRING", "STRUCTURE", "SUB", "SYNCLOCK", "THEN", "THROW", "TO",
            "TRUE", "TRY", "TRYCAST", "TYPEOF", "UINTEGER", "ULONG", "USHORT", "USING",
            "VARIANT", "WEND", "WHEN", "WHILE", "WIDENING", "WITH", "WITHEVENTS", "WRITEONLY", "XOR"]

        # Conjunto de operadores de acceso
        operadoresAcceso= {".","!","(",")","()"}

        # Conjunto de operadores de caracteres especiales
        caracteresEspeciales = {",", "{", "}", ";", ":"}

        # Conjunto de operadores de comparación
        operaCompara = {"<>", "<=", ">=", "!=", "==", "<", ">",'&'}

        # Conjunto de operadores de asignacion
        operadores_asignacion = {'=', '+=', '-=', '*=', '/=', '\=', 'Mod=', '^='}

        # Conjunto de operadores lógicos
        operaLogi = {"AND", "ANDALSO", "OR", "ORELSE", "NOT"}

        # Conjunto de operadores aritméticos
        operaAritm = {"+", "-", "*", "/", "%", "^","MOD"}

        # Se inicia una cadena que almacena el resultado final
        

        numero_de_linea = 0

        for i in saltoLinea: 
            # Se separa en tokens
            expresionesR = re.compile(
                r'([<|>])|'  # captura '<'y'>'
                r'(".*?")|'  # Texto entre ""
                r'(\d+(,\d+)*(\.\d+)*(E+[-+]?\d+)?)|' # Captura numeros que pueden incluir comas, puntos y notacion Cientifica
                r'([.,]\d+)|' # Captura '.' o ',' seguido de numeros
                r'([^\s\.()]+)|' # Captura espacios, puntos o parentesis
                r'([\.\(\)])' # Captura '.', y '(' o ')'
            )
            # compresion de lista
            tokens = [match.group() for match in expresionesR.finditer(i) if match.group()]
            # .finditer(i) inicia la busqueda de coincidencias
            # match.group obtinee el resultado de la coincidencia con la expresion regular hallada por .finditer

            lineaClasifi = ""
            numero_de_linea += 1

            for token in tokens:
                if re.match(r'^".*"$', token):  # Cadenas
                    lineaClasifi += f"Cad : {token} | "
                
                elif re.match(r"^'.*", token): # comentarios
                    lineaClasifi += f"Come : {token} | "
                
                elif token in operadoresAcceso:
                    lineaClasifi += f"OpAcc : {token} | "  # Operadores de Acceso

                elif token in caracteresEspeciales:
                    lineaClasifi += f"CarcEsp : {token} | "  # Caracteres especiales

                elif token in operaCompara:
                    lineaClasifi += f"OpComp : {token} | "  # Operadores de comprobación
                    
                elif token in operaLogi:
                    lineaClasifi += f"OpLog : {token} | "  # Operadores lógicos

                elif token in operaAritm:
                    lineaClasifi += f"OpArit : {token} | "  # Operadores Aritméticos
                
                elif token in operadores_asignacion:
                    lineaClasifi += f"OpAsign : {token} | " # Operadores Asignacion

                elif token in palabrasReservadas:
                    lineaClasifi += f"PalbRes : {token} | "  # Palabra Reservada
                
                elif re.match(r'[\+-]?(\.[0-9]+|[0-9]+[E\.\,]*)', token):  # Números
                    if self.AutoNumeroReal(token):
                        lineaClasifi += f"Numero: {token} | "
                    else:
                        lineaClasifi += f"Numero: {token} | "
                        self.cajaError.append(
                            f"Error en la línea {numero_de_linea}: {token} no es un número válido"
                            + "\n")
                
                else:  # Identi
                    
                    if self.AutoIdenti(token):
                        lineaClasifi += f"Identi: {token} | "
                    else:
                        lineaClasifi += f"Identi: {token} | "
                        self.cajaError.append(
                            f"Error en la línea {numero_de_linea}: {token} no es identi"
                            + "\n")

            # Agregar la línea clasificada al resultado final con un salto de línea
            self.cajaTexto2.append( f"{numero_de_linea} {lineaClasifi[:-2]}")

if __name__ == "__main__":
    app = QApplication(sys.argv)
    ventana = Window()
    ventana.show()
    sys.exit(app.exec_())
