// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SkinFlagConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="string" /> to objects of type <see cref="SkinFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Skins
{
    using System;

    using GW2NET.Common;
    using GW2NET.Skins;

    /// <summary>Converts objects of type <see cref="string"/> to objects of type <see cref="SkinFlags"/>.</summary>
    internal sealed class SkinFlagConverter : IConverter<string, SkinFlags>
    {
        /// <inheritdoc />
        public SkinFlags Convert(string value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            SkinFlags result;
            return Enum.TryParse(value, true, out result) ? result : default(SkinFlags);
        }
    }
}