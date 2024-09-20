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
    public class RoleViewBusiness : IRoleViewBusiness
    {
            protected readonly IRoleViewData data;

            public RoleViewBusiness(IRoleViewData data)
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

            public async Task<RoleViewDto> GetById(int id)
            {
                RoleView roleView = await this.data.GetById(id);
                RoleViewDto roleviewDto = new RoleViewDto();

            roleviewDto.Id = roleView.Id;

                return roleviewDto;
            }

            public RoleView mapearDatos(RoleView roleview, RoleViewDto entity)
            {
                roleview.Id = entity.Id;



                return roleview;
            }

            public async Task<RoleView> Save(RoleViewDto entity)
            {
                RoleView roleview = new RoleView();
            roleview.CreateAt = DateTime.Now.AddHours(-5);
            roleview = this.mapearDatos(roleview, entity);

                return await this.data.Save(roleview);
            }

            public async Task Update(RoleViewDto entity)
            {
                RoleView roleView = await this.data.GetById(entity.Id);
                if (roleView == null)
                {
                    throw new Exception("Registro no encontrado");
                }

            roleView = this.mapearDatos(roleView, entity);
                await this.data.Update(roleView);
            }
        }
    }

