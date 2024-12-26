public class MyObject
{
    public double A { get; set; }
    public double B { get; set; }

    public MyObject(double a = 0, double b = 0)
    {
        A = a;
        B = b;
    }

    public double CalculateSumOfSquares()
    {
        return A * A + B * B;
    }
}