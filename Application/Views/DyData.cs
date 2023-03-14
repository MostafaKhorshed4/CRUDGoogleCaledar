using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

using System.Dynamic;
using Microsoft.EntityFrameworkCore;

namespace Application.Views
{
    public static class DyData
    {
        public static IEnumerable<dynamic> CollectionFromSql(this DbContext dbContext, string Sql)
        {
            using (var cmd = dbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = Sql;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                cmd.CommandTimeout = 60;
                using (var dataReader = cmd.ExecuteReader())
                {

                    while (dataReader.Read())
                    {
                        var dataRow = GetDataRow(dataReader);
                        yield return dataRow;

                    }
                }


            }
        }

        public static dynamic GetDataRow(DbDataReader dataReader)
        {
            var dataRow = new ExpandoObject() as IDictionary<string, object>;
            for (var fieldCount = 0; fieldCount < dataReader.FieldCount; fieldCount++)
                dataRow.Add(dataReader.GetName(fieldCount), dataReader[fieldCount]);
            return dataRow;
        }
    }
}
