namespace Task13_6_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string filePath = @"C:\Users\User\Desktop\Text1.txt";
			var text = File.ReadAllText(filePath);
			var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

			char[] delimiters = new char[] { ' ', '\r', '\n' };
			var words = noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

			var hSet = new HashSet<string>(words);

			var dict = new Dictionary<string, int>();

			foreach (var uniqWord in hSet)
			{
				int count = 0;
				foreach (var word in words)
				{
					if (word == uniqWord)
						count++;
				}
				dict.Add(uniqWord, count);
			}

			var list = dict.Values.ToList();
			list.Sort();
			list.Reverse();

			for (int i = 0; i < 10; i++)
			{
				foreach (var pair in dict)
				{
					if (pair.Value == list[i])
						Console.WriteLine(pair.Key);
				}
			}

			Console.ReadLine();
		}
	}
}