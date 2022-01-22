# Clean-Architecture
Implementando Clean Architecture en aplicaciones .NET


¿Qué es Clean Architecture?

- Un concepto popularizado por Robert Cecil Martin (Uncle Bob)
- Propone la estructuración de código en capas.
- Cada capa debe tener su propia responsabilidad.
- Existen propuestas con diferente enfoque como: Clean Architecture, Onion Architecture, Hexagonal Architecture, Screaming...
- Cada propuesta tiene diferente enfoque, pero comparten la idea de que cada capa debe tener su propia responsabilidad.

El objetivo principal de una arquitectura limpia es la separación de responsabilidades y esto se logra
dividiendo el software en capas.

Clean Arquitectura es un conjunto de principios, patrones, buenas prácticas para desarrollar aplicaciones 
escalables y fáciles de probar.




#CASO DE USO CREAR ORDEN
Historia de Usuario: crear orden de compra

Como usuario del sistema, deseo crear una orden de compra para solicitar productos del almacén.


Datos de entrada: 
- Identificador del cliente
- Dirección de envío
- Ciudad de envío.
- País de envío.
- Código postal de envío.
- Lista de productos incluyendo:
	- Identificador del producto
	- Precio
	- cantidad

Flujo primario
1. El usuario envía la solicitud "crear orden de compra" con los datos de entrada.
2. El sistema valida los datos.
3. El sistema registra la acción " inicio de creación de orden de compra" con fines de auditoría.
4. El sistema registra la orden de compra.
5. El sistema registra la acción "Orden de compra <número de orden> creada" con fines de auditoría.
6. Cuando el número de productos de la orden de compra sea mayor que 3, el sistema iniciará el proceso de envío de correo
   de notificación de "Orden especial creada".

Flujo alterno: Error de validación
1. El procesamiento de la solicitud es cancelado.
2. El error es registrado en la bitácora de errores del sistema.
3. El sistema muestra el error al usuario.

Consideraciones.

- Northwind maneja 4 tipos de transporte de mercancías: Marítimo, Aéreo, Ferroviario y Terrestre.
  El tipo predeterminado es Terrestre.
- Northwind maneja 2 formas para especificar descuentos: Mediante porcentaje y mediante cantidades absolutas.
  El descuento predeterminado de una compra es del 10%

Validaciones:

- El identificador de cliente es requerido y debe ser de 5 caracteres alfanuméricos.
- La dirección de envío es requerida y debe ser de una longitud máxima de 60 caracteres.
- La ciudad de envío es requerida y debe tener una longitud mínima de 3 y máxima de 15 caracteres alfanuméricos.
- El país de envío es requerido y debe tener una longitud mínima de 3 y máxima de 15 caracteres alfanuméricos.
- El código postal es opcional con una longitud máxima de 10 caracteres alfanuméricos.
- Debe especificar al menos un producto en la orden.
- De cada producto especificado en la orden, será requerido el identificador del producto, la cantidad 
  y el precio.

  
Opcionales:

- Validar existencia de productos antes de aceptar la orden.
- Verificar que el cliente no tenga adeudos para poder aceptar la orden.
 




