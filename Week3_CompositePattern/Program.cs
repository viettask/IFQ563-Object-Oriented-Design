/*
 * Structural Design Pattern
 */

using System;
using System.Collections.Generic;

// Unified Graphic class
class Graphic
{
    private readonly List<Graphic> _graphics = new List<Graphic>();
    private readonly string _name;

    // Constructor for leaf nodes
    public Graphic(string name)
    {
        _name = name;
    }

    public void Add(Graphic graphic)
    {
        _graphics.Add(graphic);
    }

    public void Remove(Graphic graphic)
    {
        _graphics.Remove(graphic);
    }

    public void Draw()
    {
        Console.WriteLine($"Drawing {_name}");
        foreach (var graphic in _graphics)
        {
            graphic.Draw();
        }
    }
}

class Circle : Graphic
{
    public Circle(string name) : base(name)
    {
    }
}

class Rectangle : Graphic
{
    public Rectangle(string name) : base(name)
    {
    }
}

class Program
{
    static void Main()
    {
        // Create leaf objects
        Graphic circle = new Circle("Circle");
        Graphic rectangle = new Rectangle("Rectangle");

        // Create a composite graphic
        Graphic composite1 = new Graphic("Composite 1");
        composite1.Add(circle);
        composite1.Add(rectangle);

        // Create another composite graphic
        Graphic composite2 = new Graphic("Composite 2");
        composite2.Add(composite1);
        composite2.Add(new Rectangle("Another Rectangle"));

        // Draw all graphics
        composite2.Draw();
    }
}