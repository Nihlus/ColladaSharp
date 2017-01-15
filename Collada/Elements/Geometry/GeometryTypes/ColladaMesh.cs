//
//  ColladaMesh.cs
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
using ColladaSharp.Collada.Elements.Global;
using System.Collections.Generic;
using ColladaSharp.Collada.Elements.DataFlow;
using ColladaSharp.Common.Model;
using ColladaSharp.Collada.Elements.DataFlow.Sources;
using ColladaSharp.Common.Interfaces;
using System.Xml.Linq;

namespace ColladaSharp.Collada.Elements.Geometry.GeometryTypes
{
	public class ColladaMesh : ColladaGeometryType, IColladaSerializable
	{
		public string ID
		{
			get
			{
				return GetMeshID();
			}
		}

		public string Name
		{
			get;
			set;
		}

		// Source (at least 1)
		// Primitives (0 or more)

		public readonly ColladaExtra ExtraData = new ColladaExtra();
		private readonly ColladaFloatSource VertexPositions;
		private readonly ColladaFloatSource FaceNormals;
		private readonly ColladaFloatSource VertexColours;
		//private readonly ColladaFloatSource VertexTextureCoordinates = new ColladaFloatSource(2, new List<string>{"U", "V"};

		public ColladaMesh(string Name)
		{
			this.Name = Name;

			this.VertexPositions = new ColladaFloatSource(GetMeshID(), "positions", "", 3, new List<string>{ "X", "Y", "Z" });
			this.FaceNormals = new ColladaFloatSource(GetMeshID(), "normals", "", 3, new List<string>{ "X", "Y", "Z" });
			this.VertexColours = new ColladaFloatSource(GetMeshID(), "colors", "Col", 3, new List<string>{ "R", "G", "B" });
		}

		public string GetMeshID()
		{
			return String.Format("{0}-mesh", Name);
		}

		public void AddVertex(Vertex InVertex)
		{
			VertexPositions.AddElement(InVertex.ToList());
		}

		public void AddVertices(List<Vertex> InVertices)
		{
			foreach (Vertex vertex in InVertices)
			{
				VertexPositions.AddElement(vertex.ToList());
			}
		}

		public void RemoveVertex(int InIndex)
		{
			VertexPositions.RemoveElementAt(InIndex);
		}

		public void RemoveVertices(List<int> InIndices)
		{
			foreach (int Index in InIndices)
			{
				VertexPositions.RemoveElementAt(Index);
			}
		}

		public void AddNormal(Normal InNormal)
		{

		}

		public void AddNormals(List<Normal> InNormals)
		{

		}

		public void AddLines()
		{

		}

		public void AddLinestrips()
		{

		}

		public void AddPolygons(List<Polygon> Polygons)
		{

		}

		public void AddPolyList()
		{

		}

		public void AddTriangles()
		{

		}

		public void AddTriangleFans()
		{

		}

		public void AddTriangleStrips()
		{

		}

		public XElement GetXML()
		{
			XElement GeometryElement = ColladaXElementFactory.CreateElement("geometry");
			XElement MeshElement = ColladaXElementFactory.CreateElement("mesh");

			GeometryElement.Add(MeshElement);

			MeshElement.Add(VertexPositions.GetXML());
			MeshElement.Add(FaceNormals.GetXML());
			MeshElement.Add(VertexColours.GetXML());

			XElement VertexSourceElement = ColladaXElementFactory.CreateElement("vertices");
			VertexSourceElement.SetAttributeValue("id", GetMeshID() + "-vertices");
			XElement VertexSourceInputElement = ColladaXElementFactory.CreateElement("input");
			VertexSourceInputElement.SetAttributeValue("semantic", "POSITION");
			VertexSourceInputElement.SetAttributeValue("source", "#" + VertexPositions.GetElementID());
			MeshElement.Add(VertexSourceElement);

			return GeometryElement;
		}
	}
}

