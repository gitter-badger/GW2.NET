﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataContractXmlSerializerFactory.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides factory methods for the XML data contract serialization engine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.Common.Serializers
{
    using System.Runtime.Serialization;

    /// <summary>Provides factory methods for the XML data contract serialization engine.</summary>
    public class DataContractXmlSerializerFactory : ISerializerFactory
    {
        /// <summary>Gets a serializer for the specified type.</summary>
        /// <typeparam name="T">The serialization type.</typeparam>
        /// <returns>The <see cref="ISerializer{T}"/>.</returns>
        public ISerializer<T> GetSerializer<T>()
        {
            return new DataContractSerializer<T>(new DataContractSerializer(typeof(T)));
        }
    }
}