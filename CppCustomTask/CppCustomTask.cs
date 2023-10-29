using System;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace CppCustomTask
{
    public class CppCustomTask : Task
    {
        public string SourcePath { get; set; }
        public string Definitions { get; set; }
        public string IncludePaths { get; set; }
        public override bool Execute()
        {
            Log.LogMessage($"CppCustomTask");
            Log.LogMessage($"SourcePath = {SourcePath}");
            Log.LogMessage($"Definitions = {Definitions}");
            Log.LogMessage($"IncludePaths = {IncludePaths}");
            return true;
        }
    }
}
