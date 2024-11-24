try
{
	Console.Write("Введите n:");
	int n = int.Parse(Console.ReadLine());
	double s = 1;
	for (int k = 1; k <= n; k++)
		if (k != 3 && k != -7) s *= Math.Pow(k - 3, k - 5) * (k + 7)/(k!);
	double res = s;
	Console.WriteLine($"res={res:F2}");
}
catch (Exception e)
{
	Console.WriteLine(e.Message);
}