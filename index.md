---
title: Idle Runner — One-Page GDD
layout: default
nav_order: 1
---

# Idle Runner — One-Page GDD

**Género:** Idle + Acción mínima + Plataformeo táctico  
**Estilo visual:** Oscuro y melancólico (inspiración: *Hollow Knight*, *Limbo*, *GRIS*)

---

## 🔥 Concepto del juego
Eres el portador de una **llama frágil y viva** en un mundo de sombras.  
La llama es **poder, progreso y vínculo** con la luz: cuanto más fuerte la mantengas, más obtendrás… pero **requiere atención, decisiones y habilidad**.

---

## 🧩 Resumen general
- La llama representa la **economía principal** y el **estado del jugador**.
- Mantenerla encendida potencia el rendimiento **dentro y fuera** del juego.
- El plataformeo es **intencionado**: rutas fáciles/seguras vs. rutas difíciles/recompensadas.
- El **riesgo** (enemigos, rutas complejas) **produce más**.

---

## 🕯️ Sistema de llama
**Niveles de intensidad:** apagada → débil → estable → ardiente.

**A mayor intensidad:**
- Más enemigos derrotables por **contacto**.
- Más **esquirlas** y **eco de luz** generados.
- Mejor **idle** al salir del juego.

**Decaimiento:** si no la cuidas, la intensidad **baja** con el tiempo (activo e inactivo) hasta un **mínimo** (modo lento y poco productivo).

> **Objetivo de diseño:** que el estado de la llama sea **clarísimo visualmente** (color/halo/partículas/sonido) y legible en 1 segundo.

---

## 🎮 Gameplay (in-game)
- **Movimiento lateral automático**.
- El jugador puede:
  - **Saltar** (con control de altura/tiempo).
  - *(Más adelante)* activar **habilidad**: p. ej., *Onda de Llama*.
- **Plataformeo intencionado**:
  - Rutas difíciles → **más enemigos**, **fulgencias raras**, **fragmentos de recuerdo**.
  - Rutas seguras → **menos riesgo**, **menos productividad**.
  - Elección **del momento de salto** y **recorrido**.
- **Enemigos estratégicos**:
  - Bloquean caminos valiosos.
  - Derrota por **contacto** si la llama está **activa**.
  - Con llama **débil**, lo óptimo es **evitarlos** (o pierdes intensidad).
- **Fulgencias** (restauradoras) y **fragmentos** se colocan en zonas más difíciles → incentivan **riesgo calculado**.

---

## 💤 Idle (fuera del juego)
- La llama se mantiene según **última intensidad**.
- **Pierde fuerza lentamente** si no entras.
- A mayor intensidad:
  - Generas más **eco de luz** y **esquirlas**.
  - Desbloqueas **objetos** o **resonancias** únicas.
- **Recuperación**: entrar a tiempo o ver un **anuncio** puede **restaurar** la intensidad perdida.

---

## 🚪 Portales (niveles especiales)
- Aparecen durante la exploración o tras **tiempo en idle**.
- Al entrar:
  - Nivel **diferente y más vertical**, enfocado al plataformeo.
  - Si lo completas bien, **restauras la llama al máximo** + **recompensas exclusivas**.
  - Al terminar, vuelves al **punto exacto** de origen.

---

## 💰 Economía y recursos
- **🧿 Esquirlas**: caen de enemigos; mejoran **habilidades básicas**.
- **🌬️ Eco de luz**: generado **pasivamente** según nivel de llama.
- **🪞 Fragmentos de recuerdo**: raros; **historia**, **cosméticos**, **habilidades únicas**.

> **Loop:** Jugar bien → sube la llama → produce más (in-game & idle) → progresas → te atreves con rutas más difíciles → vuelves a jugar.

---

## 🛒 Monetización (opcional y no intrusiva)
**Anuncios opcionales**
- Restaurar la llama.
- Multiplicar recompensas tras niveles.
- Acceder directamente a **Portales**.

**Micropagos**
- Paquetes de **esquirlas** o **eco de luz**.
- **Skins** del portador o la llama.
- **Resonancias** especiales.

---

## ✅ Diferenciadores clave
- **Plataformeo táctico + idle** (no es puro clicker).
- **Combate por contacto** gobernado por la **intensidad** (no botón).
- **Llama** como elemento **visual, mecánico y narrativo** unificado.
- **Atmósfera potente** y reflexiva.
- Progresión significativa **sin** recargar la UI de botones.

---

## 🔭 Próximos pasos (MVP)
1. Prototipo de **salto** con control de altura.
2. **Indicador de llama** (4 estados) con feedback visual/sonoro.
3. Generación simple de **rutas** (segura vs. arriesgada).
4. **Enemigos por contacto** según estado de llama.
5. **Idle básico** (eco de luz) persistente.
6. Portal vertical de prueba + recompensa de restauración.

---
