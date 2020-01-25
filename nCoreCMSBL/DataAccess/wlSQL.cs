// <pageinfo>
// <name> </name>
// <email></email>
// <date_created></date_created>
// <date_modified></date_modified>
// <summary></summary>
// <copyright></copyright>
// </pageinfo>

namespace nCoreCMSBL
{
    #region namespace
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using WL.Core;
    using System.Data.OleDb;
    using System.IO;
    using System.Globalization;
    #endregion

    /// <summary>
    /// Contains functions which communicates with the databse.
    /// This class uses Microsoft's Enterprise library to communicate with the database
    /// </summary>
    internal class wlSQL
    {
        /// <summary>
        /// List of Sqlparameter
        /// </summary>
        private List<SqlParameter> _lstDbParam = new List<SqlParameter>();

        private string _conName="wlConnectionString";
        public string ConnectionStringName
        {
            get { return _conName; }
            set { _conName = value; }
        }

        /// <summary>
        /// Gets the complete array of the dbparameters
        /// </summary>
        private DbParameter[] Parameters
        {
            get
            {
                DbParameter[] dbParam = new DbParameter[this._lstDbParam.Count];

                for (int i = 0; i <= this._lstDbParam.Count - 1; i++)
                {
                    dbParam[i] = (SqlParameter)this._lstDbParam[i];
                }

                return dbParam;
            }
        }

        #region AddParameter
        /// <summary>
        /// Add a parameter in the array
        /// </summary>
        /// <param name="parameterName">name of the parameter</param>
        /// <param name="dbType">type of the parameter</param>
        /// <param name="parameterDirection">Direction of the parameter</param>
        /// <param name="size">Size of the parameter</param>
        /// <param name="value">value of the parameter</param>
        internal void AddParameter(string parameterName, DbType dbType, ParameterDirection parameterDirection, int size, object value)
        {
            // Initialization of a new sqlParameter object
            SqlParameter sqlParam = new SqlParameter();

            sqlParam.ParameterName = parameterName;
            sqlParam.DbType = dbType;
            sqlParam.Direction = parameterDirection;
            sqlParam.Size = size;
			sqlParam.Value = (value == null ? System.DBNull.Value : value);

            this._lstDbParam.Add(sqlParam);
        }

        /// <summary>
        /// Add a parameter in the array
        /// </summary>
        /// <param name="parameterName">name of the parameter</param>
        /// <param name="dbType">type of the parameter</param>
        /// <param name="parameterDirection">Direction of the parameter</param>
        /// <param name="size">Size of the parameter</param>
        /// <param name="value">value of the parameter</param>
        internal void AddParameter(string parameterName, SqlDbType dbType, ParameterDirection parameterDirection, int size, object value)
        {
            // Initialization of a new sqlParameter object
            SqlParameter sqlParam = new SqlParameter();

            sqlParam.ParameterName = parameterName;
            sqlParam.SqlDbType = dbType;
            sqlParam.Direction = parameterDirection;
            sqlParam.Size = size;
            sqlParam.Value = (value == null ? System.DBNull.Value : value);

            this._lstDbParam.Add(sqlParam);
        }
        #endregion

        private int _errorCode;
        public int ErrorCode
        {
            get { return _errorCode; }
        }

        #region Execute
        /// <summary>
        /// Handles the communication with the database, Constructs the list and returns to the calling layer
        /// </summary>
        /// <param name="spName">SQL String or stored procedure name</param>
        /// <returns>Returns the List of the entity</returns>
        internal IDataReader Execute(string spName)
        {
            wlParameterCollection obj = this.AddParameterCollection(this.Parameters);

            IDataReader idr = wlData.ExecuteReader(ConnectionStringName, CommandType.StoredProcedure, spName, obj);
            _errorCode = wlData.ErrorCode;
            return idr;
        }

        /// <summary>
        /// Handles the communication with the database, Constructs the list and returns to the calling layer
        /// </summary>
        /// <param name="spName">SQL String or stored procedure name</param>
        /// <param name="dbParameter">array of Dbparameter</param>
        /// <returns>Returns the List of the entity</returns>
        internal IDataReader Execute(string spName, DbParameter[] dbParameter)
        {
            wlParameterCollection obj = this.AddParameterCollection(dbParameter);

            IDataReader idr = wlData.ExecuteReader(ConnectionStringName, CommandType.StoredProcedure, spName, obj);
            _errorCode = wlData.ErrorCode;
            return idr;
        }

        /// <summary>
        /// Executes ExecuteNonQuery function
        /// </summary>
        /// <param name="spName">SQL String or stored procedure name</param>
        /// <param name="dbParameter">an array of dbparameters</param>
        /// <returns>integer value</returns>
        internal int ExecuteNonQuery(string spName, DbParameter[] dbParameter)
        {
            wlParameterCollection obj = this.AddParameterCollection(dbParameter);
            int intRetVal = wlData.ExecuteNonQuery(ConnectionStringName, CommandType.StoredProcedure, spName, obj);
            _errorCode = wlData.ErrorCode;
            return intRetVal;
        }

