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

        public override string ToString()
        {
            string fileOrDir = IsDirectory ? "dir" : "file";
            return $"{Name} ({fileOrDir}, size={Size})";
        }

        public string PrintStructure(int i=0)
        {
            string structure = "".PadLeft(i*2, ' ') + $"- {ToString()}";
            foreach (var file in Files)
            {
                structure += "\n" + file.PrintStructure(i+1);
            }

            return structure;
        }

        public bool IsDirectory = false;
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

        public File? Parent;

        public File GetByName(string name) => Name == name ? this : this.Descendants().First(x => x.Name == name);

        public bool IsParent(string childName) => Files.Count > 0 && Files.Any(x => x.Name == childName);

        public File GetParent(string childName)
        {
            return IsParent(childName) ? this : Files.Where(x => x.Descendants().Any(y => y.IsParent(childName))).First();
        }

        public File(string name, File? parent=null)
        {
            Name = name;
            IsDirectory = true;
            Parent = parent;
        }

        public File(string name, int size, File? parent=null)
        {
            Name = name;
            this.size = size;
            Parent = parent;
        }
    }

    readonly File filesystem = new("/", null);
    private const string cd = "$ cd ";
    private const string ls = "$ ls";

    public Day7(string input)
    {
        var commandsAndOutput = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        File currentDirectory = filesystem;

        foreach (string command in commandsAndOutput)
        {
            var structure = filesystem.PrintStructure();
            handleCommand(ref currentDirectory, command);
        }
    }

    private void handleCommand(ref File currentDir, string command)
    {
        if (command.StartsWith(cd))
        {
            string cdArg = command[cd.Length..];
            
            if (cdArg == "..") 
            {
                currentDir = currentDir.Parent;
                // var currentFile = filesystem.GetByName(currentDir);

                // var allDirectories = filesystem.Descendants().Where(x => x.IsDirectory);
                // var directoriesWithChildAsCurrent = allDirectories.Where(x => x.Files.Contains(currentFile));
                // currentDir = directoriesWithChildAsCurrent.First().Name;
                //currentDir = filesystem.Descendants().First(x => x.IsDirectory && x.Files.Contains(currentFile)).Name;
                //string dirToChangeTo = currentDir;
                //currentDir = filesystem.Descendants().Where(x => x.Files.Where(y => y.Name == dirToChangeTo)).First().Name;
                //currentDir = filesystem.GetParent(currentDir).Name;
            }
            else 
                currentDir = currentDir.GetByName(cdArg);
        }
        else if (command.StartsWith(ls)) {}
        else
        {
            var lsOutput = command.Split(' ');
            File fileToAdd;
            if (lsOutput[0] == "dir")
                fileToAdd = new(lsOutput[1], currentDir);
            else
                fileToAdd = new(lsOutput[1], int.Parse(lsOutput[0]), currentDir);
            
            currentDir.Files.Add(fileToAdd);
        }

    }

    public int TotalSizeLarger(int sizeLimit)
    {
        return this.filesystem.Descendants().Where(x => x.IsDirectory && x.Size <= sizeLimit).Sum(x => x.Size);
    }

    public int FindSmallestDirectory(int diskSize, int updateSpaceNeeded)
    {
        int freespaceNeeded = updateSpaceNeeded - (diskSize - filesystem.Size);
        return filesystem.Descendants().Where(x => x.IsDirectory && x.Size >freespaceNeeded).OrderBy(x => x.Size).First().Size;
    }
}