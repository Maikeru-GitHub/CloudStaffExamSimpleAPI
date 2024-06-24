using AutoMapper;
using CloudStaffExamSimpleAPI.Models.Domain;
using CloudStaffExamSimpleAPI.Models.DTO;
using CloudStaffExamSimpleAPI.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CloudStaffExamSimpleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        #region Declarations 

        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        #endregion

        #region Constructor 

        public PeopleController(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        #endregion

        #region Functions

        /// <summary>
        /// Retrieves all people from the repository.
        /// </summary>
        /// <returns>Returns a list of people.</returns>
        [HttpGet]
        public IActionResult GetAllPeople()
        {
            try
            {
                IEnumerable<Person> people = _personRepository.GetAll();

                return Ok(people);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Retrieves a person by their unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the person.</param>
        /// <returns>Returns the person with the specified ID if found, or NotFound if not found.</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetPersonById([FromRoute] Guid id)
        {
            try
            {
                Person? person = _personRepository.GetById(id);

                if (person == null) return NotFound();

                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Adds a new person using data from the request DTO.
        /// </summary>
        /// <param name="request">Data of the person to be added.</param>
        /// <returns>Returns the added person.</returns>
        [HttpPost]
        public IActionResult AddPerson(AddPersonDto request)
        {
            try
            {
                Person person = _mapper.Map<Person>(request);
                person = _personRepository.Create(person);

                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing person identified by ID with data from the request DTO.
        /// </summary>
        /// <param name="id">ID of the person to update.</param>
        /// <param name="request">Updated data of the person.</param>
        /// <returns>Returns the updated person.</returns>
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdatePerson([FromRoute] Guid id, UpdatePersonDto request)
        {
            try
            {
                if (!request.HasAtLeastOneField()) return BadRequest("At least one field (FirstName, LastName, Age) must be provided.");
                
                Person? person = _mapper.Map<Person>(request);
                person.Id = id;
                person = _personRepository.Update(person);

                if (person == null) return NotFound();

                return Ok(person);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes a person with the specified ID.
        /// </summary>
        /// <param name="id">ID of the person to delete.</param>
        /// <returns>Returns a message indicating success or failure.</returns>
        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeletePerson([FromRoute] Guid id)
        {
            try
            {
                Person? person = _personRepository.Delete(id);

                if (person == null) return NotFound();

                return Ok(string.Format("Succesfully Deleted with ID: {0} ", person.Id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }

    #endregion
}
