using Domains.Abstract;
using Domains.enums;

namespace Domains
{
    public class Customer : ICustomer
    {
        public int Id { get; set; }
        public List<Room> BookedRooms { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Passport { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
