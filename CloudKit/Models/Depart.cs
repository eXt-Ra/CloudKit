using System;
using CloudKit.GraphQl.Type;
namespace CloudKit.Models
{
    public class Depart
    {
		public string date_chargement { get; set; }
		public string reference_chargement { get; set; }
		public string telephone { get; set; }
        public DetailClient expediteur { get; set; }
    }
}
