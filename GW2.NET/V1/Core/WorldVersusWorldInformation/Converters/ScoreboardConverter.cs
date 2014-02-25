﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScoreboardConverter.cs" company="GW2.Net Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using GW2DotNET.V1.Core.WorldVersusWorldInformation.Details;
using Newtonsoft.Json;

namespace GW2DotNET.V1.Core.WorldVersusWorldInformation.Converters
{
    /// <summary>
    /// Converts a JSON array of scores to and from a <see cref="Scoreboard"/>.
    /// </summary>
    public class ScoreboardConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>Returns <c>true</c> if this instance can convert the specified object type; otherwise <c>false</c>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(Scoreboard).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var scores = serializer.Deserialize<int[]>(reader);

            return new Scoreboard() { Red = scores[0], Blue = scores[1], Green = scores[2] };
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var scores = (Scoreboard)value;

            writer.WriteStartArray();

            {
                serializer.Serialize(writer, scores.Red);

                serializer.Serialize(writer, scores.Blue);

                serializer.Serialize(writer, scores.Green);
            }

            writer.WriteEndArray();
        }
    }
}