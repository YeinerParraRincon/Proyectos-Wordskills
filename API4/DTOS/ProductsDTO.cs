namespace DTOS
{
    public class ProductsDTO
    {
        public long ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Ingredients { get; set; } = null!;

        public short Price { get; set; }

        public short Cost { get; set; }

        public bool Seasonal { get; set; }

        public bool Active { get; set; }

        public DateOnly Date { get; set; }

        public string Descripcion { get; set; } = null!;
    }
}
