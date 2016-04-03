﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ZuegerAdressbook.Model
{
    public class Person : BaseModel
    {
        private string _id;

        private string _firstname;

        private string _lastname;

        private Gender _gender;

        private string _title;

        private string _street1;

        private string _street2;

        private string _city;

        private string _plz;

        private DateTime? _birthdate;

        private string _emailAddress;

        private string _phoneNumber;

        private string _mobileNumber;

        private bool _hasGeneralAbo;

        private DateTime? _generalAboExpirationDate;

        private bool _hasHalbtax;

        private DateTime? _halbtaxExpirationDate;

        private bool _hasJuniorKarte;

        private DateTime? _juniorKarteExpirationDate;

        private bool _hasEnkelKarte;

        private DateTime? _enkelKarteExpirationDate;

        private string _notes;

        private string _nameOnPassport;

        private string _passportNumber;

        private IList<string> _documents;

        public Person()
        {
            _documents = new List<string>();
        }

        public string Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value == _id)
                {
                    return;
                }
                _id = value;
                OnPropertyChanged();
            }
        }

        public string Firstname
        {
            get
            {
                return _firstname;
            }
            set
            {
                if (value == _firstname)
                {
                    return;
                }
                _firstname = value;
                OnPropertyChanged();
            }
        }

        public string Lastname
        {
            get
            {
                return _lastname;
            }
            set
            {
                if (value == _lastname)
                {
                    return;
                }
                _lastname = value;
                OnPropertyChanged();
            }
        }

        public Gender Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                if (value == _gender)
                {
                    return;
                }
                _gender = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value == _title)
                {
                    return;
                }
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Street1
        {
            get
            {
                return _street1;
            }
            set
            {
                if (value == _street1)
                {
                    return;
                }
                _street1 = value;
                OnPropertyChanged();
            }
        }

        public string Street2
        {
            get
            {
                return _street2;
            }
            set
            {
                if (value == _street2)
                {
                    return;
                }
                _street2 = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value == _city)
                {
                    return;
                }
                _city = value;
                OnPropertyChanged();
            }
        }

        public string Plz
        {
            get
            {
                return _plz;
            }
            set
            {
                if (value == _plz)
                {
                    return;
                }
                _plz = value;
                OnPropertyChanged();
            }
        }

        public DateTime? Birthdate
        {
            get
            {
                return _birthdate;
            }
            set
            {
                if (value.Equals(_birthdate))
                {
                    return;
                }
                _birthdate = value;
                OnPropertyChanged();

                OnPropertyChanged("IsChild");
                OnPropertyChanged("Age");
            }
        }

        public string EmailAddress
        {
            get
            {
                return _emailAddress;
            }
            set
            {
                if (value == _emailAddress)
                {
                    return;
                }
                _emailAddress = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value == _phoneNumber)
                {
                    return;
                }
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public string MobileNumber
        {
            get
            {
                return _mobileNumber;
            }
            set
            {
                if (value == _mobileNumber)
                {
                    return;
                }
                _mobileNumber = value;
                OnPropertyChanged();
            }
        }

        public bool HasGeneralAbo
        {
            get
            {
                return _hasGeneralAbo;
            }
            set
            {
                if (value == _hasGeneralAbo)
                {
                    return;
                }
                _hasGeneralAbo = value;
                OnPropertyChanged();
            }
        }

        public bool HasHalbtax
        {
            get
            {
                return _hasHalbtax;
            }
            set
            {
                if (value == _hasHalbtax)
                {
                    return;
                }
                _hasHalbtax = value;
                OnPropertyChanged();
            }
        }

        public string Notes
        {
            get
            {
                return _notes;
            }
            set
            {
                if (value == _notes)
                {
                    return;
                }
                _notes = value;
                OnPropertyChanged();
            }
        }

        public string NameOnPassport
        {
            get
            {
                return _nameOnPassport;
            }
            set
            {
                if (value == _nameOnPassport)
                {
                    return;
                }
                _nameOnPassport = value;
                OnPropertyChanged();
            }
        }

        public string PassportNumber
        {
            get
            {
                return _passportNumber;
            }
            set
            {
                if (value == _passportNumber)
                {
                    return;
                }
                _passportNumber = value;
                OnPropertyChanged();
            }
        }

        public DateTime? GeneralAboExpirationDate
        {
            get
            {
                return _generalAboExpirationDate;
            }
            set
            {
                if (value.Equals(_generalAboExpirationDate)) return;
                _generalAboExpirationDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime? HalbtaxExpirationDate
        {
            get
            {
                return _halbtaxExpirationDate;
            }
            set
            {
                if (value.Equals(_halbtaxExpirationDate)) return;
                _halbtaxExpirationDate = value;
                OnPropertyChanged();
            }
        }

        public bool HasJuniorKarte
        {
            get
            {
                return _hasJuniorKarte;
            }
            set
            {
                if (value == _hasJuniorKarte) return;
                _hasJuniorKarte = value;
                OnPropertyChanged();
            }
        }

        public DateTime? JuniorKarteExpirationDate
        {
            get
            {
                return _juniorKarteExpirationDate;
            }
            set
            {
                if (value.Equals(_juniorKarteExpirationDate)) return;
                _juniorKarteExpirationDate = value;
                OnPropertyChanged();
            }
        }

        public bool HasEnkelKarte
        {
            get
            {
                return _hasEnkelKarte;
            }
            set
            {
                if (value == _hasEnkelKarte) return;
                _hasEnkelKarte = value;
                OnPropertyChanged();
            }
        }

        public DateTime? EnkelKarteExpirationDate
        {
            get
            {
                return _enkelKarteExpirationDate;
            }
            set
            {
                if (value.Equals(_enkelKarteExpirationDate)) return;
                _enkelKarteExpirationDate = value;
                OnPropertyChanged();
            }
        }

        public int? Age
        {
            get
            {
                if (Birthdate.HasValue == false)
                {
                    return null;
                }

                var today = DateTime.Today;
                var age = today.Year - Birthdate.Value.Year;

                if (today < Birthdate.Value.AddYears(age).Date)
                {
                    age--;
                }

                return age;
            }
        }

        public bool? IsChild
        {
            get
            {
                if (Age.HasValue == false)
                {
                    return null;
                }

                return Age <= 16;
            }
        }

        public IList<string> Documents
        {
            get
            {
                return _documents;
            }

            set
            {
                if (Equals(value, _documents)) return;
                _documents = value;
                OnPropertyChanged();
            }
        }

        public static string GenerateId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
