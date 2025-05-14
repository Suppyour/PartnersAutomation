namespace Backend.Entities
{
    public class ProductSizeEntity
    {
        public Guid ProductId { get; set; }
        public Guid SizeId { get; set; }
        public int Quantity { get; set; }

        public ProductEntity Product { get; set; }
        public SizeEntity Size { get; set; }
    }

}