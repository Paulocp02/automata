import re

cadena = "Me.GroupBox1.Controls.Add(Me.bDesconectar)"
tokens = [token for token in re.split(r'(".*?"|\s+|(?<=\D)\.(?=\D)|\.(?=\w+\.\w+)|\(|\))', cadena) if token and not token.isspace()]

print(tokens)
