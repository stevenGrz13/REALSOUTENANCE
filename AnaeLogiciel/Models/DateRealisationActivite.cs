using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnaeLogiciel.Models;

[Table("daterealisationactivite")]
public class DateRealisationActivite
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("idoccurenceactivite")]
    [DisplayName("occurenceactivite")]
    public int IdOccurenceActivite { get; set; }
    
    [Column("datedebutrealisation")]
    public DateOnly DateDebutRealisation { get; set; }
    
    [Column("datefinrealisation")]
    public DateOnly DateFinRealisation { get; set; }
    
    [ForeignKey("IdOccurenceActivite")]
    public virtual OccurenceActivite? OccurenceActivite { get; set; }
}