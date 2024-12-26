namespace ConsoleApp
{
    public class MyDerivedObject : MyObject
    {
        public double C { get; set; }
        public MyDerivedObject(double a, double b, double c) : base(a, b)
        {
            C = c;
        }
        public override double CalculateSumOfSquares()
        {
             if (A == 0)
            {
                throw new ArgumentException("Коэффициент 'a' не может быть равен 0.");
            }
            return (C - B) / A;
        }

    }
}
