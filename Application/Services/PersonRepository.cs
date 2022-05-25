using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IDatabaseContext db;
        private readonly IMapper mapper;

        public PersonRepository(IMapper mapper, IDatabaseContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        // Get All
        public List<PersonDto> GetAll()
        {
            return db.People.Select(p => mapper.Map<PersonDto>(p)).ToList();
        }

        // Get 
        public PersonDto Get(int Id)
        {
            var person = db.People.Find(Id);
            return mapper.Map<PersonDto>(person);
        }

        // Add 
        public bool Add(PersonDto personDto)
        {
            var person = mapper.Map<Person>(personDto);

            db.People.Add(person);
            int affected = db.SaveChanges();

            if (affected > 0)
            {
                return true;
            }

            return false;
        }

        // Update
        public bool Update(int Id, PersonDto personDto)
        {
            var person = db.People.Find(Id);
            var personUpdated = mapper.Map(personDto, person);

            db.People.Update(personUpdated);
            int affected = db.SaveChanges();

            if (affected > 0)
            {
                return true;
            }

            return false;
        }

        // Delete
        public bool Delete(int Id)
        {
            var person = db.People.Find(Id);

            db.People.Remove(person);
            int affected = db.SaveChanges();

            if (affected > 0)
            {
                return true;
            }

            return false;
        }
    }
}
