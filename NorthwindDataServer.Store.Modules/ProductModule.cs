using Nancy;
using Nancy.Security;
using NorthwindDataServer.Exceptions;
using NorthwindDataServer.Store.Modules.Assemblers;
using NorthwindDataServer.Store.Modules.Contracts;
using NorthwindDataServer.Store.Modules.Criterias;
using NorthwindDataServer.Store.Modules.Managers;
using NorthwindDataServer.Store.Modules.Models;
using NorthwindDataServer.Store.Modules.ServiceDefinitions;
using System;

namespace NorthwindDataServer.Store.Modules
{
    public class ProductModule : NancyModule, IProductModule
    {
        public IProductManager ProductManager { get; private set; }

        public IProductModuleAssembler ProductRoutesAssembler { get; private set; }

        public ProductModule(IProductManager productManager, IProductModuleAssembler productRoutesAssembler)
            :base("/product")
        {
            ProductRoutesAssembler = productRoutesAssembler;

            ProductManager = productManager;

            Get["/products/{UserNameAndPassword}"] = GetAllProducts;

            Get["/{Id}&{UserNameAndPassword}"] = SearchProducts;

        }

        public dynamic GetAllProducts(dynamic parameters)
        {
            this.RequiresClaims(new[] { "Admin" });

            var credentialItem = new CredentialItem(parameters.UserNameAndPassword);

            if (string.IsNullOrEmpty(credentialItem.UserName))
                ProductRoutesAssembler.PopulateSearchResponseWithResponseCode(ExceptionCodes._1002);

            var searchProductRequest = new SearchProductsRequest
            {
                //Token = credentialItem.UserName 
            };

            var searchResponse = ProductManager.ListProducts(searchProductRequest);

            return Response.AsJson(searchResponse);
        }

        public dynamic SearchProducts(dynamic parameters)
        {
            this.RequiresClaims(new[] { "Admin" });

            var credentialItem = new CredentialItem(parameters.UserNameAndPassword);

            if (string.IsNullOrEmpty(credentialItem.UserName))
                ProductRoutesAssembler.PopulateSearchResponseWithResponseCode(ExceptionCodes._1002);

            var searchProductRequest = new SearchProductsRequest
            {
                //Token = credentialItem.UserName, 
            };

            var productCriteria = new ProductCriterias()
            {
                Id = Convert.ToInt32((string)parameters.Id)
            };

            var searchResponse = ProductManager.SearchProducts(searchProductRequest, productCriteria);

            return Response.AsJson(searchResponse);
        }
    }
}
