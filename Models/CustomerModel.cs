using Models.Abstract;
using Models.ObservableModifications;

namespace Models
{
    public class CustomerModel : ObservableObject, ICustomerModel
    {
        // fields
        private string name;
        private string surname;
        private string patronymic;
        private string gender;
        private string passport;
        private DateTime birthDate;
        private string phone;
        private string email;

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
