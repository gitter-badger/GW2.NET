﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemRarity.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="ItemRarity" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="ItemRarity"/>.</summary>
    internal sealed class ConverterForItemRarity : IConverter<string, ItemRarity>
    {
        /// <summary>Converts the given object of type <see cref="string"/> to an object of type <see cref="ItemRarity"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public ItemRarity Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            ItemRarity result;
            if (Enum.TryParse(value, true, out result))
            {
                return result;
            }

            return default(ItemRarity);
        }
    }
}