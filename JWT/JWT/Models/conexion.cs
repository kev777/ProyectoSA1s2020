using System;
using System.Data.SqlClient;
using MongoDB.Bson;
using MongoDB.Driver;


namespace JWT.Models
{
    public class conexion
    {
        IMongoClient mongoClient;
        IMongoDatabase database;

        public conexion()
        {
            //con = new SqlConnection();
            string cadena = "mongodb://admin1:admin@cluster0-shard-00-00-k6sn1.mongodb.net:27017,cluster0-shard-00-01-k6sn1.mongodb.net:27017,cluster0-shard-00-02-k6sn1.mongodb.net:27017/Base1?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
            //con.ConnectionString = "Data Source=.;Initial Catalog=CONTRATACION;Integrated Security=True";
            //con.ConnectionString = "Data Source=DELEON0;Initial Catalog=software;Integrated Security=True";
            try
            {
                mongoClient = new MongoClient(cadena);
                database = mongoClient.GetDatabase("Base1");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message.ToString());
            }
        }

        public IMongoDatabase getConexion()
        {
            return database;
        }

    }
}
