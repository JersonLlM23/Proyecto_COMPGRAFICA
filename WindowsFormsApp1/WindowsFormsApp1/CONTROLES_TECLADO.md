# Controles del Teclado

## Rotación de la Figura
- **? (Flecha Izquierda)**: Rota la figura -5° (sentido antihorario)
- **? (Flecha Derecha)**: Rota la figura +5° (sentido horario)

## Movimiento Vertical
- **? (Flecha Arriba)**: Mueve la figura hacia arriba
- **? (Flecha Abajo)**: Mueve la figura hacia abajo

## Movimiento Horizontal
- **Shift + ? (Flecha Izquierda)**: Mueve la figura hacia la izquierda
- **Shift + ? (Flecha Derecha)**: Mueve la figura hacia la derecha

---

## Funcionalidad Implementada

El método `Form1_KeyDown` ahora detecta:
1. Si la tecla Shift está presionada
2. Qué tecla de flecha se presionó
3. Ejecuta la acción correspondiente:
   - **Flechas ? ?** sin Shift = Rotación
   - **Flechas ? ?** con Shift = Movimiento horizontal  
   - **Flechas ? ?** = Movimiento vertical

La figura se actualiza automáticamente después de cada acción.
