using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalystAPI.Model
{
    [Serializable]
    public class Question
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public string Tags { get; set; }
        public string Author { get; set; }
        public string Mentions { get; set; }
        public DateTime Created { get; set; }
    }
}