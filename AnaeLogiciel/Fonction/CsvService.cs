using System.Globalization;
using AnaeLogiciel.Data;
using AnaeLogiciel.Models;
using CsvHelper;

namespace AnaeLogiciel.Fonction;

public class CsvService
{
    public List<ArtisantsCSV> ImportCsv(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<ArtisantsCSV>().ToList();
            return records;
        }
    }

    public static int Idgenre(string genre, ApplicationDbContext _context)
    {
        return _context.Genre.First(a => a.Nom == genre).Id;
    }
}