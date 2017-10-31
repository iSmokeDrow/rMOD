using System.Collections.Generic;
using System.Collections.Specialized;
using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using rdbCore.Structures;

namespace rMOD.Functions
{
    public class Database
    {
        static string scriptDir
        {
            get
            {
                string dir = string.Format(@"{0}\Scripts\", Directory.GetCurrentDirectory());
                if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
                return dir;
            }
        }

        private static string connectionString
        {
            get
            {
                string conString = string.Format("Server={0};Database={1};", OPT.GetString("db.ip"), OPT.GetString("db.world.name"));
                if (OPT.GetString("db.trusted.connection") == "1") { conString += "Trusted_Connection=True;"; }
                else { conString += string.Format("uid={0};pwd={1};", OPT.GetString("db.world.user"), OPT.GetString("db.world.password")); }

                return conString;
            }
        }

        /// <summary>
        /// Creates a new SqlConnection for future uses
        /// </summary>
        /// <returns>Prepared SqlConnection</returns>
        static SqlConnection sqlCon { get { return new SqlConnection(connectionString); } }
        static ServerConnection con = new ServerConnection(sqlCon);
        static Server sv = new Server(con);
        static Microsoft.SqlServer.Management.Smo.Database db = sv.Databases[OPT.GetString("db.world.name")];

        static string generateSelect(string tableName)
        {
            string statement = string.Empty;

            if (GUI.Instance.rCore.UseSelectStatement) { statement = GUI.Instance.rCore.SelectStatement; }
            else
            {
                statement = "SELECT ";

                List<LuaField> fieldList = GUI.Instance.rCore.FieldList;

                foreach (LuaField field in fieldList) { if (field.Show) { statement += string.Format("[{0}],", field.Name); } }

                statement = string.Format("{0} FROM dbo.{1}", statement.Remove(statement.Length - 1, 1), tableName);
            }

            return statement;
        }

        public static int FetchRowCount(string tableName)
        {
            try
            {
                DataSet ds = db.ExecuteWithResults(string.Format("SELECT COUNT(*) FROM dbo.{0}", tableName));
                return (int)ds.Tables[0].Rows[0][0];
            }
            catch (Exception ex) { MessageBox.Show(string.Format("SQL Error:\n\n{0}", ex.Message), "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return 0;    
        }

        public static List<Row> FetchTable(int rowCount, string tableName)
        {
            GUI.Instance.UpdateProgressMaximum(rowCount);

            List<Row> data = new List<Row>(rowCount);

            List<LuaField> fieldList = GUI.Instance.rCore.FieldList;

            try
            {
                using (SqlCommand sqlCmd = new SqlCommand(generateSelect(tableName), sqlCon))
                {
                    sqlCmd.Connection.Open();

                    using (SqlDataReader sqlRdr = sqlCmd.ExecuteReader())
                    {
                        int curRow = 0;

                        while (sqlRdr.Read())
                        {
                            Row newRow = new Row(fieldList);

                            for (int i = 0; i < fieldList.Count; i++)
                            {
                                LuaField field = fieldList[i];

                                if (field.Show)
                                {
                                    object fieldVal = sqlRdr[field.Name];

                                    switch (field.Type)
                                    {
                                        case "short":
                                            newRow[i] = Convert.ToInt16(sqlRdr[field.Name]);
                                            break;

                                        case "ushort":
                                            newRow[i] = Convert.ToUInt16(sqlRdr[field.Name]);
                                            break;

                                        case "int":
                                            newRow[i] = (fieldVal.GetType() == typeof(DBNull)) ? 0 : Convert.ToInt32(fieldVal);
                                            break;

                                        case "uint":
                                            newRow[i] = Convert.ToInt32(sqlRdr[field.Name]);
                                            break;

                                        case "long":
                                            newRow[i] = Convert.ToInt64(sqlRdr[field.Name]);
                                            break;

                                        case "byte":
                                            byte val = new byte();
                                            newRow[i] = (Byte.TryParse(fieldVal.ToString(), out val)) ? val : 0;
                                            break;

                                        case "bitfromvector":
                                            newRow[i] = Convert.ToInt32(sqlRdr[field.Name]);
                                            break;

                                        case "datetime":
                                            newRow[i] = Convert.ToDateTime(sqlRdr[field.Name]);
                                            break;

                                        case "decimal":
                                            newRow[i] = Convert.ToDecimal(sqlRdr[field.Name]);
                                            break;

                                        case "single":
                                            newRow[i] = Convert.ToSingle(sqlRdr[field.Name]);
                                            break;

                                        case "double":
                                            newRow[i] = Convert.ToDouble(sqlRdr[field.Name]);
                                            break;

                                        case "sid":
                                            newRow[i] = Convert.ToInt32(sqlRdr[field.Name]);
                                            break;

                                        case "string":
                                            newRow[i] = Convert.ToString(sqlRdr[field.Name]);
                                            break;

                                        case "stringbylen":
                                            newRow[i] = Convert.ToString(sqlRdr[field.Name]);
                                            break;

                                        case "stringbyref":
                                            newRow[i] = Convert.ToString(sqlRdr[field.Name]);
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (field.Type)
                                    {
                                        case "bitvector":
                                            newRow[i] = new BitVector32(0);
                                            break;

                                        case "byte":
                                            newRow[i] = Convert.ToByte(field.Default);
                                            break;

                                        case "int":
                                            newRow[i] = (newRow.KeyIsDuplicate(field.Name)) ? newRow.GetShownValue(field.Name) : field.Default;
                                            break;

                                        case "short":
                                            newRow[i] = Convert.ToInt16(field.Default);
                                            break;

                                        case "string":
                                            newRow[i] = field.Default.ToString();
                                            break;
                                    }
                                }
                            }

                            data.Add(newRow);
                            curRow++;
                            if (((curRow * 100) / rowCount) != ((curRow - 1) * 100 / rowCount)) { GUI.Instance.UpdateProgressValue(curRow); }
                        }
                    }
                }
            }
            catch (SqlException ex) { MessageBox.Show(string.Format("SQL Error:\n\n{0}", ex.Message), "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                GUI.Instance.UpdateProgressMaximum(100);
                GUI.Instance.UpdateProgressValue(0);
            }

            return data;
        }

        public static void ExportToTable(List<Row> data, string tableName)
        {
            try
            {
                if (OPT.GetBool("db.save.backup")) { scriptTable(tableName, true); }

                using (SqlCommand sqlCmd = new SqlCommand("", sqlCon))
                {
                    sqlCmd.Connection.Open();
                    if (OPT.GetBool("db.save.drop"))
                    {
                        scriptTable(tableName, false);
                        sqlCmd.CommandText = string.Format("DROP TABLE {0}", tableName);
                        sqlCmd.ExecuteNonQuery();
                        string script = new StreamReader(string.Format(@"{0}\{1}_{2}_so.sql", scriptDir, tableName, DateTime.Now.ToString("hhMMddyyy"))).ReadToEnd();
                        db.ExecuteNonQuery(script);
                    }
                    else { sqlCmd.CommandText = string.Format("TRUNCATE TABLE {0}", tableName); sqlCmd.ExecuteNonQuery(); }

                    sqlCmd.Connection.Close();
                }

                SqlCommand insertCmd = GUI.Instance.rCore.InsertStatement;
                insertCmd.Connection = sqlCon;
                insertCmd.CommandText = insertCmd.CommandText.Replace("<tableName>", tableName);

                int rows = data.Count;
                GUI.Instance.UpdateProgressMaximum(rows);
                for (int rowIdx = 0; rowIdx < rows; rowIdx++)
                {
                    Row row = data[rowIdx];
                    using (SqlCommand sqlCmd = insertCmd)
                    {
                        foreach (SqlParameter sqlParam in sqlCmd.Parameters) { sqlParam.Value = row[sqlParam.ParameterName]; }
                        sqlCmd.Connection.Open();
                        sqlCmd.ExecuteNonQuery();
                        sqlCmd.Connection.Close();
                    }

                    if (((rowIdx * 100) / rows) != ((rowIdx - 1) * 100 / rows)) { GUI.Instance.UpdateProgressValue(rowIdx); }
                }
            }
            catch (Exception ex) { MessageBox.Show(string.Format("SQL Error:\n\n{0}", ex.Message), "SQL Exception", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally
            {
                GUI.Instance.UpdateProgressValue(0);
                GUI.Instance.UpdateProgressMaximum(100);
            }           
        }

        /// <summary>
        /// Create a .sql containing the create and insert scripts necessary to recreate the table in its current state
        /// </summary>
        /// <param name="tableName">Target table being scripted</param>
        public static void scriptTable(string tableName, bool scriptData)
        {
            ScriptingOptions opts = new ScriptingOptions()
            {
                ScriptData = scriptData,
                ScriptDrops = false,
                ScriptSchema = true,
                FileName = string.Format(@"{0}\{1}_{2}{3}.sql", scriptDir, tableName, DateTime.Now.ToString("hhMMddyyyy"), (!scriptData) ? "_so" : string.Empty)               
            };
            db.Tables[tableName].EnumScript(opts);
        }
    }
}
