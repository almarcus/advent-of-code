namespace AOC2022;

static class NodeExtensions
{
    public static List<Day7.File> Descendants(this Day7.File node)
    {
        return node.Files.Concat(node.Files.SelectMany(n => n.Descendants())).ToList();
    }
}
public class Day7
{



    public class File
    {
        public string Name;
        public List<File> Files = new();
        private int? size;

        public int Size
        {
            get
            {
                return size ?? Files.Sum(x => x.Size);
            }
            set
            {
                size = value;
            }
        }

        public File GetByName(string name)
        {

            return Name == name ? this : this.Descendants().First(x => x.Name == name);
            // if (Name == name)
            //     return this;
            // else
            // {
            //     foreach (File file in Files)
            //     { 
            //         return file.GetByName(name);
            //         //if (file.GetByName(name).Name == name) return file;
            //     }
            // }


                //return Files.Where(x => x.GetByName(name) != null).FirstOrDefault();
                //return Files.Where(x => x.GetByName(name) != null).Select(x => x.GetByName(name)).First();
          //  return Name == name ? this : Files.Where(x => x.GetByName(name) != null)?.First();
        }

        public bool IsParent(string childName)
        {
            return Files.Any(x => x.Name == childName);
        }

        public File GetParent(string childName)
        {
            return IsParent(childName) ? this : Files.Where(x => x.IsParent(childName)).First();
        }

        public File(string name)
        {
            Name = name;
        }

        public File(string name, int size)
        {
            Name = name;
            this.size = size;
        }
    }

    readonly File filesystem = new("/");
    private const string cd = "$ cd ";
    private const string ls = "$ ls";

    public Day7(string input)
    {
        var commandsAndOutput = input.Split('\n');

        string currentDirectoryName = filesystem.Name;

        foreach (string command in commandsAndOutput)
        {
            handleCommand(ref currentDirectoryName, command);
        }


    }

    private void handleCommand(ref string currentDir, string command)
    {
        if (command.StartsWith(cd))
        {
            string cdArg = command[cd.Length..];
            
            if (cdArg == "..") 
                currentDir = filesystem.GetParent(currentDir).Name;
            else 
                currentDir = filesystem.GetByName(cdArg).Name;
        }
        else if (command.StartsWith(ls)) {}
        else
        {
            var lsOutput = command.Split(' ');
            File fileToAdd;
            if (lsOutput[0] == "dir")
                fileToAdd = new(lsOutput[1]);
            else
                fileToAdd = new(lsOutput[1], int.Parse(lsOutput[0]));
            
            filesystem.GetByName(currentDir).Files.Add(fileToAdd);
        }

    }
}