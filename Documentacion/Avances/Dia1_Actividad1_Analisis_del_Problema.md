<!-- # Día 1 – Actividad 1: Análisis del problema  -->

**Proyecto Integrador: Sistema de administración de asientos de cine**

**Responsable:** Erick Jair Hernández Pacheco

---

## 1. Identificación del problema

Un cine desea digitalizar la administración de sus asientos para evitar errores en las reservaciones, como vender dos veces el mismo asiento, liberar un lugar equivocado o no saber cuántos lugares quedan en una función. Actualmente el control es manual, lo que provoca confusión y pérdida de tiempo.

La solución es un programa que represente la sala como una matriz de asientos y permita reservarlos, liberarlos, consultarlos y obtener estadísticas de ocupación.

---

## 2. Descripción de requerimientos

### Requerimientos funcionales

| ID | Requerimiento | Descripción |
|---|---|---|
| RF-01 | Mostrar matriz | Despliega la sala completa indicando qué asientos están libres y cuáles ocupados, con encabezados de fila y columna. |
| RF-02 | Reservar asiento | Cambia un asiento libre a ocupado. Rechaza la operación si ya estaba ocupado. |
| RF-03 | Liberar asiento | Cambia un asiento ocupado a libre. Rechaza la operación si ya estaba libre. |
| RF-04 | Consultar disponibilidad | Informa si un asiento específico está libre u ocupado. |
| RF-05 | Contar ocupados y disponibles | Recorre la matriz y muestra ambas cantidades. |
| RF-06 | Porcentaje de ocupación | Calcula y muestra el porcentaje de asientos ocupados respecto al total. |

### Requerimientos no funcionales

- **Validación de datos:** el programa no debe fallar si el usuario escribe letras, números fuera de rango o datos vacíos.
- **Manejo de excepciones:** controlar entradas inválidas sin que el programa se detenga.
- **Usabilidad:** menú claro y mensajes comprensibles.
- **Modularidad:** cada operación debe estar en su propia función.
- **Mantenibilidad:** nombres significativos y comentarios adecuados.

---

## 3. Estructura de datos utilizada y justificación

Se utilizará una **matriz (arreglo bidimensional)** donde cada posición `[fila][columna]` representa un asiento. Cada celda almacena su estado: `0` = disponible y `1` = ocupado (o los caracteres `"L"` y `"X"`).

**¿Por qué una matriz?**

- La sala de cine es físicamente una cuadrícula de filas y columnas, así que la matriz la representa de forma natural.
- El acceso a cualquier asiento es directo por sus índices, por lo que reservar, liberar y consultar son operaciones inmediatas.
- El tamaño de la sala es fijo, lo cual encaja con un arreglo de tamaño definido.
- Los recorridos con ciclos anidados permiten mostrar la sala y contar ocupados y disponibles de forma sencilla.
- Es una estructura vista en clase, por lo que no se incurre en penalización por usar estructuras no autorizadas.

**Operaciones sobre la estructura:**

| Operación | Uso en el proyecto |
|---|---|
| Inserción / modificación | Marcar un asiento como ocupado al reservar. |
| Eliminación (lógica) | Marcar un asiento como libre al liberar. |
| Búsqueda | Consultar el estado de un asiento por fila y columna. |
| Recorrido | Mostrar la sala y contar ocupados y disponibles. |

---

## 4. Casos de uso

### CU-01 Mostrar asientos

- **Actor:** Empleado de taquilla.
- **Flujo:** el actor elige la opción "Mostrar asientos" → el sistema recorre la matriz y la imprime con el estado de cada asiento.

### CU-02 Reservar asiento

- **Actor:** Empleado de taquilla.
- **Precondición:** el asiento existe y está libre.
- **Flujo principal:** el actor elige "Reservar" → ingresa fila y columna → el sistema valida el rango → verifica que esté libre → lo marca como ocupado → muestra confirmación.
- **Flujos alternos:** posición fuera de rango → error y se pide de nuevo; asiento ya ocupado → mensaje de que no está disponible.

### CU-03 Liberar asiento

- **Actor:** Empleado de taquilla.
- **Precondición:** el asiento existe y está ocupado.
- **Flujo principal:** el actor elige "Liberar" → ingresa fila y columna → el sistema valida → verifica que esté ocupado → lo marca como libre → muestra confirmación.
- **Flujos alternos:** posición inválida → error; asiento ya libre → aviso de que no había reservación.

### CU-04 Consultar disponibilidad

- **Actor:** Empleado de taquilla.
- **Flujo:** el actor elige "Consultar" → ingresa fila y columna → el sistema valida y muestra si el asiento está libre u ocupado.

### CU-05 Ver estadísticas

- **Actor:** Empleado o administrador.
- **Flujo:** el actor elige "Estadísticas" → el sistema recorre la matriz, cuenta ocupados y disponibles, calcula el porcentaje y los muestra.

---

## 5. Alcance y limitaciones

### Alcance

- Administración de los asientos de una sola sala y una sola función.
- Reservar, liberar, consultar, mostrar y obtener estadísticas mediante un menú.
- Validación de entradas y mensajes de error claros.

### Limitaciones

- No se manejan múltiples salas, horarios ni películas.
- No se registran datos del cliente, precios ni pagos.
- Los datos viven en memoria: al cerrar el programa se pierde el estado, salvo que se agregue guardado en archivo como mejora opcional.
- Un solo usuario a la vez (sin acceso concurrente).
- Interfaz en consola o interfaz sencilla, según se decida el Día 3.

---

## 6. Supuestos

- La sala tiene un tamaño fijo (por ejemplo, 5 filas × 8 columnas; por definir).
- Todos los asientos inician disponibles.
- Las filas se identifican con letras (A, B, C…) y las columnas con números (1, 2, 3…), o ambos con números; se definirá en el diseño de la interfaz.