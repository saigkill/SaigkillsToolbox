# Saigkills Toolbox

## Description
This is a collection of my personal tools and libraries.

* Firewall checker
* DateOnlyConverter
* DateTimeExtensions
* IEnumerableExtensions
* StringExtensions
* DataTableGenerator
* TemporaryDirectory Generator
* Hash Generator
* TemporaryFile Generator
* Pipeline pattern support
* Retry pattern support
* CSV Service
* Email Service
* WebDav Service

The project is splitted into several subprojects. Each subproject is a single NuGet package.

This project replaces and continues the project [SaschasToolbox](https://www.nuget.org/packages/SaschaManns.SaschasToolbox/). The old project is deprecated and will not be maintained anymore.

## Badges

|What|Status|
|---|---|
|Language|C#|
|Framework|.NET 8, netstandard2.0 |
|Continuous Integration Prod | [![Build status](https://dev.azure.com/saigkill/Saigkill.Toolbox/_apis/build/status/Saigkill.Toolbox-.NET%20Desktop-CI-Prod)](https://dev.azure.com/saigkill/Saigkill.Toolbox/_build/latest?definitionId=65)|
|Continuous Integration Stage | [![Build status](https://dev.azure.com/saigkill/Saigkill.Toolbox/_apis/build/status/Saigkill.Toolbox-.NET%20Desktop-CI-Stage)](https://dev.azure.com/saigkill/Saigkill.Toolbox/_build/latest?definitionId=66) |
|Deployment Prod | [![Deployment status](https://vsrm.dev.azure.com/saigkill/_apis/public/Release/badge/820066de-bb64-4006-87d1-70ca26310c2f/1/1)](https://dev.azure.com/saigkill/Saigkill.Toolbox/_release?_a=releases&view=mine&definitionId=1) |
|Deployment Stage | [![Deployment status](https://vsrm.dev.azure.com/saigkill/_apis/public/Release/badge/820066de-bb64-4006-87d1-70ca26310c2f/2/2)](https://dev.azure.com/saigkill/Saigkill.Toolbox/_release?_a=releases&view=mine&definitionId=2) |
|Code Coverage|![Azure DevOps coverage](https://img.shields.io/azure-devops/coverage/saigkill/Saigkill.Toolbox/66) |
|Bugreports|[![GitHub issues](https://img.shields.io/github/issues/saigkill/SaschasToolbox)](https://github.com/saigkill/SaigkillsToolbox/issues)
|Bugreports|[![Board Status](https://dev.azure.com/saigkill/820066de-bb64-4006-87d1-70ca26310c2f/2988b49e-078f-47a8-810c-f179fa8efa81/_apis/work/boardbadge/745fc052-256a-4941-9d95-ee0e344b0563)](https://dev.azure.com/saigkill/820066de-bb64-4006-87d1-70ca26310c2f/_boards/board/t/2988b49e-078f-47a8-810c-f179fa8efa81/Stories/)|
|Blog|[![Blog](https://img.shields.io/badge/Blog-Saigkill-blue)](https://saschamanns.de)|

File a bug report [on Github](https://github.com/saigkill/SaigkillsToolbox/issues?q=sort%3Aupdated-desc+is%3Aissue+is%3Aopen).

File a bug report [on Azure DevOps](https://dev.azure.com/saigkill/Saigkill.Toolbox/_workitems/recentlyupdated/).

## Documentation

A little documentation is [there](https://dev.azure.com/saigkill/Saigkill.Toolbox/_wiki/wikis/Saigkill.Toolbox.wiki/6/Main-Site).

A api doc is [there](https://moongladestorage2024.blob.core.windows.net/$web/saigkills-toolbox/api/Checker.html).

## Deployment

The deployment is done by Azure DevOps. 
The development branch is deployed to [Azure Artifacts Nuget feed](https://pkgs.dev.azure.com/saigkill/Saigkill.Toolbox/_packaging/SaigkillsToolbox-Stage/nuget/v3/index.json).
The master branch is deployed to [NuGet.org](https://www.nuget.org/packages?q=saigkill.toolbox).

|Name|Status|Version|
|---|---|---|
|Saigkill.Toolbox.Checker | ![NuGet Downloads](https://img.shields.io/nuget/dt/Saigkill.Toolbox.Checker) | ![NuGet Version](https://img.shields.io/nuget/v/Saigkill.Toolbox.Checker) |
|Saigkill.Toolbox.Converter | ![NuGet Downloads](https://img.shields.io/nuget/dt/Saigkill.Toolbox.Converter) | ![NuGet Version](https://img.shields.io/nuget/v/Saigkill.Toolbox.Converter) |
|Saigkill.Toolbox.Extensions | ![NuGet Downloads](https://img.shields.io/nuget/dt/Saigkill.Toolbox.Extensions) | ![NuGet Version](https://img.shields.io/nuget/v/Saigkill.Toolbox.Extensions) |
|Saigkill.Toolbox.Generators | ![NuGet Downloads](https://img.shields.io/nuget/dt/Saigkill.Toolbox.Generators) | ![NuGet Version](https://img.shields.io/nuget/v/Saigkill.Toolbox.Generators) |
|Saigkill.Toolbox.Patterns | ![NuGet Downloads](https://img.shields.io/nuget/dt/Saigkill.Toolbox.Patterns) | ![NuGet Version](https://img.shields.io/nuget/v/Saigkill.Toolbox.Patterns) |
|Saigkill.Toolbox.Services | ![NuGet Downloads](https://img.shields.io/nuget/dt/Saigkill.Toolbox.Services) | ![NuGet Version](https://img.shields.io/nuget/v/Saigkill.Toolbox.Services) |


## Installation
Just install the needed package to your project.
