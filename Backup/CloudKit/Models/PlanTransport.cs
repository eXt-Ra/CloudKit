using System;
namespace CloudKit.Models
{
    public class PlanTransport
    {
		public bool transport_direct { get; set; }
		public Remettant remettant { get; set; }
		public Distributeur distributeur { get; set; }
		public PfDepose pf_depose { get; set; }
		public Traction traction { get; set; }
		public PfVia1 pf_via1 { get; set; }
		public int delai { get; set; }
    }
}
