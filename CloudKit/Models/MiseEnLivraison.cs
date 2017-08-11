using System;
namespace CloudKit.Models
{
    public class MiseEnLivraison
    {
		public bool etat { get; set; }
		public string date { get; set; }
		public string motif_decalage { get; set; }
    }
}
