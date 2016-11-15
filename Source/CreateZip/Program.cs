using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PDFSynthesizer;

namespace ZipItUp
{
    static class Program
    {
        public static void Main()
        {
            try
            {
                var assemblyPath = Assembly.GetAssembly(typeof(SynthesizablePDF)).Location;
                var outputDirectory = Directory.GetParent(assemblyPath).ToString();
                var deployDirectory = GetDeploymentDirectory(outputDirectory);

                if (!deployDirectory.Exists)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Expected deployment folder does not exist:");
                    Console.WriteLine(deployDirectory);
                    Console.Read();

                    return;
                }

                var destination = CreateDeploymentPackage(deployDirectory, outputDirectory);

                Console.WriteLine("Successfully created deployment package:");
                Console.WriteLine();
                Console.WriteLine(destination);
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Something went wrong :\");
                Console.WriteLine();
                Console.WriteLine(ex);
                Console.Read();
            }
        }

        static DirectoryInfo GetDeploymentDirectory(string outputDirectoryPath)
        {
            var locationPathElements = outputDirectoryPath.Split(Path.DirectorySeparatorChar).ToList();
            var rootIndex = locationPathElements.IndexOf("root");
            var rootPath = string.Join(Path.DirectorySeparatorChar.ToString(), locationPathElements.Take(rootIndex + 1).ToArray());

            return new DirectoryInfo(Path.Combine(rootPath, "Deploy"));
        }

        static string CreateDeploymentPackage(DirectoryInfo deployDirectory, string outputDirectory)
        {
            var deployments = deployDirectory.GetFiles("*WhizBang*v*.zip", SearchOption.TopDirectoryOnly).Select(x => x.Name);
            Version nextVersion;

            if (!deployments.Any())
            {
                nextVersion = new Version(1, 0, 0, 0);
            }
            else
            {
                var regEx = new Regex(@"[\d.]{1,7}\d");
                nextVersion = deployments.Select(x => new Version(regEx.Match(x).ToString())).Max().IncrementRevision();
            }

            var destination = Path.Combine(deployDirectory.ToString(), string.Format("WhizBang v{0}.zip", nextVersion));
            ZipFile.CreateFromDirectory(outputDirectory, destination);

            return destination;
        }

        static Version IncrementRevision(this Version startingVersion)
        {
            return new Version(startingVersion.Major, startingVersion.Minor, Math.Max(startingVersion.Build, 0), startingVersion.Revision + 1);
        }
    }
}