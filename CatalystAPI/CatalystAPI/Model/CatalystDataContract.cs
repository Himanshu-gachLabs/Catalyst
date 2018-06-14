using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalystAPI.Model
{
    public class Question
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public List<Answers> Answers { get; set; }
        public int AnswersCount { get; set; }
        public string Tags { get; set; }
        public string Author { get; set; }
        public string Mentions { get; set; }
        public string UserID { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }

    }

    public class Answers
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Answer { get; set; }
        public int Likes { get; set; }
        public int Unlikes { get; set; }
        public int Accepted { get; set; }
        public string Author { get; set; }
        public string Mentions { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }

    }
    public class Comments
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public string Mentions { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }

    }
    public class Tags
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserCount { get; set; }
        public DateTime Created { get; set; }
        public bool IsActive { get; set; }
        public bool IsPopular { get; set; }
    }
    public class Like
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public bool IsLiked { get; set; }
    }

    public class Error
    {
        public int ID { get; set; }
        public string Method { get; set; }
        public string Params { get; set; }
        public string StackTrace { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
    }
}
