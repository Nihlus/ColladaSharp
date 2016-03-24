//
//  AssetCoverage.cs
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
using ColladaSharp.Common;

namespace ColladaSharp.Collada.Elements.Asset
{
	public class AssetCoverage
	{
		public List<AssetGeographicLocation> GeographicLocations = new List<AssetGeographicLocation>();

		public AssetCoverage()
		{
		}

		public XElement GetXML()
		{
			XElement Element = ColladaXElementFactory.CreateElement("coverage");

			foreach (AssetGeographicLocation Location in GeographicLocations)
			{
				Element.Add(Location.GetXML());
			}

			return Element;
		}
	}

	public class AssetGeographicLocation
	{
		public float Longitude;
		public float Latitude;
		public float Altitude;
		public AltitudeMode Mode = AltitudeMode.RelativeToGround;

		public AssetGeographicLocation(float InLongitude, float InLatitude, float InAltitude, AltitudeMode InMode = AltitudeMode.RelativeToGround)
		{
			this.Longitude = InLongitude;
			this.Latitude = InLatitude;
			this.Altitude = InAltitude;
			this.Mode = InMode;
		}

		public XElement GetXML()
		{
			XElement Element = ColladaXElementFactory.CreateElement("geographic_location");
			Element.Add(ColladaXElementFactory.CreateElement("longitude", Longitude));
			Element.Add(ColladaXElementFactory.CreateElement("latitude", Latitude));

			XElement AltitudeElement = ColladaXElementFactory.CreateElement("altitude", Altitude);
			AltitudeElement.SetAttributeValue("mode", Mode.ToFriendlyName());

			Element.Add(AltitudeElement);

			return Element;
		}
	}
}

