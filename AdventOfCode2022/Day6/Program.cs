

int GetCharacterNumber(int numberOfChar)
{
    List<string> input = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList();
    Stack<char> chars = new Stack<char>();

    foreach (string line in input)
    {
        for (int i = 0; i < line.Length - numberOfChar; i++)
        {
            int j = 0;
            string s = line.Substring(i, numberOfChar);
            for (j = 0; j < s.Length; j++)
            {
                if (s.Substring(j + 1, s.Length - j - 1).Contains(s[j]))
                {
                    break;
                }
            }
            if (j == s.Length)
            {
                return i + 14;
            }
        }
    }
    return 0;
}

Console.WriteLine(GetCharacterNumber(14));