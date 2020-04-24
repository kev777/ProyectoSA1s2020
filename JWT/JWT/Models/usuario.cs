using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using JWT.Models;

namespace JWT.Models
{
    public class usuario
    {

        conexion conec = new conexion();
        IMongoDatabase database;
        int salida;

        #region login
        public int ejecuta(Object token, UserInfo user)
        {
            database = conec.getConexion();
            bdtoken bd = new bdtoken();

            try
            {
                var collection = database.GetCollection<BsonDocument>("Usuario");
                //var filtro = Builders<BsonDocument>.Filter.Eq("password", password.ToString(), "usuario", user.ToString());
                //user._id = token.ToString();

                bd.client_id = user._id;
                bd._id = token.ToString();

                BsonDocument documento = bd.ToBsonDocument();
                collection.InsertOne(documento);

                salida = 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.Message);
            }

            return salida;

        }
        #endregion


    }
}
