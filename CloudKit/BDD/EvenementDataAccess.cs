using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CloudKit.Models;

namespace CloudKit.BDD
{
    public class EvenementDataAccess : SqlServerAccess
    {
		public EvenementDataAccess(string connectionString) : base(connectionString)
        {
		}

        internal List<Evenement> GetEventFromPosition(int idPosition){
            string v = String.Format("select OTETEVCODE, OTETEVLIBCL1, OTEDATE, OTEVAL3, OTEVAL1 from ORDEVE where OTEOTSID = '{0}' order by OTEID desc", idPosition);
			try
			{
                SqlDataReader readerOrdre = new SqlCommand(v, GetConnection()).ExecuteReader();
				if (readerOrdre != null && readerOrdre.HasRows)
				{
                    List<Evenement> list = new List<Evenement>();
					while (readerOrdre.Read())
					{
                        Evenement res = new Evenement();
                        res.code = readerOrdre["OTETEVCODE"].ToString();
                        res.libelle = readerOrdre["OTETEVLIBCL1"].ToString();
                        res.date = readerOrdre["OTEDATE"].ToString();
                        res.remarque = readerOrdre["OTEVAL3"].ToString();
                        res.information = readerOrdre["OTEVAL1"].ToString();
                        list.Add(res);
					}

                    return list;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return null;
			}
			finally
			{
				//readerOrdre.Close();
			}

			return null;
        }
    }
}
