// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version value="$version"/>
// </file>

using System;
using System.Collections;
using System.CodeDom.Compiler;
using MonoDevelop.Projects;
using MonoDevelop.Core.Gui;
using MonoDevelop.Ide.Gui;

namespace MonoDevelop.Ide.Tasks
{
	public enum TaskType {
		Error,
		Warning,
		Message,
		SearchResult,
		Comment
	}
	
	public class Task 
	{
		TaskPriority priority = TaskPriority.Normal;
		string   description;
		string   fileName;
		TaskType type;
		Project project;
		int      line;
		int      column;
		

		public override string ToString ()
		{
			return String.Format ("[Task:File={0}, Line={1}, Column={2}, Type={3}, Priority={4}, Description={5}]",
			                     fileName,
			                     line,
			                     column,
			                     type,
			                     Enum.GetName (typeof (TaskPriority), priority),
			                     description);
		}
		
		public Project Project {
			get {
				return project;
			}
		}
		
		public TaskPriority Priority
		{
			get { return priority; }
			set { priority = value; }
		}
		
		public int Line {
			get {
				return line;
			}
		}
		
		public int Column {
			get {
				return column;
			}
		}
		
		public string Description {
			get {
				return description;
			}
		}
		
		public string FileName {
			get {
				return fileName;
			}
			set {
				fileName = value;
			}
		}
		
		public TaskType TaskType {
			get {
				return type;
			}
		}
		
//		public Task (string fileName, string description, int column, int line)
//		{
//			if (fileName != null)
//				type = TaskType.SearchResult;
//			else
//				type = TaskType.Comment;
//			this.fileName    = fileName;
//			this.description = description.Trim();
//			this.column      = column;
//			this.line        = line;
//		}
		
		public Task (string fileName, string description, int column, int line, TaskType type, Project project)
			: this (fileName, description, column, line, type)
		{
			this.project = project;
		}
		
		public Task (string fileName, string description, int column, int line, TaskType type, Project project, TaskPriority priority)
			: this (fileName, description, column, line, type, priority)
		{
			this.project = project;
		}
		
		public Task (string fileName, string description, int column, int line, TaskType type, TaskPriority priority)
			: this (fileName, description, column, line, type)
		{
			this.priority = priority;
		}
		
		public Task (string fileName, string description, int column, int line, TaskType type)
		{
			this.type        = type;
			this.fileName    = fileName;
			this.description = description.Trim();
			this.column      = column;
			this.line        = line;
		}
		
		public Task (Project project, CompilerError error)
		{
			this.project = project;
			type        = error.IsWarning ? error.ErrorNumber == "COMMENT" ? TaskType.Message : TaskType.Warning : TaskType.Error;
			column      = error.Column;
			line        = error.Line;
			description = error.ErrorText;
			if (error.ErrorNumber != String.Empty && error.ErrorNumber != null)
				description += "(" + error.ErrorNumber + ")";
			fileName    = error.FileName;
		}
		
		public void JumpToPosition()
		{
			if (fileName != null && fileName.Length > 0) {
				IdeApp.Workbench.OpenDocument (fileName, Math.Max (1, line), Math.Max (1, column), true);
			}
		}
	}
}
