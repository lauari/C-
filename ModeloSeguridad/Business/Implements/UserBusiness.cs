using Business.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class UserBusiness : IUserBusiness
    {
        protected readonly IUserData data;

        public UserBusiness(IUserData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        //public async Task<IEnumerable<RoleViewDto>> GetAll()
        //{
        //    IEnumerable<Role> views = await this.data.GetAll();
        //    var roleviewDtos = views.Select(roleview => new RoleViewDto
        //    {
        //        Id = roleview.Id,
        //        State = roleview.State,

        //    });

        //    return roleviewDtos;
        //}

        //public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        //{
        //    return await this.data.GetAllSelect();
        //}

        public async Task<UserDto> GetById(int id)
        {
            User user = await this.data.GetById(id);
            UserDto userDto = new UserDto();

            userDto.Id = user.Id;
            userDto.Username = user.Username;

            return userDto;
        }

        public User mapearDatos(User user, UserDto entity)
        {
            user.Id = entity.Id;
            user.Username = entity.Username;



            return user;
        }

        public async Task<User> Save(UserDto entity)
        {
            User user = new User();
            user.CreateAt = DateTime.Now.AddHours(-5);
            user = this.mapearDatos(user, entity);

            return await this.data.Save(user);
        }

        public async Task Update(UserDto entity)
        {
            User user = await this.data.GetById(entity.Id);
            if (user == null)
            {
                throw new Exception("Registro no encontrado");
            }

            user = this.mapearDatos(user, entity);
            await this.data.Update(user);
        }
    }
}
