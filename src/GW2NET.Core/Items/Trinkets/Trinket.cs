﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trinket.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides the base class for trinket types.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Items
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using GW2NET.ChatLinks;

    /// <summary>Provides the base class for trinket types.</summary>
    public abstract class Trinket : Item, IUpgrade, IUpgradable
    {
        private InfixUpgrade infixUpgrade = new InfixUpgrade();

        /// <inheritdoc />
        public virtual InfixUpgrade InfixUpgrade
        {
            get
            {
                Debug.Assert(this.infixUpgrade != null, "this.infixUpgrade != null");
                return this.infixUpgrade;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Precondition: value != null");
                }

                this.infixUpgrade = value;
            }
        }

        /// <summary>Gets or sets the item's infusion slots.</summary>
        public virtual ICollection<InfusionSlot> InfusionSlots { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item. This is a navigation property. Use the value of <see cref="SecondarySuffixItemId"/> to obtain a reference.</summary>
        public virtual Item SecondarySuffixItem { get; set; }

        /// <summary>Gets or sets the item's secondary suffix item identifier.</summary>
        public virtual int? SecondarySuffixItemId { get; set; }

        /// <summary>Gets or sets the item's suffix item. This is a navigation property. Use the value of <see cref="SuffixItemId"/> to obtain a reference.</summary>
        public virtual Item SuffixItem { get; set; }

        /// <summary>Gets or sets the item's suffix item identifier.</summary>
        public virtual int? SuffixItemId { get; set; }

        /// <summary>Gets an item chat link for this item.</summary>
        /// <returns>The <see cref="ChatLink"/>.</returns>
        public override ChatLink GetItemChatLink()
        {
            return new ItemChatLink
            {
                ItemId = this.ItemId, 
                SuffixItemId = this.SuffixItemId, 
                SecondarySuffixItemId = this.SecondarySuffixItemId
            };
        }
    }
}