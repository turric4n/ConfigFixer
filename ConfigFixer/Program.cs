﻿using System;
using System.Linq;
using System.IO;
using System.IO.Compression;

namespace ConfigFixer
{
    class Program
    {
        static void RenameConfig(string ZipPath, string SrcConfig, string DestConfig)
        {
            using (var archive = new ZipArchive(File.Open(ZipPath, FileMode.Open, FileAccess.ReadWrite), ZipArchiveMode.Update))
            {
                Console.WriteLine("Desired environment configuration -> " + SrcConfig);
                ZipArchiveEntry entryToCopy = archive.Entries.Where(x => x.Name == SrcConfig).FirstOrDefault();
                if (entryToCopy == null) { throw new Exception("ZIP does not contains environment source file"); }
                var entryToDelete = archive.Entries.Where(x => x.Name == DestConfig).Last();
                if (entryToDelete != null) { entryToDelete.Delete(); }
                var entryTomod = archive.CreateEntry(DestConfig);
                Console.WriteLine("Copy config from -> " + SrcConfig + " to " + entryTomod.Name);
                using (var a = entryToCopy.Open())
                    using (var b = entryTomod.Open())
                        a.CopyTo(b);                
            }
        }

        static void Main(string[] args)
        {
            try
            {
                if (args.Count() != 3) { throw new ArgumentException("Invalid arguments"); }
                var zipPath = args[0].ToString();
                if (!File.Exists(zipPath)) { throw new FileNotFoundException("Invalid Zip File"); }
                var srcConfig = args[1].ToString();
                var dstConfig = args[2].ToString();
                RenameConfig(zipPath, srcConfig, dstConfig);
            }
            catch (Exception e)
            {                
                Console.WriteLine("Critical error... " + e.Message);
                Environment.Exit(1);
            }
        }
    }
}

