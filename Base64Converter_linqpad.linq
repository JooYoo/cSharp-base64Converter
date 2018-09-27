<Query Kind="Program" />

void Main()
{
	var input =Console.ReadLine();
	byte[] bytes = Encoding.UTF8.GetBytes(input);
	string base64 = Convert.ToBase64String(bytes);
	Console.WriteLine(base64);
	
	Console.WriteLine("Press Enter ...");
	Console.ReadLine();
	


}

