using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

public class Produs
{
    [Key]
    [Column("id")] 
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string Denumire { get; set; }

    [MaxLength(500)]
    public string Descriere { get; set; }

    [Required]
    [Column("data_intrare")] 
    public string Data_Intrare { get; set; }

    [Column("data_expirare")]
    public string Data_Expirare { get; set; }

    [Required]
    public int Cantitate { get; set; }
}
