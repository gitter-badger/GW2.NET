﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorModelConverter.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type  to objects of type .
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Colors.Converters
{
    using System;

    using GW2NET.Colors;
    using GW2NET.Common;
    using GW2NET.V2.Colors.Json;

    /// <summary>Converts objects of type <see cref="ColorModelDataContract"/> to objects of type <see cref="ColorModel"/>.</summary>
    public sealed class ColorModelConverter : IConverter<ColorModelDataContract, ColorModel>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<int[], Color> converterForColor;

        /// <summary>Initializes a new instance of the <see cref="ColorModelConverter"/> class.</summary>
        /// <param name="converterForColor">The converter for <see cref="Color"/>.</param>
        public ColorModelConverter(IConverter<int[], Color> converterForColor)
        {
            if (converterForColor == null)
            {
                throw new ArgumentNullException("converterForColor", "Precondition: converterForColor != null");
            }

            this.converterForColor = converterForColor;
        }

        /// <inheritdoc />
        public ColorModel Convert(ColorModelDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var colorModel = new ColorModel
            {
                Brightness = value.Brightness,
                Contrast = value.Contrast,
                Hue = value.Hue,
                Saturation = value.Saturation,
                Lightness = value.Lightness
            };
            var rgb = value.Rgb;
            if (rgb != null && rgb.Length == 3)
            {
                colorModel.Rgb = this.converterForColor.Convert(rgb, state);
            }

            return colorModel;
        }
    }
}