using CsvHelper.Configuration.Attributes;

namespace AnaeLogiciel.Models;

public class ArtisantsCSV
{
    [Name("nom")]
    public string Nom { get; set; }
    
    [Name("genre")]
    public string Genre { get; set; }
}