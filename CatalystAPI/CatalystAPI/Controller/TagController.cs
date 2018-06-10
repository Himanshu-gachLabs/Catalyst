using CatalystAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;

namespace CatalystAPI.Controller
{
    public class TagsController : ApiController
    {
        // GET: api/Tags
        public string Get()
        {
            List<Tags> lstTags = new List<Tags>();
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
    ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(Constants.SP_AllTags, connection);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataSet ds = new DataSet();
                        da.Fill(ds, Constants.SP_AllTags);

                        DataTable dt = ds.Tables[Constants.SP_AllTags];
                        if (dt.Rows.Count > 0)
                        {
                            lstTags = (from DataRow row in dt.Rows
                                            select new Tags
                                            {
                                                ID = int.Parse(row[Constants.TagsColumns.ID].ToString()),
                                                Name = row[Constants.TagsColumns.Name].ToString(),
                                                Description = row[Constants.TagsColumns.Description].ToString(),
                                                UserCount = int.Parse(row[Constants.TagsColumns.UserCount].ToString())

                                            }).ToList();
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            string jsonTags = JsonConvert.SerializeObject(lstTags);
            return jsonTags;
        }

        // GET: api/Tags/5
        public void Get(int id)
        {

        }

        // POST: api/Tags
        public string Post([FromBody]Tags objTag)
        {
            string result;

            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
        ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand(Constants.SP_SetTag, connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = objTag.Name;
                    da.SelectCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value = objTag.Description;

                    connection.Open();
                    int i = da.SelectCommand.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {
                        result = "Tag Added Succesfully";

                    }
                    else
                    {
                        result = "Tag Addition Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                Error objError = new Error();
                objError.Method = "SP_SetTag";
                objError.Params = objTag.Name + "," + objTag.Description;
                objError.StackTrace = ex.StackTrace;
                objError.Message = ex.Message;
                objError.Source = ex.Source;

                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
        ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand(Constants.SP_SetError, connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Method", SqlDbType.NVarChar, 50).Value = objError.Method;
                    da.SelectCommand.Parameters.Add("@Params", SqlDbType.NVarChar, 1000).Value = objError.Params;
                    da.SelectCommand.Parameters.Add("@StackTrace", SqlDbType.NVarChar, 500).Value = objError.StackTrace;
                    da.SelectCommand.Parameters.Add("@Message", SqlDbType.NVarChar, 250).Value = objError.Message;
                    da.SelectCommand.Parameters.Add("@Source", SqlDbType.NVarChar, 250).Value = objError.Source;
                    connection.Open();
                    int i = da.SelectCommand.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {
                        result = "Tag Addition Error Logged Succesfully";
                    }
                    else
                    {
                        result = "Tag Addition Error Log Failed";
                    }
                }
            }
            return result;
        }

        // PUT: api/Tags/5
        public void Put(int id, [FromBody]Tags objTag)
        {
        }

        // DELETE: api/Tags/5
        public void Delete(int id)
        {
        }
    }
}
