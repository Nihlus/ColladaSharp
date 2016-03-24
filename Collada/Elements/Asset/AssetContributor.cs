﻿//
//  Contributor.cs
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
using System.Reflection;
using ColladaSharp.Common;

namespace ColladaSharp.Collada.Elements.Asset
{
	public sealed class AssetContributor
	{
		public string Author;
		public string AuthorEmail;
		public string AuthorWebsite;
		public string AuthoringTool;
		public string Comments;
		public string Copyright;
		public string SourceData;

		public AssetContributor()
		{
			AuthorWebsite = "";
			AuthoringTool = "ColladaSharp v" + this.GetAssemblyVersion();
			Comments = "Created by ColladaSharp";
		}

		public XElement GetXML()
		{
			XElement Element = new XElement("contributor");

			if (!String.IsNullOrEmpty(Author))
			{
				Element.Add(new XElement("author", Author));
			}

			if (!String.IsNullOrEmpty(AuthorEmail))
			{
				Element.Add(new XElement("author_email", AuthorEmail));
			}

			if (!String.IsNullOrEmpty(AuthorWebsite))
			{
				Element.Add(new XElement("author_website", AuthorWebsite));
			}

			if (!String.IsNullOrEmpty(AuthoringTool))
			{
				Element.Add(new XElement("authoring_tool", AuthoringTool));
			}

			if (!String.IsNullOrEmpty(Comments))
			{
				Element.Add(new XElement("comments", Comments));
			}

			if (!String.IsNullOrEmpty(Copyright))
			{
				Element.Add(new XElement("copyright", Copyright));
			}

			if (!String.IsNullOrEmpty(SourceData))
			{
				Element.Add(new XElement("source_data", SourceData));
			}

			return Element;
		}
	}
}