        /// <summary>
        /// Executes ExecuteNonQuery function
        /// </summary>
        /// <param name="spName">SQL String or stored procedure name</param>
        /// <returns>integer value</returns>
        internal int ExecuteNonQuery(string spName)
        {
            wlParameterCollection obj = this.AddParameterCollection(this.Parameters);
            int intRetVal = wlData.ExecuteNonQuery(ConnectionStringName, CommandType.StoredProcedure, spName, obj);
            _errorCode = wlData.ErrorCode;
            return intRetVal;
        }

        /// <summary>
        /// Executes ExecuteScalar function
        /// </summary>
        /// <param name="spName">SQL String or stored procedure name</param>
        /// <param name="dbParameter">an array of dbparameters</param>
        /// <returns>string value</returns>
        internal string ExecuteScalar(string spName, DbParameter[] dbParameter)
        {
            string strRetVal;
            wlParameterCollection obj = this.AddParameterCollection(dbParameter);
            strRetVal = wlData.ExecuteScalar(ConnectionStringName, CommandType.StoredProcedure, spName, obj).ToString();
            _errorCode = wlData.ErrorCode;
            return strRetVal;
        }

        /// <summary>
        /// Executes ExecuteScalar function
        /// </summary>
        /// <param name="spName">SQL String or stored procedure name</param>
        /// <returns>string value</returns>
        internal string ExecuteScalar(string spName)
        {
            string strRetVal;
            wlParameterCollection obj = this.AddParameterCollection(this.Parameters);
            strRetVal = wlData.ExecuteScalar(ConnectionStringName, CommandType.StoredProcedure, spName, obj).ToString();
            _errorCode = wlData.ErrorCode;
            return strRetVal;
        }

        /// <summary>
        /// Executes ExecuteDataSet function
        /// </summary>
        /// <param name="spName">SQL String or stored procedure name</param>
        /// <returns>return DataSet</returns>
        internal DataSet ExecuteDataSet(string spName)
        {
            wlParameterCollection obj = this.AddParameterCollection(this.Parameters);
            DataSet ds = wlData.ExecuteDataset(ConnectionStringName, CommandType.StoredProcedure, spName, obj);
            _errorCode = wlData.ErrorCode;
            
            return ds;
        }

       
        #endregion

        #region AddParameterCollection
        /// <summary>
        /// Add parameters to wlParameterCollection Class
        /// </summary>
        /// <param name="dbParam">array of Dbparameter</param>
        /// <returns>return wlParameterCollection</returns>
        private wlParameterCollection AddParameterCollection(DbParameter[] dbParam)
        {
            wlParameterCollection obj = new wlParameterCollection();
            SqlParameter p;
            foreach (DbParameter d in dbParam)
            {
                p = new SqlParameter();
                p.ParameterName = d.ParameterName;
                p.Direction = d.Direction;
                p.Value = d.Value;
                p.Size = d.Size;
                p.DbType = d.DbType;
                obj.Add(p);
            }

            return obj;
        }
        #endregion


        internal DataTable GetCSVRows(string path)
        {
            string header = "Yes";
            string sql = string.Empty;
            DataTable dataTable = null;
            string pathOnly = string.Empty;
            string fileName = string.Empty;
            try
            {
                pathOnly = Path.GetDirectoryName(path);
                fileName = Path.GetFileName(path);
                sql = @"SELECT * FROM [" + fileName + "]";
                using (OleDbConnection connection = new OleDbConnection(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                        ";Extended Properties=\"Text;HDR=" + header + "\""))
                {
                    using (OleDbCommand command = new OleDbCommand(sql, connection))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            dataTable = new DataTable();
                            dataTable.Locale = CultureInfo.CurrentCulture;
                            adapter.Fill(dataTable);

                        }
                    }
                }
            }
            finally
            {

            }
            return dataTable;

        }
		
		internal DataTable GetExcelData(string path)
        {
            string header = "Yes";
            string sql = string.Empty;
            DataTable dataTable = null;
            string pathOnly = string.Empty;
            string fileName = string.Empty;
            try
            {
                pathOnly = Path.GetDirectoryName(path);
                fileName = Path.GetFileName(path);
                sql = @"SELECT * FROM [Sheet1$]";
                using (OleDbConnection connection = new OleDbConnection(
                        @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + (pathOnly + "\\" + fileName) +
                        ";Extended Properties=\"Excel 8.0;HDR=" + header + ";IMEX=1\""))
                {
                   
                    using (OleDbCommand command = new OleDbCommand(sql, connection))
                    {
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            dataTable = new DataTable();
                            dataTable.Locale = CultureInfo.CurrentCulture;
                            adapter.Fill(dataTable);

                        }
                    }
                    

                }
            }
            finally
            {
               
            }
            return dataTable;

        }
    }
}
