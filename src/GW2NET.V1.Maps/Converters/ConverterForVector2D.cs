﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForVector2D.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:double[]" /> to objects of type <see cref="Vector2D" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V1.Maps.Converters
{
    using System;

    using GW2NET.Common;
    using GW2NET.Common.Drawing;

    /// <summary>Converts objects of type <see cref="T:double[]"/> to objects of type <see cref="Vector2D"/>.</summary>
    internal sealed class ConverterForVector2D : IConverter<double[], Vector2D>
    {
        /// <inheritdoc />
        public Vector2D Convert(double[] value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            if (value.Length != 2)
            {
                throw new ArgumentException("Precondition value.Length == 2", "value");
            }

            return new Vector2D(value[0], value[1]);
        }
    }
}