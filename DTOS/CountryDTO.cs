using System.ComponentModel.DataAnnotations;

namespace Trevoir.DTOS
{
    public class CreateCountryDTO
    {

        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Country Name is too long")]
        public string? Name { get; set; }
    }
    public class CountryDTO : CreateCountryDTO
    {
        public int Id { get; set; }
        public IList<HotelDTOS> Hotels { get; set; }

    }


}
