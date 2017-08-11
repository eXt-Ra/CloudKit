using System;
using System.Collections.Generic;
using CloudKit.GraphQl.Type;
using GraphQL.Types;

namespace CloudKit.Models
{
    public class Result
    {
		public int count { get; set; }
		public List<string> frets { get; set; }
		public string numero_chrono { get; set; }
		public string reference_interne { get; set; }
		public string code_client { get; set; }
		public string code_livreur { get; set; }
		public bool demande_enlevement { get; set; }
		public Infos infos { get; set; }
        //public Depart depart { get; set; }
        public Depart depart { get; set; }
		public Arrivee arrivee { get; set; }
        public DetailClient expediteur { get; set; }
		public Marchandise marchandise { get; set; }
		public Raq raq { get; set; }
		public PlanTransport plan_transport { get; set; }
		public Ged ged { get; set; }
		public Livraison livraison { get; set; }
		public List<int> palettes { get; set; }
		public List<PlansTransport> plans_transports { get; set; }
    }

	public class Position
	{
        public int id { get; set; }
        public string numCommande { get; set; }
		public string refClient { get; set; }
		public Infos infos { get; set; }
		public Depart depart { get; set; }
		public Arrivee arrivee { get; set; }
		public Marchandise marchandise { get; set; }
		public PlanTransport plan_transport { get; set; }
		public Livraison livraison { get; set; }
		public List<int> palettes { get; set; }
		public List<PlansTransport> plans_transports { get; set; }
	}


  //  public class dd {
		//public int ordrePosition { get; set; }
		//public int idPosition { get; set; }
		//public string numPosition { get; set; }
		//public string refClient { get; set; }
		//public int nbColis { get; set; }
		//public int nbColisFictif { get; set; }
		//public int nbPalette { get; set; }
		//public decimal poids { get; set; }
		//public decimal ml { get; set; }
		//public int col { get; set; }
		//public int colisSurPal { get; set; }
		//public DateTime dateImpLiv { get; set; }
		//public string clientNom { get; set; }
		//public string expediteurNom { get; set; }
		//public string expediteurAdresse { get; set; }
		//public string expediteurVille { get; set; }
		//public string expediteurCp { get; set; }
		//public string chargementNom { get; set; }
		//public string chargementAdresse { get; set; }
		//public string chargementVille { get; set; }
		//public string chargementCp { get; set; }
		//public string livraisonNom { get; set; }
		//public string livraisonAdresse { get; set; }
		//public string livraisonVille { get; set; }
		//public string livraisonCp { get; set; }
		//public List<codebarre> codebarre { get; set; }
		//public List<evenement> evenement { get; set; }
		//public string zoneQuaiTheorique { get; set; }
		//public Exception ex { get; set; }
    //}
}
