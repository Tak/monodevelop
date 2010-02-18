//
// DataProvider.cs
//
// Authors:
//  Levi Bard <taktaktaktaktaktaktaktaktaktak@gmail.com> 
//
// Copyright (C) 2008 Levi Bard
// Based on CBinding by Marcos David Marin Amador <MarcosMarin@gmail.com>
//
// This source code is licenced under The MIT License:
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//


using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

using MonoDevelop.Core;
using MonoDevelop.Core.Gui;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Projects.Gui.Completion;

using MonoDevelop.ValaBinding.Parser;
using MonoDevelop.ValaBinding.Parser.Afrodite;

namespace MonoDevelop.ValaBinding
{
	public class ParameterDataProvider : IParameterDataProvider
	{
		private TextEditor editor;
		private IList<Symbol> functions;
		private string functionName;
		private string returnType;
		private ProjectInformation info;
		
		private static Regex identifierRegex = new Regex(@"^[^\w\d]*(?<identifier>\w[\w\d\.<>]*)", RegexOptions.Compiled);
		public ParameterDataProvider (Document document, ProjectInformation info, string functionName)
		{
			this.editor = document.TextEditor;
			this.functionName = functionName;
			this.info = info;

			functions = new List<Symbol> ();
			Symbol function = info.GetFunction (functionName, document.FileName, editor.CursorLine, editor.CursorColumn);
			if (null != function){ functions.Add (function); }
		}// member function constructor
		
		/// <summary>
		/// Create a ParameterDataProvider for a constructor
		/// </summary>
		/// <param name="constructorOverload">
		/// A <see cref="System.String"/>: The named of the pertinent constructor overload
		/// </param>
		public ParameterDataProvider (Document document, ProjectInformation info, string typename, string constructorOverload)
		{
			this.functionName = constructorOverload;
			this.editor = document.TextEditor;
			this.info = info;
			
			List<Symbol> myfunctions = info.GetConstructorsForType (typename, document.FileName, editor.CursorLine, editor.CursorColumn, null); // bottleneck
			if (1 < myfunctions.Count) {
				foreach (Symbol function in myfunctions) {
					if (functionName.Equals (function.Name, StringComparison.Ordinal)) {
						functions = new List<Symbol> () {function};
						return;
					}
				}
			}
			
			functions = myfunctions;
		}// constructor constructor
		
		/// <summary>
		/// The number of overloads for this method
		/// </summary>
		public int OverloadCount {
			get { return functions.Count; }
		}
		
		/// <summary>
		/// Get the index of the parameter where the cursor is currently positioned.
		/// </summary>
		/// <param name="ctx">
		/// A <see cref="CodeCompletionContext"/>
		/// </param>
		/// <returns>
		/// A <see cref="System.Int32"/>: The index of the parameter, 
		/// 0 for no parameter entered, 
		/// -1 for outside the list
		/// </returns>
		public int GetCurrentParameterIndex (CodeCompletionContext ctx)
		{
			int cursor = editor.CursorPosition;
			int i = ctx.TriggerOffset;
			
			if (i > cursor)
				return -1;
			else if (i == cursor)
				return 1;
			
			int parameterIndex = 1;
			
			while (i++ < cursor) {
				char ch = editor.GetCharAt (i-1);
				if (ch == ',')
					parameterIndex++;
				else if (ch == ')')
					return -1;
			}
			
			return parameterIndex;
		}
		
		/// <summary>
		/// Get the markup to use to represent the specified method overload
		/// in the parameter information window.
		/// </summary>
		public string GetMethodMarkup (int overload, string[] parameterMarkup, int currentParameter)
		{
			string paramTxt = string.Join (", ", parameterMarkup);
			Symbol function = functions[overload];
			
			int len = function.FullyQualifiedName.LastIndexOf (".");
			string prename = null;
			
			if (len > 0)
				prename = function.FullyQualifiedName.Substring (0, len + 1);
			
//			string cons = string.Empty;
			
//			if (function.IsConst)
//				cons = " const";

			return string.Format ("{2} {3}<b>{0}</b>({1})", GLib.Markup.EscapeText (function.Name), 
			                                                paramTxt, 
			                                                GLib.Markup.EscapeText (function.ReturnType.TypeName), 
			                                                GLib.Markup.EscapeText (prename));
			// return prename + "<b>" + function.Name + "</b>" + " (" + paramTxt + ")" + cons;
		}
		
		/// <summary>
		/// Get the text to use to represent the specified parameter
		/// </summary>
		public string GetParameterMarkup (int overload, int paramIndex)
		{
			Symbol function = functions[overload];
			
			if (null != function && null != function.Parameters[paramIndex]) {
				string name = function.Parameters[paramIndex].Name;
				string type = function.Parameters[paramIndex].TypeName;
				return GLib.Markup.EscapeText (string.Format ("{1} {0}", name, type));
			}
			
			return string.Empty;
		}
		
		/// <summary>
		/// Get the number of parameters of the specified method
		/// </summary>
		public int GetParameterCount (int overload)
		{
			if (null != functions && null != functions[overload] && null != functions[overload].Parameters) {
				return functions[overload].Parameters.Count;
			}
			return 0;
		}
	}
	
	/// <summary>
	/// Data for Vala completion
	/// </summary>
	internal class CompletionData : ICompletionData
	{
		private string image;
		private string text;
		private string description;
		private string completion_string;
		
		public CompletionData (Symbol item)
		{
			this.text = item.Name;
			this.completion_string = item.Name;
			this.description = item.DisplayText;
			this.image = item.Icon;
			DisplayFlags = DisplayFlags.None;
			CompletionCategory = new ValaCompletionCategory (text, image);
		}
		
		public IconId Icon {
			get { return image; }
		}
		
		public string DisplayText {
			get { return text; }
		}
		
		public string Description {
			get { return description; }
		}

		public string CompletionText {
			get { return completion_string; }
		}
		
		public DisplayFlags DisplayFlags {
			get; set;
		}
		
		public CompletionCategory CompletionCategory  {
			get; set; 
		}
	}

	internal class ValaCompletionDataList: CompletionDataList
	{
		public ValaCompletionDataList (): base ()
		{
		}
		
		internal virtual void AddRange (IEnumerable<CompletionData> vals)
		{
			foreach (CompletionData item in vals) {
				Add (item);
			}
		}
	}// ValaCompletionDataList
	
	internal class ValaCompletionCategory: CompletionCategory
	{
		public ValaCompletionCategory (string text, string image): base (text, image)
		{
		}
		
		public override int CompareTo (CompletionCategory other)
		{
			return DisplayText.CompareTo (other.DisplayText);
		}
	}
}
