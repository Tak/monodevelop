// 
// ProjectBuilder.cs
//  
// Author:
//       Lluis Sanchez Gual <lluis@novell.com>
// 
// Copyright (c) 2009 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Remoting;
using Microsoft.Build.BuildEngine;
using Microsoft.Build.Framework;
using System.Collections.Generic;
using System.Collections;

namespace MonoDevelop.Projects.Formats.MSBuild
{
	public class ProjectBuilder: MarshalByRefObject, IProjectBuilder
	{
		Project project;
		Engine engine;
		string file;
		
		public ProjectBuilder (string file, string binDir)
		{
			this.file = file;
			engine = new Engine (binDir);
			engine.GlobalProperties.SetProperty ("BuildingInsideVisualStudio", "true");
			Refresh ();
		}
		
		public void Refresh ()
		{
			project = new Project (engine);
			project.Load (file);
		}
		
		public MSBuildResult[] RunTarget (string target, string configuration, string platform, ILogWriter logWriter)
		{
			try {
				SetupEngine (configuration, platform);
				
				LocalLogger logger = new LocalLogger (Path.GetDirectoryName (file));
				engine.RegisterLogger (logger);
				
				ConsoleLogger consoleLogger = new ConsoleLogger (LoggerVerbosity.Normal, logWriter.WriteLine, null, null);
				engine.RegisterLogger (consoleLogger);
				
				project.Build (target);
				return logger.BuildResult.ToArray ();
				
			} finally {
				engine.UnregisterAllLoggers ();
			}
		}
		
		public string[] GetAssemblyReferences (string configuration, string platform)
		{
			SetupEngine (configuration, platform);
			
			project.Build ("ResolveReferences");
			BuildItemGroup grp = project.GetEvaluatedItemsByName ("ReferencePath");
			List<string> refs = new List<string> ();
			foreach (BuildItem item in grp)
				refs.Add (item.Include);
			return refs.ToArray ();
		}
		
		void SetupEngine (string configuration, string platform)
		{
			Environment.CurrentDirectory = Path.GetDirectoryName (file);
			engine.GlobalProperties.SetProperty ("Configuration", configuration);
			if (!string.IsNullOrEmpty (platform))
				engine.GlobalProperties.SetProperty ("Platform", platform);
			else
				engine.GlobalProperties.RemoveProperty ("Platform");
		}
		
		public override object InitializeLifetimeService ()
		{
			return null;
		}
	}
}

