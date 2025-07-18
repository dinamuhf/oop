using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        int sum1 = calc.Add(5, 10);           
        int sum2 = calc.Add(1, 2, 3);       
        double sum3 = calc.Add(2.5, 4.3);    
        Console.WriteLine("Sum of 5 + 10 = " + sum1);
        Console.WriteLine("Sum of 1 + 2 + 3 = " + sum2);
        Console.WriteLine("Sum of 2.5 + 4.3 = " + sum3);
    }
}

#region 1
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }
    public int Add(int a, int b, int c)
    {
        return a + b + c;
    }
    public double Add(double a, double b)
    {
        return a + b;
    }
}
#endregion

# region 2   
public class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }
    public Rectangle()
    {
        Width = 0;
        Height = 0;
    }
    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public Rectangle(int size)
    {
        Width = size;
        Height = size;
    }
}
#endregion

#region 3
public class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }
    public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }
    public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }
    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}
#endregion
#region 4
public class Employee
{
    public virtual void Work()
    {
        Console.WriteLine("Employee is working");
    }
}

public class Manager : Employee
{
    public override void Work()
    {
        base.Work(); 
        Console.WriteLine("Manager is managing");
    }
}
#endregion

#region 5


// a) 
public class BaseClass
{
    public virtual void DisplayMessage()
    {
        Console.WriteLine("Message from BaseClass");
    }
}

// b) 
public class DerivedClass1 : BaseClass
{
    public override void DisplayMessage()
    {
        Console.WriteLine("Message from DerivedClass1");
    }
}

// c) 
public class DerivedClass2 : BaseClass
{
    public new void DisplayMessage()
    {
        Console.WriteLine("Message from DerivedClass2");
    }
}
#endregion

#region part2
public class Duration
{
    public int Hours { get; set; }
    public int Minutes { get; set; }
    public int Seconds { get; set; }

    // 1. 
    public Duration(int h, int m, int s)
    {
        Hours = h;
        Minutes = m;
        Seconds = s;
        Normalize();
    }

    // 2. 
    public Duration(int totalSeconds)
    {
        Hours = totalSeconds / 3600;
        Minutes = (totalSeconds % 3600) / 60;
        Seconds = totalSeconds % 60;
    }
    private void Normalize()
    {
        int total = ToSeconds();
        Hours = total / 3600;
        Minutes = (total % 3600) / 60;
        Seconds = total % 60;
    }

    public int ToSeconds() => Hours * 3600 + Minutes * 60 + Seconds;

    // 2
    public override string ToString()
    {
        string output = "";
        if (Hours > 0)
            output += $"Hours: {Hours}, ";
        if (Hours > 0 || Minutes > 0)
            output += $"Minutes: {Minutes}, ";
        output += $"Seconds: {Seconds}";
        return output;
    }
    // Override Equals()
    public override bool Equals(object obj)
    {
        if (obj is Duration other)
            return this.ToSeconds() == other.ToSeconds();
        return false;
    }
    public override int GetHashCode()
    {
        return ToSeconds();
    }

    // 4. 

    public static Duration operator +(Duration d1, Duration d2)
    {
        return new Duration(d1.ToSeconds() + d2.ToSeconds());
    }

    public static Duration operator +(Duration d, int seconds)
    {
        return new Duration(d.ToSeconds() + seconds);
    }

    public static Duration operator +(int seconds, Duration d)
    {
        return new Duration(d.ToSeconds() + seconds);
    }

    public static Duration operator -(Duration d1, Duration d2)
    {
        return new Duration(d1.ToSeconds() - d2.ToSeconds());
    }

    public static Duration operator ++(Duration d)
    {
        return new Duration(d.ToSeconds() + 60);
    }

    public static Duration operator --(Duration d)
    {
        return new Duration(d.ToSeconds() - 60);
    }

    public static bool operator >(Duration d1, Duration d2)
    {
        return d1.ToSeconds() > d2.ToSeconds();
    }

    public static bool operator <(Duration d1, Duration d2)
    {
        return d1.ToSeconds() < d2.ToSeconds();
    }

    public static bool operator >=(Duration d1, Duration d2)
    {
        return d1.ToSeconds() >= d2.ToSeconds();
    }

    public static bool operator <=(Duration d1, Duration d2)
    {
        return d1.ToSeconds() <= d2.ToSeconds();
    }

    public static implicit operator bool(Duration d)
    {
        return d.ToSeconds() > 0;
    }

    public static explicit operator DateTime(Duration d)
    {
        return new DateTime().AddSeconds(d.ToSeconds());
    }
}
#endregion