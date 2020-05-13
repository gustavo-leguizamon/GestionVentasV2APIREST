# GestionVentasV2APIREST

## Clientes
### Registra un nuevo cliente (POST)
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

### Devuelve una lista con todos los clientes (GET)
- http://localhost:56670/api/Client

### Devuelve una lista de clientes según un DNI (GET)
- http://localhost:56670/api/Client/GetByDNI/{dni}


- http://localhost:56670/api/Client/GetByDNI/50000001

### Devuelve una lista de clientes según coincidencias con un nombre y apellido (GET)
- http://localhost:56670/api/Client/GetByName/{name}/{lastname}


- http://localhost:56670/api/Client/GetByName/cosme/fulanito


## Productos
### Registra un nuevo producto (POST)
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


### Devuelve una lista con todos los productos (GET)
- http://localhost:56670/api/Product


### Devuelve un producto según un código (GET)
- http://localhost:56670/api/Product/GetByCode/{code}


- http://localhost:56670/api/Product/GetByCode/MOU



## Ventas
### Registrar venta de productos (POST)
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


### Reporte de ventas del día (GET)
- http://localhost:56670/api/Sale/DailyReport


### Reporte de ventas del día filtrado por algún producto (GET)
- http://localhost:56670/api/Sale/DailyReport/{productId}


- http://localhost:56670/api/Sale/DailyReport/2
