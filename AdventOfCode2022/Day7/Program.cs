


using System.Collections.Generic;
using System.Drawing;

int GetSize()
{
    //Basically what will this function do is comprehend the input commands
    //to create all the directories with the files in them
    //Therefore we will have a unique mapping that we can iterate easly

    List<string> input = System.IO.File.ReadAllLines(@"..\\..\\..\\input.txt").ToList();
    List<string> directoryNames = new List<string>(); //saving directory names
    List<string> directories = new List<string>(); //saving all directories available in all sublevels >.<
    string currentDirectory = ""; //used to know the current directory while reading the input
    int TotalSizeSmallerThan100 = 0, TotalSizeUsed = 0;
    Dictionary<string, int> directorySizes = new Dictionary<string, int>();

    for (int i = 0; i < input.Count; i++)
    {

        if (input.ElementAt(i)[0] == '$')//It's a Command
        {
            if (input.ElementAt(i).Split(" ")[1] == "cd") //Change Directory Command
            {
                if (input.ElementAt(i).Split(" ")[2] != "..") //example: cd a or cd e
                {

                    if (input.ElementAt(i).Split(" ")[2] == "/")// root/home directory 
                        currentDirectory = "/";
                    else
                    {
                        if (currentDirectory == "/")
                            currentDirectory += (input.ElementAt(i).Split(" ")[2]);// example: /a /b /e
                        else
                            currentDirectory += "/" + (input.ElementAt(i).Split(" ")[2]);//example: /a/b/e or /a/d
                        directories.Remove(currentDirectory);
                    }

                }
                else //Go one dir back, /a/b/c -> /a/b
                {
                    List<string> temp = currentDirectory.Split('/').ToList();
                    temp.RemoveAt(temp.Count - 1);//Removing last dir
                    currentDirectory = string.Join("/", temp);
                }
            }
            else if (input.ElementAt(i).Split(" ")[1] == "ls")
            {
                i++;//Goes to the next line
                for (int j = i; j < input.Count; j++)
                {
                    if (input.ElementAt(j)[0] == '$')
                    {
                        i--;//since the for loop of i will increase it, we dont want to skip the $ line
                        break;//Listing ended
                    }
                    else //Listing still going
                    {
                        if (input.ElementAt(j).Split(" ")[0] == "dir")
                        {

                            if (currentDirectory == "/")
                            {
                                directories.Add(currentDirectory + input.ElementAt(j).Split(" ")[1]);
                                directoryNames.Add(currentDirectory + input.ElementAt(j).Split(" ")[1]);
                            }
                            else
                            {
                                directories.Add(currentDirectory + "/" + input.ElementAt(j).Split(" ")[1]);
                                directoryNames.Add(currentDirectory + "/" + input.ElementAt(j).Split(" ")[1]);
                            }
                        }
                        else
                        {
                            if (currentDirectory == "/")
                                directories.Add(currentDirectory + input.ElementAt(j));
                            else
                                directories.Add(currentDirectory + "/" + input.ElementAt(j));
                        }
                    }
                    i++; //increasing the line
                }
            }
        }

        else //Not command
        {
            //well, nothing...
        }

    }

    foreach (string x in directories)
    {
        Console.WriteLine(x);
    }
    foreach (string x in directoryNames)
    {
        Console.WriteLine(x);
    }
    Console.WriteLine();

    directoryNames.Add("/");//Don't forget the root one!
    //Calculate the dir size
    //part1
    foreach (string main in directoryNames)
    {
        int size = 0;

        foreach (string dir in directories)
        {
            if (dir.Contains(main + "/"))
            {
                size += int.Parse(dir.Split('/').ToList().Last().Split(" ")[0]);
            }
        }
        if (size <= 100000)
            TotalSizeSmallerThan100 += size;

        directorySizes.Add(main, size);//part2
    }

    //Calculating Total Size
    foreach (string dir in directories)
    {
        TotalSizeUsed += int.Parse(dir.Split('/').ToList().Last().Split(" ")[0]);
    }

    //part2
    int neededSpace = 30000000 - (70000000 - TotalSizeUsed);
    foreach (KeyValuePair<string, int> keyValuePair in directorySizes)
    {
        //Removing directories that wont make the space
        if (keyValuePair.Value < neededSpace)
            directorySizes.Remove(keyValuePair.Key);
    }

    Console.WriteLine("Part1:" + TotalSizeSmallerThan100);
    Console.WriteLine("Part2:" + directorySizes.Values.ToList().Min());

    return 0;
}

int a = GetSize();