using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnaeLogiciel.Models;

[Table("daterealisationsousactivite")]
public class DateRealisationSousActivite
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("idoccurencesousactivite")]
    [DisplayName("occurencesousactivite")]
    public int IdOccurenceSousActivite { get; set; }
    
    [Column("datedebutrealisation")]
    public DateOnly DateDebutRealisation { get; set; }
    
    [Column("datefinrealisation")]
    public DateOnly DateFinRealisation { get; set; }
    
    [ForeignKey("IdOccurenceSousActivite")]
    public virtual OccurenceSousActivite? OccurenceSousActivite { get; set; }
}