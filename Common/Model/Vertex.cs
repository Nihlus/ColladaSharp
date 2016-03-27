//
//  Vertex.cs
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
using System.Collections.Generic;

namespace ColladaSharp.Common.Model
{
	public class Vertex
	{
		public float X
		{
			get;
			set;
		}

		public float Y
		{
			get;
			set;
		}

		public float Z
		{
			get;
			set;
		}

		public Vertex()
		{
		}

		public Vertex(float XYZ)
			: this(XYZ, XYZ, XYZ)
		{

		}

		public Vertex(float X, float Y, float Z)
		{
			this.X = X;
			this.Y = Y;
			this.Z = Z;
		}

		public Vertex(List<float> Values)
		{
			if (Values.Count == 3)
			{
				this.X = Values[0];
				this.Y = Values[1];
				this.Z = Values[2];
			}
			else
			{
				throw new ArgumentException("The input values must contain exactly 3 elements.");
			}
		}
	}
}

