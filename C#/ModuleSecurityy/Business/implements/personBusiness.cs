using Business.Interfaces;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.implements
{
    public class personBusiness : IPersonBusiness
    {
        protected readonly IPersonData data;
        public personBusiness(IPersonData data)
        {
            this.data = data;
        }
        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }
        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            IEnumerable<Person> persons = await this.data.GetAll();
            var personDtos = persons.Select(Person => new PersonDto
            {
                Id = Person.Id,
                First_name = Person.First_name,
                Last_name = Person.Last_name,
                Email = Person.Email,
                Type_document = Person.Type_document,
                Document = Person.Document,
                Birth_of_date = Person.Birth_of_date

            });
            return personDtos;
        }

        public Task<Person> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Person MappingData(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.First_name = entity.First_name;
            person.Last_name = entity.Last_name;
            person.Email = entity.Email;
            person.Type_document = entity.Type_document;
            person.Document = entity.Document;
            person.Birth_of_date= entity.Birth_of_date;

            return person;
        }
        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person();
            person.CreateAt = DateTime.Now.AddHours(-5);
            person = this.MappingData(person, entity);
            person.person_id = null;

            return await this.data.Save(person);
        }

        public Task<Person> Save(Person person)
        {
            throw new NotImplementedException();
        }

        public async Task Update(PersonDto entity)
        {
            Person person = await this.data.GetById(entity.Id);
            if (person == null)
            {
                throw new Exception("Registro no encontrado");
            }
            person = this.MappingData(person, entity);
            await this.data.Update(person);
        }

        public Task Update(Person person)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Person>> IPersonBusiness.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
