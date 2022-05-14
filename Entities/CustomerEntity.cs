using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class CustomerEntity
    {
        // Mapped properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Passport { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        public RoomEntity Room { get; set; }
    }
}
