namespace ConsoleApp
{
    public class MyObject
    {
        public double A { get; set; }
        public double B { get; set; }
        public MyObject(double a, double b)
        {
            A = a;
            B = b;
        }
        public double CalculateSumOfSquares()
        {
           return A * A + B * B;
        }
    }
}
