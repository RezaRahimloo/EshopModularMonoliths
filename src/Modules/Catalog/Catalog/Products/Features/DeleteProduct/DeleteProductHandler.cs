﻿

namespace Catalog.Products.Features.DeleteProduct
{
    public record DeleteProductCommand(Guid ProductId) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);
    internal class DeleteProductHandler(CatalogDbContext dbContext) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var product = await dbContext.Products.FindAsync([command.ProductId], cancellationToken);

            if (product == null)
            {
                throw new Exception($"Product not found: {command.ProductId}");
            }

            dbContext.Products.Remove(product);
            var rowsAffected = await dbContext.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(rowsAffected > 0);
        }
    }
}
