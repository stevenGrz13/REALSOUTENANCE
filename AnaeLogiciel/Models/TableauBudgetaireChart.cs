using System.ComponentModel.DataAnnotations.Schema;

namespace AnaeLogiciel.Models;

public class TableauBudgetaireChart
{
    public int Budget { get; set; }
    
    public int Depense { get; set; }
    
    public int Reste { get; set; }
}