﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SeasoningRecipe.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents detailed information about a seasoning crafting recipe.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2DotNET.V1.RecipesDetails.Types.RecipeTypes
{
    using GW2DotNET.V1.Common.Converters;

    using Newtonsoft.Json;

    /// <summary>Represents detailed information about a seasoning crafting recipe.</summary>
    [JsonConverter(typeof(DefaultJsonConverter))]
    public class SeasoningRecipe : Recipe
    {
        /// <summary>Initializes a new instance of the <see cref="SeasoningRecipe" /> class.</summary>
        public SeasoningRecipe()
            : base(RecipeType.Seasoning)
        {
        }
    }
}