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
    public class QuestionsController : ApiController
    {
        // GET: api/Questions
        public string Get()
        {
            List<Question> lstQuestions = new List<Question>();
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
    ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(Constants.SP_GetAllQuestions, connection);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;

                        DataSet ds = new DataSet();
                        da.Fill(ds, Constants.tbl_AllQuestions);

                        DataTable dt = ds.Tables[Constants.tbl_AllQuestions];
                        if (dt.Rows.Count > 0)
                        {
                            lstQuestions = (from DataRow row in dt.Rows
                                            select new Question
                                            {
                                                ID = int.Parse(row[Constants.QuestionColumns.ID].ToString()),
                                                Title = row[Constants.QuestionColumns.Title].ToString(),
                                                Author = row[Constants.QuestionColumns.Author].ToString(),
                                                Created = DateTime.Parse(row[Constants.QuestionColumns.Created].ToString()),
                                                Description = row[Constants.QuestionColumns.Description].ToString(),
                                                Likes = int.Parse(row[Constants.QuestionColumns.Likes].ToString()),
                                                Mentions = row[Constants.QuestionColumns.Mentions].ToString(),
                                                Tags = row[Constants.QuestionColumns.Tags].ToString(),
                                                AnswersCount = int.Parse(row[Constants.QuestionColumns.AnswersCount].ToString())

                                            }).ToList();
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            string jsonQuestion = JsonConvert.SerializeObject(lstQuestions);
            return jsonQuestion;
            //return lstQuestions;
        }

        // GET: api/Questions/5
        public string Get(int id)
        {
            Question objQuestion = new Question();
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
    ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(Constants.SP_GetAllQuestionsbyID, connection);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@questID", SqlDbType.Int, 50).Value = id;

                        DataSet ds = new DataSet();
                        da.Fill(ds, Constants.tbl_AllQuestions);

                        DataTable dt = ds.Tables[Constants.tbl_AllQuestions];
                        if (dt.Rows.Count > 0)
                        {
                            objQuestion = (from DataRow row in dt.Rows
                                           select new Question
                                           {
                                               ID = int.Parse(row[Constants.QuestionColumns.ID].ToString()),
                                               Title = row[Constants.QuestionColumns.Title].ToString(),
                                               Author = row[Constants.QuestionColumns.Author].ToString(),
                                               Created = DateTime.Parse(row[Constants.QuestionColumns.Created].ToString()),
                                               Description = row[Constants.QuestionColumns.Description].ToString(),
                                               Likes = int.Parse(row[Constants.QuestionColumns.Likes].ToString()),
                                               Mentions = row[Constants.QuestionColumns.Mentions].ToString(),
                                               Tags = row[Constants.QuestionColumns.Tags].ToString()
                                           }).FirstOrDefault();
                        }
                    }

                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(Constants.SP_GetAnswerByQuestionID, connection);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        da.SelectCommand.Parameters.Add("@questID", SqlDbType.Int, 50).Value = id;

                        DataSet ds = new DataSet();
                        da.Fill(ds, Constants.tbl_AllAnswers);

                        DataTable dt = ds.Tables[Constants.tbl_AllAnswers];
                        if (dt.Rows.Count > 0)
                        {
                            List<Answers> lstAnswers = new List<Answers>();
                            lstAnswers = (from DataRow row in dt.Rows
                                          select new Answers
                                          {
                                              ID = int.Parse(row[Constants.AnswerColumns.ID].ToString()),
                                              Answer = row[Constants.AnswerColumns.Answer].ToString(),
                                              Author = row[Constants.AnswerColumns.Author].ToString(),
                                              Created = DateTime.Parse(row[Constants.AnswerColumns.Created].ToString()),
                                              Accepted = int.Parse(row[Constants.AnswerColumns.Accepted].ToString()),
                                              Likes = int.Parse(row[Constants.AnswerColumns.Likes].ToString()),
                                              QuestionID = int.Parse(row[Constants.AnswerColumns.QuestionID].ToString()),
                                              Mentions = row[Constants.AnswerColumns.Mentions].ToString()
                                          }).ToList();

                            objQuestion.Answers = lstAnswers;
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            string jsonQuestion = JsonConvert.SerializeObject(objQuestion);
            return jsonQuestion;
            //return lstQuestions;
        }

        // POST: api/Questions
        public string Post([FromBody]Question objQuestion)
        {
             string result;
            //Question objQuestion = new Question();
            //objQuestion = (JsonConvert.DeserializeObject(value)) as Question;
            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
        ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand(Constants.SP_SetQuestion, connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 250).Value = objQuestion.Title;
                    da.SelectCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 4000).Value = objQuestion.Description;
                    da.SelectCommand.Parameters.Add("@Likes", SqlDbType.Int).Value = objQuestion.Likes;
                    da.SelectCommand.Parameters.Add("@Tags", SqlDbType.NVarChar, 250).Value = objQuestion.Tags;
                    da.SelectCommand.Parameters.Add("@Author", SqlDbType.NVarChar, 250).Value = objQuestion.Author;
                    da.SelectCommand.Parameters.Add("@Mentions", SqlDbType.NVarChar, 250).Value = objQuestion.Mentions;
                    connection.Open();
                    int i = da.SelectCommand.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {
                        result = "Question Added Succesfully";

                    }
                    else
                    {
                        result = "Question Addition Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                Error objError = new Error();
                objError.Method = "SP_SetError";
                objError.Params = objQuestion.Title + "," + objQuestion.Description + "," + objQuestion.Likes + "," + objQuestion.Tags + "," + objQuestion.Author + "," + objQuestion.Mentions;
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
                        result = "Question Addition Error Logged Succesfully";
                    }
                    else
                    {
                        result = "Question Addition Error Log Failed";
                    }
                }
            }
            return result;
        }

        // PUT: api/Questions/5
        public string Put(int id, [FromBody]Question objQuestion)
        {
            string result;
            //Question objQuestion = new Question();
            //objQuestion = (JsonConvert.DeserializeObject(value)) as Question;
            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
        ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand(Constants.SP_UpdateQuestion, connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if(objQuestion.Title != null)
                        da.SelectCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 250).Value = objQuestion.Title;
                    if(objQuestion.Description!= null)
                        da.SelectCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 4000).Value = objQuestion.Description;
                    if(objQuestion.Likes >= 0)
                        da.SelectCommand.Parameters.Add("@Likes", SqlDbType.Int).Value = objQuestion.Likes;
                    if (objQuestion.Tags != null)
                        da.SelectCommand.Parameters.Add("@Tags", SqlDbType.NVarChar, 250).Value = objQuestion.Tags;
                    if (objQuestion.Author != null)
                        da.SelectCommand.Parameters.Add("@Author", SqlDbType.NVarChar, 250).Value = objQuestion.Author;
                    if (objQuestion.Mentions != null)
                        da.SelectCommand.Parameters.Add("@Mentions", SqlDbType.NVarChar, 250).Value = objQuestion.Mentions;
                    connection.Open();
                    int i = da.SelectCommand.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {
                        result = "Question Updated Succesfully";
                    }
                    else
                    {
                        result = "Question Updation Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                Error objError = new Error();
                objError.Method = "SP_SetError";
                objError.Params = objQuestion.Title + "," + objQuestion.Description + "," + objQuestion.Likes + "," + objQuestion.Tags + "," + objQuestion.Author + "," + objQuestion.Mentions;
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
                        result = "Quesiton Updation Error Logged Succesfully";
                    }
                    else
                    {
                        result = "Question Updation Error Log Failed";
                    }
                }
            }
            return result;
        }

        // DELETE: api/Questions/5
        public void Delete(int id)
        {
        }
    }
}
