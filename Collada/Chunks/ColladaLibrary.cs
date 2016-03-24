//
//  Library.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2016 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Collections;
using System.Collections.Generic;
using ColladaSharp.Collada.Elements;
using System.Xml.Linq;
using ColladaSharp.Common;

namespace ColladaSharp.Collada.Chunks
{
	/// <summary>
	/// Collada Library section. Used for storing elements that can be referenced
	/// from other parts of the file.
	/// </summary>
	public sealed class ColladaLibrary : IEnumerable
	{
		private readonly LibraryType Type;

		/// <summary>
		/// The list of values in this library.
		/// </summary>
		private readonly List<XElement> Elements = new List<XElement>();

		public ColladaLibrary(LibraryType InType)
		{
			this.Type = InType;
		}

		/// <summary>
		/// Gets the enumerator for this Library.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator GetEnumerator()
		{
			return Elements.GetEnumerator();
		}

		public XElement GetXML()
		{
			XElement libraryElement = ColladaXElementFactory.CreateElement("library_" + Type.ToFriendlyName());

			foreach (XElement Element in Elements)
			{
				libraryElement.Add(Element);
			}

			return libraryElement;
		}
	}
}

