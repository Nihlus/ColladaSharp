//
//  Extensions.cs
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

namespace ColladaSharp.Common
{
	public static class Extensions
	{
		public static string ToFriendlyName(this AltitudeMode Altitude)
		{
			switch (Altitude)
			{
				case AltitudeMode.Absolute:
					{
						return "absolute";
					}
				case AltitudeMode.RelativeToGround:
					{
						return "relativeToGround";
					}
				default:
					{
						return "absolute";
					}
			}
		}

		public static string ToFriendlyName(this Axis axis)
		{
			switch (axis)
			{
				case Axis.X:
					{
						return "X_UP";
					}
				case Axis.Y:
					{
						return "Y_UP";
					}
				case Axis.Z:
					{
						return "Z_UP";
					}
				default:
					{
						throw new NotImplementedException("Invalid axis value.");
					}
			}
		}

		public static string GetXMLTime(this DateTime Time)
		{
			return Time.ToString("O");
		}

		public static Version GetAssemblyVersion(this object ob)
		{
			return Assembly.GetAssembly(ob.GetType()).GetName().Version;
		}
	}
}

