//
//  ColladaGeometry.cs
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
using ColladaSharp.Collada.Chunks;
using ColladaSharp.Collada.Elements.Geometry.GeometryTypes;
using System.Collections.Generic;
using ColladaSharp.Collada.Elements.Global;

namespace ColladaSharp.Collada.Elements.Geometry
{
	public class ColladaGeometry : IColladaSerializable
	{
		public ColladaAssetData AssetData = new ColladaAssetData();
		public ColladaGeometryType GeometricData = new ColladaGeometryType();
		public List<ColladaExtra> ExtraData = new List<ColladaExtra>();

		public ColladaGeometry()
		{
		}

		public XElement GetXML()
		{
			XElement Element = new XElement("geometry");

			return Element;
		}
	}
}

