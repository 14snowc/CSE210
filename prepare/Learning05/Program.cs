using System;

class Program
{
    static void Main(string[] args)
    {
        var circle = new Circle("Cyan", 3);
        var square = new Square("Silver", 5);
        var rectangle = new Rectangle("Red", 4, 2);


        var shapes = new List<Shape> {circle, square, rectangle};
        foreach (var shape in shapes)
        {   
        Console.WriteLine($"{shape.GetColor()} : {shape.GetArea()}");
        }
    }
}

class Shape
{
    //Attributes
    protected string _color;


    //Methods
    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string newColor)
    {
        _color = newColor;
    }

    public virtual double GetArea()
    {
        return 0;
    }
}

class Square : Shape
{
    //Attributes
    protected double _size;

    //Methods
    public Square(string color, double size) : base(color)
    {
        _size = size;
    }
    public override double GetArea()
    {
        return _size * 2;
    }
}

class Rectangle : Shape
{
    //Attributes
    protected double _length;
    protected double _width;

    //Methods
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }
    public override double GetArea()
    {
        return _length * _width;
    }
}

class Circle : Shape
{
    //Attributes
    protected double _radius;

    //Methods
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }
    public override double GetArea()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}