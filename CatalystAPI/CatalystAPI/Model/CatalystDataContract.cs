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
        public DateTime Created { get; set; }
    }
    
    public class Answers
    {
        public int ID { get; set; }
        public int QuestionID { get; set; }
        public string Answer { get; set; }
        public int Likes { get; set; }
        public int Accepted { get; set; }
        public string Author { get; set; }
        public string Mentions { get; set; }
        public DateTime Created { get; set; }
    }
}