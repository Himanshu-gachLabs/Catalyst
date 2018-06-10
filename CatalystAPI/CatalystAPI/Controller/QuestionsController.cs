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

        [HttpGet]
        [Route("api/Question/GetAllByTag/{Tag}")]
        public string QuestionGetAllByTag(string Tag)
        {
            List<Question> lstQuestions = new List<Question>();
            using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
    ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))
                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = new SqlCommand(Constants.SP_GetAllQuestionsByTag, connection);
                        da.SelectCommand.CommandType = CommandType.StoredProcedure;
                        if(Tag != "All")
                            da.SelectCommand.Parameters.Add("@Tag", SqlDbType.NVarChar, 50).Value = Tag;

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
                { 
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand(Constants.SP_SetQuestion, connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 250).Value = objQuestion.Title;
                    da.SelectCommand.Parameters.Add("@Description", SqlDbType.NVarChar, 4000).Value = objQuestion.Description;
                    da.SelectCommand.Parameters.Add("@Tags", SqlDbType.NVarChar, 250).Value = objQuestion.Tags;
                    da.SelectCommand.Parameters.Add("@Author", SqlDbType.NVarChar, 250).Value = objQuestion.Author;
                    da.SelectCommand.Parameters.Add("@Mentions", SqlDbType.NVarChar, 250).Value = objQuestion.Mentions;
                        da.SelectCommand.Parameters.Add("@UserID", SqlDbType.NVarChar, 250).Value = objQuestion.UserID;
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
            }
            catch (Exception ex)
            {
                Error objError = new Error();
                objError.Method = "SP_SetError";
                objError.Params = objQuestion.Title + "," + objQuestion.Description + "," + objQuestion.Tags + "," + objQuestion.Author + "," + objQuestion.Mentions;
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
                    da.SelectCommand.Parameters.Add("@QuestID", SqlDbType.Int).Value = id;
                    if (objQuestion.Title != null)
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
                    if (objQuestion.IsActive != null)
                        da.SelectCommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = objQuestion.IsActive;
                    SqlParameter retValue = da.SelectCommand.Parameters.Add("return", SqlDbType.Int);
                    retValue.Direction = ParameterDirection.ReturnValue;
                    connection.Open();
                    int i = da.SelectCommand.ExecuteNonQuery();
                    connection.Close();
                    if (int.Parse(retValue.Value.ToString()) >= 1)
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
                objError.Params = objQuestion.Title + "," + objQuestion.Description + "," + objQuestion.Likes + "," + objQuestion.Tags + "," + objQuestion.Author + "," + objQuestion.Mentions + "," + objQuestion.IsActive;
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
        public string Delete(int id)
        {
            string result;
            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
        ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand(Constants.SP_DeleteQuestion, connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                    connection.Open();
                    int i = da.SelectCommand.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {
                        result = "Question Deleted Succesfully";

                    }
                    else
                    {
                        result = "Question Deletion Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                Error objError = new Error();
                objError.Method = "SP_DeleteQuestion";
                objError.Params = id.ToString();
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
                        result = "Question Deletion Error Logged Succesfully";
                    }
                    else
                    {
                        result = "Question Deletion Error Log Failed";
                    }
                }
            }
            return result;
        }

        [HttpPost]
        [Route("api/Questions/like")]
        public string QuestionLike([FromBody]Like objLike)
        { 
            string result;
            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.
        ConnectionStrings[Constants.CatalystDBConnectionString].ConnectionString))

                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand(Constants.SP_LikeQuestion, connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand.Parameters.Add("@QuestID", SqlDbType.Int).Value = objLike.ID;
                    da.SelectCommand.Parameters.Add("@LikerID", SqlDbType.NVarChar,50).Value = objLike.UserID;
                    da.SelectCommand.Parameters.Add("@LikerName", SqlDbType.NVarChar, 100).Value = objLike.UserName;

                    connection.Open();
                    int i = da.SelectCommand.ExecuteNonQuery();
                    connection.Close();
                    if (i >= 1)
                    {
                        result = "Question Liked Succesfully";

                    }
                    else
                    {
                        result = "Question Liking Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                Error objError = new Error();
                objError.Method = "SP_LikeQuestion";
                objError.Params = objLike.ID.ToString();
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
                        result = "Question Liking Error Logged Succesfully";
                    }
                    else
                    {
                        result = "Question Liking Error Log Failed";
                    }
                }
            }
            result = "Liked " + objLike.ID + " sdc";
            return result;
        }

        [HttpPost]
        [Route("api/Questions/dislike")]
        public string QuestionDisLike([FromBody]Dislike objDislike)
        {
            return "DisLiked " + objDislike.ID + " sdc";
        }
    }
}
