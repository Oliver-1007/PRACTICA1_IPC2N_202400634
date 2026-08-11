# Práctica 1 — Sistema de Veterinaria con POO en C#

**Universidad de San Carlos de Guatemala**
Facultad de Ingeniería — Escuela de Ciencias y Sistemas
Curso: Introducción a la Programación y Computación 2 (IPC2)

| | |
|---|---|
| **Estudiante** | Oliver Jorge Raxtún Morales |
| **Carné** | 202400634 |
| **Fecha de entrega** | Viernes 14 de agosto |

---

## Descripción

Aplicación de consola que simula el sistema de citas de una veterinaria. Permite
registrar y gestionar cuatro tipos de pacientes —perros, gatos, aves y tortugas—,
cada uno con atributos y una dosis de medicamento propias, calculada a partir de una
dosis estándar (mg/kg) ajustada según un factor específico de cada especie.

## Competencia y objetivos

Aplicar los cuatro pilares de la Programación Orientada a Objetos en C#:

- **Abstracción**: modelar el concepto general de "paciente de veterinaria".
- **Encapsulamiento**: proteger y controlar el acceso a los atributos de cada mascota.
- **Herencia**: definir especies concretas (Perro, Gato, Ave, Tortuga) a partir de una
  clase base común (`Mascota`).
- **Polimorfismo**: cada especie calcula su propia dosis de medicamento a partir del
  mismo método heredado, aplicando un factor de ajuste distinto.

## Reglas de negocio: cálculo de dosis

`Dosis final (mg) = Peso (kg) × dosis_por_Kg (mg/kg) × factor de ajuste de la especie`

| Especie  | Factor de ajuste | Justificación |
|----------|:---:|---|
| Perro    | 100 % | Dosis estándar, sin ajuste |
| Gato     | 90 %  | Requiere ligeramente menos medicamento |
| Ave      | 50 %  | Menor cantidad por sus características fisiológicas |
| Tortuga  | 80 %  | Dosis ligeramente inferior a la estándar |

## Estructura del proyecto

```
Practica1_Veterinaria/
├── Program.cs                   # Punto de entrada; ejecuta el menú en bucle
├── Modelos/
│   ├── Mascota.cs                # Clase base abstracta (Abstracción/Encapsulamiento)
│   ├── Perro.cs                  # Hereda de Mascota — dosis con factor 100 %
│   ├── Gato.cs                   # Hereda de Mascota — dosis con factor 90 %
│   ├── Ave.cs                    # Hereda de Mascota — dosis con factor 50 %
│   └── Tortuga.cs                # Hereda de Mascota — dosis con factor 80 %
├── Servicios/
│   ├── Veterinaria.cs            # Lógica de negocio: registrar, buscar, listar, eliminar
│   └── MenuConsola.cs            # Menú interactivo, lectura y validación de datos
├── Practica1_Veterinaria.csproj
└── README.md
```

## Requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download) o superior instalado en el equipo.

## Cómo compilar y ejecutar

Desde la carpeta raíz del proyecto (`Practica1_Veterinaria/`):

```bash
# Restaurar dependencias (solo la primera vez)
dotnet restore

# Compilar
dotnet build

# Ejecutar
dotnet run
```

## Uso del sistema — menú principal

```
1. Registrar nueva mascota
2. Gestionar pacientes registrados
3. Listar todos los pacientes
4. Salir
```

1. **Registrar nueva mascota**: se elige la especie (Perro/Gato/Ave/Tortuga), se
   ingresan los datos generales (nombre, peso, sexo, edad, propietario) y los
   específicos de la especie. El sistema asigna automáticamente un código único de
   8 caracteres y el estado inicial "Sano".
2. **Gestionar pacientes registrados**: buscando por código, se puede:
   - Consultar la información completa del paciente.
   - Cambiar su estado (Sano / Enfermo).
   - Calcular la dosis de medicamento a partir de una dosis estándar (mg/kg).
   - Devolver (eliminar) al paciente del sistema.
3. **Listar todos los pacientes**: muestra la información de todos los registrados.
4. **Salir**: termina la ejecución. El programa se mantiene corriendo hasta elegir
   esta opción.

Todas las entradas del usuario se validan (números fuera de rango, texto vacío,
opciones inválidas, etc.), pidiendo el dato nuevamente en caso de error.

## Principios de POO aplicados

- **Abstracción**: `Mascota` es una clase `abstract` que no puede instanciarse
  directamente; define el contrato común de cualquier paciente.
- **Encapsulamiento**: el código único (`Codigo`) y el estado (`Estado`) solo pueden
  modificarse mediante métodos controlados (`CambiarEstado`), no directamente desde
  fuera de la clase.
- **Herencia**: `Perro`, `Gato`, `Ave` y `Tortuga` heredan los atributos y métodos
  comunes de `Mascota` y agregan sus propios atributos.
- **Polimorfismo**: el método `CalcularDosis()` se comporta distinto en cada especie
  gracias a la propiedad abstracta `FactorAjusteDosis`, que cada clase hija
  redefine; y `MostrarInformacion()` se extiende (`override`) para mostrar los
  atributos particulares de cada especie.

## Autor

Oliver Jorge Raxtún Morales — Carné 202400634
