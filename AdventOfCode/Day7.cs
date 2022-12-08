using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using static System.Formats.Asn1.AsnWriter;

namespace AdventOfCode
{
    internal class Day7 : Puzzle
    {
        private Directory GetDirectoryGraph()
        {
            var root = new Directory("/");
            Directory current = root;

            var index = 1;
            while (index < Input.Length)
            {
                var args = Input[index].Split(" ");
                if (args[0] == "$")
                {
                    switch (args[1])
                    {
                        case "cd":
                            current = HandleCd(current, args[2]);
                            index++;
                            break;
                        case "ls":
                            index = HandleLs(current!, index + 1);
                            break;
                    }
                }
            }

            return root;
        }

        private Directory HandleCd(Directory current, string arg)
        {
            return arg == ".." 
                ? current.Parent!
                : current.SubDirs[arg];
        }

        private int HandleLs(Directory dir, int index)
        {
            var row = Input[index].Split(" ");
            while (!row[0].StartsWith("$"))
            {
                if (row[0] == "dir")
                {
                    dir.SubDirs.Add(row[1], new Directory(row[1], dir));
                }
                else
                {
                    dir.Files.Add(new FileInfo(row[1], int.Parse(row[0])));
                }
                index++;

                if (index == Input.Length)
                {
                    return index;
                }
                row = Input[index].Split(" ");
            }
            return index;
        }

        public int CalculateSize(Directory dir, Dictionary<string, int> map)
        {
            var fileSizes = dir.Files.Sum(file => file.Size);
            var dirSizes = dir.SubDirs.Sum(d => CalculateSize(d.Value, map));

            var totalSize = fileSizes + dirSizes;

            map.Add(GetPath(dir), totalSize);
            return totalSize;
        }

        public string GetPath(Directory dir)
        {
            return dir.Parent != null
                ? $"{GetPath(dir.Parent)}{dir.Name}/"
                : dir.Name;
        }

        public override string Part1()
        {
            var graph = GetDirectoryGraph();

            var dirSizes = new Dictionary<string, int>();
            CalculateSize(graph, dirSizes);

            return dirSizes.Where(dir => dir.Value < 100000).Sum(dir => dir.Value).ToString();
        }

        public override string Part2()
        {
            var graph = GetDirectoryGraph();

            var dirSizes = new Dictionary<string, int>();
            var totalSize = CalculateSize(graph, dirSizes);

            var freeSpace = 70000000 - totalSize;
            var neededSpace = 30000000 - freeSpace;

            return dirSizes.Where(dir => dir.Value > neededSpace).Min(dir => dir.Value).ToString();
        }
    }

    public class Directory
    {
        public Directory(string name)
        {
            Name = name;
            SubDirs = new Dictionary<string, Directory>();
            Files = new List<FileInfo>();
        }

        public Directory(string name, Directory parent)
        {
            Name = name;
            Parent = parent;
            SubDirs = new Dictionary<string, Directory>();
            Files = new List<FileInfo>();
        }

        public string Name { get; set; }
        public Directory? Parent { get; set; }
        public Dictionary<string, Directory> SubDirs { get; set; }
        public List<FileInfo> Files { get; set; }
    }

    public class FileInfo
    {
        public FileInfo(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public string Name { get; set; }
        public int Size { get; set; }
    }
}
