using Models.enums;
using System.ComponentModel;

namespace Models.Builders
{
    public static class CustomerBuilder
    {
        private static readonly EnumConverter _converter = new(typeof(CustomerModel));
        public static void SetGender(this CustomerModel model, Gender gender)
        {
            model.Gender = gender.ToString();
        }

        public static Gender GetGender(this CustomerModel model)
        {
            return (Gender)_converter.ConvertFromString(model.Gender);
        }
    }
}
