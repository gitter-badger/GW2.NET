﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttributeDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the AttributeDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace GW2NET.V1.Items.Json
{
    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:1/item_details")]
    internal sealed class AttributeDataContract
    {
        [DataMember(Name = "attribute", Order = 0)]
        internal string Attribute { get; set; }

        [DataMember(Name = "modifier", Order = 1)]
        internal string Modifier { get; set; }
    }
}