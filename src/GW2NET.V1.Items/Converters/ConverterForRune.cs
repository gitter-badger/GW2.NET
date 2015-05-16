// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForRune.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="UpgradeComponentDataContract" /> to objects of type <see cref="Rune" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.Contracts;
using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    /// <summary>Converts objects of type <see cref="UpgradeComponentDataContract"/> to objects of type <see cref="Rune"/>.</summary>
    internal sealed class ConverterForRune : IConverter<UpgradeComponentDataContract, Rune>
    {
        /// <summary>Converts the given object of type <see cref="UpgradeComponentDataContract"/> to an object of type <see cref="Rune"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public Rune Convert(UpgradeComponentDataContract value)
        {
            Contract.Assume(value != null);
            return new Rune();
        }
    }
}