using System;
using System.Collections.Generic;

namespace CloudKit.Models
{
    public class Gps
    {
        public string chauffeur { get; set; }
        public List<LatLng> latlng { get; set; }
		public LatLng lastlatlng { get; set; }
    }
}
