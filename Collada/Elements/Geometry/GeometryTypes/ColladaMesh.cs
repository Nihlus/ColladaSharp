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

namespace ColladaSharp.Collada.Elements.Geometry.GeometryTypes
{
	public class ColladaMesh : ColladaGeometryType
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
		// Vertices (1)
		// Primitives (0 or more)

		public readonly ColladaExtra ExtraData = new ColladaExtra();
		private readonly ColladaFloatSource VertexPositions = new ColladaFloatSource("positions", 3, new List<string>{ "X", "Y", "Z" });
		private readonly ColladaFloatSource FaceNormals = new ColladaFloatSource("normals", 3, new List<string>{ "X", "Y", "Z" });
		private readonly ColladaFloatSource VertexColours = new ColladaFloatSource("colors", "Col", 3, new List<string>{ "R", "G", "B" });
		//private readonly ColladaFloatSource VertexTextureCoordinates = new ColladaFloatSource(2, new List<string>{"U", "V"};

		public ColladaMesh(string Name)
		{
			this.Name = Name;
		}

		public string GetMeshID()
		{
			return String.Format("{0}-mesh", Name);
		}

		public void AddVertex(Vertex InVertex)
		{

		}

		public void AddVertices(List<Vertex> InVertices)
		{
			
		}

		public void RemoveVertex(int InIndex)
		{

		}

		public void RemoveVertices(List<int> InIndices)
		{

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
	}
}

