﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuagganRepository.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Represents a repository that retrieves data from the /v2/quaggans interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace GW2NET.V2.Quaggans
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using GW2NET.Common;
    using GW2NET.Common.Converters;
    using GW2NET.Quaggans;
    using GW2NET.V2.Common;

    /// <summary>Represents a repository that retrieves data from the /v2/quaggans interface.</summary>
    public class QuagganRepository : IQuagganRepository
    {
        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<QuagganDataContract>>, IDictionaryRange<string, Quaggan>> converterForBulkResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<string>>, ICollection<string>> converterForIdentifiersResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<ICollection<QuagganDataContract>>, ICollectionPage<Quaggan>> converterForPageResponse;

        /// <summary>Infrastructure. Holds a reference to a type converter.</summary>
        private readonly IConverter<IResponse<QuagganDataContract>, Quaggan> converterForResponse;

        /// <summary>Infrastructure. Holds a reference to the service client.</summary>
        private readonly IServiceClient serviceClient;

        /// <summary>Initializes a new instance of the <see cref="QuagganRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        public QuagganRepository(IServiceClient serviceClient)
            : this(serviceClient, new ConverterAdapter<ICollection<string>>(), new ConverterForQuaggan())
        {
            Contract.Requires(serviceClient != null);
        }

        /// <summary>Initializes a new instance of the <see cref="QuagganRepository"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <param name="converterForIdentifiers">The converter for <see cref="T:ICollection{string}"/>.</param>
        /// <param name="converterForQuaggan">The converter for <see cref="Quaggan"/>.</param>
        internal QuagganRepository(IServiceClient serviceClient, IConverter<ICollection<string>, ICollection<string>> converterForIdentifiers, IConverter<QuagganDataContract, Quaggan> converterForQuaggan)
        {
            Contract.Requires(serviceClient != null);
            Contract.Requires(converterForIdentifiers != null);
            Contract.Requires(converterForQuaggan != null);
            this.serviceClient = serviceClient;
            this.converterForIdentifiersResponse = new ConverterForResponse<ICollection<string>, ICollection<string>>(converterForIdentifiers);
            this.converterForResponse = new ConverterForResponse<QuagganDataContract, Quaggan>(converterForQuaggan);
            this.converterForBulkResponse = new ConverterForDictionaryRangeResponse<QuagganDataContract, string, Quaggan>(converterForQuaggan, quaggan => quaggan.Id);
            this.converterForPageResponse = new ConverterForCollectionPageResponse<QuagganDataContract, Quaggan>(converterForQuaggan);
        }

        /// <inheritdoc />
        ICollection<string> IDiscoverable<string>.Discover()
        {
            var request = new QuagganDiscoveryRequest();
            var response = this.serviceClient.Send<ICollection<string>>(request);
            return this.converterForIdentifiersResponse.Convert(response) ?? new List<string>(0);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync()
        {
            IQuagganRepository self = this;
            return self.DiscoverAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollection<string>> IDiscoverable<string>.DiscoverAsync(CancellationToken cancellationToken)
        {
            var request = new QuagganDiscoveryRequest();
            var responseTask = this.serviceClient.SendAsync<ICollection<string>>(request, cancellationToken);
            return responseTask.ContinueWith<ICollection<string>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Quaggan IRepository<string, Quaggan>.Find(string identifier)
        {
            var request = new QuagganDetailsRequest
            {
                Identifier = identifier
            };
            var response = this.serviceClient.Send<QuagganDataContract>(request);
            return this.converterForResponse.Convert(response);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Quaggan> IRepository<string, Quaggan>.FindAll()
        {
            var request = new QuagganBulkRequest();
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<string, Quaggan>(0);
        }

        /// <inheritdoc />
        IDictionaryRange<string, Quaggan> IRepository<string, Quaggan>.FindAll(ICollection<string> identifiers)
        {
            var request = new QuagganBulkRequest
            {
                Identifiers = identifiers.ToList()
            };
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            return this.converterForBulkResponse.Convert(response) ?? new DictionaryRange<string, Quaggan>(0);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync()
        {
            IQuagganRepository self = this;
            return self.FindAllAsync(CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync(CancellationToken cancellationToken)
        {
            var request = new QuagganBulkRequest();
            var responseTask = this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<string, Quaggan>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync(ICollection<string> identifiers)
        {
            IQuagganRepository self = this;
            return self.FindAllAsync(identifiers, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<IDictionaryRange<string, Quaggan>> IRepository<string, Quaggan>.FindAllAsync(ICollection<string> identifiers, CancellationToken cancellationToken)
        {
            var request = new QuagganBulkRequest
            {
                Identifiers = identifiers.ToList()
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith<IDictionaryRange<string, Quaggan>>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        Task<Quaggan> IRepository<string, Quaggan>.FindAsync(string identifier)
        {
            IQuagganRepository self = this;
            return self.FindAsync(identifier, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<Quaggan> IRepository<string, Quaggan>.FindAsync(string identifier, CancellationToken cancellationToken)
        {
            var request = new QuagganDetailsRequest
            {
                Identifier = identifier
            };
            var responseTask = this.serviceClient.SendAsync<QuagganDataContract>(request, cancellationToken);
            return responseTask.ContinueWith<Quaggan>(this.ConvertAsyncResponse, cancellationToken);
        }

        /// <inheritdoc />
        ICollectionPage<Quaggan> IPaginator<Quaggan>.FindPage(int pageIndex)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex
            };
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Quaggan>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        ICollectionPage<Quaggan> IPaginator<Quaggan>.FindPage(int pageIndex, int pageSize)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var response = this.serviceClient.Send<ICollection<QuagganDataContract>>(request);
            var values = this.converterForPageResponse.Convert(response);
            if (values == null)
            {
                return new CollectionPage<Quaggan>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        /// <inheritdoc />
        Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex)
        {
            IQuagganRepository self = this;
            return self.FindPageAsync(pageIndex, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex, CancellationToken cancellationToken)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex, int pageSize)
        {
            IQuagganRepository self = this;
            return self.FindPageAsync(pageIndex, pageSize, CancellationToken.None);
        }

        /// <inheritdoc />
        Task<ICollectionPage<Quaggan>> IPaginator<Quaggan>.FindPageAsync(int pageIndex, int pageSize, CancellationToken cancellationToken)
        {
            var request = new QuagganPageRequest
            {
                Page = pageIndex,
                PageSize = pageSize
            };
            var responseTask = this.serviceClient.SendAsync<ICollection<QuagganDataContract>>(request, cancellationToken);
            return responseTask.ContinueWith(task => this.ConvertAsyncResponse(task, pageIndex), cancellationToken);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollection<string> ConvertAsyncResponse(Task<IResponse<ICollection<string>>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollection<string>>() != null);
            return this.converterForIdentifiersResponse.Convert(task.Result) ?? new List<string>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private IDictionaryRange<string, Quaggan> ConvertAsyncResponse(Task<IResponse<ICollection<QuagganDataContract>>> task)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<IDictionaryRange<string, Quaggan>>() != null);
            return this.converterForBulkResponse.Convert(task.Result) ?? new DictionaryRange<string, Quaggan>(0);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private Quaggan ConvertAsyncResponse(Task<IResponse<QuagganDataContract>> task)
        {
            Contract.Requires(task != null);
            return this.converterForResponse.Convert(task.Result);
        }

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Not a public API.")]
        private ICollectionPage<Quaggan> ConvertAsyncResponse(Task<IResponse<ICollection<QuagganDataContract>>> task, int pageIndex)
        {
            Contract.Requires(task != null);
            Contract.Ensures(Contract.Result<ICollectionPage<Quaggan>>() != null);
            var values = this.converterForPageResponse.Convert(task.Result);
            if (values == null)
            {
                return new CollectionPage<Quaggan>(0);
            }

            PageContextPatchUtility.Patch(values, pageIndex);

            return values;
        }

        [ContractInvariantMethod]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Only used by the Code Contracts for .NET extension.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.serviceClient != null);
            Contract.Invariant(this.converterForBulkResponse != null);
            Contract.Invariant(this.converterForIdentifiersResponse != null);
            Contract.Invariant(this.converterForPageResponse != null);
            Contract.Invariant(this.converterForResponse != null);
        }
    }
}