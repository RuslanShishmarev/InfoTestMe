using InfoTestMe.Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace InfoTestMe.Admin.Web.Models.Data.Extensions
{
    public static class TestQuestionExtensions
    {
        public static TestQuestionDTO ToDTO(this TestQuestion testQuestion)
        {
            List<TestAnswerDTO> answers = JsonConvert.DeserializeObject<List<TestAnswerDTO>>(testQuestion.Answers);

            return new TestQuestionDTO()
            {
                Id = testQuestion.Id,
                TestId = testQuestion.TestId,
                Text = testQuestion.Text,
                Image = testQuestion.Image,
                Answers = answers,
            };
        }
    }
}