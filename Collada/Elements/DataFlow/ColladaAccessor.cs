//
//  ColladaAccessor.cs
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
using ColladaSharp.Common.Interfaces;
using System.Xml.Linq;
using System.Collections.Generic;

namespace ColladaSharp.Collada.Elements.DataFlow
{
	public class ColladaAccessor : IColladaSerializable
	{
		private string SourceID;
		private int ArrayAccessorCount;
		private int Stride;
		private List<KeyValuePair<string, string>> Parameters = new List<KeyValuePair<string, string>>();

		public ColladaAccessor(string InSourceID, int InArrayAccessorCount, int InStride)
		{
			this.SourceID = InSourceID;
			this.ArrayAccessorCount = InArrayAccessorCount;
			this.Stride = InStride;
		}

		public void AddParameter(string ParameterName, string ParameterType)
		{
			this.Parameters.Add(new KeyValuePair<string, string>(ParameterName, ParameterType));
		}

		public XElement GetXML()
		{
			XElement AccessorElement = ColladaXElementFactory.CreateElement("accessor");

			AccessorElement.SetAttributeValue("source", SourceID);
			AccessorElement.SetAttributeValue("count", ArrayAccessorCount);
			AccessorElement.SetAttributeValue("stride", Stride);

			foreach (KeyValuePair<string, string> Parameter in Parameters)
			{
				XElement ParameterElement = ColladaXElementFactory.CreateElement("param");
				ParameterElement.SetAttributeValue("name", Parameter.Key);
				ParameterElement.SetAttributeValue("type", Parameter.Value);

				AccessorElement.Add(ParameterElement);
			}

			return AccessorElement;
		}
	}
}

