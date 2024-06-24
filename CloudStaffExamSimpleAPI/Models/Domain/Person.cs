namespace CloudStaffExamSimpleAPI.Models.Domain
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //nullable so that in update it will not default to 0 when used with automapper
        public int? Age { get; set; }
    }
}
