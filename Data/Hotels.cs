using System.ComponentModel.DataAnnotations.Schema;

namespace Trevoir.Data
{
    public class Hotels
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
