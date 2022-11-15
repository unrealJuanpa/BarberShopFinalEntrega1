import pyodbc
import pandas as pd
import os
import facebook
import numpy as np

os.system("cls")

cnstr = ("Driver={SQL Server Native Client 11.0};"
        "Server=(LocalDB)\\MSSQLLocalDB;"
        "Database=C:\\Users\\Acer\\source\\repos\\BarberShopFinalEntrega1\\DB\\DatabaseBS.mdf;"
)

data = pd.read_sql("select P.Nombre, P.ProcentajeDescuento, P.Descripcion, P.FechaHoraInicio, P.FechaHoraFin, P.Activo, T.Nombre from [dbo].[Promocion] as P, [dbo].[TipoTratamiento] as T where P.IdTratamiento = T.IdTratamiento", pyodbc.connect(cnstr))
sample = data.sample(n=1).values.tolist()

print("Mensaje a publicar:")
msg = f'Aprovecha la promoción 🎉{sample[0][0]}🎉 con un {sample[0][1]}% de descuento 😱😱😱 sobre el tratamiento 😎{sample[0][-1]}😎\n\n{str(sample[0][2]).capitalize()} 🤩\n\nValida desde {sample[0][3]} hasta el {sample[0][4]}\n\nSolo en Barbería Caballeros\nTel: 67230834'
print(msg)

graph = facebook.GraphAPI("EAAMH0lO7pqABAJ99Kf3fVkaqCFrJYWIW1CHzeuNRTPKkNpVDsPUvKnC8zZBrCZC8iKEDVsLK0Cdt1gGvT8GzlVYzdMZCudjaSFksXzMl0Ocmgk3hLg5mwsfQHsvtqZCFS7iUJqUe9WxcXDiGhS1ZCVvki3ZC69fnpsHDWLxd6CRGJWUbrLZA6rwm8ti56VO1PMZD")
graph.put_object("110684335192445", "feed", message=msg)