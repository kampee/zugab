﻿using System;
using System.Collections.Generic;

using OfficeOpenXml;

using ZuegerAdressbook.Model;
using ZuegerAdressbook.Extensions;

namespace ZuegerAdressbook.Service
{
    public class AddressbookWorksheet
    {
        private readonly ExcelWorksheet _worksheet;

        public int Row { get; set; }

        public AddressbookWorksheet(ExcelWorksheet worksheet)
        {
            _worksheet = worksheet;
        }

        public IList<Person> ReadPersons()
        {
            var persons = new List<Person>();

            for (int rowIndex = 2; ; rowIndex++)
            {
                var row = GetRow(rowIndex);
                var person = new Person
                {
                    Id = row.Id,
                    Gender = row.Gender,
                    Firstname = row.Firstname,
                    Lastname = row.Lastname,
                    Title = row.Title,
                    Street1 = row.Street1,
                    Plz = row.Plz,
                    City = row.City,
                    PhoneNumber = row.PhoneNumber,
                    MobileNumber = row.MobileNumber,
                    BusinessPhoneNumber = row.BusinessPhoneNumber,
                    EmailAddress = row.EmailAddress,
                    Birthdate = row.Birthdate,
                    NameOnPassport = row.NameOnPassport,
                    PassportNumber = row.PassportNumber,
                    PassportExpirationDate = row.PassportExpirationDate,
                    HasJuniorKarte = row.HasJuniorKarte,
                    JuniorKarteExpirationDate = row.JuniorKarteExpirationDate,
                    HasGeneralAbo = row.HasGeneralAbo,
                    GeneralAboExpirationDate = row.GeneralAboExpirationDate,
                    HasEnkelKarte = row.HasEnkelKarte,
                    EnkelKarteExpirationDate = row.EnkelKarteExpirationDate,
                    HasHalbtax = row.HasHalbtax,
                    HalbtaxExpirationDate = row.HalbtaxExpirationDate,
                    HasCancellationInsurance = row.HasCancellationInsurance,
                    CancellationInsuranceExpirationDate = row.CanellationInsuranceExpirationDate,
                    Notes = row.Notes,
                    ChangeDate = DateTime.Now,
                    SbbInformationChangeDate = DateTime.Now
                };

                if (IsEmptyPerson(person) == false)
                {
                    persons.Add(person);
                }
                else
                {
                    break;
                }
            }

            return persons;
        }

        public void WritePersons(IList<Person> persons)
        {
            WriteColumnHeaders();

            var rowIndex = 2;
            foreach (var person in persons)
            {
                var row = GetRow(rowIndex);
                row.Id = person.Id;
                row.Firstname = person.Firstname;
                row.Lastname = person.Lastname;
                row.Gender = person.Gender;
                row.Title = person.Title;
                row.Street1 = person.Street1;
                row.City = person.City;
                row.Plz = person.Plz;
                row.Birthdate = person.Birthdate;
                row.EmailAddress = person.EmailAddress;
                row.PhoneNumber = person.PhoneNumber;
                row.MobileNumber = person.MobileNumber;
                row.BusinessPhoneNumber = person.BusinessPhoneNumber;
                row.HasGeneralAbo = person.HasGeneralAbo;
                row.GeneralAboExpirationDate = person.GeneralAboExpirationDate;
                row.HasHalbtax = person.HasHalbtax;
                row.HalbtaxExpirationDate = person.HalbtaxExpirationDate;
                row.NameOnPassport = person.NameOnPassport;
                row.PassportNumber = person.PassportNumber;
                row.PassportExpirationDate = person.PassportExpirationDate;
                row.HasJuniorKarte = person.HasJuniorKarte;
                row.JuniorKarteExpirationDate = person.JuniorKarteExpirationDate;
                row.HasEnkelKarte = person.HasEnkelKarte;
                row.EnkelKarteExpirationDate = person.EnkelKarteExpirationDate;
                row.HasCancellationInsurance = person.HasCancellationInsurance;
                row.CanellationInsuranceExpirationDate = person.CancellationInsuranceExpirationDate;
                row.Notes = person.Notes;

                rowIndex++;
            }
        }

        private void WriteColumnHeaders()
        {
            _worksheet.Cells[1, 1].Value = "Id";
            _worksheet.Cells[1, 2].Value = "Vorname";
            _worksheet.Cells[1, 3].Value = "Nachname";
            _worksheet.Cells[1, 4].Value = "Geschlecht";
            _worksheet.Cells[1, 5].Value = "Titel";
            _worksheet.Cells[1, 6].Value = "Strasse";
            _worksheet.Cells[1, 7].Value = "Stadt";
            _worksheet.Cells[1, 8].Value = "PLZ";
            _worksheet.Cells[1, 9].Value = "Geburtsdatum";
            _worksheet.Cells[1, 10].Value = "E-Mail";
            _worksheet.Cells[1, 11].Value = "Tel Privat";
            _worksheet.Cells[1, 12].Value = "Tel Mobile";
            _worksheet.Cells[1, 13].Value = "Tel Geschäftlich";
            _worksheet.Cells[1, 14].Value = "GA";
            _worksheet.Cells[1, 15].Value = "GA Ablaufdatum";
            _worksheet.Cells[1, 16].Value = "HalbTax";
            _worksheet.Cells[1, 17].Value = "HalbTax Ablaufdatum";
            _worksheet.Cells[1, 18].Value = "Name auf Pass";
            _worksheet.Cells[1, 19].Value = "Passnummer";
            _worksheet.Cells[1, 20].Value = "Pass gültig bis";
            _worksheet.Cells[1, 21].Value = "Junior Karte";
            _worksheet.Cells[1, 22].Value = "Junior Karte Ablaufdatum";
            _worksheet.Cells[1, 23].Value = "Enkel Karte";
            _worksheet.Cells[1, 24].Value = "Enkel Karte Ablaufdatum";
            _worksheet.Cells[1, 25].Value = "Annullationsversicherung";
            _worksheet.Cells[1, 26].Value = "Annullationsversicherung gültig bis";
            _worksheet.Cells[1, 27].Value = "Notizen";
        }

        private AddressbookWorksheetRow GetRow(int row)
        {
            return new AddressbookWorksheetRow(_worksheet, row);
        }

        private bool IsEmptyPerson(Person person)
        {
            return person.Firstname.IsNullOrEmpty() && person.Lastname.IsNullOrEmpty();
        }
    }
}
