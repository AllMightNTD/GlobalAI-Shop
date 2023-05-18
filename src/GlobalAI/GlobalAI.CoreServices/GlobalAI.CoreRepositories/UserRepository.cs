
//using GlobalAI.DataAccess.Base;
//using GlobalAI.DataAccess.Base;
//using GlobalAI.DataAccess.Base;
using GlobalAI.CoreEntities.DataEntities;
using GlobalAI.CoreEntities.Dto.User;
using GlobalAI.DataAccess.Base;
using GlobalAI.DataAccess.Models;
using GlobalAI.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GlobalAI.CoreRepositories
{
    public class UserRepository : BaseEFRepository<User>
    {
        public UserRepository(DbContext dbContext, ILogger logger, string seqName = null) : base(dbContext, logger, seqName)
        {
        }

        /// <summary>
        /// cap nhat user
        /// </summary>
        /// <param name="input"></param>
        public void Update(int userId, decimal gPoint)
        {
            var user = _dbSet.FirstOrDefault(d => d.UserId == userId && !d.Deleted);
            user.GPoint = gPoint;
        }
        /// <summary>
        /// Tạo mới user
        /// </summary>
        /// <param name="entity"></param>
        public void AddUser(User entity)
        {
            _logger.LogInformation($"{nameof(AddUser)}: entity = {JsonSerializer.Serialize(entity)}");

            entity.CreatedDate = DateTime.Now;
            entity.Password = CommonUtils.CreateMD5(entity.Password);

            _globalAIDbContext.Users.Add(entity);
        }

        /// <summary>
        /// Tìm theo username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User FindByUsername(string username)
        {
            _logger.LogInformation($"{nameof(FindByUsername)}: username = {username}");

            return _globalAIDbContext.Users.AsNoTracking().FirstOrDefault(x => x.Username == username && !x.Deleted);
        }

        /// <summary>
        /// Tìm theo email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User FindByEmail(string email)
        {
            _logger.LogInformation($"{nameof(FindByUsername)}: email = {email}");

            return _globalAIDbContext.Users.AsNoTracking().FirstOrDefault(x => x.Email == email && !x.Deleted);
        }

        /// <summary>
        /// Tìm theo sdt
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public User FindByPhone(string phone)
        {
            _logger.LogInformation($"{nameof(FindByUsername)}: phone = {phone}");

            return _globalAIDbContext.Users.AsNoTracking().FirstOrDefault(x => x.Phone == phone && !x.Deleted);
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User ValidateUser(string username, string password)
        {
            _logger.LogInformation($"{nameof(ValidateUser)} -> {nameof(User)}: username={username}, password={password}");

            string encryptedPassword = CommonUtils.CreateMD5(password);
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Username == username && x.Password == encryptedPassword && !x.Deleted);
        }

        /// <summary>
        /// Tìm kiếm user phân trang
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public PagingResult<ViewUserDto> FindUser(FindUserDto dto)
        {
            _logger.LogInformation($"{nameof(FindUser)}: dto = {JsonSerializer.Serialize(dto)}");

            var query = from user in _globalAIDbContext.Users.AsNoTracking()
                        where !user.Deleted && (
                            dto.Keyword == null || user.FirstName.ToLower().Contains(dto.Keyword.ToLower()) || user.LastName.ToLower().Contains(dto.Keyword.ToLower())
                            || user.Email.ToLower().Contains(dto.Keyword.ToLower()) || user.Phone.ToLower().Contains(dto.Keyword.ToLower()) ||
                            user.DisplayName.ToLower().Contains(dto.Keyword.ToLower())
                        )
                        orderby user.UserId descending
                        select new ViewUserDto
                        {
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            CreatedBy = user.CreatedBy,
                            CreatedDate = user.CreatedDate,
                            DisplayName = user.DisplayName,
                            Email = user.Email,
                            IsVerifiedEmail = user.IsVerifiedEmail,
                            LastFailedLogin = user.LastFailedLogin,
                            LastLogin = user.LastLogin,
                            Phone = user.Phone,
                            Status = user.Status,
                            UserId = user.UserId,
                            Username = user.Username,
                            UserType = user.UserType
                        };

            return new PagingResult<ViewUserDto>
            {
                Items = query.Skip(dto.Skip).Take(dto.PageSize),
                TotalItems = query.Count()
            };
        }
    }
}
