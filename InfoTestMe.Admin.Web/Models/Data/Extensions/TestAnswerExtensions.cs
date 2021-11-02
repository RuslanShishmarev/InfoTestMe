using InfoTestMe.Common.Models;

namespace InfoTestMe.Admin.Web.Models.Data.Extensions
{
    public static class TestAnswerExtensions
    {
        public static TestAnswerDTO ToDTO(this TestAnswer testAnswer)
        {
            return new TestAnswerDTO()
            {
                Id = testAnswer.Id,
                Text = testAnswer.Text,
                IsRight = testAnswer.IsRight,
            };
        }
    }
}