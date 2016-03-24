//
//  Enums.cs
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
	public enum Axis : byte
	{
		X,
		Y,
		Z
	}

	public enum SceneUnits : byte
	{
		Metric,
		Imperial,
		Arbitrary
	}

	public enum AltitudeMode : byte
	{
		Absolute,
		RelativeToGround
	}

	public enum LibraryType : byte
	{
		AnimationClips,
		Animations,
		ArticulatedSystems,
		Cameras,
		Controllers,
		Effects,
		ForceFields,
		Formulas,
		Geometries,
		Images,
		Joints,
		KinematicsModels,
		KinematicsScenes,
		Lights,
		Materials,
		Nodes,
		PhysicsMaterials,
		PhysicsModels,
		PhysicsScenes,
		VisualScenes
	}
}

