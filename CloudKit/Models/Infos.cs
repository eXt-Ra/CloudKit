using System;
namespace CloudKit.Models
{
    public class Infos
    {
		public Saisie saisie { get; set; }
		public Transmission transmission { get; set; }
		public Modification modification { get; set; }
		public bool transmise { get; set; }
		public bool annulee { get; set; }
		public bool modifiee { get; set; }
		public int timestamp_derniere_action { get; set; }
    }
}
