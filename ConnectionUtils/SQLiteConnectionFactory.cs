using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace ConnectionUtils
{
	public class SQLiteConnectionFactory : ConnectionFactory
	{
		public override IDbConnection createConnection(IDictionary<string, string> props)
		{
			// Windows SQLite Connection, fisierul .db ar trebuie sa fie in directorul debug/bin
			String connectionString = props["ConnectionString"];
			//String connectionString = "Data Source =D:/Proiecte personale/PoateAiciFunctioneaza/AgentieTurism.db;Version=3";
			return new SQLiteConnection(connectionString);
			//return new SQLiteConnectionFactory(connectionString);
		}
	}
}
