# Deezer REST SDK for .net

The Deezer REST SDK for .net allows you to build .net applications that take advantage of 
the [Deezer REST API](http://developers.deezer.com/api).

Please note that this SDK is unofficial (but the core team of that lib works at Deezer).

## Features

- /infos API method - *Gets the infos about the availability of the Deezer service for the current country (geo IP-based)*
- /artist/{id} API method - *Gets an artist based on it's ID.*

## Getting started

### Download & install

#### Via Git

To get the source code of the SDK via git, just type: 

	git clone git://github.com/cmaneu/deezer-net-api.git
	cd deezer-net-api

#### Via NuGet

When we have an interesting level of features, we will publish it to Nuget.

## Target frameworks

We are providing a Portable Class Library that targets the following frameworks: 

- .net Framework 4.0.3 and higher, 
- Silverlight 5, 
- Windows Phone 8, 
- Windows Store Apps (Windows 8).

We do regular checks against Mono/Xamarin compiler, but it's not a priority (if something is broke, 
feel free to create an issue or a pull request :) ).

## Planned features

A lot of work !

- Access to user infos (albums, playlists, favourites artists, ...)
- Access to user history
- Access to Deezer exclusive content (top charts, editorial content, ...)

## Dependencies

- Json.Net
- Microsoft HTTP Library
- Microsoft BCL Library

## Unit tests

We do provide unit tests for that library. As there is no clean ways to run the tests on every platform 
targeted by the SDK, for now, we only use the Windows Store apps unit test runner.

We know that some initiatives - like [Test framework used in PCL Storage](http://pclstorage.codeplex.com/) 
- try to provide some solutions, but it's just the beginning of that lib.
