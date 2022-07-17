using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EXAM.models;

namespace EXAM
{
    internal class DataBase
    {
        private readonly string _connectionString;

        public DataBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<OurTableOut> ShowContent()
        {
            var showContents = new List<OurTableOut>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(
                           cmdText: "SELECT TOP (1000) [PropId] ,[nCanonId]" +
                                    " ,[dtReportDate],[nTerOtdelenie],[nTerPodrazdel]," +
                                    "[vProcent] FROM [MyDB].[NashaBaza].[OurTable]" +
                                    "order by PropId desc",
                           connection: connection
                       )
                      )
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dtReportDate = reader.GetDateTime(2);
                            var nCanonId = reader.GetInt32(1);
                            var nTerOtdelenie = reader.GetInt32(3);
                            var nTerPodrazdel = reader.GetInt32(4);
                            var propId = reader.GetInt64(0);
                            var vProcent = reader.GetDecimal(5);

                            showContents.Add(new OurTableOut
                            {
                                DtReportDate = dtReportDate,
                                NCanonId = nCanonId,
                                NTerOtdelenie = nTerOtdelenie,
                                NTerPodrazdel = nTerPodrazdel,
                                PropId = propId,
                                VProcent = vProcent
                            });
                        }
                    }
                }


            }

            return showContents;
        }

        public void AddContent(OurTableIn source)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var commandString = string
                    .Format("Insert Into [MyDB].[NashaBaza].[OurTable]" +
                            "(nCanonId, dtReportDate, nTerOtdelenie, " +
                            "nTerPodrazdel, vProcent) " +
                            "Values({0},'{1}',{2},{3},{4}.{5})",
                        source.NCanonId, source.DtReportDate, source.NTerOtdelenie,
                        source.NTerPodrazdel, source.VProcent[0], source.VProcent[1]
                    );

                using (var command = new SqlCommand(
                           cmdText: commandString,
                           connection: connection
                       )
                      )
                {
                    

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
