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
