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
    public class GetAllQuestionsController : ApiController
    {
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
                catch (Exception ex)
                {

                }

            string jsonQuestion = JsonConvert.SerializeObject(lstQuestions);
            return jsonQuestion;
        }
    }
}
