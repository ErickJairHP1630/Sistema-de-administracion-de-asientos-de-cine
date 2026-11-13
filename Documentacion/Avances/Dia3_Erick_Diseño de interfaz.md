# Día 3 – Actividad 1: Diseño de pantallas

**Proyecto Integrador: Sistema de administración de asientos de cine**

**Responsable:** Erick Jair Hernández Pacheco

---

## 1. Tipo de interfaz

Se eligió una **interfaz de consola (texto)** porque:

- Permite concentrarse en la lógica de la matriz, que es lo que se evalúa.
- No requiere librerías adicionales ni estructuras no vistas en clase.

Convenciones visuales:

| Elemento | Representación |
|---|---|
| Asiento libre | `[ ]` |
| Asiento ocupado | `[X]` |
| Filas | Letras A a E |
| Columnas | Números 1 a 8 |
| Pantalla (frente) | Línea `======== PANTALLA ========` arriba de la matriz |

---

## 2. Pantalla principal (menú)

```
==================================================
      SISTEMA DE ADMINISTRACIÓN DE ASIENTOS
                 CINE - SALA 1
==================================================
  1. Mostrar asientos
  2. Reservar asiento
  3. Liberar asiento
  4. Consultar disponibilidad
  5. Estadísticas de ocupación
  6. Salir
==================================================
Seleccione una opción (1-6): _
```

---

## 3. Pantalla: Mostrar asientos

```
============== PANTALLA ==============

      1   2   3   4   5   6   7   8
  A  [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]
  B  [ ] [X] [X] [ ] [ ] [ ] [ ] [ ]
  C  [ ] [ ] [ ] [X] [ ] [ ] [ ] [ ]
  D  [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]
  E  [X] [ ] [ ] [ ] [ ] [ ] [ ] [X]

  [ ] Libre    [X] Ocupado

Presione Enter para volver al menú...
```

---

## 4. Pantalla: Reservar asiento

```
----------- RESERVAR ASIENTO -----------
Ingrese la fila (A-E): B
Ingrese la columna (1-8): 4

Reservación exitosa: asiento B4 ocupado.

Presione Enter para volver al menú...
```

Caso de error (asiento ya ocupado):

```
----------- RESERVAR ASIENTO -----------
Ingrese la fila (A-E): B
Ingrese la columna (1-8): 2

El asiento B2 ya está ocupado. Elija otro.

Presione Enter para volver al menú...
```

---

## 5. Pantalla: Liberar asiento

```
----------- LIBERAR ASIENTO -----------
Ingrese la fila (A-E): B
Ingrese la columna (1-8): 2

Asiento B2 liberado correctamente.

Presione Enter para volver al menú...
```

---

## 6. Pantalla: Consultar disponibilidad

```
-------- CONSULTAR DISPONIBILIDAD --------
Ingrese la fila (A-E): C
Ingrese la columna (1-8): 4

El asiento C4 está OCUPADO.

Presione Enter para volver al menú...
```

---

## 7. Pantalla: Estadísticas

```
----------- ESTADÍSTICAS DE OCUPACIÓN -----------
Total de asientos:        40
Asientos ocupados:         5
Asientos disponibles:     35
Porcentaje de ocupación:  12.5 %

Presione Enter para volver al menú...
```

---

## 8. Pantalla: Salir

```
Gracias por usar el sistema. ¡Hasta luego!
```



