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
        public static string SP_AllTags = "[dbo].[stp_GetAllTags]";
        public static string tbl_AllAnswers = "AllAnswers";
        public static string SP_SetQuestion = "[dbo].[stp_SetQuestion]";
        public static string stp_SetSubscribedTags = "[dbo].[stp_SetSubscribedTags]";
        public static string SP_SetError = "[dbo].[stp_SetEror]";
        public static string SP_UpdateQuestion = "[dbo].[stp_UpdateQuestion]";
        public static string SP_SetAnswer = "[dbo].[stp_SetAnswer]";
        public static string SP_SetComment = "[dbo].[stp_SetComment]";
        public static string SP_SetTag = "[dbo].[stp_SetTag]";
        public static string SP_DeleteQuestion = "[dbo].[stp_DeleteQuestion]";
        public static string SP_LikeQuestion = "[dbo].[stp_LikeQuestion]";
        public static string SP_LikeAnswer = "[dbo].[stp_LikeAnswer]";



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
        public static class TagsColumns
        {
            public static string ID = "ID";
            public static string Name = "Name";
            public static string Description = "Description";
            public static string UserCount = "UserCount";

        }
    }
}