using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace JsonConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Requires 2 arguments => program.exe ContentFolder finalfilePath");
                Console.ReadKey();
            }
            //program.exe ContentFolder finalfilePath
            //Load all files
            List<Photo> p = new List<Photo>();
            //get all files in folder
            foreach (var theFile in Directory.GetFiles(args[0]))
            {
                var q = JsonConvert.DeserializeObject<List<Photo>>(File.ReadAllText(theFile)).Where(x => x.promoted_at != null);
                if(q.Any())
                {
                    foreach (var photo in q)
                    {
                        p.Add(photo);
                    }
                }
            }
            File.WriteAllText(args[1],JsonConvert.SerializeObject(p));
            /*
            var all = from x in p
                where (x.promoted_at != null)
                select x;
            */

        }
    }
}
