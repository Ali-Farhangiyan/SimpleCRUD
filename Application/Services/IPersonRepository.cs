using Application.Dto;

namespace Application.Services
{
    public interface IPersonRepository
    {
        bool Add(PersonDto personDto);
        bool Delete(int Id);
        PersonDto Get(int Id);
        IEnumerable<PersonDto> GetAll();
        bool Update(int Id, PersonDto personDto);
    }
}