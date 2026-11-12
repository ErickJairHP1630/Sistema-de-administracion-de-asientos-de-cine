# Día 2 – Actividad 2: Pseudocódigo

**Proyecto Integrador: Sistema de administración de asientos de cine**

**Responsable:** Carlos Damian Nava Solis
La sala se representa con una matriz de 5 filas y 8 columnas.     
Cada asiento vale 0 si está libre y 1 si está ocupado.

---

## 1. Programa principal

```
INICIO
    Crear matriz sala de 5 filas y 8 columnas
    Poner todos los asientos en 0 (libres)

    REPETIR
        Mostrar menú
        Leer opción

        SEGUN opción
            1: Mostrar la sala
            2: Reservar asiento
            3: Liberar asiento
            4: Consultar asiento
            5: Mostrar estadísticas
            6: Escribir "Hasta luego"
            OTRO: Escribir "Opción inválida"
        FIN SEGUN
    HASTA QUE opción sea 6
FIN
```

---

## 2. Mostrar la sala

```
PROCEDIMIENTO mostrarSala
    PARA cada fila de la sala
        PARA cada columna de la fila
            SI el asiento vale 0 ENTONCES
                Escribir "[ ]"
            SINO
                Escribir "[X]"
            FIN SI
        FIN PARA
        Salto de línea
    FIN PARA
FIN PROCEDIMIENTO
```

---

## 3. Reservar asiento

```
PROCEDIMIENTO reservarAsiento
    Leer fila y columna

    SI la fila o la columna no existen ENTONCES
        Escribir "Asiento no válido"
    SINO
        SI el asiento vale 1 ENTONCES
            Escribir "El asiento ya está ocupado"
        SINO
            Poner el asiento en 1
            Escribir "Reserva exitosa"
        FIN SI
    FIN SI
FIN PROCEDIMIENTO
```

---

## 4. Liberar asiento

```
PROCEDIMIENTO liberarAsiento
    Leer fila y columna

    SI la fila o la columna no existen ENTONCES
        Escribir "Asiento no válido"
    SINO
        SI el asiento vale 0 ENTONCES
            Escribir "El asiento ya estaba libre"
        SINO
            Poner el asiento en 0
            Escribir "Asiento liberado"
        FIN SI
    FIN SI
FIN PROCEDIMIENTO
```

---

## 5. Consultar asiento

```
PROCEDIMIENTO consultarAsiento
    Leer fila y columna

    SI la fila o la columna no existen ENTONCES
        Escribir "Asiento no válido"
    SINO
        SI el asiento vale 0 ENTONCES
            Escribir "El asiento está disponible"
        SINO
            Escribir "El asiento está ocupado"
        FIN SI
    FIN SI
FIN PROCEDIMIENTO
```

---

## 6. Estadísticas

```
PROCEDIMIENTO mostrarEstadisticas
    ocupados ← 0
    disponibles ← 0

    PARA cada fila de la sala
        PARA cada columna de la fila
            SI el asiento vale 1 ENTONCES
                ocupados ← ocupados + 1
            SINO
                disponibles ← disponibles + 1
            FIN SI
        FIN PARA
    FIN PARA

    total ← 5 × 8
    porcentaje ← (ocupados / total) × 100

    Escribir "Ocupados: ", ocupados
    Escribir "Disponibles: ", disponibles
    Escribir "Porcentaje de ocupación: ", porcentaje, "%"
FIN PROCEDIMIENTO