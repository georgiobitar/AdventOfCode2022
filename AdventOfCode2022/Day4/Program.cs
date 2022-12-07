

void FindIntersections(int o)
{  
    Console.WriteLine("Total: " + System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList().Where(x => (int.Parse(x.Split(",")[0].Split("-")[(o == 1) ? 0 : 1]) >= int.Parse(x.Split(",")[1].Split("-")[0]) && int.Parse(x.Split(",")[0].Split("-")[(o == 1) ? 1 : 0]) <= int.Parse(x.Split(",")[1].Split("-")[1])) || (int.Parse(x.Split(",")[0].Split("-")[0]) <= int.Parse(x.Split(",")[1].Split("-")[(o == 1) ? 0 : 1]) && int.Parse(x.Split(",")[0].Split("-")[1]) >= int.Parse(x.Split(",")[1].Split("-")[(o == 1) ? 1 : 0]))).Count());
}
//part1
FindIntersections(1);
//part2
FindIntersections(2);