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
    public class CommentsController : ApiController
    {
        // GET: api/Comments
        public void Get()
        {

        }

        // GET: api/Comments/5
        public void Get(int id)
        {

        }

        // POST: api/Comments
        public string Post([FromBody]Comments objComment)
        {
            string result;

            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
        ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand(Constants.SP_SetComment, connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@QuestionID", SqlDbType.Int).Value = objComment.QuestionID;
                    da.SelectCommand.Parameters.Add("@Author", SqlDbType.NVarChar, 50).Value = objComment.Author;
                    da.SelectCommand.Parameters.Add("@Mentions", SqlDbType.NVarChar, 250).Value = objComment.Mentions;
                    da.SelectCommand.Parameters.Add("@Comment", SqlDbType.NVarChar, 500).Value = objComment.Comment;

                    connection.Open();
                    int i = da.SelectCommand.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {
                        result = "Comment Added Succesfully";

                    }
                    else
                    {
                        result = "Comment Addition Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                Error objError = new Error();
                objError.Method = "SP_SetComment";
                objError.Params = objComment.QuestionID + "," + objComment.Author + "," + objComment.Mentions + "," + objComment.Comment;
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
                        result = "Comment Addition Error Logged Succesfully";
                    }
                    else
                    {
                        result = "Comment Addition Error Log Failed";
                    }
                }
            }
            return result;
        }

        // PUT: api/Comments/5
        public void Put(int id, [FromBody]Question objQuestion)
        {
        }

        // DELETE: api/Comments/5
        public void Delete(int id)
        {
        }
    }
}
