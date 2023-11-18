using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnaeLogiciel.Models;

[Table("artisants")]
public class Artisants
{
    [Key]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("idprojet")]
    [DisplayName("projet")]
    public int IdProjet { get; set; }
    
    [Column("nom")]
    public string Nom { get; set; }
    
    [Column("idgenre")]
    [DisplayName("genre")]
    public int IdGenre { get; set; }
}