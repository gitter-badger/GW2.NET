﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CraftingRecipeUnlocker.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.Items.Details.Contracts.Consumables
{
    using System.Runtime.Serialization;

    using GW2DotNET.Common;

    /// <summary>Represents a crafting recipe.</summary>
    [TypeDiscriminator(Value = "CraftingRecipe", BaseType = typeof(Unlocker))]
    public class CraftingRecipeUnlocker : Unlocker
    {
        /// <summary>Gets or sets the crafting recipe's ID.</summary>
        [DataMember(Name = "recipe_id"0000)]
        public virtual int RecipeId { get; set; }
    }
}