using Business.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.implements
{
    public class roleviewBusiness : IRoleviewBusiness
    {
        protected readonly IRoleViewData data;
        public roleviewBusiness(IRoleViewData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<RoleViewDto>> GetAll()
        {
            IEnumerable<RoleView> RoleViews = await this.data.GetAll();
            var roleviewDtos = RoleViews.Select(RoleView => new RoleViewDto
            {
                Id = RoleView.Id,
                State = RoleView.State,
                Role_id = RoleView.Role_id,
                View_id = RoleView.View_id,



            });
            return roleviewDtos;
        }

        public Task<RoleView> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public RoleView MappingData(RoleView roleView, RoleViewDto entity)
        {
            roleView.Id = entity.Id;
            roleView.State = entity.State;
            roleView.Role_id = entity.Role_id;
            roleView.View_id = entity.View_id;

            return roleView;
        }
        public async Task<RoleView> Save(RoleViewDto entity)
        {
            RoleView roleView = new RoleView();
            roleView.CreateAt = DateTime.Now.AddHours(-5);
            roleView = this.MappingData(roleView, entity);
            roleView.roleView_id = null;

            return await this.data.Save(roleView);
        }

        public Task<RoleView> Save(RoleView roleView)
        {
            throw new NotImplementedException();
        }

        public async Task Update(RoleViewDto entity)
        {
            RoleView roleView = await this.data.GetById(entity.Id);
            if (roleView == null)
            {
                throw new Exception("Registro no encontrado");
            }
            roleView = this.MappingData(roleView, entity);
            await this.data.Update(roleView);
        }

        public Task Update(RoleView roleView)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Role>> IRoleviewBusiness.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
