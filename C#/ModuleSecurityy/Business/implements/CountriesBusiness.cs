using Business.Interfaces;
using Data.Implements;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.implements
{
    public class CountriesBusiness : ICountriesBusiness
    {
        private readonly ICountriesData data;

        public CountriesBusiness(ICountriesData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<CountriesDto>> GetAll()
        {
            IEnumerable<Countries> countries = await this.data.GetAll();
            var countriesDtos = countries.Select(countries => new CountriesDto
            {
                Id = countries.Id,
                Name = countries.Name,

            });
            return countriesDtos;
        }

        public async Task<Countries> GetById(int id)
        {
            return await this.data.GetById(id);
        }

        public Countries MappingData(Countries countries, CountriesDto entity)
        {
            countries.Id = entity.Id;
            countries.Name = entity.Name;

            return countries;
        }

        public async Task<Countries> Save(CountriesDto entity)
        {
            Countries countries = new Countries
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            countries = MappingData(countries, entity);
            countries.countries_id = null;
            return await this.data.Save(countries);
        }

        public async Task Update(CountriesDto entity)
        {
            Countries countries = await this.data.GetById(entity.Id);
            if (countries == null)
            {
                throw new Exception("Registro no encontrado");
            }
            countries = MappingData(countries, entity);
            await this.data.Update(countries);
        }
    }
}
