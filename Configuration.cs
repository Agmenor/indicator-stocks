using System;
using System.IO;
using System.Collections.Generic;

namespace indicatorstocks
{
	public class Configuration
	{
		private String path;

		public Configuration (String name)
		{
			path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); 
			path += @"/" + name + @"/symbols.conf";
		
			if (!Directory.Exists(Path.GetDirectoryName(path)))
				Directory.CreateDirectory(Path.GetDirectoryName(path));

			if (!File.Exists(path))
				File.Create(path);
		}

		public string[] GetSymbols ()
		{
			List<string> symbols = new List<string>();

			using (StreamReader sr = new StreamReader(path)) 
			{
			    string line;
			    while ((line = sr.ReadLine()) != null) 
			        symbols.Add(line);
			}

			return symbols.ToArray();
		}
	}
}