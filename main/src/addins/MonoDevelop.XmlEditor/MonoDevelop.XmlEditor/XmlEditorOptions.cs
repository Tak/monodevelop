//
// MonoDevelop XML Editor
//
// Copyright (C) 2005-2007 Matthew Ward
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

using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Xml;

namespace MonoDevelop.XmlEditor
{
	/// <summary>
	/// The Xml Editor options.
	/// </summary>
	public static class XmlEditorOptions
	{
		internal static readonly string OptionsProperty = "XmlEditor.AddIn.Options";
		internal static readonly string ShowSchemaAnnotationPropertyName = "ShowSchemaAnnotation";
		internal static readonly string AutoCompleteElementsPropertyName = "AutoCompleteElements";
		internal static readonly string AutoInsertFragmentsPropertyName = "AutoInsertFragment";
		internal static readonly string AssociationPrefix = "Association";
		
		static Properties properties;

		static XmlEditorOptions ()
 		{
 			properties = PropertyService.Get (OptionsProperty, new Properties());
			Properties.PropertyChanged += HandlePropertiesPropertyChanged;
			
			ShowSchemaAnnotation = properties.Get<bool> (ShowSchemaAnnotationPropertyName, false);
			AutoCompleteElements = properties.Get<bool> (AutoCompleteElementsPropertyName, false);
			AutoInsertFragments = properties.Get<bool> (AutoInsertFragmentsPropertyName, false);
		}

 		static void HandlePropertiesPropertyChanged (object sender, PropertyChangedEventArgs e)
 		{
			if (e.Key == ShowSchemaAnnotationPropertyName) {
				ShowSchemaAnnotation = (bool)e.NewValue;
			} else if (e.Key == AutoCompleteElementsPropertyName) {
				AutoCompleteElements = (bool)e.NewValue;
			} else if (e.Key == AutoInsertFragmentsPropertyName) {
				AutoInsertFragments = (bool)e.NewValue;
			} else if (XmlSchemaAssociationChanged != null && e.Key.StartsWith (AssociationPrefix)) {
				var ext = e.Key.Substring (AssociationPrefix.Length);
				var assoc = e.NewValue as XmlSchemaAssociation;
				XmlSchemaAssociationChanged (null, new XmlSchemaAssociationChangedEventArgs (ext, assoc));
			}
 		}

 		internal static Properties Properties {
			get {
				Debug.Assert(properties != null);
				return properties;
 			}
		}
		
		#region Properties

		/// <summary>
		/// Raised when any xml editor property is changed.
		/// </summary>
		public static event EventHandler<XmlSchemaAssociationChangedEventArgs> XmlSchemaAssociationChanged;
		
		/// <summary>
		/// Gets an association between a schema and a file extension.
		/// </summary>
		/// <remarks>
		/// <para>The property will be an xml element when the SharpDevelopProperties.xml
		/// is read on startup.  The property will be a schema association
		/// if the user changes the schema associated with the file
		/// extension in tools->options.</para>
		/// <para>The normal way of doing things is to
		/// pass the GetProperty method a default value which auto-magically
		/// turns the xml element into a schema association so we would not 
		/// have to check for both.  In this case, however, I do not want
		/// a default saved to the SharpDevelopProperties.xml file unless the user
		/// makes a change using Tools->Options.</para>
		/// <para>If we have a file extension that is currently missing a default 
		/// schema then if we  ship the schema at a later date the association will 
		/// be updated by the code if the user has not changed the settings themselves. 
		/// </para>
		/// <para>For example, the initial release of the xml editor add-in had
		/// no default schema for .xsl files, by default it was associated with
		/// no schema and this setting is saved if the user ever viewed the settings
		/// in the tools->options dialog.  Now, after the initial release the
		/// .xsl schema was created and shipped with SharpDevelop, there is
		/// no way to associate this schema to .xsl files by default since 
		/// the property exists in the SharpDevelopProperties.xml file.</para>
		/// <para>An alternative way of doing this might be to have the
		/// config info in the schema itself, which a special SharpDevelop 
		/// namespace.  I believe this is what Visual Studio does.  This
		/// way is not as flexible since it requires the user to locate
		/// the schema and change the association manually.</para>
		/// </remarks>
		public static XmlSchemaAssociation GetSchemaAssociation (string extension)
		{
			var association = Properties.Get<XmlSchemaAssociation> (AssociationPrefix + extension.ToLowerInvariant ());
			
			if (association == null)
				association = XmlSchemaAssociation.GetDefaultAssociation (extension);
			
			return association;
		}
		
		public static void RemoveSchemaAssociation (string extension)
		{
			Properties.Set (AssociationPrefix + extension.ToLowerInvariant (), null); 
		}
		
		public static void SetSchemaAssociation (XmlSchemaAssociation association)
		{
			Properties.Set (AssociationPrefix + association.Extension.ToLowerInvariant (), association);
		}
		
		public static IEnumerable<string> GetRegisteredFileExtensions ()
		{
			//for some reason we get an out of sync error unless we copy the list
			List<string> tempList = new List<string> (Properties.Keys);
			foreach (string key in tempList)
				if (key.StartsWith (AssociationPrefix))
					yield return key.Substring (AssociationPrefix.Length);
		}
		
		public static bool ShowSchemaAnnotation { get; private set; }
		public static bool AutoCompleteElements { get; private set; }
		
		/// <summary>
		/// Automatically insert fragments such as ="" when committing an attribute and > when pressing / in a tag.
		/// Off by default since it forces the user to alter typing behaviour.
		/// </summary>
		public static bool AutoInsertFragments { get; private set; }
		
		#endregion
	}
	
	public class XmlSchemaAssociationChangedEventArgs : EventArgs
	{
		public string Extension { get; private set; }
		public XmlSchemaAssociation Association { get; private set; }
		
		public XmlSchemaAssociationChangedEventArgs (string extension, XmlSchemaAssociation association)
		{
			this.Extension = extension;
			this.Association = association;
		}		
	}
}
