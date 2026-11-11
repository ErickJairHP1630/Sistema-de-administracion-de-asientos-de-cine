# Día 1 – Actividad 2: Identificación de entradas, procesos y salidas

**Proyecto Integrador: Sistema de administración de asientos de cine**

**Responsable:** Carlos Damian Nava Solis

---

## 1. Entradas

- Opción elegida del menú (número entero).
- Fila del asiento (letra o número).
- Columna del asiento (número).
- Dimensiones de la sala (filas y columnas), si se decide que sean configurables.

## 2. Procesos

- Inicializar la matriz con todos los asientos disponibles.
- Validar que la fila y la columna estén dentro del rango de la sala.
- Reservar: verificar que el asiento esté libre y marcarlo como ocupado.
- Liberar: verificar que el asiento esté ocupado y marcarlo como libre.
- Consultar: revisar el estado de un asiento específico.
- Recorrer la matriz para contar asientos ocupados y disponibles.
- Calcular el porcentaje de ocupación: (ocupados / total de asientos) × 100.

## 3. Salidas

- Representación visual de la matriz de asientos (por ejemplo, `[ ]` libre y `[X]` ocupado).
- Mensajes de confirmación (reserva o liberación exitosa).
- Mensajes de error (asiento ya ocupado, asiento ya libre, posición inválida, opción inválida).
- Estado de un asiento consultado.
- Total de asientos ocupados y disponibles.
- Porcentaje de ocupación.

---

## 4. Resumen por operación

| Operación | Entradas | Proceso | Salidas |
|---|---|---|---|
| Mostrar asientos | Opción del menú | Recorrer la matriz | Matriz con asientos libres y ocupados |
| Reservar | Fila y columna | Validar rango, verificar que esté libre, marcar como ocupado | Confirmación o error |
| Liberar | Fila y columna | Validar rango, verificar que esté ocupado, marcar como libre | Confirmación o error |
| Consultar | Fila y columna | Validar rango, leer el estado del asiento | Libre u ocupado |
| Estadísticas | Opción del menú | Contar ocupados y disponibles, calcular porcentaje | Totales y porcentaje de ocupación |

---

## 5. Pendientes para el Día 2

- Definir el lenguaje de programación.
- Fijar el tamaño final de la sala y la notación de filas y columnas.
- Elaborar el diagrama de flujo, el algoritmo general y el pseudocódigo.
