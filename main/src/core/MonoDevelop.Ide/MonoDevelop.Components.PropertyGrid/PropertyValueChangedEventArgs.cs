/* 
 * PropertyValueChangedEventArgs.cs - The arguments for the PropertyGrid's PropertyValueChanged event
 * 
 * Part of PropertyGrid - A Gtk# widget that displays and allows 
 * editing of all of an object's public properties 
 * 
 * Authors: 
 *  Michael Hutchinson <m.j.hutchinson@gmail.com>
 *  
 * Copyright (C) 2005 Michael Hutchinson
 *
 * This sourcecode is licenced under The MIT License:
 * 
 * Permission is hereby granted, free of charge, to any person obtaining
 * a copy of this software and associated documentation files (the
 * "Software"), to deal in the Software without restriction, including
 * without limitation the rights to use, copy, modify, merge, publish,
 * distribute, sublicense, and/or sell copies of the Software, and to permit
 * persons to whom the Software is furnished to do so, subject to the
 * following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
 * OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN
 * NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
 * DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
 * OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
 * USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

using System;
using System.ComponentModel;

namespace MonoDevelop.Components.PropertyGrid
{
	public class PropertyValueChangedEventArgs
	{
		private PropertyDescriptor changedItem;
		private object oldValue;
		private object newValue;

		public PropertyValueChangedEventArgs (PropertyDescriptor changedItem, object oldValue, object newValue)
		{
			this.changedItem = changedItem;
			this.oldValue = oldValue;
			this.newValue = newValue;
		}

		public object OldValue {
			get { return oldValue; }
		}

		public object NewValue
		{
			get { return newValue; }
		}

		public PropertyDescriptor ChangedItem {
			get { return changedItem; }
		}
	}
}
