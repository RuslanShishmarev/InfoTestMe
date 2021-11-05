using InfoTestMe.Admin.Web.Models.Abstractions;
using InfoTestMe.Admin.Web.Models.Data;
using InfoTestMe.Admin.Web.Models.Data.Extensions;
using InfoTestMe.Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTestMe.Admin.Web.Services
{
    public class AuthorService : CommonService<AuthorDTO>, IAuthorService
    {
        private FileService _fileService = new FileService();
        public AuthorService(InfoTestMeDataContext db) : base(db) { }

        #region PRIVATE METHODS
        private Author GetAuthor(int id)
        {
            return DB.Authors.FirstOrDefault(a => a.Id == id);
        }

        private void CreateAuthor(AuthorDTO dto)
        {
            Author newAuthor = new Author()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Image = _fileService.GetByteArrayFromJson(dto.Image?.ToString()),
                RegistrationDate = DateTime.Now,
                Description = dto.Description,
                KeyWords = JsonConvert.SerializeObject(dto.KeyWords)
            };
            DB.Authors.Add(newAuthor);
        }

        private void UpdateAuthor(AuthorDTO dto)
        {
            Author author = GetAuthor(dto.Id);
            
            author.FirstName = dto.FirstName;
            author.LastName = dto.LastName;
            author.Email = dto.Email;
            author.Password = dto.Password;
            author.Image = _fileService.GetByteArrayFromJson(dto.Image?.ToString());
            author.Description = dto.Description;
            author.KeyWords = JsonConvert.SerializeObject(dto.KeyWords);

            DB.Authors.Update(author);
        }

        private void DeleteAuthor(int id)
        {
            Author user = GetAuthor(id);
            DB.Authors.Remove(user);
        }

        #endregion

        public AuthorDTO Get(int id)
        {
            return GetAuthor(id)?.ToDTO();
        }
        public bool Create(AuthorDTO dto)
        {
            return CreateOrUpdateActionData(CreateAuthor, dto);
        }

        public bool Update(AuthorDTO dto)
        {
            return CreateOrUpdateActionData(UpdateAuthor, dto);
        }

        public bool Delete(int id)
        {
            return DeleteActionData(DeleteAuthor, id);
        }

        public List<AuthorShortDTO> GetByRange(int startPosition = 0, int countModels = 10)
        {
            List<AuthorShortDTO> authorDtos = new List<AuthorShortDTO>();

            int allCount = DB.Authors.Count();

            if (allCount <= startPosition)
            {
                return authorDtos;
            }
            else if(allCount < startPosition + countModels)
            {
                countModels = allCount - startPosition;
            }

            authorDtos = DB.Authors.ToList().GetRange(startPosition,countModels).Select(a => a.ToShortDTO()).ToList();
            return authorDtos;
        }

        public Author GetAuthorByLogin(string login)
        {
            return DB.Authors.FirstOrDefault(a => a.Email == login);
        }

        public bool IsExistAuthor(string email)
        {
            Author existAuthor = GetAuthorByLogin(email);

            return existAuthor == null ? false : true;
        }
    }
}
