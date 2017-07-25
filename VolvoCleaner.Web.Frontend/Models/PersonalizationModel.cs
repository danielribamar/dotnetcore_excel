using VolvoCleaner.Web.Frontend.Business;
using VolvoCleaner.Web.Frontend.Helpers;

namespace VolvoCleaner.Web.Frontend.Models
{
    public class PersonalizationModel
    {
        #region aux
        private object _id { get; set; }
        private object _firstName { get; set; }
        private object _lastName { get; set; }
        private object _additionalName { get; set; }
        private object _additionalSurname { get; set; }
        private object _gender { get; set; }
        private object _contactCreatedDate { get; set; }
        #endregion
        public object Id { get; set; }
        public object FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value == null)
                {
                    _firstName = "";
                }
                else
                {
                    var temp = value.ToString();
                    ValuesHelper.RemoveMultipleAndWhiteSpaces(ref temp);
                    ValuesHelper.ToTitleCase(ref temp);
                    _firstName = temp;
                }
            }
        }
        public object LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value == null)
                {
                    _lastName = "";
                }
                else
                {
                    var temp = value.ToString();
                    ValuesHelper.RemoveMultipleAndWhiteSpaces(ref temp);
                    ValuesHelper.ToTitleCase(ref temp);
                    _lastName = temp;
                }
            }
        }
        public object AdditionalName
        {
            get
            {
                return _additionalName;
            }
            set
            {
                if (value == null)
                {
                    _additionalName = "";
                }
                else
                {
                    var temp = value.ToString();
                    ValuesHelper.RemoveMultipleAndWhiteSpaces(ref temp);
                    ValuesHelper.ToTitleCase(ref temp);
                    _additionalName = temp;
                }
            }
        }
        public object AdditionalSurname
        {
            get
            {
                return _additionalSurname;
            }
            set
            {
                if (value == null)
                {
                    _additionalSurname = "";
                }
                else
                {
                    var temp = value.ToString();
                    ValuesHelper.RemoveMultipleAndWhiteSpaces(ref temp);
                    ValuesHelper.ToTitleCase(ref temp);
                    _additionalSurname = temp;
                }
            }
        }
        public object Gender
        {
            get { return _gender; }
            set
            {
                var temp = value.ToString();
                ValuesHelper.SetGender(ref temp, _firstName.ToString());
                _gender = temp;
            }
        }
        public object ContactCreatedDate { get; set; }


    }
}
