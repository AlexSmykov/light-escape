using System;

namespace Hints
{
    public class HintCreate
    {
        public float x { get; set; }
        public float y { get; set; }
        public string message { get; set; }
        public string author_token { get; set; }

        public HintCreate(float x, float y, string message, string authorToken)
        {
            this.x = x;
            this.y = y;
            this.message = message;
            author_token = authorToken;
        }
    }

    public class HintGet
    {
        public int id { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public bool is_administrative { get; set; }
        public string message { get; set; }
        public string author_token { get; set; }
        public DateTime created { get; set; }
        public bool liked_by_me { get; set; }
        public bool is_mine { get; set; }
    }

    public class LikeCreate
    {
        public string user_token { get; set; }
    }
}