using VolvoCleaner.Web.Frontend.Helpers;

namespace VolvoCleaner.Web.Frontend.Models
{
    public class ServiceModel
    {
        public static int _rowNumber { get; set; }

        public ServiceModel(int rowNumber)
        {
            _rowNumber = rowNumber;
        }
        #region aux
        public object _filename = "";
        public object _titleSalutation = "";
        public object _firstName = "";
        public object _familyName = "";
        public object _gender = "";
        public object _language = "PT";
        public object _address1 = "";
        public object _address2 = "";
        public object _address3 = "";
        public object _address4 = "";
        public object _postcode = "";
        public object _townCity = "";
        public object _email = "";
        public object _mobileNumber = "";
        public object _telephoneNumber = "";
        public object _vIN = "";
        public object _eventDate = "";
        public object _dealerCode = "";
        public object _businessPrivate = "";
        public object _company = "";
        public object _serviceType = "";
        public object _salesDate = "";
        public object _mileage = "";
        public object _emailPref = "";
        public object _directMailPref = "";
        public object _phonePref = "";
        public object _sMSPref = "";
        #endregion

        public object Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }
        public object TitleSalutation
        {
            get { return _titleSalutation; }
            set { _titleSalutation = ""; }
        }
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
                    ValuesHelper.RemoveSpecialCharacters(ref temp);
                    ValuesHelper.RemoveDiacritics(ref temp);
                    ValuesHelper.RemoveMultipleAndWhiteSpaces(ref temp);
                    ValuesHelper.ToTitleCase(ref temp);
                    _firstName = temp;
                }
            }
        }
        public object FamilyName
        {
            get
            {
                return _familyName;
            }
            set
            {
                if (value == null)
                {
                    _familyName = "";
                }
                else
                {
                    var temp = value.ToString();
                    ValuesHelper.RemoveSpecialCharacters(ref temp);
                    ValuesHelper.RemoveDiacritics(ref temp);
                    ValuesHelper.RemoveMultipleAndWhiteSpaces(ref temp);
                    ValuesHelper.ToTitleCase(ref temp);
                    _familyName = temp;
                }
            }
        }
        public object Gender
        {
            get { return _gender; }
            set { }
        }
        public object Language
        {
            get { return _language; }
            set { }
        }
        public object Address1
        {
            get { return _address1; }
            set
            {
                if (value == null)
                {
                    _address1 = "";
                }
                else
                {
                    var temp = value.ToString();
                    ValuesHelper.RemoveSpecialCharacters(ref temp);
                    ValuesHelper.RemoveDiacritics(ref temp);
                    _address1 = temp;
                }
            }
        }
        public object Address2 { get; set; }
        public object Address3 { get; set; }
        public object Address4 { get; set; }
        public object Postcode { get; set; }
        public object TownCity { get; set; }
        public object Email { get; set; }
        public object MobileNumber { get; set; }
        public object TelephoneNumber { get; set; }
        public object VIN
        {
            get { return _vIN; }
            set
            {
                if (value == null)
                {
                    _vIN = "";
                }
                else
                {
                    var temp = value.ToString();
                    ValuesHelper.RemoveMultipleAndWhiteSpaces(ref temp);
                    _vIN = temp;
                }
            }
        }
        public object EventDate
        {
            get { return _eventDate; }
            set
            {
                _eventDate = value;
            }
        }
        public object DealerCode
        {
            get { return _dealerCode; }
            set
            {
                if (value == null)
                {
                    _dealerCode = "";
                }
                else
                {
                    var temp = value.ToString();
                    ValuesHelper.RemoveMultipleAndWhiteSpaces(ref temp);
                    _dealerCode = temp;
                }
            }
        }
        public object BusinessPrivate { get; set; }
        public object Company { get; set; }
        public object ServiceType
        {
            get { return _serviceType; }
            set
            {
                if (value == null)
                {
                    _serviceType = "";
                }
                else
                {
                    var temp = value.ToString();
                    ValuesHelper.ToTitleCase(ref temp);
                    _serviceType = temp;
                }
            }
        }
        public object SalesDate
        {
            get { return _salesDate; }
            set
            {
                _salesDate = value;
            }
        }
        public object Mileage { get; set; }
        public object EmailPref { get; set; }
        public object DirectMailPref { get; set; }
        public object PhonePref { get; set; }
        public object SMSPref { get; set; }

    }
}
