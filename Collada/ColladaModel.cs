//
//  ColladaModel.cs
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
using System.Xml.Linq;
using ColladaSharp.Collada.Chunks;
using System.Collections.Generic;
using ColladaSharp.Collada.Elements;

namespace ColladaSharp.Collada
{
	/// <summary>
	/// Represents a Collada model which can be manipulated and altered in code.
	/// </summary>
	public class ColladaModel
	{
		public readonly Version ColladaVersion = new Version("1.5.0");
		public static readonly string XMLNS = "https://www.khronos.org/files/collada_schema_1_5";
		public static readonly string XMLBase = "https://www.w3.org/TR/xmlbase/";

		public ColladaAsset Asset = new ColladaAsset();
		public List<ColladaLibrary> Libraries = new List<ColladaLibrary>();
		public ColladaScene Scene = new ColladaScene();

		public XDocument GetXML()
		{			
			XElement RootElement = ColladaXElementFactory.CreateElement("COLLADA");
			RootElement.SetAttributeValue("version", ColladaVersion);
			RootElement.SetAttributeValue("base", XMLBase);

			if (!Asset.GetXML().IsEmpty)
			{
				RootElement.Add(Asset.GetXML());
			}

			foreach (ColladaLibrary Library in Libraries)
			{
				if (!Library.GetXML().IsEmpty)
				{
					RootElement.Add(Library.GetXML());
				}
			}

			if (!Scene.GetXML().IsEmpty)
			{
				RootElement.Add(Scene.GetXML());
			}

			XDocument document = new XDocument(RootElement);
			return document;
		}
	}
}

