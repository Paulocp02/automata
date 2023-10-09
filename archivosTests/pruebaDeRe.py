import re

def es_notacion_cientifica(cadena):
    # Definir la expresión regular
    patron = r'[+\-]?\d+(\.\d*)?([Ee][+\-]?\d+)?'
    
    # Utilizar re.fullmatch() para buscar el patrón en toda la cadena
    if re.fullmatch(patron, cadena):
        return True
    else:
        return False

# Ejemplos de uso
cadena1 = "3.14E-10"
cadena2 = "42"
cadena3 = "abc"
cadena4 = "1.23e45"

print(f"'{cadena1}' es notación científica: {es_notacion_cientifica(cadena1)}")
print(f"'{cadena2}' es notación científica: {es_notacion_cientifica(cadena2)}")
print(f"'{cadena3}' es notación científica: {es_notacion_cientifica(cadena3)}")
print(f"'{cadena4}' es notación científica: {es_notacion_cientifica(cadena4)}")
