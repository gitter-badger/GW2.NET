﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bloodlust.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The Bloodlust bonus.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2DotNET.V1.WorldVersusWorld.Matches.Contracts.Maps.Bonuses
{
    using GW2DotNET.Common;

    /// <summary>The Bloodlust bonus.</summary>
    [TypeDiscriminator(Value = "bloodlust", BaseType = typeof(MapBonus))]
    public class Bloodlust : MapBonus
    {
    }
}