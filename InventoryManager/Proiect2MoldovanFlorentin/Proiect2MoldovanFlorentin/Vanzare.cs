using System;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Vanzare")]
public class Vanzare
{
    public int Id { get; set; }
    public string NumeProdus { get; set; }
    public int Cantitate { get; set; }
    public string DataVanzare { get; set; }
}