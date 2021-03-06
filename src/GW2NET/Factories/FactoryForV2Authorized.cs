﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FactoryForV2Authorized.cs" company="GW2.NET Coding Team">
//   This product is licensed under the GNU General Public License version 2 (GPLv2) as defined on the following page: http://www.gnu.org/licenses/gpl-2.0.html
// </copyright>
// <summary>
//   Provides access to the authorized part of the version 2 API.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GW2NET.Factories
{
    using System;
    using GW2NET.Common;
    using GW2NET.V2.Accounts;

    /// <summary>Provides access to the authorized part of the version 2 API.</summary>
    public class FactoryForV2Authorized : FactoryBase
    {
        /// <summary>Initializes a new instance of the <see cref="FactoryForV2Authorized"/> class.</summary>
        /// <param name="serviceClient">The service client.</param>
        /// <exception cref="ArgumentNullException">The value of <paramref name="serviceClient"/> is a null reference.</exception>
        public FactoryForV2Authorized(IServiceClient serviceClient)
            : base(serviceClient)
        {
        }

        /// <summary>Gets access to the accounts endpoint.</summary>
        public AccountRepositoryFactory Accounts
        {
            get
            {
                return new AccountRepositoryFactory(this.ServiceClient);
            }
        }
    }
}