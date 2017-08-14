using System;
namespace CloudKit.Models
{
    public class Arrivee
    {
		public string date_livraison { get; set; }
        public string imperatif_livraison { get; set; }
        public DateTime date_imperatif_livraison { get; set; }
		public string telephone { get; set; }
		public DetailClient destinataire { get; set; }
    }
}
