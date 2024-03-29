﻿using AutoMapper;
using E_commerce.Application.Commands;
using E_commerce.Infrastructure.Data;
using E_commerceWebsite.AggregateModels.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace E_commerce.Application.CommandsHandler
{
    public class UpdateProductBrandsCommandHandler : IRequestHandler<UpdateProductBrandsCommand, Unit>
    {
        private readonly StoreDbContext _dbContext;
        private readonly IProductBrandRepository _productBrandRepository;

        public UpdateProductBrandsCommandHandler(StoreDbContext dbContext, IProductBrandRepository productBrandRepository)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _productBrandRepository = productBrandRepository ?? throw new ArgumentNullException(nameof(productBrandRepository));
        }

        public async Task<Unit> Handle(UpdateProductBrandsCommand request, CancellationToken cancellationToken)
        {
            // Check if a product brand with the updated name already exists
            var existingProductBrand = await _productBrandRepository.GetProductBrandByName(request.UpdatedProductBrandName);

            if (existingProductBrand != null && existingProductBrand.ProductBrandId != request.ProductBrandId)
            {
                // Handle the case where a product brand with the updated name already exists
                throw new InvalidOperationException($"Product brand with the name '{request.UpdatedProductBrandName}' already exists.");
            }

            var productBrand = await _dbContext.productBrands.FindAsync(request.ProductBrandId);

            if (productBrand != null)
            {
                productBrand.ProductBrandName = request.UpdatedProductBrandName;


                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            // Indicate success by returning Unit.Value (equivalent to void)
            return Unit.Value;
        }
    }
}