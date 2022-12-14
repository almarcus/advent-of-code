namespace AOC2022;

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
            return Name == name ? this : Files.FirstOrDefault(x => x.GetByName(name) != null);
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

    // public class File
    // {
    //     public string Name;
    //     private int size;

    //     public virtual int Size()
    //     {
    //         return size;
    //     }
    //     public File(string name, int size) 
    //     {
    //         Name = name;
    //         this.size = size;
    //     }
    // }
    // public class Directory : File
    // {
    //     public List<File> Files = new();

    //     public override int Size()
    //     {
    //         return Files.Sum(x => x.Size());
    //     }

    //     public File FindByName(string name)
    //     {
    //         return Files.First(x => x.Name == name);
    //     }

    //     public Directory(string name) : base(name, 0)
    //     {
    //     }
    //}

    public Day7(string input)
    {
        // Directory top = new("/");
        // File b = new("b.txt", 14848514);
        // File c = new("c.dat", 8504156);
        // Directory a = new("a");
        // File f = new("f", 29116);
        // top.Files.Add(b);
        // top.Files.Add(c);
        // top.Files.Add(a);
        // a.Files.Add(f);

        File top = new("/");
        File b = new("b.txt", 14848514);
        File c = new("c.dat", 8504156);
        File a = new("a");
        File f = new("f", 29116);
        top.Files.Add(b);
        top.Files.Add(c);
        top.Files.Add(a);
        a.Files.Add(f);

        var parent = top.GetParent("a");
        parent = top.GetParent("f");
        parent = top.GetParent("b.txt");
    }
}