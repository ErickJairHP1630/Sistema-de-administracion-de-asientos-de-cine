# Sistema de Administración de Asientos de Cine

Proyecto Integrador — Estructuras de datos (matrices)

## Integrantes

- Erick Jair Hernández Pacheco
- Carlos Damián Nava Solís

## ¿De qué trata?

Un cine tenía problemas al vender boletos: a veces se reservaba dos veces el mismo asiento, se liberaba un lugar equivocado o nadie sabía cuántos lugares quedaban. Nuestro programa ayuda a llevar ese control. La sala tiene 5 filas (de la A a la E) con 8 asientos cada una, en total 40 lugares. Cada asiento aparece como `[ ]` si está libre o como `[X]` si ya está ocupado.

Por dentro, la sala es una **matriz** (arreglo de dos dimensiones): cada posición `[fila, columna]` guarda un `0` si el asiento está libre y un `1` si está ocupado.

## ¿Qué se puede hacer con el programa?

- Ver cómo está la sala.
- Reservar un asiento.
- Liberar un asiento (por ejemplo, si alguien cancela).
- Revisar si un asiento está libre u ocupado.
- Saber cuántos asientos están ocupados y cuántos libres.
- Ver qué porcentaje de la sala está lleno.

El programa valida lo que escribe el usuario: si pone una fila que no existe, una columna fuera de rango o letras donde van números, muestra un mensaje y regresa al menú sin cerrarse.

## Tecnologías utilizadas

- C# (.NET)
- Visual Studio Code
- Git y GitHub

## ¿Cómo está organizado este repositorio?

- **CodigoFuente/** — el programa en C# (`CineAsientos/`).
- **Documentacion/** — los avances de cada día en `Avances/` y el documento técnico final en PDF.
- **Evidencias/** — capturas de pantalla del programa funcionando y de las pruebas.
- **README.md** — este archivo.

## ¿Cómo se usa?

1. Instala el SDK de .NET desde [dotnet.microsoft.com/download](https://dotnet.microsoft.com/download).
2. Clona el repositorio:
   ```
   git clone https://github.com/USUARIO/Sistema-de-administracion-de-asientos-de-cine.git
   ```
3. Entra a la carpeta del proyecto:
   ```
   cd Sistema-de-administracion-de-asientos-de-cine/CodigoFuente/CineAsientos
   ```
4. Ejecuta el programa:
   ```
   dotnet run
   ```
5. Aparece un menú con opciones del 1 al 6. Escribe el número de la opción y presiona Enter. Para los asientos se pide la fila (letra A–E) y la columna (número 1–8).

## Avance

- Día 1 – Análisis del problema: terminado
- Día 2 – Diseño algorítmico y diagramas de flujo: terminado
- Día 3 – Diseño de interfaz: terminado
- Día 4 – Desarrollo del módulo de captura: en proceso
- Día 5 – Desarrollo de consultas: pendiente
- Día 6 – Implementación de estadísticas: pendiente
- Día 7 – Pruebas y documentación: pendiente
- Día 8 – Exposición y demostración: pendiente
