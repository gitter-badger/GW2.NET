﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForUpgradeRemoval.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="ConsumableDataContract" /> to objects of type <see cref="UpgradeRemoval" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Items.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Items;
    using GW2NET.V1.Items.Json;

    /// <summary>Converts objects of type <see cref="ConsumableDataContract"/> to objects of type <see cref="UpgradeRemoval"/>.</summary>
    internal sealed class ConverterForUpgradeRemoval : IConverter<ConsumableDataContract, UpgradeRemoval>
    {
        /// <inheritdoc />
        public UpgradeRemoval Convert(ConsumableDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            return new UpgradeRemoval();
        }
    }
}