/*
 * Creational Design Pattern
 * */


using System;

// Abstract Product for Chair
abstract class Chair
{
}
class ModernChair : Chair
{
    public ModernChair()
    {
        Console.WriteLine("A ModernChair is created");
    }
}
class VictorianChair : Chair
{
    public VictorianChair()
    {
        Console.WriteLine("A VictorianChair is created");
    }
}

// Abstract Product for Table
abstract class Table
{
}
// Concrete Products for Table
class ModernTable : Table
{
    public ModernTable()
    {
        Console.WriteLine("A ModernTable is created");
    }
}
class VictorianTable : Table
{
    public VictorianTable()
    {
        Console.WriteLine("A VictorianTable is created");
    }
}

// Abstract Maker for Dining Set
abstract class DiningSetMaker
{
    // Factory Methods
    public abstract Chair CreateChair();
    public abstract Table CreateTable();

    // An operation that uses the Products
    public void MakeADiningSet()
    {
        Chair chair1 = CreateChair();
        Chair chair2 = CreateChair();
        Chair chair3 = CreateChair();
        Chair chair4 = CreateChair();
        Table table = CreateTable();

    }
}

// Concrete Factories
class ModernDiningSetMaker : DiningSetMaker
{
    public override Chair CreateChair()
    {
        return new ModernChair();
    }

    public override Table CreateTable()
    {
        return new ModernTable();
    }
}

class VictorianDiningSetMaker : DiningSetMaker
{
    public override Chair CreateChair()
    {
        return new VictorianChair();
    }

    public override Table CreateTable()
    {
        return new VictorianTable();
    }
}

class Program
{
    static void Main()
    {
        // Using ModernDiningSetFactory
        DiningSetMaker modernFactory = new ModernDiningSetMaker();
        modernFactory.MakeADiningSet();

        Console.WriteLine();

        // Using VictorianDiningSetFactory
        DiningSetMaker victorianFactory = new VictorianDiningSetMaker();
        victorianFactory.MakeADiningSet();
    }
}
