using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGasCore.Helpers
{
    /// <summary>
    /// Utility Class to Access any Database using Dapper as ORM
    /// </summary>
    /// <typeparam name="T">Object Datatype to work with</typeparam>
    public class DapperDAO<T>
    {
        static IDbConnection _dbConnection;
        /// <summary>
        /// Get Object from Database 
        /// </summary>
        /// <param name="dbConnection">Oracle or SQL Server</param>
        /// <param name="paras">Parameters</param>
        /// <param name="procName">Command Text or Stored Procedure Name</param>
        /// <param name="commandType">StoredProc or Text</param>
        /// <returns>Generic Type</returns>
        public static async Task<T> GetObjectAsync(DbConnection dbConnection, IDictionary<string, string> paras, string procName, CommandType commandType)
        {
            try
            {
                _dbConnection = dbConnection;
                IEnumerable<T> retVal;
                using (var con = _dbConnection)
                {
                    DynamicParameters dbParams = new DynamicParameters();
                    foreach (var para in paras)
                    {
                        dbParams.Add(para.Key, para.Value);
                    }
                    retVal = await SqlMapper.QueryAsync<T>(con, procName, dbParams, commandType: commandType);
                }
                return retVal.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Object from Database 
        /// </summary>
        /// <param name="dbConnection">Oracle or SQL Server</param>
        /// <param name="paras">Parameters</param>
        /// <param name="procName">Command Text or Stored Procedure Name</param>
        /// <returns>Generic Type</returns>
        public static T GetObjectNoParam(DbConnection dbConnection, IDictionary<string, string> paras, string procName)
        {
            try
            {
                _dbConnection = dbConnection;
                T retVal;
                using (var con = _dbConnection)
                {
                    DynamicParameters dbParams = new DynamicParameters();
                    foreach (var para in paras)
                    {
                        dbParams.Add(para.Key, para.Value);
                    }
                    retVal = SqlMapper.Query<T>(con, procName, dbParams, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Get Object from Database without Parameters in Dictionary Object
        /// </summary>
        /// <param name="dbConnection">Oracle or SQL Server</param>
        /// <param name="procName">Command Text or Stored Procedure Name</param>
        /// <param name="commandType">StoredProc or Text</param>
        /// <returns>Generic Type</returns>
        public static T GetObject(DbConnection dbConnection, string procName, CommandType commandType)
        {
            try
            {
                _dbConnection = dbConnection;
                T retVal;
                using (var con = _dbConnection)
                {
                    retVal = SqlMapper.Query<T>(con, procName, commandType: commandType).FirstOrDefault();
                }
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Get Object List from Database 
        /// </summary>
        /// <param name="dbConnection">Oracle or SQL Server</param>
        /// <param name="paras">Parameters</param>
        /// <param name="procName">Command Text or Stored Procedure Name</param>
        /// <param name="commandType">StoredProc or Text</param>
        /// <returns></returns>
        public static async Task<List<T>> GetListAsync(DbConnection dbConnection, IDictionary<string, string> paras, string procName, CommandType commandType)
        {
            try
            {
                _dbConnection = dbConnection;
                List<T> retVal;
                using (var con = _dbConnection)
                {
                    DynamicParameters dbParams = new DynamicParameters();
                    foreach (var para in paras)
                    {
                        dbParams.Add(para.Key, para.Value);
                    }

                    retVal = (await SqlMapper.QueryAsync<T>(_dbConnection, procName, dbParams, commandType: commandType)).ToList();
                }
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Object List from Database 
        /// </summary>
        /// <param name="dbConnection">Oracle or SQL Server</param>
        /// <param name="paras">Parameters</param>
        /// <param name="procName">Command Text or Stored Procedure Name</param>
        /// <returns></returns>
        public static List<T> GetListWithParam(DbConnection dbConnection, IDictionary<string, string> paras, string procName)
        {
            try
            {
                _dbConnection = dbConnection;
                List<T> retVal;
                using (var con = _dbConnection)
                {
                    DynamicParameters dbParams = new DynamicParameters();
                    foreach (var para in paras)
                    {
                        dbParams.Add(para.Key, para.Value);
                    }

                    retVal = SqlMapper.Query<T>(_dbConnection, procName, dbParams, commandType: CommandType.StoredProcedure).ToList();
                }
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Object List from Database without Parameters in Dictionary Object
        /// </summary>
        /// <param name="dbConnection">Oracle or SQL Server</param>
        /// <param name="procName">Command Text or Stored Procedure Name</param>
        /// <param name="commandType">StoredProc or Text</param>
        /// <returns></returns>
        public static List<T> GetList(DbConnection dbConnection, string procName, CommandType commandType)
        {
            try
            {
                _dbConnection = dbConnection;
                List<T> retVal;
                using (var con = _dbConnection)
                {
                    retVal = SqlMapper.Query<T>(_dbConnection, procName, commandType: commandType).ToList();
                }
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get Object List from Database without Parameters in Dictionary Object
        /// </summary>
        /// <param name="dbConnection">Oracle or SQL Server</param>
        /// <param name="procName">Command Text or Stored Procedure Name</param>
        /// <returns></returns>
        public static List<T> GetListNoParam(DbConnection dbConnection, string procName)
        {
            try
            {
                _dbConnection = dbConnection;
                List<T> retVal;
                using (var con = _dbConnection)
                {
                    retVal = SqlMapper.Query<T>(_dbConnection, procName).ToList();
                }
                return retVal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Insert Object to Database 
        /// </summary>
        /// <param name="dbConnection">Oracle or SQL Server</param>
        /// <param name="paras">Parameters</param>
        /// <param name="procName">Command Text or Stored Procedure Name</param>
        /// <param name="commandType">StoredProc or Text</param>
        /// <returns>Generic Type</returns>
        public static async Task<T> SetObject(DbConnection dbConnection, IDictionary<string, string> paras, string procName, CommandType commandType)
        {
            try
            {
                _dbConnection = dbConnection;
                IEnumerable<T> retVal;
                using (var con = _dbConnection)
                {
                    DynamicParameters dbParams = new DynamicParameters();
                    foreach (var para in paras)
                    {
                        dbParams.Add(para.Key, para.Value);
                    }
                    retVal = await SqlMapper.QueryAsync<T>(con, procName, dbParams, commandType: commandType);
                }
                return retVal.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Insert Object to Database 
        /// </summary>
        /// <param name="dbConnection">Oracle or SQL Server</param>
        /// <param name="paras">Parameters</param>
        /// <param name="procName">Command Text or Stored Procedure Name</param>
        /// <param name="commandType">StoredProc or Text</param>
        /// <returns>Generic Type</returns>
        public static async Task<T> SetObjectGetOpenDirectionParam(DbConnection dbConnection, dynamic paras, string procName, CommandType commandType)
        {
            try
            {
                _dbConnection = dbConnection;
                IEnumerable<T> retVal;
                using (var con = _dbConnection)
                {
                    retVal = await SqlMapper.QueryAsync<T>(con, procName, paras, commandType: commandType);


                    return retVal.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
