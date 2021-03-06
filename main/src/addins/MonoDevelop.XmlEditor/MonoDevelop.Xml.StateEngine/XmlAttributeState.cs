// 
// XmlAttributeState.cs
// 
// Author:
//   Michael Hutchinson <mhutchinson@novell.com>
// 
// Copyright (C) 2008 Novell, Inc (http://www.novell.com)
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
using System.Text;
using System.Diagnostics;

namespace MonoDevelop.Xml.StateEngine
{
	
	
	public class XmlAttributeState : State
	{
		XmlNameState XmlNameState;
		XmlDoubleQuotedAttributeValueState DoubleQuotedAttributeValueState;
		XmlSingleQuotedAttributeValueState SingleQuotedAttributeValueState;
		XmlUnquotedAttributeValueState UnquotedAttributeValueState;
		XmlMalformedTagState MalformedTagState;
		
		const int NAMING = 0;
		const int GETTINGEQ = 1;
		const int GETTINGVAL = 2;
		
		public XmlAttributeState () : this (
			new XmlNameState (),
			new XmlDoubleQuotedAttributeValueState (),
			new XmlSingleQuotedAttributeValueState (),
			new XmlUnquotedAttributeValueState (),
			new XmlMalformedTagState ())
		{}
		
		public XmlAttributeState (
			XmlNameState nameState,
			XmlDoubleQuotedAttributeValueState doubleQuotedAttributeValueState,
			XmlSingleQuotedAttributeValueState singleQuotedAttributeValueState,
			XmlUnquotedAttributeValueState unquotedAttributeValueState,
			XmlMalformedTagState malformedTagState)
		{
			this.XmlNameState = nameState;
			this.DoubleQuotedAttributeValueState = doubleQuotedAttributeValueState;
			this.SingleQuotedAttributeValueState = singleQuotedAttributeValueState;
			this.UnquotedAttributeValueState = unquotedAttributeValueState;
			this.MalformedTagState = malformedTagState;
			
			Adopt (this.XmlNameState);
			Adopt (this.DoubleQuotedAttributeValueState);
			Adopt (this.SingleQuotedAttributeValueState);
			Adopt (this.UnquotedAttributeValueState);
			Adopt (this.MalformedTagState);
		}

		public override State PushChar (char c, IParseContext context, ref string rollback)
		{
			XAttribute att = context.Nodes.Peek () as XAttribute;
			
			if (c == '<') {
				//parent handles message
				if (att != null)
					context.Nodes.Pop ();
				rollback = string.Empty;
				return Parent;
			}
			
			//state has just been entered
			if (context.CurrentStateLength == 1)  {
				
				if (context.PreviousState is XmlNameState) {
					Debug.Assert (att.IsNamed);
					context.StateTag = GETTINGEQ;
				}
				else if (context.PreviousState is XmlAttributeValueState) {
					//Got value, so end attribute
					context.Nodes.Pop ();
					att.End (context.LocationMinus (1));
					IAttributedXObject element = (IAttributedXObject) context.Nodes.Peek ();
					element.Attributes.AddAttribute (att);
					rollback = string.Empty;
					return Parent;
				}
				else {
					//starting a new attribute
					Debug.Assert (att == null);
					Debug.Assert (context.StateTag == NAMING);
					att = new XAttribute (context.LocationMinus (1));
					context.Nodes.Push (att);
					rollback = string.Empty;
					return XmlNameState;
				}
			}
			
			if (c == '>') {
				context.LogWarning ("Attribute ended unexpectedly with '>' character.");
				if (att != null)
					context.Nodes.Pop ();
				rollback = string.Empty;
				return Parent;
			}
			
			if (context.StateTag == GETTINGEQ) {
				if (char.IsWhiteSpace (c)) {
					return null;
				} else if (c == '=') {
					context.StateTag = GETTINGVAL;
					return null;
				}
			} else if (context.StateTag == GETTINGVAL) {
				if (char.IsWhiteSpace (c)) {
					return null;
				} else if (c== '"') {
					return DoubleQuotedAttributeValueState;
				} else if (c == '\'') {
					return SingleQuotedAttributeValueState;
				} else if (char.IsLetterOrDigit (c)) {
					rollback = string.Empty;
					return UnquotedAttributeValueState;
				}
			}
			
			if (Char.IsLetterOrDigit (c) || char.IsPunctuation (c) || char.IsWhiteSpace (c)) {
				context.LogError ("Unexpected character '" + c + "' in attribute.");
				if (att != null)
					context.Nodes.Pop ();
				rollback = string.Empty;
				return Parent;
			}
			
			rollback = string.Empty;
			return Parent;
		}
	}
}
