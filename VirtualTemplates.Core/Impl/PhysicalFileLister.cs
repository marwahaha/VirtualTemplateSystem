﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using VirtualTemplates.Core.Interfaces;

namespace VirtualTemplates.Core.Impl
{
    public class PhysicalFileLister : IPhysicalFileLister
    {
        public IEnumerable<string> ListPhysicalFiles()
        {
            return this.ListPhysicalFiles(HostingEnvironment.ApplicationPhysicalPath, new List<string>() { "*.cshtml", "*.css", "*.js" });
        }

        public IEnumerable<string> ListPhysicalFiles(string path, IList<string> searchPattern)
        {
            var results = new List<string>();

            foreach (var s in searchPattern)
            {
                foreach (var f in Directory.GetFiles(path, s, SearchOption.AllDirectories))
                {
                    results.Add(f.Remove(0, path.Length - 1).Replace(@"\", @"/"));
                }
            }
            return results.OrderBy(x => x);
        }

        public IEnumerable<string> ListPhysicalFiles(string path, string searchPattern)
        {
            return this.ListPhysicalFiles(path, new List<string> { searchPattern });
        }

    }
}