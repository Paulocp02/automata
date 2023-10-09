def error(entrada):
    print(entrada + " no es una variable aprobada")

def autoVariable(entrada):
    
    tamanio = len(entrada)
    conta = 0
    estado = 1
    while conta < tamanio:
        simbolo = entrada[conta]
        if estado == 1:
            if ('A' <= simbolo <= 'Z')  or (simbolo == '_'):
                estado = 3
            elif ('0'<= simbolo <= '9'):
                estado =2
            else:
                error(entrada)
                break

        elif estado==2:
            error(entrada)
            break

        elif estado == 3:
            if ('A' <= simbolo <= 'Z') or  ('0' <= simbolo <= '9') or (simbolo == '_'):
                estado = 3
            else:
                error(entrada)
                break
        
        conta = conta + 1

    if estado == 3 and tamanio > 0:
        print(entrada + ' es una variable aceptada')

def clasificacion():
    entrada = "suma_1"
    entrada= entrada.upper()
    autoVariable(entrada)

clasificacion()
