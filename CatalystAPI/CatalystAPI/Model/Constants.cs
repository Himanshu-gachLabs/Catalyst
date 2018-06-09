using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalystAPI.Model
{
    public static class Constants
    {
        public static string SP_GetAllQuestions = "stp_GetAllQuestions";
        public static string SP_GetAllQuestionsbyID = "[dbo].[stp_GetQuestionByQuestionID]";
        public static string SP_GetAnswerByQuestionID = "[dbo].[stp_GetAnswerByQuestionID]";
        public static string CatalystDBConnectionString = "CatalystDBConnectionString";
        public static string tbl_AllQuestions = "AllQuestions";
        public static string tbl_AllAnswers = "AllAnswers";
        public static class QuestionColumns
        {
            public static string ID = "ID";
            public static string Title = "Title";
            public static string Author = "Author";
            public static string Created = "Created";
            public static string Description = "Description";
            public static string Likes = "Likes";
            public static string Mentions = "Mentions";
            public static string Tags = "Tags";
            public static string AnswersCount = "AnswersCount";
        }
        public static class AnswerColumns
        {
            public static string ID = "ID";
            public static string QuestionID = "QuestionID";
            public static string Author = "Author";
            public static string Created = "Created";
            public static string Answer = "Answer";
            public static string Likes = "Likes";
            public static string Accepted = "Accepted";
            public static string Mentions = "Mentions";
        }
    }
}