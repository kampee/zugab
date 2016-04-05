﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZuegerAdressbook.ViewModels;

namespace Test
{
    [TestClass]
    public class PersonViewModelTests
    {
        [TestMethod]
        public void GivenSevenYearsOldThenIsChild()
        {
            var person = new PersonViewModel()
                         {
                             Birthdate = DateTime.Now.AddYears(-7)
                         };

           Assert.IsTrue(person.IsChild.Value);
        }

        [TestMethod]
        public void GivenSixteenAndOneDayYearsOldThenIsChild()
        {
            // wurde gestern 16
            var person = new PersonViewModel
                         {
                             Birthdate = DateTime.Now.AddYears(-16).AddDays(-1)
                         };

           Assert.IsTrue(person.IsChild.Value);
        }

        [TestMethod]
        public void GivenSixteenYearsOldThenIsChild()
        {
            var person = new PersonViewModel
            {
                             Birthdate = DateTime.Now.AddYears(-16)
                         };

           Assert.IsTrue(person.IsChild.Value);
        }

        [TestMethod]
        public void GivenSixteenSubtractOneDayYearsOldThenIsAdult()
        {
            // wird am nächsten tag 16 (ist noch 15)
            var person = new PersonViewModel
            {
                Birthdate = DateTime.Now.AddYears(-16).AddDays(1)
            };

            Assert.IsTrue(person.IsChild.Value);
        }

        [TestMethod]
        public void GivenSeventeenSubtractOneDayYearsOldThenIsChild()
        {
            // wird am nächsten tag 17 (ist noch 16)
            var person = new PersonViewModel
            {
                Birthdate = DateTime.Now.AddYears(-17).AddDays(1)
            };

            Assert.IsTrue(person.IsChild.Value);
        }

        [TestMethod]
        public void GivenSeventeenYearsOldThenIsChild()
        {
            var person = new PersonViewModel
            {
                Birthdate = DateTime.Now.AddYears(-17)
            };

            Assert.IsFalse(person.IsChild.Value);
        }

        [TestMethod]
        public void GivenTwentyYearsOldThenIsAdult()
        {
            var person = new PersonViewModel
            {
                Birthdate = DateTime.Now.AddYears(-20)
            };

            Assert.IsFalse(person.IsChild.Value);
        }

        [TestMethod]
        public void GivenUnknownBirthdateThenIsUnknown()
        {
            var person = new PersonViewModel();

            Assert.IsNull(person.IsChild);
        }
    }
}