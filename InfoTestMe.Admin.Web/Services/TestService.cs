using InfoTestMe.Admin.Web.Models.Abstractions;
using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Admin.Web.Models.Data.Extensions;
using InfoTestMe.Common.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Services
{
    public class TestService : CommonService<TestDTO>, ITestService
    {
        public TestService(InfoTestMeDataContext db) : base(db) { }

        #region PRIVATE METHODS
        private Test GetTest(int id)
        {
            var test = DB.Tests.Include(t => t.Questions).FirstOrDefault(t => t.Id == id);
            return test;
        }
        private void CreateTest(TestDTO dto)
        {
            Test test = new Test()
            {
                AuthorId = dto.AuthorId,
                Name = dto.Name,
                Description = dto.Description,
                Image = dto.Image
            };

            DB.Tests.Add(test);
            DB.SaveChanges();

            if(dto.Questions?.Count > 0)
            {
                List<TestQuestion> questions = new List<TestQuestion>();
                foreach(TestQuestionDTO questionDTO in dto.Questions)
                {
                    TestQuestion testQuestion = new TestQuestion()
                    {
                        TestId = test.Id,
                        Text = questionDTO.Text,
                        Answers = JsonConvert.SerializeObject(questionDTO.Answers)
                    };

                    questions.Add(testQuestion);
                }

                test.Questions.AddRange(questions);
            }

        }

        private void UpdateTest(TestDTO dto)
        {
            Test test = GetTest(dto.Id);

            test.Name = dto.Name;
            test.Description = dto.Description;
            test.Image = dto.Image;

            DB.Tests.Update(test);
        }

        private void DeleteTest(int id)
        {
            Test test = GetTest(id);
            DB.Tests.Remove(test);
        }

        #endregion
        public TestDTO Get(int id)
        {
            return GetTest(id).ToDTO();
        }

        public bool Create(TestDTO dto)
        {
            return CreateOrUpdateActionData(CreateTest, dto);
        }

        public bool Update(TestDTO dto)
        {
            return CreateOrUpdateActionData(UpdateTest, dto);
        }

        public bool Delete(int id)
        {
            return DeleteActionData(DeleteTest, id);
        }

    }
}
