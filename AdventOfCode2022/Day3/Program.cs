





using System.Text;

void GetPriorities()
{
    List<string> priorities = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList();
    List<char> tempChar = new List<char>();
    int totalPriorities = 0;

    foreach (var prior in priorities)
    {
        Console.WriteLine(prior[..((prior.Length / 2) )]);
        Console.WriteLine(prior.Substring(prior.Length / 2, prior.Length / 2));
        
        foreach (char c in prior[..((prior.Length / 2))])
        {
            if (!tempChar.Contains(c))
            {
                if (prior.Substring(prior.Length / 2, prior.Length / 2).Contains(c))
                {
                    tempChar.Add(c);
                    totalPriorities += ((int)c >= 97) ? ((int)c - 96) : ((int)c - 38);
                }
            }
        }
        tempChar = new List<char>();
    }

    Console.WriteLine("Score:" + totalPriorities);

}

void GetBadges()
{
    List<string> priorities = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList();
    List<string> tempStrings = new List<string>();
    int totalPriorities = 0;

    foreach (var prior in priorities)
    {
        if (tempStrings.Count() < 3)
            tempStrings.Add(prior);
        if(tempStrings.Count() == 3)
        {
            string shortestString = tempStrings.FirstOrDefault(x => x.Length == tempStrings.Min(y => y.Length));
            tempStrings.Remove(shortestString);
            foreach(char c in shortestString)
            {
                if (tempStrings.TrueForAll(x => x.Contains(c)))
                {
                    totalPriorities += ((int)c >= 97) ? ((int)c - 96) : ((int)c - 38);
                    tempStrings = new List<string>();
                    break;
                }
            }
        }
    }

    Console.WriteLine("Total: " + totalPriorities);
}

//GetPriorities();
GetBadges();