Imports System

Module Program
    Sub Main()
        ' Números enteros
        Dim entero As Integer = 42
        Console.WriteLine("Número entero: " & entero)

        Dim largo As Long = 1234567890L
        Console.WriteLine("Número largo: " & largo)

        Dim byte1 As Byte = 255
        Console.WriteLine("Número byte: " & byte1)

        ' Números de punto flotante
        Dim flotante As Single = 3.14F
        Console.WriteLine("Número flotante: " & flotante)

        Dim doble As Double = 123.456
        Console.WriteLine("Número doble: " & doble)

        ' Números decimales
        Dim decimal1 As Decimal = 123.4567890123456789012345678D
        Console.WriteLine("Número decimal: " & decimal1)

        ' Números complejos (no nativos en VB, pero puedes usar bibliotecas externas)
        Dim numeroComplejo As Complex = New Complex(3.0, 4.0)
        Console.WriteLine("Número complejo: " & numeroComplejo)

        ' Números racionales (no nativos en VB, pero puedes usar bibliotecas externas)
        Dim numeroRacional As Rational = New Rational(1, 2)
        Console.WriteLine("Número racional: " & numeroRacional)

        Console.ReadLine()
    End Sub
End Module
