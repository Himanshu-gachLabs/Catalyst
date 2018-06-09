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
    public class AnswersController : ApiController
    {
        // GET: api/Answers
        public void Get()
        {
            
        }

        // GET: api/Answers/5
        public void Get(int id)
        {
            
        }

        // POST: api/Answers
        public string Post([FromBody]Answers objAnswer)
        {
            string result;

            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
        ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand(Constants.SP_SetAnswer, connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@QuestionID", SqlDbType.Int).Value = objAnswer.QuestionID;
                    da.SelectCommand.Parameters.Add("@Likes", SqlDbType.Int).Value = objAnswer.Likes;
                    da.SelectCommand.Parameters.Add("@Accepted", SqlDbType.Int).Value = objAnswer.Accepted;
                    da.SelectCommand.Parameters.Add("@Author", SqlDbType.NVarChar, 50).Value = objAnswer.Author;
                    da.SelectCommand.Parameters.Add("@Mentions", SqlDbType.NVarChar, 250).Value = objAnswer.Mentions;
                    da.SelectCommand.Parameters.Add("@Answer", SqlDbType.NVarChar, 4000).Value = objAnswer.Answer;

                    connection.Open();
                    int i = da.SelectCommand.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {
                        result = "Answer Added Succesfully";

                    }
                    else
                    {
                        result = "Answer Addition Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                Error objError = new Error();
                objError.Method = "SP_SetAnswer";
                objError.Params = objAnswer.QuestionID + "," + objAnswer.Likes + "," + objAnswer.Accepted + "," + objAnswer.Author + "," + objAnswer.Mentions + "," + objAnswer.Answer;
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
                        result = "Answer Addition Error Logged Succesfully";
                    }
                    else
                    {
                        result = "Answer Addition Error Log Failed";
                    }
                }
            }
            return result;
        }

        // PUT: api/Answers/5
        public void Put(int id, [FromBody]Question objQuestion)
        {
        }

        // DELETE: api/Answers/5
        public void Delete(int id)
        {
        }
    }
}
