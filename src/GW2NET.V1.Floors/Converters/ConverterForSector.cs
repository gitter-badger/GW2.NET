﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForSector.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="SectorDataContract" /> to objects of type <see cref="Sector" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Common.Drawing;
using GW2NET.Maps;
using GW2NET.V1.Floors.Json;

namespace GW2NET.V1.Floors.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="SectorDataContract"/> to objects of type <see cref="Sector"/>.</summary>
    internal sealed class ConverterForSector : IConverter<SectorDataContract, Sector>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<double[], Vector2D> converterForVector2D;

        /// <summary>Initializes a new instance of the <see cref="ConverterForSector"/> class.</summary>
        public ConverterForSector()
            : this(new ConverterForVector2D())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForSector"/> class.</summary>
        /// <param name="converterForVector2D">The converter for <see cref="Vector2D"/>.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="converterForVector2D"/> is a null reference.</exception>
        public ConverterForSector(IConverter<double[], Vector2D> converterForVector2D)
        {
            if (converterForVector2D == null)
            {
                throw new ArgumentNullException("converterForVector2D", "Precondition: converterForVector2D != null");
            }

            this.converterForVector2D = converterForVector2D;
        }

        /// <inheritdoc />
        public Sector Convert(SectorDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var sector = new Sector
            {
                SectorId = value.SectorId, 
                Name = value.Name, 
                Level = value.Level, 
            };
            var coordinates = value.Coordinates;
            if (coordinates != null && coordinates.Length == 2)
            {
                sector.Coordinates = this.converterForVector2D.Convert(coordinates, state);
            }

            return sector;
        }
    }
}