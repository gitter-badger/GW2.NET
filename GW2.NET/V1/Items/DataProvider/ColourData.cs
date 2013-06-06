﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColourData.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   The colour data provider.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Linq;

using GW2DotNET.V1.Infrastructure;
using GW2DotNET.V1.Items.Models;

namespace GW2DotNET.V1.Items.DataProvider
{
    /// <summary>
    /// The colour data provider.
    /// </summary>
    public class ColourData : IEnumerable<GwColour>
    {
        /// <summary>
        /// The language.
        /// </summary>
        private readonly Language language;

        /// <summary>
        /// The colours cache.
        /// </summary>
        private IEnumerable<GwColour> coloursCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColourData"/> class.
        /// </summary>
        /// <param name="language">The language the content is retrieved in.</param>
        internal ColourData(Language language)
        {
            this.language = language;
        }

        /// <summary>
        /// Gets the colours.
        /// </summary>
        private IEnumerable<GwColour> Colours
        {
            get
            {
                return this.coloursCache ?? (this.coloursCache = this.GetColours());
            }
        }

        /// <summary>
        /// Gets a single colour from the colours cache.
        /// </summary>
        /// <param name="id">
        /// The id of the colour.
        /// </param>
        /// <returns>
        /// The <see cref="GwColour"/>.
        /// </returns>
        public GwColour this[int id]
        {
            get
            {
                return this.Colours.Single(colour => colour.Id == id);
            }
        }

        /// <summary>
        ///  Gets a single colour from the colours cache.
        /// </summary>
        /// <param name="name">
        /// The name of the colour.
        /// </param>
        /// <returns>
        /// The <see cref="GwColour"/>.
        /// </returns>
        public GwColour this[string name]
        {
            get
            {
                return this.Colours.Single(colour => colour.Id == id);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<GwColour> GetEnumerator()
        {
            return this.Colours.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Colours.GetEnumerator();
        }

        /// <summary>
        /// Gets all colours from the api server.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        private IEnumerable<GwColour> GetColours()
        {
            var arguments = new List<KeyValuePair<string, object>>
            {
                new KeyValuePair<string, object>("lang", this.language)
            };

            var returnColours = ApiCall.GetContent<Dictionary<string, Dictionary<int, GwColour>>>(
                "colors.json", arguments, ApiCall.Categories.Miscellaneous)["colors"].Select(returnColour => new GwColour(returnColour.Key, returnColour.Value.Name, returnColour.Value.BaseRgb, returnColour.Value.Cloth, returnColour.Value.Leather, returnColour.Value.Metal)).ToList();

            return returnColours;
        }
    }
}