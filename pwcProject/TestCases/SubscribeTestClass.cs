using NUnit.Framework;

namespace PwCProject
{
    /// <summary>
    /// This class contains the methods which are applicable on the Subscribe page of the website.
    /// </summary>
    public class SubscribeTestClass : TestBase
    {
        Home hm = new Home();
        Subscribe subs = new Subscribe();

        [Test, Order(1)]
        [TestCase(Description = "Verify the Title of the Subscribe Page")]
        public void Verify_The_Title_Of_The_Subscribe_Page()
        {
            hm.ClickSubscribe();
            Assert.AreEqual(subs.GetPageTitle(), Constants._pageTitleSubscribe, "Page Title is Subscribe");
        }

        [Test, Order(2)]
        [TestCase(Description = "Verify the names of all the fields of Subscribe form")]
        public void Verify_The_Names_Of_Fields_Of_Subscribe_Form()
        {
            hm.ClickSubscribe();
            subs.SwitchToiFrame();
            Assert.AreEqual(subs.GetFieldName("FirstName"), Constants._firstNameValueSubscribe, "Field value is First name");
            Assert.AreEqual(subs.GetFieldName("LastName"), Constants._lastNameValueSubscribe, "Field value is Last name");
            Assert.AreEqual(subs.GetFieldName("Company"), Constants._companyValueSubscribe, "Field value is Organisation");
            Assert.AreEqual(subs.GetFieldName("JobTitle"), Constants._jobTitleValueSubscribe, "Field value is Job title");
            Assert.AreEqual(subs.GetFieldName("EmailAddress"), Constants._businessEmailValueSubscribe, "Field value is Business email address");
            Assert.AreEqual(subs.GetDropdownFieldNames("State"), Constants._stateValueSubscribe, "Field value is State");
            Assert.AreEqual(subs.GetDropdownFieldNames("Country"), Constants._countryValueSubscribe, "Field value is Country");
        }

        [Test, Order(3)]
        [TestCase(Description = "Verify the type of all the fields of Subscribe form")]
        public void Verify_The_Type_Of_Fields_Of_Subscribe_Form()
        {
            Assert.AreEqual(subs.GetFieldType("FirstName"), Constants._firstNameTypeSubscribe, "Field type is Text");
            Assert.AreEqual(subs.GetFieldType("LastName"), Constants._lastNameTypeSubscribe, "Field type is Text");
            Assert.AreEqual(subs.GetFieldType("Company"), Constants._companyTypeSubscribe, "Field type is Text");
            Assert.AreEqual(subs.GetFieldType("JobTitle"), Constants._jobTitleTypeSubscribe, "Field type is Text");
            Assert.AreEqual(subs.GetFieldType("EmailAddress"), Constants._businessEmailTypeSubscribe, "Field type is email");
            Assert.IsTrue(subs.GetDropdownType("State"), "Field type is dropdown");
            Assert.IsTrue(subs.GetDropdownType("Country"), "Field type is dropdown");
        }

        [Test, Order(4)]
        [TestCase(Description = "Verify that all the fields are required in the Subscribe form")]
        public void Verify_All_The_Fields_Are_Required_In_The_Subscribe_Form()
        {
            Assert.IsTrue(subs.GetRequiredField("FirstName"), "First name is a required field");
            Assert.IsTrue(subs.GetRequiredField("LastName"), "Last name is a required field");
            Assert.IsTrue(subs.GetRequiredField("Company"), "Company is a required field");
            Assert.IsTrue(subs.GetRequiredField("JobTitle"), "Job Title is a required field");
            Assert.IsTrue(subs.GetRequiredField("EmailAddress"), "Business email is a required field");
            Assert.IsTrue(subs.GetRequiredField("State"), "State is a required field");
            Assert.IsTrue(subs.GetRequiredField("Country"), "Country is a required field");
        }

        [Test, Order(5)]
        [TestCase(Description = "Verify the Successful verification of Google Recaptcha in Subscribe form")]
        public void Verify_The_Successful_Verification_Of_Recaptcha_In_The_Subscribe_Form()
        {
            Assert.AreEqual(subs.FetchRecaptchaStatus(), Constants._recaptchaStatusSubscribe, "Captcha is complete");
        }
    }
}
