using System.ComponentModel.DataAnnotations.Schema;
using Trevoir.Data;

namespace Trevoir.DTOS
{
    public class CreateHotelDTO
    {

        public string? Name { get; set; }
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
    public class HotelDTOS : CreateHotelDTO
    {
        public int Id { get; set; }
        public CountryDTO Country { get; set; }
    }
}
