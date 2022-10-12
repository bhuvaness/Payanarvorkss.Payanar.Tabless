﻿using MongoDB.Bson;
using MongoDB.Driver;
using Payanarvorkss.Payanar.Tabless.Api.DataModelss;

namespace Payanarvorkss.Payanar.Tabless.Api.Business
{
    public class PayanarTableBusiness
    {
        public async Task<DataModelss.PayanarTable> Create(DtoModelss.PayanarTable table)
        {
            DataModelss.PayanarTable dataTable = ConvertTo(table);
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTableRowss = database.GetCollection<DataModelss.PayanarTableRow>(table.UniqueId);
            dataTable.Rows.ToList().ForEach(v =>
            {
                payanarTableRowss.InsertOneAsync(v);
            });
            return dataTable;
        }
        public async Task<DtoModelss.PayanarTable> Read(DtoModelss.PayanarTableDesign tableDesign)
        {
            var client = new MongoDB.Driver.MongoClient("mongodb+srv://bhuvaness:Kg3dQIRhQeKmKAt7@cluster0.dt0ycsn.mongodb.net/?retryWrites=true&w=majority");
            var database = client.GetDatabase("PayanarTabless");
            var payanarTableRowss = database.GetCollection<DataModelss.PayanarTableRow>(tableDesign.UniqueId);
            var query = await payanarTableRowss.FindAsync(x => !string.IsNullOrEmpty(x.UniqueId));
            var result = query.ToList();
            DtoModelss.PayanarTable table = ConvertFrom(tableDesign, result);
            return table;
        }
        private DataModelss.PayanarTable ConvertTo(DtoModelss.PayanarTable table)
        {
            DataModelss.PayanarTable dataTable = new DataModelss.PayanarTable();

            dataTable.UniqueId = table.UniqueId;
            dataTable.Name = table.Name;

            foreach (var row in table.Rows)
            {
                dataTable.AddRow(row);
            }

            return dataTable;
        }
        private DtoModelss.PayanarTable ConvertFrom(DtoModelss.PayanarTableDesign tableDesign, IEnumerable<DataModelss.PayanarTableRow> rows)
        {
            DtoModelss.PayanarTable table = new DtoModelss.PayanarTable();

            table.UniqueId = tableDesign.UniqueId;
            table.Name = tableDesign.Name;

            foreach (var row in rows)
            {
                table.AddRow(row);
            }

            return table;
        }
    }
}