﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConverterForCombatBuff.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Converts objects of type <see cref="CombatBuffDataContract" /> to objects of type <see cref="CombatBuff" />.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GW2NET.Common;
using GW2NET.Items;
using GW2NET.V1.Items.Json;

namespace GW2NET.V1.Items.Converters
{
    using System;

    /// <summary>Converts objects of type <see cref="CombatBuffDataContract"/> to objects of type <see cref="CombatBuff"/>.</summary>
    internal sealed class ConverterForCombatBuff : IConverter<CombatBuffDataContract, CombatBuff>
    {
        /// <inheritdoc />
        public CombatBuff Convert(CombatBuffDataContract value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value", "Precondition: value != null");
            }

            var itemBuff = new CombatBuff
            {
                Description = value.Description
            };

            int skillId;
            if (int.TryParse(value.SkillId, out skillId))
            {
                itemBuff.SkillId = skillId;
            }

            return itemBuff;
        }
    }
}