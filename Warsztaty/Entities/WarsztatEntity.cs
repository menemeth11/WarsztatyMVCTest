namespace Warsztaty.Entities
{
    public class WarsztatEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string? Desciption { get; set; }

        public string Address { get; set; } = default!;
        public string? PhoneNumber { get; set; }
    }
}
