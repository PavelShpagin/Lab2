using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    static class RootDir 
    {
		public static string Get(string path)
		{
			// Get the base directory of the current application domain
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

			// Navigate up the directory structure until you find a file with the ".sln" extension,
			// which typically indicates the root of the project
			string directory = baseDirectory;
			while (!Directory.GetFiles(directory, "*.sln").Any())
			{
				string parentDirectory = Directory.GetParent(directory).FullName;
				if (parentDirectory == directory)
				{
					// Reached the root without finding a solution file
					break;
				}
				directory = parentDirectory;
			}

			return Path.Combine(directory, "Lab2", path);
		}
	}
}
