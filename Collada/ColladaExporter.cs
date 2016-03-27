//
//  ColladaExporter.cs
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
using ColladaSharp.Collada.Elements;
using ColladaSharp.Collada.Chunks;

namespace ColladaSharp.Collada
{
	public static class ColladaExporter
	{
		public static bool Export(ColladaModel Model, string exportPath)
		{
			return false;
		}

		public static XDocument Export(ColladaModel Model)
		{
			XElement RootElement = ColladaXElementFactory.CreateElement("COLLADA");
			RootElement.SetAttributeValue("version", Model.ColladaVersion);
			RootElement.SetAttributeValue("base", ColladaModel.XMLBase);

			if (!Model.AssetData.GetXML().IsEmpty)
			{
				RootElement.Add(Model.AssetData.GetXML());
			}

			foreach (ColladaLibrary Library in Model.Libraries)
			{
				if (!Library.GetXML().IsEmpty)
				{
					RootElement.Add(Library.GetXML());
				}
			}

			if (!Model.Scene.GetXML().IsEmpty)
			{
				RootElement.Add(Model.Scene.GetXML());
			}

			XDocument document = new XDocument(RootElement);
			return document;
		}
	}
}

