using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using CloudKit.GraphQl.Type;
using CloudKit.Models;
namespace CloudKit.BDD
{
    public class PositionDataAccess : SqlServerAccess
    {
        public PositionDataAccess(string connectionString) : base(connectionString)
        {
        }

        public Result GetPositionWithPositionNumber(string g)
        {
            string v = String.Format("SELECT OTSID,OTSNUM,OTSREF,OTSDEPDTDEB,OTSPDS,OTSARRADR1,OTSARRUSRPAYINTER, OTSDEPTIENOM,OTSARRTIENOM,OTSDTLIM,OTSARRDTDEB,OTSARRUSRVILCP,OTSDEPUSRVILCP,OTSARRADR2, OTSDEPADR1 ,OTSDEPADR2 ,OTSDEPADR2,OTSDEPUSRVILLIB,OTSDEPUSRPAYINTER,OTSDIV1,OTSDIV3,OTSCOL,OTSLONG,OTSLIVHAYON,OTSMEMO FROM ORDRE WHERE OTSNUM = '{0}'", g);
            SqlDataReader readerOrdre = new SqlCommand(v, GetConnection()).ExecuteReader();
            try
            {
                if (readerOrdre != null && readerOrdre.HasRows)
                {
                    while (readerOrdre.Read())
                    {
                        DetailClient dClient = new DetailClient();

                        dClient.raison_sociale = readerOrdre["OTSDEPTIENOM"].ToString();
                        dClient.adresse = String.Format("{0} {1}", readerOrdre["OTSDEPADR1"], readerOrdre["OTSDEPADR2"]);
                        dClient.code_postal = readerOrdre["OTSDEPUSRVILCP"].ToString();
                        dClient.ville = readerOrdre["OTSDEPUSRVILLIB"].ToString();
                        dClient.pays = readerOrdre["OTSDEPUSRPAYINTER"].ToString();


                        DetailClient aClient = new DetailClient
                        {
                            raison_sociale = readerOrdre["OTSARRTIENOM"].ToString(),
                            adresse = String.Format("{0} {1} {2}", readerOrdre["OTSARRADR1"], readerOrdre["OTSARRADR2"], readerOrdre["OTSARRADR1"]),
                            code_postal = readerOrdre["OTSARRUSRVILCP"].ToString(),
                            ville = readerOrdre["OTSARRUSRPAYINTER"].ToString(),
                            pays = readerOrdre["OTSARRUSRPAYINTER"].ToString()
                        };

                        Arrivee a = new Arrivee();

                        a.date_livraison = (readerOrdre["OTSARRDTDEB"]).ToString();
                        a.imperatif_livraison = (readerOrdre["OTSDTLIM"]).ToString();
                        a.destinataire = aClient;

                        Depart d = new Depart
                        {
                            date_chargement = (readerOrdre["OTSDEPDTDEB"]).ToString(),
                            expediteur = dClient
                        };

                        Marchandise m = new Marchandise
                        {
                            palettes = new Palettes
                            {
                                facturees = Convert.ToInt32(readerOrdre["OTSDIV1"]),
                                //coup_de_fourches = (int)readerOrdre["OTSDIV3"]
                            },
                            nombre_colis = Convert.ToInt32(readerOrdre["OTSCOL"]),
                            //m.metre_lineaire = (float)readerOrdre["OTSLONG"]; //isNUll
                            poids = (double)readerOrdre["OTSPDS"],
                            hayon_tp = Convert.ToBoolean((decimal)readerOrdre["OTSLIVHAYON"]),
                            observations = readerOrdre["OTSMEMO"].ToString()
                        };



                        Result r = new Result();
                        r.numero_chrono = readerOrdre["OTSNUM"].ToString();
                        r.reference_interne = readerOrdre["OTSREF"].ToString();
                        r.depart = d;
                        r.arrivee = a;
                        r.marchandise = m;


                        return r;
                    }

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

        public Result GetPositionWithGroupageNumber(string v)
        {
            throw new NotImplementedException();
        }

        public List<Result> GetPositionWithCodeChauffeur(string g, string dateTime1, string dateTime2)
        {
            string v = String.Format("select OTSID,OTSNUM,OTSREF,OTSDEPDTDEB,OTSPDS,OTSARRADR1,OTSARRUSRPAYINTER, OTSDEPTIENOM,OTSARRTIENOM,OTSDTLIM,OTSARRDTDEB,OTSARRUSRVILCP,OTSDEPUSRVILCP,OTSARRADR2, OTSDEPADR1 ,OTSDEPADR2 ,OTSDEPADR2,OTSDEPUSRVILLIB,OTSDEPUSRPAYINTER,OTSDIV1,OTSDIV3,OTSCOL,OTSLONG,OTSLIVHAYON,OTSMEMO from ordre , ordpla, voyage where voyid=otpvoyid and  otpotsid=otsid and OTPCHSALCODE='{0}' and VOYDEPDTDEB between '{1} 00:00:00' and  '{2} 23:59:59'",g,dateTime1,dateTime2);
            SqlDataReader readerOrdre = new SqlCommand(v, GetConnection()).ExecuteReader();
            try
            {
                if (readerOrdre != null && readerOrdre.HasRows)
                {
                    List<Result> res = new List<Result>();
                    while (readerOrdre.Read())
                    {
                        DetailClient dClient = new DetailClient();

                        dClient.raison_sociale = readerOrdre["OTSDEPTIENOM"].ToString();
                        dClient.adresse = String.Format("{0} {1}", readerOrdre["OTSDEPADR1"], readerOrdre["OTSDEPADR2"]);
                        dClient.code_postal = readerOrdre["OTSDEPUSRVILCP"].ToString();
                        dClient.ville = readerOrdre["OTSDEPUSRVILLIB"].ToString();
                        dClient.pays = readerOrdre["OTSDEPUSRPAYINTER"].ToString();


                        DetailClient aClient = new DetailClient
                        {
                            raison_sociale = readerOrdre["OTSARRTIENOM"].ToString(),
                            adresse = String.Format("{0} {1} {2}", readerOrdre["OTSARRADR1"], readerOrdre["OTSARRADR2"], readerOrdre["OTSARRADR1"]),
                            code_postal = readerOrdre["OTSARRUSRVILCP"].ToString(),
                            ville = readerOrdre["OTSARRUSRPAYINTER"].ToString(),
                            pays = readerOrdre["OTSARRUSRPAYINTER"].ToString()
                        };

                        Arrivee a = new Arrivee();

                        a.date_livraison = (readerOrdre["OTSARRDTDEB"]).ToString();
                        a.imperatif_livraison = (readerOrdre["OTSDTLIM"]).ToString();
                        a.destinataire = aClient;

                        Depart d = new Depart
                        {
                            date_chargement = (readerOrdre["OTSDEPDTDEB"]).ToString(),
                            expediteur = dClient
                        };

                        Marchandise m = new Marchandise();
                        m.palettes = new Palettes
                        {
                            facturees = Convert.ToInt32(readerOrdre["OTSDIV1"].ToString()),
                            //coup_de_fourches = (int)readerOrdre["OTSDIV3"]
                        };
                        m.nombre_colis = Convert.ToInt32(readerOrdre["OTSCOL"].ToString());
                        //m.metre_lineaire = (float)readerOrdre["OTSLONG"]; //isNUll
                        m.poids = (double)readerOrdre["OTSPDS"];
                        //m.hayon_tp = Convert.ToBoolean((readerOrdre["OTSLIVHAYON"].ToString()) == "" ? "false" : readerOrdre["OTSLIVHAYON"].ToString());
                        m.observations = readerOrdre["OTSMEMO"].ToString();



                        Result r = new Result();
                        r.numero_chrono = readerOrdre["OTSNUM"].ToString();
                        r.reference_interne = readerOrdre["OTSREF"].ToString();
                        r.depart = d;
                        r.arrivee = a;
                        r.marchandise = m;

                        res.Add(r);
                    }

                    return res;
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

        public Result GetPositionWithParcelNumber(string g)
        {
            string v = String.Format("select OTSID,OTSNUM,OTSREF,OTSDEPDTDEB,OTSPDS,OTSARRADR1,OTSARRUSRPAYINTER, OTSDEPTIENOM,OTSARRTIENOM,OTSDTLIM,OTSARRDTDEB,OTSARRUSRVILCP,OTSDEPUSRVILCP,OTSARRADR2, OTSDEPADR1 ,OTSDEPADR2 ,OTSDEPADR2,OTSDEPUSRVILLIB,OTSDEPUSRPAYINTER,OTSDIV1,OTSDIV3,OTSCOL,OTSLONG,OTSLIVHAYON,OTSMEMO from ORDRE as POS,ORDCOL as COL ,  QUAI,tOURNEEVILLE where POS.OTSID = COL.OTLOTSID AND COL.OTLNUMCB = '{0}'	AND otsarrvilid*= TOUVILID AND OTSVPECODE*= QUAVTOCODE", g);

            SqlDataReader readerOrdre = new SqlCommand(v, GetConnection()).ExecuteReader();
            try
            {
                if (readerOrdre != null && readerOrdre.HasRows)
                {
                    while (readerOrdre.Read())
                    {
                        DetailClient dClient = new DetailClient();

                        dClient.raison_sociale = readerOrdre["OTSDEPTIENOM"].ToString();
                        dClient.adresse = String.Format("{0} {1}", readerOrdre["OTSDEPADR1"], readerOrdre["OTSDEPADR2"]);
                        dClient.code_postal = readerOrdre["OTSDEPUSRVILCP"].ToString();
                        dClient.ville = readerOrdre["OTSDEPUSRVILLIB"].ToString();
                        dClient.pays = readerOrdre["OTSDEPUSRPAYINTER"].ToString();


                        DetailClient aClient = new DetailClient
                        {
                            raison_sociale = readerOrdre["OTSARRTIENOM"].ToString(),
                            adresse = String.Format("{0} {1} {2}", readerOrdre["OTSARRADR1"], readerOrdre["OTSARRADR2"], readerOrdre["OTSARRADR1"]),
                            code_postal = readerOrdre["OTSARRUSRVILCP"].ToString(),
                            ville = readerOrdre["OTSARRUSRPAYINTER"].ToString(),
                            pays = readerOrdre["OTSARRUSRPAYINTER"].ToString()
                        };

                        Arrivee a = new Arrivee();

                        a.date_livraison = (readerOrdre["OTSARRDTDEB"]).ToString();
                        a.imperatif_livraison = (readerOrdre["OTSDTLIM"]).ToString();
                        a.destinataire = aClient;

                        Depart d = new Depart
                        {
                            date_chargement = (readerOrdre["OTSDEPDTDEB"]).ToString(),
                            expediteur = dClient
                        };

                        Marchandise m = new Marchandise();
                        m.palettes = new Palettes
                        {
                            facturees = Convert.ToInt32(readerOrdre["OTSDIV1"].ToString()),
                            //coup_de_fourches = (int)readerOrdre["OTSDIV3"]
                        };
                        m.nombre_colis = Convert.ToInt32(readerOrdre["OTSCOL"].ToString());
                        //m.metre_lineaire = (float)readerOrdre["OTSLONG"]; //isNUll
                        m.poids = (double)readerOrdre["OTSPDS"];
                        m.hayon_tp = Convert.ToBoolean((readerOrdre["OTSLIVHAYON"].ToString()) == "" ? "false" : readerOrdre["OTSLIVHAYON"].ToString());
                        m.observations = readerOrdre["OTSMEMO"].ToString();



                        Result r = new Result();
                        r.numero_chrono = readerOrdre["OTSNUM"].ToString();
                        r.reference_interne = readerOrdre["OTSREF"].ToString();
                        r.depart = d;
                        r.arrivee = a;
                        r.marchandise = m;


                        return r;
                    }

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

