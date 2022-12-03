

void GetCalories(int numberOfRows)
{
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
    Console.WriteLine("Highest calories: " + stack.OrderByDescending(x => x).Take(numberOfRows).ToList().Sum());
}
GetCalories(1);
GetCalories(3);
