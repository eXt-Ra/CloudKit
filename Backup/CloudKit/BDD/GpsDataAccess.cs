using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CloudKit.Models;

namespace CloudKit.BDD
{
    public class GpsDataAccess : SqlServerAccess
    {
        public GpsDataAccess(string connectionString) : base(connectionString)
        {
        }

        internal Gps GetGpsWithCodeChauffeur(string g, string dateTime1, string dateTime2)
        {

            string v = String.Format("select DGPCOND, DGPPOSITION, DGPHEUREPOS, DGPDERNIEREHEURE, DGPDERNIEREPOS from DMSGPS WHERE DGPDATE between '{1} 00:00:00' and  '{2} 23:59:59' AND DGPCOND ='{0}'", g, dateTime1, dateTime2);
            SqlDataReader readerOrdre = new SqlCommand(v, GetConnection()).ExecuteReader();
            try
            {
                if (readerOrdre != null && readerOrdre.HasRows)
                {
                    while (readerOrdre.Read())
                    {
                        Gps res = new Gps();
                        res.chauffeur = readerOrdre["DGPCOND"].ToString();
                        List<LatLng> listLatLng = new List<LatLng>();
                        string f = readerOrdre["DGPPOSITION"].ToString();
                        string k = readerOrdre["DGPHEUREPOS"].ToString();
                        string[] fSplit = f.Split('|');
                        string[] kSplit = k.Split('|');

                        for (int i = 0; i < fSplit.Length; i++)
                        {
                            try
                            {
                                if (fSplit[i] != "NULL")
                                {
									listLatLng.Add(new LatLng
									{
										lat = fSplit[i].Split(';')[0],
										lng = fSplit[i].Split(';')[1],
										date = kSplit[i]
									});
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }

                        res.latlng = listLatLng;


                        res.lastlatlng = new LatLng
                        {
                            lat = readerOrdre["DGPDERNIEREPOS"].ToString().Split(';')[0],
                            lng = readerOrdre["DGPDERNIEREPOS"].ToString().Split(';')[1],
                            date = readerOrdre["DGPDERNIEREHEURE"].ToString()
                        };

                        return res;
                    }

                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            finally
            {
                readerOrdre.Close();
            }

            return null;
        }
    }
}
