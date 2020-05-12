# Student-Success-Tracking
![GitHub](https://img.shields.io/github/license/DthRazak/Student-Success-Tracking)
[![Build status](https://ci.appveyor.com/api/projects/status/a43xeqp95t52mwrt?svg=true)](https://ci.appveyor.com/project/DthRazak/student-success-tracking)
![GitHub issues](https://img.shields.io/github/issues-raw/DthRazak/Student-Success-Tracking)
![GitHub closed issues](https://img.shields.io/github/issues-closed-raw/DthRazak/Student-Success-Tracking)

The goal of the project is to provide an easy and convenient way to track the success of the students.

## Prerequirements

* Visual Studio 2019
* .NET Core 3.1
* MSSQL

## How To Run

* Open solution in Visual Studio 2019
* Load solution dependencies from contex menu
* Set SST.WebUI project as Startup Project and build it.
* In package manager console set default project to SST.Persistence and write `update-database Migration-1`
* Run the application.

## Documentation

Please click [here](docs/Documentation.pdf) for the Student-Success-Tracking documentation. 
This includes lots of information and will be helpful if you want to understand the features Student-Success-Tracking currently offers.

## License

This project is licensed with the [Apache License 2.0](LICENSE).