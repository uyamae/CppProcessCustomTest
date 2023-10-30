using System;
using System.Collections.Generic;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace CppCustomTask
{
    public class CppCustomTask : Task
    {
        public string SourcePath { get; set; }
        public string Definitions { get; set; }
        public string IncludePaths { get; set; }

        public string OutputDir { get; set; }
        [Output]
        public string OutputPaths { get; set; }
        public override bool Execute()
        {
            Log.LogMessage($"CppCustomTask");
            //Log.LogMessage($"SourcePath = {SourcePath}");
            //Log.LogMessage($"Definitions = {Definitions}");
            //Log.LogMessage($"IncludePaths = {IncludePaths}");
            //Log.LogMessage($"OutputDir = {OutputDir}");
            string[] FilePaths = SourcePath.Split(';');
            List<string> OutputPathList = new List<string>();
            if (!System.IO.Directory.Exists(OutputDir))
            {
                System.IO.Directory.CreateDirectory(OutputDir);
            }
            foreach (string filePath in FilePaths)
            {
                string fileName = System.IO.Path.GetFileNameWithoutExtension(filePath);
                string outputFilePath = System.IO.Path.Combine(OutputDir, $"{fileName}.gen.cpp");
                using (System.IO.StreamWriter writer = System.IO.File.CreateText(outputFilePath))
                {
                    writer.WriteLine("#include <string>");
                    writer.WriteLine($"namespace {fileName}_private {{");
                    writer.WriteLine($"  const char * prepro_defs = \"{Definitions}\";");
                    //writer.WriteLine($"  const char * include_paths = \"{IncludePaths}\"");
                    writer.WriteLine($"}} // namespace {fileName}_private");

                    OutputPathList.Add(outputFilePath);

                    Log.LogMessage($"generate {outputFilePath}");
                }
            }
            OutputPaths = string.Join(";", OutputPathList);
            Log.LogMessage($"OutputPaths={OutputPaths}");
            return true;
        }
    }
}
