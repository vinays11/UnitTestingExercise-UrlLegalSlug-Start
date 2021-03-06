﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrlLegalSlug;

namespace UrlLegalSlugTest
{
    [TestClass]
    public class SlugProducerTests
    {
        [TestMethod]
        [TestCategory("ClassTest")]
        public void SlugProducer_GetUrlSlug_WhenTitleContainsNoIllegalCharacters_ReturnsAsIs()
        {
            // Arrange
            var expectedSlug = "abcdegfhijklmnopqrstuvwxyz0123456789";

            // Act
            var actualSlug = SlugProducer.GetUrlSlug(expectedSlug);

            // Assert
            Assert.AreEqual(expectedSlug, actualSlug, $"We were expecting the Url slug to be: {expectedSlug}, but found the actual Url slug to be {actualSlug}");
        }

        [TestMethod]
        [TestCategory("ClassTest")]
        [DataRow("home security access", "home-security-access")]
        [DataRow("home.security.access", "home-security-access")]
        [DataRow("home-security-access", "home-security-access")]
        [DataRow("home–security–access", "home-security-access")]
        [DataRow("home security–access", "home-security-access")]
        [DataRow("home -–security–access", "home-security-access")]
        [DataRow("-home -–security–access-", "home-security-access")]
        public void SlugProducer_GetUrlSlug_WhenTitleContainsAllowedIllegalCharacters_ReplacesAllowedIllegalCharactersWithDash(string inputSlug, string expectedSlugArgument)
        {
            //Assert
            var expectedSlug = expectedSlugArgument;

            // Act
            var actualSlug = SlugProducer.GetUrlSlug(inputSlug);

            // Assert
            Assert.AreEqual(expectedSlug, actualSlug, $"We were expecting the Url slug to be: {expectedSlug}, but found the actual Url slug to be {actualSlug}");
        }

        [TestMethod]
        [TestCategory("ClassTest")]
        [DataRow("HoME-sEcuRity-AcCeSS-V1", "home-security-access-v1")]
        [DataRow("0home1-Se2c3ur456ITY@.a7CC8ess9", "0home1-se2c3ur456ity-a7cc8ess9")]
        public void SlugProducer_GetUrlSlug_WhenTitleContainsUpperCaseAlphabets_ReturnsLowerCaseAlphabets(string inputSlug, string expectedSlugArgument)
        {
            //Arrange
            var expectedSlug = expectedSlugArgument;

            //Act
            var actualSlug = SlugProducer.GetUrlSlug(inputSlug);

            //Assert
            Assert.AreEqual(expectedSlug, actualSlug, $"We were expecting the Url slug to be: {expectedSlug}, but found the actual Url slug to be {actualSlug}");
        }

        [TestMethod]
        [TestCategory("ClassTest")]
        [DataRow("home@=se!c*\\urity ac`ces$", "homesecurity-acces")]
        [DataRow("#h^ome security%acc*ess&", "home-securityaccess")]
        [DataRow("(h>ome s.+curity}-a\":ess)", "home-s-curity-aess")]
        [DataRow("'h~om?e se+cur<ity}-a\"*ess|", "home-security-aess")]
        [DataRow("{ho/me-security-acc_ess};", "home-security-access")]
        public void SlugProducer_GetUrlSlag_WhenTitleContainsIllegalCharacters_ReplacesIllegalCharactersWithBlank(string inputSlug,
            string expectedSlugArgument)
        {
            //Assert
            var expectedSlug = expectedSlugArgument;

            //Act
            var actualSlug = SlugProducer.GetUrlSlug(inputSlug);

            //Assert
            Assert.AreEqual(expectedSlug, actualSlug, $"We were expecting the Url slug to be: {expectedSlug}, but found the actual Url slug to be {actualSlug}");
        }
    }
}
