﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColorRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v1/colors.json interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V1.Colors
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Entities.Colors;
    using GW2NET.V1.Colors.Json;
    using GW2NET.V1.Colors.Json.Converters;

    /// <summary>Represents a repository that retrieves data from the /v1/colors.json interface.</summary>
    public class ColorRepository : IRepository<int, ColorPalette>, ILocalizable
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<ColorCollectionDataContract, ICollection<ColorPalette>> converterForColorPaletteCollection;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="ColorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public ColorRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterForColorPaletteCollection())
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Initializes a new instance of the <see cref="ColorRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForColorPaletteCollection">The converter for <see cref="ICollection{ColorPalette}"/>.</param>
        internal ColorRepository(IServiceClient serviceClient, IConverter<ColorCollectionDataContract, ICollection<ColorPalette>> converterForColorPaletteCollection)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForColorPaletteCollection != null);
            Contract.Ensures(this.serviceClient != null);
            Contract.Ensures(this.converterForColorPaletteCollection != null);
            this.serviceClient = serviceClient;
            this.converterForColorPaletteCollection = converterForColorPaletteCollection;
        }

        /// <summary>Gets or sets the locale.</summary>
        public CultureInfo Culture { get; set; }

        /// <inheritdoc />
        ICollection<int> IDiscoverable<int>.Discover()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync()
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollection<int>> IDiscoverable<int>.DiscoverAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ColorPalette IRepository<int, ColorPalette>.Find(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        IDictionaryRange<int, ColorPalette> IRepository<int, ColorPalette>.FindAll()
        {
            var request = new ColorRequest { Culture = this.Culture };
            var response = this.serviceClient.Send<ColorCollectionDataContract>(request);
            if (response.Content == null || response.Content.Colors == null)
            {
                return new DictionaryRange<int, ColorPalette>(0);
            }

            var values = this.converterForColorPaletteCollection.Convert(response.Content);
            var colorPalettes = new DictionaryRange<int, ColorPalette>(values.Count) { SubtotalCount = values.Count, TotalCount = values.Count };

            foreach (var colorPalette in values)
            {
                colorPalette.Culture = request.Culture;
                colorPalettes.Add(colorPalette.ColorId, colorPalette);
            }

            return colorPalettes;
        }

        /// <inheritdoc />
        IDictionaryRange<int, ColorPalette> IRepository<int, ColorPalette>.FindAll(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync()
        {
            return ((IRepository<int, ColorPalette>)this).FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new ColorRequest { Culture = this.Culture };
            return this.serviceClient.SendAsync<ColorCollectionDataContract>(request, cancellationToken).ContinueWith<IDictionaryRange<int, ColorPalette>>(task =>
            {
                var response = task.Result;
                if (response.Content == null || response.Content.Colors == null)
                {
                    return new DictionaryRange<int, ColorPalette>(0);
                }

                var values = this.converterForColorPaletteCollection.Convert(response.Content);
                var colorPalettes = new DictionaryRange<int, ColorPalette>(values.Count) { SubtotalCount = values.Count, TotalCount = values.Count };

                foreach (var colorPalette in values)
                {
                    colorPalette.Culture = request.Culture;
                    colorPalettes.Add(colorPalette.ColorId, colorPalette);
                }

                return colorPalettes;
            }, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync(ICollection<int> identifiers)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<IDictionaryRange<int, ColorPalette>> IRepository<int, ColorPalette>.FindAllAsync(ICollection<int> identifiers, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ColorPalette> IRepository<int, ColorPalette>.FindAsync(int identifier)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ColorPalette> IRepository<int, ColorPalette>.FindAsync(int identifier, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<ColorPalette> IPaginator<ColorPalette>.FindPage(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        ICollectionPage<ColorPalette> IPaginator<ColorPalette>.FindPage(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex, int pageSize)
        {
            throw new NotSupportedException();
        }

        /// <inheritdoc />
        Task<ICollectionPage<ColorPalette>> IPaginator<ColorPalette>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>The invariant method for this class.</summary>
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForColorPaletteCollection != null);
        }
    }
}