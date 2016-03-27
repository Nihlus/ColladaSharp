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
using ColladaSharp.Common.Interfaces;
using ColladaSharp.Collada.Elements.Global;

namespace ColladaSharp.Collada.Chunks
{
	/// <summary>
	/// Collada Library section. Used for storing elements that can be referenced
	/// from other parts of the file.
	/// </summary>
	public abstract class ColladaLibrary : IEnumerable, IColladaSerializable
	{
		protected LibraryType Type;
		public string ID;
		public string Name;

		public ColladaAssetData AssetData;
		public readonly List<ColladaExtra> ExtraData = new List<ColladaExtra>();

		/// <summary>
		/// The list of values in this library.
		/// </summary>
		private readonly List<ColladaElement> Elements = new List<ColladaElement>();

		/// <summary>
		/// Gets the enumerator for this Library.
		/// </summary>
		/// <returns>The enumerator.</returns>
		public IEnumerator GetEnumerator()
		{
			return Elements.GetEnumerator();
		}

		public virtual XElement GetXML()
		{
			throw new NotImplementedException();
		}
	}
}

