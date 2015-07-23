using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace moonshine_table_creator
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathPNGs = @".PNG\";
            string fileExt = "*.png";

            string[] files = Directory.GetFiles(pathPNGs, fileExt)
                     .Select(path => Path.GetFileName(path))
                     .ToArray();
            string line = "| ";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("list.txt"))
            {
                file.WriteLine("| Name          | Icon          | Name          | Icon          |");
                file.WriteLine("| ------------- |:-------------:| ------------- |:-------------:|");
                for (int i = 0; i < files.Length; i++)
                {
                    string[] name = files[i].Split('.');
                    line += name[0] + " | [![" + name[0] + " icon](../raw/master/.PNG/" + files[i] + ")](../blob/master/.PNG/" + files[i] + ") | ";
                    if (i != 0 && (i + 1) % 2 == 0)
                    {
                        file.WriteLine(line);
                        line = "| ";
                    }
                }
                file.WriteLine("Generated with the [Moonshine Table Creator](https://github.com/bejonwe/moonshine-table-creator)");
            }
        }
    }
}
