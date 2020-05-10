# GestionVentasV2APIREST

## Clientes
### Registra un nuevo cliente
- http://localhost:56670/api/Client

### JSON
```
{
  "dni": "string",
  "nombre": "string",
  "apellido": "string",
  "direccion": "string",
  "telefono": "string"
}
```

### Devuelve una lista con todos los clientes
- http://localhost:56670/api/Client

### Devuelve una lista de clientes según un DNI
- http://localhost:56670/api/Client/GetByDNI/50000001

### Devuelve una lista de clientes según coincidencias con un nombre y apellido
- http://localhost:56670/api/Client/GetByName/to5/ez


## Productos
### Registra un nuevo producto
- http://localhost:56670/api/Product

### JSON
```
{
  "codigo": "string",
  "marca": "string",
  "nombre": "string",
  "precio": 0
}
```


### Devuelve una lista con todos los productos
- http://localhost:56670/api/Product


### Devuelve un producto según un código
- http://localhost:56670/api/Product/GetByCode/f



## Ventas
### Registrar venta de productos
- http://localhost:56670/api/Sale

### JSON
```
{
  "clienteId": 0,
  "carrito": {
    "productos": [
      {
        "productoId": 0
      },
      {
        "productoId": 0
      },
      {
        "productoId": 0
      }
    ]
  }
}
```


### Reporte de ventas del día
- http://localhost:56670/api/Sale/DailyReport


### Reporte de ventas del día filtrado por algún producto
- http://localhost:56670/api/Sale/DailyReport/2

