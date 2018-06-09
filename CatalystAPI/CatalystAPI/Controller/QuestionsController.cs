using CatalystAPI.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
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
                                                AnswersCount = 5

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
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Questions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Questions/5
        public void Delete(int id)
        {
        }
    }
}
