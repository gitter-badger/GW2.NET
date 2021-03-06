// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorModelDataContract.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Defines the ColorModelDataContract type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.V2.Colors.Json
{
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;

    [DataContract]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "http://wiki.guildwars2.com/wiki/API:2/colors")]
    public sealed class ColorModelDataContract
    {
        [DataMember(Name = "brightness", Order = 0)]
        public int Brightness { get; set; }

        [DataMember(Name = "contrast", Order = 1)]
        public double Contrast { get; set; }

        [DataMember(Name = "hue", Order = 2)]
        public int Hue { get; set; }

        [DataMember(Name = "saturation", Order = 3)]
        public double Saturation { get; set; }

        [DataMember(Name = "lightness", Order = 4)]
        public double Lightness { get; set; }

        [DataMember(Name = "rgb", Order = 5)]
        public int[] Rgb { get; set; }
    }
}