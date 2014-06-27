﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectiveCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a collection of objectives and their localized name.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.WorldVersusWorld.Objectives.Contracts
{
    using System.Collections.Generic;

    using GW2DotNET.Common.Contracts;

    /// <summary>Represents a collection of objectives and their localized name.</summary>
    public class ObjectiveCollection : ServiceContractList<Objective>
    {
        /// <summary>Initializes a new instance of the <see cref="ObjectiveCollection" /> class.</summary>
        public ObjectiveCollection()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ObjectiveCollection"/> class.</summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public ObjectiveCollection(int capacity)
            : base(capacity)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ObjectiveCollection"/> class.</summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public ObjectiveCollection(IEnumerable<Objective> collection)
            : base(collection)
        {
        }
    }
}