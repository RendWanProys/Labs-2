try
{
    Console.WriteLine("Введите текст, при наличи '«' или '»' они будут удалены!");
    string input = Console.ReadLine();
    string newText = input.Replace("«", "").Replace("»", "").Replace("<", "").Replace(">", "");
    Console.WriteLine(newText);
}
catch
{

}