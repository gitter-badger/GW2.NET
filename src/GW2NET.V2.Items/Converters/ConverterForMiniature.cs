﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForMiniature.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="DetailsDataContract" /> to objects of type <see cref="Miniature" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="DetailsDataContract"/> to objects of type <see cref="Miniature"/>.</summary>
    internal sealed class ConverterForMiniature : IConverter<DetailsDataContract, Miniature>
    {
        /// <summary>Converts the given object of type <see cref="DetailsDataContract"/> to an object of type <see cref="Miniature"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public Miniature Convert(DetailsDataContract value, object state)
        {
            // MEMO: value is always null here because miniatures never have details
            return new Miniature();
        }
    }
}