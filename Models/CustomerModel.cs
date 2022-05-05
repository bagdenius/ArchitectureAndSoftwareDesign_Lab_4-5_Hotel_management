using Models.Abstract;
using Models.enums;

namespace Models
{
    public class CustomerModel : ICustomerModel
    {
        public int Id { get; set; }
        public List<RoomModel> BookedRooms { get; set; }
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
