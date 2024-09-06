using Business.Interfaces;
using Data.Implements;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.implements
{
    public class CityBusiness : ICityBusiness
    {
        protected readonly ICityDta data;
        public CityBusiness(ICityDta data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<CityDto>> GetAll()
        {
            IEnumerable<City> cities = await this.data.GetAll();
            var cityDtos = cities.Select(City => new CityDto
            {
                Id = City.Id,
                Name = City.Name,
                Postalcode = City.Postalcode,
               

            });
            return cityDtos;
        }

        public Task<City> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public City MappingData(City city, CityDto entity)
        {
            city.Id = entity.Id;
            city.Name = entity.Name;
            city.Postalcode = entity.Postalcode;
          

            return city;
        }
        public async Task<City> Save(CityDto entity)
        {
            City city = new City();
            city.CreateAt = DateTime.Now.AddHours(-5);
            city = this.MappingData(city, entity);
            city.city_id = null;

            return await this.data.Save(city);
        }

        public Task<City> Save(City city)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CityDto entity)
        {
            City city = await this.data.GetById(entity.Id);
            if (city == null)
            {
                throw new Exception("Registro no encontrado");
            }
            city = this.MappingData(city, entity);
            await this.data.Update(city);
        }

        public Task Update(City city)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<CityDto>> ICityBusiness.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
