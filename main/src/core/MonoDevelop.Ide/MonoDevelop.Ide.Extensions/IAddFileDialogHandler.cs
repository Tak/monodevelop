// 
// IAddFileDialogHandler.cs
//  
// Author:
//       Lluis Sanchez Gual <lluis@novell.com>
// 
// Copyright (c) 2010 Novell, Inc (http://www.novell.com)
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
using MonoDevelop.Components.Extensions;


namespace MonoDevelop.Ide.Extensions
{
	/// <summary>
	/// This interface can be implemented to provide a custom implementation
	/// for the AddFileDialog dialog (used to add files to a project)
	/// </summary>
	public interface IAddFileDialogHandler
	{
		/// <summary>
		/// Show the dialog
		/// </summary>
		bool Run (AddFileDialogData data);
	}

	/// <summary>
	/// Data for the IAddFileDialogHandler implementations
	/// </summary>
	public class AddFileDialogData: SelectFileDialogData
	{
		/// <summary>
		/// Build actions from which the user can select the one to apply to the new file
		/// </summary>
		public string[] BuildActions;
		
		/// <summary>
		/// Selected build action. To be set by the handler.
		/// </summary>
		public string OverrideAction { get; set; }
	}
}
