﻿using BuildingBlocks.CQRS;
using Catalog.API.Models;
using System.Windows.Input;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(Guid Id,
     string Name,
     List<string> Category,
     string Description,
     string ImageFile,
     decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // create entity from command

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price,
            };


            // TODO
            // save to db
            // return result

            return new CreateProductResult(Guid.NewGuid());

        }
    }
}
