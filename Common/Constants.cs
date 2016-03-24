//
//  Constants.cs
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

namespace ColladaSharp.Common
{
	/// <summary>
	/// Container class for library-wide constants, such as file suffixes or XML
	/// element, attribute or schema names.
	/// </summary>
	public static class Constants
	{
		/*
			File and IO constants.
		*/

		/// <summary>
		/// File suffix for Collada Document Archives.
		/// </summary>
		public const string COLLADA_DOCUMENT_ARCHIVE_SUFFIX = "zae";

		/// <summary>
		/// File suffix for Collada Documents.
		/// </summary>
		public const string COLLADA_DOCUMENT_SUFFIX = "dae";
	}
}

