# OnSale

![alt text](https://github.com/nibro7778/mydiary/workflows/dotnet-core-build/badge.svg)
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)

On Sale App 2021 using .NET Core 5.0 + Xamarin Forms [Prism].

The project is based on [Zuluaga's Tutorial](https://www.youtube.com/playlist?list=PLuEZQoW9bRnTKcse75pub6T3-pi5M7NGy) with the following changes:

### OnSale.Web

* NET Core 5.0 instead of NET Core 2.2
* The Image Storage [(ImageHelper)](https://github.com/ShellShocker08/OnSale_2021/blob/main/OnSale.Web/Helpers/ImageUpload/ImageHelper.cs) is local with different functions:
    * **UploadImageAsync:** Upload Image with date structure
    * **UpdateImageAsync:** Update Image and check if you want to keep track of image history or delete previous and create new one
    * **DeleteImage** Delete Image from server  



## NuGets

### OnSale.Common

| NuGet                                             | Version |
| --------------------------------------------------|---------|
| NETStandard.Library                               | 2.0.3   |
| System.ComponentModel.Annotations                 | 5.0.0   |
| Newtonsoft.Json                                   | 12.0.3  |

### OnSale.Web

| NuGet                                             | Version |
| --------------------------------------------------|---------|
| Microsoft.AspNetCore.Identity.EntityFrameworkCore | 5.0.0   |
| Microsoft.EntityFrameworkCore                     | 5.0.0   |
| Microsoft.EntityFrameworkCore.Tools               | 5.0.0   |
| Microsoft.EntityFrameworkCore.SqlServer           | 5.0.0   |
| Windows.Azure.Storage                             | 9.3.3   |
