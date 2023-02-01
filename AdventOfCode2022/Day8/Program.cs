



void GetNumberOfVisibleTrees()
{
    string[] input = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList().ToArray();
    int[,] trees = new int[input.Count(), input[0].Length];
    int numberOfVisibleTrees = input[0].Length * 2 + 2 * (input.Count() - 2);
    int sectionSmallerLeft = 0;
    int sectionSmallerRight = 0;
    int sectionSmallerTop = 0;
    int sectionSmallerDown = 0;

    List<int> areas = new List<int>();

    //Filling array
    for (int i = 0; i < input.Count(); i++)
    {
        for (int j = 0; j < input[0].Length; j++)
        {
            trees[i, j] = int.Parse(input[i][j].ToString());
        }
    }

    for (int i = 1; i < input.Count() - 1; i++)
    {
        for (int j = 1; j < input[0].Length - 1; j++)
        {
            int tempTree = 0;
            for (int k = 0; k < j; k++)//check left side
            {
                if (trees[i, j] >= trees[i, k])
                    sectionSmallerLeft++;
                else
                { sectionSmallerLeft = 0; }
            }


            for (int k = j + 1; k <= input[0].Length - 1; k++)//check right side
            {
                if (trees[i, j] > trees[i, k])
                    sectionSmallerRight++;
                else
                { break; }
            }


            for (int k = 0; k < i; k++)//check top side
            {
                if (trees[i, j] > trees[k, j])
                    sectionSmallerTop++;
                else
                { sectionSmallerTop = 0;  }
            }



            for (int k = i + 1; k <= input.Count() - 1; k++)//check top side
            {
                if (trees[i, j] > trees[k, j])
                    sectionSmallerDown++;
                else
                { break; }
            }

            areas.Add(sectionSmallerLeft * sectionSmallerRight * sectionSmallerTop * sectionSmallerDown);
            sectionSmallerLeft = 0;
            sectionSmallerRight = 0;
            sectionSmallerTop = 0;
            sectionSmallerDown = 0;

            //if (sectionSmallerLeft > 0 || sectionSmallerRight > 0 || sectionSmallerTop > 0 || sectionSmallerDown > 0)
            //    numberOfVisibleTrees++;break include up
        }
    }

    Console.WriteLine(areas.Max());
}

GetNumberOfVisibleTrees();