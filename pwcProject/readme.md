Pre-requisites for Running the PwCProject

Tools - 
	Visual Studio 2019 Community Version 16.8.5 
	Microsoft .NET Framework 4.8.03761

Packages Installed - 
	Selenium.WebDriver(4.3.0)
	Selenium.Support(4.3.0)
	NUnit (3.13.2)
	NUnit3TestAdapter(4.1.0)
	WebDriverManager (2.13.0)
	System.Configuration.ConfigurationManager (6.0.0)
	Microsoft.Extensions.Configuration.Binder (6.0.0)
	Microsoft.Extensions.Configuration.Json (6.0.0)
	Microsoft.NET.Test.Sdk (16.11.0)
	System.Windows.Extensions (6.0.0)
	SeleniumExtras.WaitHelpers (1.0.2)

Architecture -
	The project is a "NUnit 3 .Net Core Unit Test Project". The framework design is based on the Page Object Model where each page has a different class that contains the methods specific to that class. 
	Also each page has a separate TestClass containing the test cases related to that page. 
	The project is designed in a modular approach where each action is performed in a separate module. The methods are generalized to avoid code redundancy and to enhance reusability.
	Data Driven Development is used to separate the data from the code. No hard coding is done

Test Cases

	There is a separate folder named "TestCases" containing all the test cases related to the provided scenarios. The test cases are saggreegated into three different test classes.
		- HomeTestClass - This test class contains the test cases related to the Home page of the website.
		- SearchTestClass - The test cases related to the search functionality are present in this class.
		- SubscribeTestClass - The test cases of Subscribe form are embedded in this test class. 

	Steps for running Tests - 
		
		The test cases can be run in the Test Explorer window by clicking the green icon on the extreme left side of the top menu. 
	
Recaptcha

	FYI -
		Google Recaptcha is implemented to enforce security which protects the sites from spam. It decects the presence of a bot or any malicious software.
		Google Recaptcha can not be automated. It can be bypassed in the test environment for testing purpose.
		Although I have put my efforts to automate it but it cannot be.
	
