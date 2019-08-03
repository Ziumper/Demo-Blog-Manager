using System;

namespace Blog.Bll.Services.Parsing {

    public class ParserService : IParserService
    {
        public int ParseUserId(string userId)
        {
            return Int32.Parse(userId);
        }
    }
}