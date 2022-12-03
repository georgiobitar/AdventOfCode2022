
//part1
//void GetScore()
//{
//    List<string> strategy = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList();
//    strategy = strategy.Select(x => x.Replace("A", "1").Replace("B","2").Replace("C","3").Replace("X","1").Replace("Y", "2").Replace("Z", "3")).ToList();
//    int totalScore = 0;


//    foreach (string row in strategy)
//    {
//        int result = int.Parse(row.Split(" ")[1]) - int.Parse(row.Split(" ")[0]);
//        totalScore += int.Parse(row.Split(" ")[1]); //adding selection score

//        if (result == 0)
//            totalScore += 3;
//        else if (result == 1 || result == -2)
//            totalScore += 6;
//    }

//    Console.WriteLine("Score: " + totalScore);
//}


//part2
void GetScore()
{
    List<string> strategy = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList();
    strategy = strategy.Select(x => x.Replace("A", "1").Replace("B", "2").Replace("C", "3").Replace("X", "1").Replace("Y", "2").Replace("Z", "3")).ToList();
    int totalScore = 0;

    foreach (string row in strategy)
    {
        int move = 0;
        if (row.Split(" ")[1] == "1") //lose
        {
            move = int.Parse(row.Split(" ")[0]) - 1;
            if (move <= 0) move = 3;
        }
        else if (row.Split(" ")[1] == "2")//draw
        {
            totalScore += 3;
            move = int.Parse(row.Split(" ")[0]);
        }
        else if (row.Split(" ")[1] == "3")//win
        {
            totalScore += 6;
            move = int.Parse(row.Split(" ")[0]) + 1;
            if (move > 3) move = 1;
        }
        totalScore += move;
    }
    Console.WriteLine("Score: " + totalScore);
}
GetScore();
