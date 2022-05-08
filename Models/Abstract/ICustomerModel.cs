using Models.enums;

namespace Models.Abstract
{
    public interface ICustomerModel
    {
        // mapped properties
        public int Id { get; set; }
        public List<RoomModel> BookedRooms { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Gender { get; set; }
        public string Passport { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
