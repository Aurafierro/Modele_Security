using Business.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.implements
{
    public class viewBusiness : IViewBusiness
    {
        protected readonly IViewData data;

        public viewBusiness(IViewData data)
        {
            this.data = data;
        }

        public async Task Delete (int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<ViewDto>> GetAll()
        {
            IEnumerable<View> views = await this.data.GetAll();
            var viewDto = views.Select(view => new ViewDto
            {
                Id = view.Id,
                Name = view.Name,
                Description= view.Description,
                Route = view.Route,
                ModuloId= view.ModuloId,
                ApartmentState= view.State,

            });
            return viewDto;
        }
    }


    public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
    {
        return await this.data.GetAllSelect();
    }
    public async Task <ViewDto>GetById(int id)
    {
        viewBusiness view = await this.data.GetById(id);
        ViewDto = new ViewDto();


        ViewDto.Id = view.Id;
        ViewDto.Name = entity.Name;

        ViewDto.Description = entity.Description;
        ViewDto.Route = entity.Route;
        ViewDto.ModuloId = view.State;
        return viewDto;

    }
    public Vire mapear(View view, ViewDto entity)
    {
        view.Id = entity.Id;
        view.Name = entity.Name;
        view.Description = entity.Description;
        view.Route = entity.Route;
        view.ModuloId = entity.State;
        return view;
    }
}
