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

namespace ColladaSharp.Collada.Elements.DataFlow.Sources
{
	public class ColladaFloatSource : ColladaSource
	{
		public string Name
		{
			get;
			private set;
		}

		private List<float> Values = new List<float>();

		private readonly int Stride;
		private readonly List<string> ParameterNames;

		public ColladaFloatSource(string InSourceName, string InSourceIDName, int InStride, List<string> InParameterNames)
			: this(InSourceIDName, InStride, InParameterNames)
		{
			if (String.IsNullOrEmpty(InSourceName))
			{
				this.Name = InSourceName;
			}
			else
			{
				throw new ArgumentException("The input name must be a valid nonzero-length string.");
			}
		}

		public ColladaFloatSource(string InSourceIDName, int InStride, List<string> InParameterNames)
		{
			if (String.IsNullOrEmpty(InSourceIDName))
			{
				this.SourceIDName = InSourceIDName;
			}
			else
			{
				throw new ArgumentException("The input sub ID must be a valid nonzero-length string.");
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

		public override XElement GetXML(string ParentName)
		{
			XElement Element = ColladaXElementFactory.CreateElement("source");

			string sourceElementID;
			if (!String.IsNullOrEmpty(Name))
			{
				sourceElementID = String.Format("{0}-{1}", ParentName, SourceIDName);
			}
			else
			{
				sourceElementID = String.Format("{0}-{1}-{2}", ParentName, SourceIDName, Name);
				Element.SetAttributeValue("name", Name);
			}

			Element.SetAttributeValue("id", sourceElementID);

			Element.Add(CreateArrayElement(ParentName));
			Element.Add(CreateAccessorTechniqueElement(ParentName));

			return Element;
		}

		private XElement CreateArrayElement(string ParentName)
		{
			XElement ArrayElement = ColladaXElementFactory.CreateElement("float_array");

			string arrayElementID;
			if (!String.IsNullOrEmpty(Name))
			{
				arrayElementID = String.Format("{0}-{1}-array", ParentName, SourceIDName);
			}
			else
			{
				arrayElementID = String.Format("{0}-{1}-{2}-array", ParentName, SourceIDName, Name);
			}

			ArrayElement.SetAttributeValue("id", arrayElementID);
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

		private XElement CreateAccessorTechniqueElement(string ParentName)
		{
			XElement TechniqueElement = ColladaXElementFactory.CreateElement("technique_common");

			string accessorSourceID;
			if (!String.IsNullOrEmpty(Name))
			{
				accessorSourceID = String.Format("#{0}-{1}-array", ParentName, SourceIDName);
			}
			else
			{
				accessorSourceID = String.Format("#{0}-{1}-{2}-array", ParentName, SourceIDName, Name);
			}

			ColladaAccessor SourceAccessor = new ColladaAccessor(accessorSourceID, Values.Count / Stride, Stride, ParameterNames, "float");
			TechniqueElement.Add(SourceAccessor.GetXML());

			return TechniqueElement;
		}
	}
}

