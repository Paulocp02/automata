Imports System

Module Program
    Sub Main()
        ' N�meros enteros
        Dim entero As Integer = 42
        Console.WriteLine("N�mero entero: " & entero)

        Dim largo As Long = 1234567890L
        Console.WriteLine("N�mero largo: " & largo)

        Dim byte1 As Byte = 255
        Console.WriteLine("N�mero byte: " & byte1)

        ' N�meros de punto flotante
        Dim flotante As Single = 3.14F
        Console.WriteLine("N�mero flotante: " & flotante)

        Dim doble As Double = 123.456
        Console.WriteLine("N�mero doble: " & doble)

        ' N�meros decimales
        Dim decimal1 As Decimal = 123.4567890123456789012345678D
        Console.WriteLine("N�mero decimal: " & decimal1)

        ' N�meros complejos (no nativos en VB, pero puedes usar bibliotecas externas)
        Dim numeroComplejo As Complex = New Complex(3.0, 4.0)
        Console.WriteLine("N�mero complejo: " & numeroComplejo)

        ' N�meros racionales (no nativos en VB, pero puedes usar bibliotecas externas)
        Dim numeroRacional As Rational = New Rational(1, 2)
        Console.WriteLine("N�mero racional: " & numeroRacional)

        Console.ReadLine()
    End Sub
End Module
