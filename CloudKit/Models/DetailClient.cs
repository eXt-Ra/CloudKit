using System;
namespace CloudKit.Models
{
    public class DetailClient
    {
		public string raison_sociale { get; set; }
		public string adresse { get; set; }
		public string code_postal { get; set; }
		public string ville { get; set; }
		public string pays { get; set; }
		public Ville detail { get; set; }
		public string clientId { get; set; }
		public string clientCode { get; set; }
		public string adresse2 { get; set; }
    }
}
