



namespace Catalog.Products.Features.UpdateProduct
{
    public record UpdateProductCommand(ProductDto Product) : ICommand<UpdateProductResult>;
    public record UpdateProductResult(bool IsSuccess);
    internal class UpdateProductHandler(CatalogDbContext dbContext) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var product = await dbContext.Products.FindAsync([command.Product.Id], cancellationToken);

            if (product == null)
            {
                throw new Exception($"Product not found: {command.Product.Id}");
            }

            UpdateProductWithNewValues(product, command.Product);

            dbContext.Products.Update(product);
            var changedRows = await dbContext.SaveChangesAsync(cancellationToken);

            return new UpdateProductResult(changedRows > 0);
        }

        private void UpdateProductWithNewValues(Product product, ProductDto productDto)
        {
            product.Update(
                productDto.Name,
                productDto.Category,
                productDto.Description,
                productDto.ImageFile,
                productDto.Price);
        }
    }
}
