using System.IO;
using System.Text;
class Program
{
    struct Product
    {
        public string Name;
        public int Year;
        public int Quantity;
        public string Manufacturer;
        public double Price;
    }
    static void Main()
    {
        string filePath = "products.bin";
        Encoding encoding = Encoding.UTF8; 
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create), encoding))
        {
            // Записываем несколько товаров
            WriteProduct(writer, new Product { Name = "Яблоки", Year = 2018, Quantity = 100, Manufacturer = "Сады Придонья", Price = 50.0 });
            WriteProduct(writer, new Product { Name = "Апельсины", Year = 2020, Quantity = 50, Manufacturer = "Испания", Price = 70.0 });
            WriteProduct(writer, new Product { Name = "Бананы", Year = 2017, Quantity = 75, Manufacturer = "Эквадор", Price = 60.0 });
        }
        double totalLoss = 0;
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open), encoding))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                Product product = ReadProduct(reader);
                if (DateTime.Now.Year - product.Year > 5)
                {
                    totalLoss += product.Quantity * product.Price;
                }
            }
        }
        Console.WriteLine("Сумма потерь при списании товаров: " + totalLoss);
    }

    static void WriteProduct(BinaryWriter writer, Product product)
    {
        writer.Write(product.Name);
        writer.Write(product.Year);
        writer.Write(product.Quantity);
        writer.Write(product.Manufacturer);
        writer.Write(product.Price);
    }

    static Product ReadProduct(BinaryReader reader)
    {
        Product product = new Product();
        product.Name = reader.ReadString();
        product.Year = reader.ReadInt32();
        product.Quantity = reader.ReadInt32();
        product.Manufacturer = reader.ReadString();
        product.Price = reader.ReadDouble();
        return product;
    }
}

