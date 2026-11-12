# Día 2 – Actividad 1: Algoritmo general y diagramas de flujo

**Proyecto Integrador: Sistema de administración de asientos de cine**

**Responsable:** Erick Jair Hernández Pacheco

---

## 1. Algoritmo general

1. Inicio del programa.
2. Crear la sala con todos los asientos disponibles.
3. Mostrar el menú: mostrar asientos, reservar, liberar, consultar, estadísticas o salir.
4. El usuario elige una opción.
5. Si la opción no existe, se muestra un error y se regresa al menú.
6. Se realiza la acción elegida:
   - **Mostrar asientos:** se imprime la sala con los lugares libres y ocupados.
   - **Reservar:** se pide fila y columna; si el asiento está libre, se ocupa.
   - **Liberar:** se pide fila y columna; si el asiento está ocupado, se libera.
   - **Consultar:** se pide fila y columna y se indica si está libre u ocupado.
   - **Estadísticas:** se cuentan los asientos ocupados y disponibles y se calcula el porcentaje de ocupación.
7. Se regresa al menú hasta que el usuario elija salir.
8. Fin del programa.

---

## 2. Diagrama de flujo general

```mermaid
flowchart TD
    A([Inicio]) --> B["Crear sala con todos<br/>los asientos libres"]
    B --> C["Mostrar menú"]
    C --> D[/"Leer opción"/]
    D --> E{"¿Qué opción eligió?"}
    E -- "1 Mostrar" --> F["Mostrar la sala"]
    E -- "2 Reservar" --> G["Reservar asiento"]
    E -- "3 Liberar" --> H["Liberar asiento"]
    E -- "4 Consultar" --> I["Consultar asiento"]
    E -- "5 Estadísticas" --> J["Mostrar estadísticas"]
    E -- "6 Salir" --> K([Fin])
    E -- "Otra" --> L[/"Mostrar: opción inválida"/]
    F --> C
    G --> C
    H --> C
    I --> C
    J --> C
    L --> C
```

---

## 3. Diagrama de flujo: Reservar asiento

```mermaid
flowchart TD
    A([Inicio]) --> B[/"Pedir fila y columna"/]
    B --> C{"¿El asiento existe?"}
    C -- No --> D[/"Mostrar: asiento no válido"/]
    C -- Sí --> E{"¿Está libre?"}
    E -- No --> F[/"Mostrar: ya está ocupado"/]
    E -- Sí --> G["Marcar como ocupado"]
    G --> H[/"Mostrar: reserva exitosa"/]
    D --> I([Fin])
    F --> I
    H --> I
```

---

## 4. Diagrama de flujo: Liberar asiento

```mermaid
flowchart TD
    A([Inicio]) --> B[/"Pedir fila y columna"/]
    B --> C{"¿El asiento existe?"}
    C -- No --> D[/"Mostrar: asiento no válido"/]
    C -- Sí --> E{"¿Está ocupado?"}
    E -- No --> F[/"Mostrar: ya estaba libre"/]
    E -- Sí --> G["Marcar como libre"]
    G --> H[/"Mostrar: asiento liberado"/]
    D --> I([Fin])
    F --> I
    H --> I
```

---

## 5. Diagrama de flujo: Consultar asiento

```mermaid
flowchart TD
    A([Inicio]) --> B[/"Pedir fila y columna"/]
    B --> C{"¿El asiento existe?"}
    C -- No --> D[/"Mostrar: asiento no válido"/]
    C -- Sí --> E{"¿Está libre?"}
    E -- Sí --> F[/"Mostrar: asiento disponible"/]
    E -- No --> G[/"Mostrar: asiento ocupado"/]
    D --> H([Fin])
    F --> H
    G --> H
```

---

## 6. Diagrama de flujo: Estadísticas

```mermaid
flowchart TD
    A([Inicio]) --> B["Poner contadores en cero"]
    B --> C["Revisar cada asiento de la sala"]
    C --> D{"¿Está ocupado?"}
    D -- Sí --> E["Sumar 1 a ocupados"]
    D -- No --> F["Sumar 1 a disponibles"]
    E --> G{"¿Faltan asientos<br/>por revisar?"}
    F --> G
    G -- Sí --> C
    G -- No --> H["Calcular porcentaje:<br/>ocupados / total × 100"]
    H --> I[/"Mostrar ocupados, disponibles<br/>y porcentaje"/]
    I --> J([Fin])
```