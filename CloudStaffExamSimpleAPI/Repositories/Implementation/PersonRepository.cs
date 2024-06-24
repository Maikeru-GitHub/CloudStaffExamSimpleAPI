using AutoMapper;
using CloudStaffExamSimpleAPI.Models.Domain;
using CloudStaffExamSimpleAPI.Repositories.Interface;

namespace CloudStaffExamSimpleAPI.Repositories.Implementation
{
    /// <summary>
    /// Implementation of IPersonRepository using an in-memory list for storage.
    /// </summary>
    public class PersonRepository : IPersonRepository
    {
        #region Declarations

        private static readonly List<Person> people = new List<Person>();
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public PersonRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        #endregion

        #region Functions

        public IEnumerable<Person> GetAll()
        {
            return people;
        }

        public Person? GetById(Guid id)
        {
            Person? existingPerson = people.Where(x => x.Id == id).FirstOrDefault();

            return existingPerson;
        }

        public Person Create(Person person)
        {
            person.Id = Guid.NewGuid();
            people.Add(person);

            return person;
        }

        public Person? Update(Person person)
        {
            Person? existingPerson = people.Where(x => x.Id == person.Id).FirstOrDefault();
            if (existingPerson != null) _mapper.Map(person, existingPerson);

            return existingPerson;
        }

        public Person? Delete(Guid id)
        {
            Person? existingPerson = people.Where(x => x.Id == id).FirstOrDefault();
            if (existingPerson != null) people.Remove(existingPerson);

            return existingPerson;
        }
    }

    #endregion
}
