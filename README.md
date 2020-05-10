# GestionVentasV2APIREST
1 - Registrar venta
- http://localhost:56670/api/Sale
{
  "clienteId": 2,
  "cart": {
    "products": [
      {
        "productoId": 2
      }
    ]
  }
}

2 - Reporte de ventas del día
- http://localhost:56670/api/Sale/ReporteDiarioVentas

3 - Reporte de ventas del día filtrado por algún producto
- http://localhost:56670/api/Sale/ReporteDiarioVentas/2


4 - Registra un nuevo cliente
- http://localhost:56670/api/Client

- Registra un nuevo producto
- http://localhost:56670/api/Product
{
  "codigo": "555",
  "marca": "5",
  "nombre": "st55ring",
  "precio": 045
}

5 - 
