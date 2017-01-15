//
//  ColladaFloatSource.cs
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
using System.Xml.Linq;
using ColladaSharp.Collada.Elements.Global;

namespace ColladaSharp.Collada.Elements.DataFlow.Sources
{
	public class ColladaFloatSource : ColladaSource
	{
		public string ParentName
		{
			get;
			private set;
		}

		public string SourceTypeName
		{
			get;
			private set;
		}

		public string SourceName
		{
			get;
			private set;
		}

		private List<float> Values = new List<float>();

		private readonly int Stride;
		private readonly List<string> ParameterNames;

		public ColladaFloatSource(string InParentName, string InSourceTypeName, string InSourceName, int InStride, List<string> InParameterNames)
		{
			if (!String.IsNullOrEmpty(InParentName))
			{
				this.ParentName = InParentName;
			}
			else
			{
				throw new ArgumentException("The input name must be a valid nonzero-length string.");
			}

			if (!String.IsNullOrEmpty(InSourceTypeName))
			{
				this.SourceTypeName = InSourceTypeName;
			}
			else
			{
				throw new ArgumentException("The input sub ID must be a valid nonzero-length string.");
			}

			if (!String.IsNullOrEmpty(InSourceName))
			{
				this.SourceName = InSourceName;
			}

			if (InStride > 0)
			{
				if (InStride == InParameterNames.Count)
				{
					this.Stride = InStride;
					this.ParameterNames = InParameterNames;
				}
				else
				{
					throw new ArgumentException("The stride length and the parameter name list must have the same length.");
				}
			}
			else
			{
				throw new ArgumentException("The stride must be at least 1.");
			}
		}

		public List<float> GetElementAt(int Index)
		{			
			if (Index <= ((Values.Count / Stride) - 1))
			{
				return Values.GetRange(Index, Stride);
			}
			else
			{
				throw new IndexOutOfRangeException("The index was out of range. Index must be aligned to the stride of the elements in the source.");
			}
		}

		public void AddElement(List<float> InValue)
		{
			if (InValue.Count == Stride)
			{
				this.Values.AddRange(InValue);
			}
			else
			{
				throw new ArgumentException("The collection of input values must have the same length as the stride.");
			}
		}

		public void AddRange(List<List<float>> InValues)
		{
			foreach (List<float> Value in InValues)
			{
				AddElement(Value);
			}
		}

		public void RemoveElementAt(int Index)
		{
			if (Index <= ((Values.Count / Stride) - 1))
			{
				Values.RemoveRange(Index, Stride);
			}
			else
			{
				throw new IndexOutOfRangeException("The index was out of range. Index must be aligned to the stride of the elements in the source.");
			}
		}

		public void RemoveElementsInRange(int Index, int Count)
		{
			for (int i = 0; i < Count; ++i)
			{
				RemoveElementAt(Index);
			}
		}

		public override XElement GetXML()
		{
			XElement Element = ColladaXElementFactory.CreateElement("source");

			Element.SetAttributeValue("id", GetElementID());

			Element.Add(CreateArrayElement());
			Element.Add(CreateAccessorTechniqueElement());

			return Element;
		}

		public string GetElementID()
		{
			string sourceElementID;
			if (!String.IsNullOrEmpty(SourceName))
			{
				sourceElementID = String.Format("{0}-{1}-{2}", ParentName, SourceTypeName, SourceName);
			}
			else
			{
				sourceElementID = String.Format("{0}-{1}", ParentName, SourceTypeName);
			}

			return sourceElementID;
		}

		private XElement CreateArrayElement()
		{
			XElement ArrayElement = ColladaXElementFactory.CreateElement("float_array");


			ArrayElement.SetAttributeValue("id", GetElementID());
			ArrayElement.SetAttributeValue("count", Values.Count);

			// Add all of the elements in the array
			foreach (float Value in Values)
			{
				if (!String.IsNullOrEmpty(ArrayElement.Value))
				{
					ArrayElement.Value += " " + Value;
				}
				else
				{
					ArrayElement.Value = Value.ToString();
				}
			}

			return ArrayElement;
		}

		private XElement CreateAccessorTechniqueElement()
		{
			ColladaTechnique Technique = ColladaTechnique.GetCommonTechnique();

			string accessorSourceID = String.Format("#{0}-array", GetElementID());


			ColladaAccessor SourceAccessor = new ColladaAccessor(accessorSourceID, Values.Count / Stride, Stride);
			foreach (string parameterName in ParameterNames)
			{
				SourceAccessor.AddParameter(parameterName, "float");
			}

			Technique.SetAccessor(SourceAccessor);
			return Technique.GetXML();
		}
	}
}

