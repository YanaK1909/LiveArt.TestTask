using System;
using System.Collections.Generic;
using System.Linq;
using LiveArt.ProductsManagement.Domain.Contracts.Services;
using Microsoft.Extensions.Configuration;

namespace LiveArt.ProductsManagement.Api.Services
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public ConnectionStringProvider(IConfiguration configuration)
        {
            this.ConnectionString = configuration.GetConnectionString("ProductsManagement");
        }

        public string ConnectionString { get; }
    }
}
