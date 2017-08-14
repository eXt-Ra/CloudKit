using System;
namespace CloudKit.Models
{
    public class Marchandise
    {
		public Palettes palettes { get; set; }
		public int nombre_colis { get; set; }
		public int nombre_etiquettes { get; set; }
		public int volume { get; set; }
		public float metre_lineaire { get; set; }
		public double poids { get; set; }
		public int palettes_euro { get; set; }
		public bool porteur { get; set; }
		public bool hayon_tp { get; set; }
		public bool restitution_euro { get; set; }
		public Adr adr { get; set; }
		public string type { get; set; }
		public ContreRemboursement contre_remboursement { get; set; }
		public string observations { get; set; }
    }
}
