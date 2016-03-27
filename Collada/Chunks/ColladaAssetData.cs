//
//  Asset.cs
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
using ColladaSharp.Collada.Elements.Asset;
using ColladaSharp.Common;
using System.Collections.Generic;
using ColladaSharp.Collada.Elements.Global;
using System.Xml.Linq;
using ColladaSharp.Collada.Elements;
using ColladaSharp.Common.Interfaces;

namespace ColladaSharp.Collada.Chunks
{
	/// <summary>
	/// This class represents a complete Asset section in a Collada document.
	/// All members are listed in the order that they must appear in the XML
	/// document.
	/// </summary>
	public class ColladaAssetData : IColladaSerializable
	{
		public AssetContributor Contributor = new AssetContributor();
		public AssetCoverage Coverage = new AssetCoverage();
		public DateTime Created = DateTime.UtcNow;
		public List<string> Keywords = new List<string>();
		public DateTime Modified = DateTime.UtcNow;
		public string Revision;
		public string Subject;
		public string Title;
		public AssetSceneUnit SceneUnit = new AssetSceneUnit();
		public Axis UpAxis = Axis.Y;
		public ColladaExtra Extra = new ColladaExtra();

		public XElement GetXML()
		{
			XElement Element = ColladaXElementFactory.CreateElement("asset");
			if (!Contributor.GetXML().IsEmpty)
			{
				Element.Add(Contributor.GetXML());
			}

			if (!Coverage.GetXML().IsEmpty)
			{
				Element.Add(Coverage.GetXML());
			}

			Element.Add(ColladaXElementFactory.CreateElement("created", Created.GetXMLTime()));

			if (Keywords.Count > 0)
			{
				XElement keywordsElement = ColladaXElementFactory.CreateElement("keywords");
				foreach (string keyword in Keywords)
				{
					if (!String.IsNullOrEmpty(keywordsElement.Value))
					{
						keywordsElement.Value += " " + keyword;
					}
					else
					{
						keywordsElement.Value = keyword;
					}
				}

				Element.Add(keywordsElement);
			}

			Element.Add(ColladaXElementFactory.CreateElement("modifed", Modified.GetXMLTime()));

			if (!String.IsNullOrEmpty(Revision))
			{
				Element.Add(ColladaXElementFactory.CreateElement("revision", Revision));
			}

			if (!String.IsNullOrEmpty(Subject))
			{
				Element.Add(ColladaXElementFactory.CreateElement("subject", Subject));
			}

			if (!String.IsNullOrEmpty(Title))
			{
				Element.Add(ColladaXElementFactory.CreateElement("title", Title));
			}
					
			Element.Add(SceneUnit.GetXML());

			Element.Add(ColladaXElementFactory.CreateElement("up_axis", UpAxis.ToFriendlyName()));

			if (!Extra.GetXML().IsEmpty)
			{
				Element.Add(Extra.GetXML());
			}

			return Element;
		}
	}
}

