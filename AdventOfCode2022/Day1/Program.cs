

//part1
//List<string> calories = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList();
//Stack<int> stack = new Stack<int>();
//stack.Push(0);
//int temp = 0;

//foreach (string ca in calories)
//{
//    if (ca != "")
//    {
//        temp += int.Parse(ca);
//    }
//    else
//    {
//        if (temp > stack.First())
//            stack.Push(temp);
//        temp = 0;
//    }
//}
//Console.WriteLine("Highest calories: " + stack.First());

//part 2
List<string> calories = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList();
Stack<int> stack = new Stack<int>();
stack.Push(0);
int temp = 0;

foreach (string ca in calories)
{
    if (ca != "")
    {
        temp += int.Parse(ca);
    }
    else
    {
        stack.Push(temp);
        temp = 0;
    }
}
Console.WriteLine("Highest calories: " + stack.ToList().OrderByDescending(x => x).Take(3).ToList().Sum());