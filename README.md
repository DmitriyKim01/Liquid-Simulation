# Liquid-Simulation

A C# project focused on simulating and visualizing the behavior of liquid drops with an emphasis on paint drop dynamics. This repository includes modular libraries for drawing, geometric shape handling, pattern generation, and simulation benchmarking, as well as comprehensive test coverage for each core area.

## Features

- **Paint Drop Simulation**: Core module (`PaintDropSimulation`) for simulating liquid drop physics and interaction.
- **Visualization & Drawing**: Utilities in the `DrawingLibrary` for rendering, exporting, and manipulating simulation visuals.
- **Geometric Shape Support**: `ShapeLibrary` provides reusable code for geometric computations essential to the simulation.
- **Pattern Generation**: `PatternGenerationLib` for algorithmic creation and management of visual patterns in simulations.
- **Benchmarking & Performance**: `PaintDropSimulationBenchmarking` and a dedicated `Performance.md` for tracking performance metrics and comparisons.
- **Testing**: Dedicated test directories for each module (`PaintDropSimulationTests`, `PatternGenerationLibTests`, `ShapeLibraryTests`).

## Directory Structure

```
.
├── DrawingLibrary/
├── PaintDropSimulation/
├── PaintDropSimulationBenchmarking/
├── PaintDropSimulationTests/
├── PaintDrops.sln
├── PaintDrops/
├── PatternGenerationLib/
├── PatternGenerationLibTests/
├── ShapeLibrary/
├── ShapeLibraryTests/
├── .gitignore
├── .gitlab-ci.yml
├── global.json
├── Performance.md
└── README.md
```

## Technologies

- **Primary Language**: C#
- **Auxiliary**: Batchfile scripts
- **Build/Config**: `.gitlab-ci.yml`, `global.json`, `.gitignore`
- **Solution/Project Files**: `PaintDrops.sln`

## Getting Started

1. Clone the repository:
   ```bash
   git clone https://github.com/DmitriyKim01/Liquid-Simulation.git
   ```
2. Open `PaintDrops.sln` in Visual Studio 2022 or later.
3. Restore NuGet packages and build the solution.
4. Run the desired simulation projects or test runner of your choice.

## Performance

Details and current benchmarks are tracked in [`Performance.md`](./Performance.md).

For questions or collaboration, visit the [project on GitHub](https://github.com/DmitriyKim01/Liquid-Simulation) or contact the repository owner.
