﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForItemFlagCollection.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="T:ICollection{string}" /> to objects of type <see cref="ItemFlags" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Items
{
    using System;
    using System.Collections.Generic;

    using GW2NET.Common;
    using GW2NET.Items;

    /// <summary>Converts objects of type <see cref="T:ICollection{string}"/> to objects of type <see cref="ItemFlags"/>.</summary>
    internal sealed class ConverterForItemFlagCollection : IConverter<ICollection<string>, ItemFlags>
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<string, ItemFlags> converterForItemFlag;

        /// <summary>Initializes a new instance of the <see cref="ConverterForItemFlagCollection"/> class.</summary>
        internal ConverterForItemFlagCollection()
            : this(new ConverterForItemFlag())
        {
        }

        /// <summary>Initializes a new instance of the <see cref="ConverterForItemFlagCollection"/> class.</summary>
        /// <param name="converterForItemFlag">The converter for <see cref="ItemFlags"/>.</param>
        internal ConverterForItemFlagCollection(IConverter<string, ItemFlags> converterForItemFlag)
        {
            if (converterForItemFlag == null)
            {
                throw new ArgumentNullException("converterForItemFlag", "Precondition: converterForItemFlag != null");
}

            this.converterForItemFlag = converterForItemFlag;
        }

        /// <summary>Converts the given object of type <see cref="T:ICollection{string}"/> to an object of type <see cref="ItemFlags"/>.</summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="state"></param>
        /// <returns>The converted value.</returns>
        public ItemFlags Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var result = default(ItemFlags);
            foreach (var s in value)
            {
                result |= this.converterForItemFlag.Convert(s, state);
            }

            return result;
        }
    }
}