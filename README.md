# README #

1. Initial development started, nothing really to say or do here

### What is this repository for? ###

* Initial build of the AgileTracker for sprint and project planning within the Agile process.
* Version: 1.0.0.x

### How do I get set up? ###

* Summary of set up
	1. Clone the /master branch to the appropriate branch type
	2. Navigate to the Node directory and run `npm install`
	3. Build SuperSolution
* Configuration
* Dependencies
	1. NodeJS v10.15.0
	2. Node Package Manager v6.4.1
	3. .NET Framework v4.7.2
	4. Visual Studio 2017
* Database configuration
	1. Azure deployed Cosmos DB instance running MongoDB API

* How to run tests
* Deployment instructions

### Contribution guidelines ###

* Writing tests
	1. All tests must have an optional flag to be removed from release builds.
* Code review
	1. Pull Requests are reviewed before being accepted. Any change requests will be commented to the pull request before sending back.
* Other guidelines
	1. Variable Requirements
		* Parameter names must be indicative of the intent of the variable
		* All object variables (i.e. instnace of a class) must be prefixed with an 'o' e.g. `Foo oFoo;`
		* String variables must be prefixed with an 's' e.g. `std::string sInputString;`
		* Member variables of a class can optionally be prefixed with an `m_`
			
			
	2. Class Requirements
		* All class names must adhere to the standards for the given language
		
	3. Project Requiremnts
		* All projects must use the default `gcagt` namespace
	
					