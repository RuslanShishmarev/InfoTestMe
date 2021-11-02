using InfoTestMe.Common.Models;
using System.Linq;

namespace InfoTestMe.Admin.Web.Models.Data.Extensions
{
    public static class TestQuestionExtensions
    {
        public static TestQuestionDTO ToDTO(this TestQuestion testQuestion)
        {
            return new TestQuestionDTO()
            {
                Id = testQuestion.Id,
                Text = testQuestion.Text,
                Image = testQuestion.Image,
                Answers = testQuestion.Answers?.Select(c => c.Id).ToList(),
            };
        }
    }
}