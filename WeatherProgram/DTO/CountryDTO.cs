public class CountryDTO
{
    public string Name { get; set; }
    public ICollection<string> Cities { get; set; }
}
