using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace WebApplication1.Model.DAL
{
    public class SpelareDAL
    {
        // Anslutningssträng
        private static readonly string connectionString = WebConfigurationManager.ConnectionStrings["WP13_mg222pi_ProjektConnectionString"].ConnectionString;

        public IEnumerable<Spelare> GetSpelare()
        {
            // Skapar anslutningsobject
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    // Skapa list och initiera
                    var spelare = new List<Spelare>(100);

                    var cmd = new SqlCommand("appSchema.usp_GetSpelare", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Öppna anslutning
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Arbeta utifrån index istället för namn

                        var spelareIdIndex = reader.GetOrdinal("SpelareID");
                        var skicklighetstypID = reader.GetOrdinal("SkicklighetstypID");
                        var hjälteID = reader.GetOrdinal("HjälteID");
                        var förnamn = reader.GetOrdinal("Förnamn");
                        var efternamn = reader.GetOrdinal("Efternamn");
                        var lön = reader.GetOrdinal("Lön");
                        var hjältenamn = reader.GetOrdinal("Hjältenamn");
                        var skicklighet = reader.GetOrdinal("Skicklighet");


                        while (reader.Read())
                        {
                            spelare.Add(new Spelare
                            {
                                SpelareID = reader.GetInt32(spelareIdIndex),
                                SkicklighetstypID = reader.GetInt32(skicklighetstypID),
                                HjälteID = reader.GetInt32(hjälteID),
                                Förnamn = reader.GetString(förnamn),
                                Efternamn = reader.GetString(efternamn),
                                Lön = reader.GetInt32(lön),
                                Skicklighet = reader.GetString(skicklighet),
                                Hjältenamn = reader.GetString(hjältenamn)
                            });
                        }
                    }

                    // Trimmar ner list
                    spelare.TrimExcess();

                    return spelare;
                }
            }

            catch
            {
                throw new ApplicationException("Ett fel uppstod med att hämta spelare från databasen.");
            }
        }

        public Spelare GetSpelareById(int spelareID)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("appSchema.usp_GetSpelareById", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SpelareID", System.Data.SqlDbType.Int, 4).Value = spelareID;

                    // Öppna anslutning
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Arbeta utifrån index istället för namn

                        var spelareIdIndex = reader.GetOrdinal("SpelareID");
                        var skicklighetstypID = reader.GetOrdinal("SkicklighetstypID");
                        var hjälteID = reader.GetOrdinal("HjälteID");
                        var förnamn = reader.GetOrdinal("Förnamn");
                        var efternamn = reader.GetOrdinal("Efternamn");
                        var lön = reader.GetOrdinal("Lön");
                        var skicklighet = reader.GetOrdinal("Skicklighet");
                        var hjältenamn = reader.GetOrdinal("Hjältenamn");


                        if (reader.Read())
                        {
                            return new Spelare
                            {
                                SpelareID = reader.GetInt32(spelareIdIndex),
                                SkicklighetstypID = reader.GetInt32(skicklighetstypID),
                                HjälteID = reader.GetInt32(hjälteID),
                                Förnamn = reader.GetString(förnamn),
                                Efternamn = reader.GetString(efternamn),
                                Lön = reader.GetInt32(lön),
                                Skicklighet = reader.GetString(skicklighet),
                                Hjältenamn = reader.GetString(hjältenamn)
                            };
                        }
                    }
                }

                return null;
            }

            catch
            {
                throw new ApplicationException("Ett fel uppstod med att hämta spelaren från databasen.");
            }
        }

        public void InsertSpelare(Spelare spelare)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("appSchema.usp_InsertSpelare", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Förnamn", System.Data.SqlDbType.VarChar, 25).Value = spelare.Förnamn;
                    cmd.Parameters.Add("@Efternamn", System.Data.SqlDbType.VarChar, 30).Value = spelare.Efternamn;
                    cmd.Parameters.Add("@SkicklighetstypID", System.Data.SqlDbType.Int, 4).Value = spelare.SkicklighetstypID;
                    cmd.Parameters.Add("@HjälteID", System.Data.SqlDbType.Int, 4).Value = spelare.HjälteID;
                    cmd.Parameters.Add("@Lön", System.Data.SqlDbType.Int, 4).Value = spelare.Lön;
                    cmd.Parameters.Add("@Hjältenamn", System.Data.SqlDbType.VarChar, 20).Value = spelare.Hjältenamn;
                    cmd.Parameters.Add("@Skicklighet", System.Data.SqlDbType.VarChar, 10).Value = spelare.Skicklighet;

                    cmd.Parameters.Add("@SpelareID", System.Data.SqlDbType.Int, 4).Direction = System.Data.ParameterDirection.Output;

                    // Öppna anslutning
                    conn.Open();

                    // Returnerar inga poster
                    cmd.ExecuteNonQuery();

                    // Hämtar primärnyckel
                    spelare.SpelareID = (int)cmd.Parameters["@SpelareID"].Value;
                }
            }

            catch
            {
                throw new ApplicationException("Ett fel uppstod med att lägga till den nya spelaren i databasen.");
            }
        }

        public void UpdateSpelare(Spelare spelare)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("appSchema.usp_UpdateSpelare", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SpelareID", System.Data.SqlDbType.Int, 4).Value = spelare.SpelareID;
                    cmd.Parameters.Add("@Förnamn", System.Data.SqlDbType.VarChar, 25).Value = spelare.Förnamn;
                    cmd.Parameters.Add("@Efternamn", System.Data.SqlDbType.VarChar, 30).Value = spelare.Efternamn;
                    cmd.Parameters.Add("@SkicklighetstypID", System.Data.SqlDbType.Int, 4).Value = spelare.SkicklighetstypID;
                    cmd.Parameters.Add("@HjälteID", System.Data.SqlDbType.Int, 4).Value = spelare.HjälteID;
                    cmd.Parameters.Add("@Lön", System.Data.SqlDbType.Int, 4).Value = spelare.Lön;
                    cmd.Parameters.Add("@Hjältenamn", System.Data.SqlDbType.VarChar, 20).Value = spelare.Hjältenamn;
                    cmd.Parameters.Add("@Skicklighet", System.Data.SqlDbType.VarChar, 10).Value = spelare.Skicklighet;
                    

                    // Öppna anslutning
                    conn.Open();

                    cmd.ExecuteNonQuery();
                
                }
            }

            catch
            {
                throw new ApplicationException("Ett fel uppstod med att uppdatera spelaren i databasen.");
            }
        }

        public void DeleteSpelare(int spelareID)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("appSchema.usp_DeleteSpelare", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SpelareID", System.Data.SqlDbType.Int, 4).Value = spelareID;


                    // Öppna anslutning
                    conn.Open();

                    cmd.ExecuteNonQuery();

                }
            }

            catch
            {
                throw new ApplicationException("Ett fel uppstod med att uppdatera spelaren i databasen.");
            }
        }
    }
}