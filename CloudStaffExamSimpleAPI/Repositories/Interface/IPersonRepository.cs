using CloudStaffExamSimpleAPI.Models.Domain;

namespace CloudStaffExamSimpleAPI.Repositories.Interface
{
    /// <summary>
    /// Repository interface for managing persons.
    /// </summary>
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
        Person? GetById(Guid id);
        Person Create(Person person);
        Person? Update(Person person);
        Person? Delete(Guid id);
    }
}
