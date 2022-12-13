namespace Trevoir.Data
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual IList<Hotels> Hotels { get; set; }
    }
}
