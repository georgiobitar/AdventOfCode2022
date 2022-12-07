using System.Text.RegularExpressions;


List<string> GetStackNumberAndHeights()
{
    List<string> input = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList();
    List<string> crates = new List<string>();

    int number = 0;
    //Determining the number of stacks (9)
    foreach (string line in input)
    {

        if (line.Any(Char.IsDigit)) //We got the to the lines 
        {
            foreach (char c in line)//Trimming wasn't working...
            {
                if (c.ToString().Any(Char.IsDigit))
                    number++;
            }
            crates.Add(number.ToString());
            return crates;
        }
        else { crates.Add(line); }
    }
    return crates;
}

void GetCrates(bool part2)
{
    List<string> crates = GetStackNumberAndHeights();
    int numberOfStacks = int.Parse(crates.Last());
    crates.RemoveAt(crates.Count - 1);
    string[,] strings = new string[numberOfStacks, crates.Count()];
    List<Stack<string>> stack = new List<Stack<string>>();

    //Initialize stack
    for (int i = 0; i < numberOfStacks; i++)
    {
        stack.Add(new Stack<string>());
    }

    //The letter corresponding to the crate is mentioned at every i*4+1 character
    crates.Reverse();
    for (int j = 0; j < crates.Count(); j++)
    {
        {
            for (int i = 0; i < numberOfStacks; i++)
            {
                if (crates.ElementAt(j).Substring(i * 4 + 1, 1).ToString().Trim() != "")
                    stack.ElementAt(i).Push(crates.ElementAt(j).Substring(i * 4 + 1, 1).ToString());
            }
        }
    }

    //Move things around from stack to stack
    List<string> lines = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList();
    lines.RemoveRange(0, numberOfStacks + 2 - 1);

    foreach (string line in lines)
    {

        int quantityToMove = int.Parse(line.Split(" ")[1]);
        int from = int.Parse(line.Split(" ")[3]);
        int to = int.Parse(line.Split(" ")[5]);

        List<string> temp = new List<string>();

        for (int i = 0; i < quantityToMove; i++)
        {
            temp.Add(stack.ElementAt(from - 1).First());
            stack.ElementAt(from - 1).Pop();
        }

        if (part2)
            temp.Reverse();

        foreach (string x in temp)
        {
            stack.ElementAt(to - 1).Push(x);
        }
        temp = new List<string>();

    }

    //Print end result
    foreach (Stack<string> s in stack)
    {
        Console.WriteLine(s.First());
    }

}

GetCrates(true);