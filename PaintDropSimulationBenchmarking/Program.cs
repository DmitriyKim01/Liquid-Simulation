using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using PaintDropSimulation;
using ShapeLibrary;

class PaintDropSimulationBenchmark
{
    public static void Main(String[] args)
    {
        BenchmarkSurface(500, 500);
        BenchmarkSurface(1000, 1000);
        BenchmarkSurface(2000, 2000);
    }

    private static void BenchmarkSurface(int surfaceWidth, int surfaceHeight)
    {
        int radius = 15;
        int numOfDrops = 150;
        Console.WriteLine($"\nSurface ({surfaceWidth},{surfaceHeight})");
        Bench(() => AddPaintDropsToSurface(surfaceWidth, surfaceHeight, radius, numOfDrops), $"Radius ({radius}), Paintdrops ({numOfDrops})");
        Console.ReadKey();
        radius = 15;
        numOfDrops = 300;
        Bench(() => AddPaintDropsToSurface(surfaceWidth, surfaceHeight, radius, numOfDrops), $"Radius ({radius}), Paintdrops ({numOfDrops})");
        Console.ReadKey();
        radius = 500;
        numOfDrops = 1500;
        Bench(() => AddPaintDropsToSurface(surfaceWidth, surfaceHeight, radius, numOfDrops), $"Radius ({radius}), Paintdrops ({numOfDrops})");
        Console.ReadKey();
    }


    private static void AddPaintDropsToSurface(int width, int height, float radius, float numOfPaintdrops)
    {
        Random rnd = new Random();
        ISurface surface = PaintDropSimulationFactory.CreateSurface(width, height);
        surface.AddPaintDropEvent += (IPaintDrop drop) => { };
        surface.PatternGeneration += (ISurface surface) => new Vector(2, 2);
        for (int i = 0; i < numOfPaintdrops; i++)
        {
            ICircle circle = ShapesFactory.CreateCircle(rnd.Next(surface.Width), rnd.Next(surface.Height), radius, new Colour(255, 0, 0));
            IPaintDrop paintDrop = PaintDropSimulationFactory.CreatePaintDrop(circle);
            surface.AddPaintDrop(paintDrop);
        }
    }

    private static void Bench(Action task, string header)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        task?.Invoke();
        sw.Stop();
        Console.WriteLine($"Time: {sw.ElapsedMilliseconds}ms | {header} \n");
    }
}