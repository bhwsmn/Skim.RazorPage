# Skim
> Skim - Link Shortener

Skim is a minimalistic, NOJS URL Shortener Webapp.

![Index](https://github.com/smnbhw/Skim.RazorPage/raw/master/Readme%20Assets/Index.png)

## Features

- Strictly 100% No Javascript required
- Minimalistic and lightweight (Less than 70 KB, and most of it is the background image, which can be removed without any consequences)
- Fully responsive
- Validations - Ignores misformed URL and same domain links

## Installation

OS X, Linux & Windows:
(git clone and run the following commands in the cloned directory)

```sh
dotnet restore
dotnet run
```

## Docker Instruction

Clone this git repository and inside the cloned directory, run the following commands to create a docker container:

```sh
docker build --tag skim:latest .
docker run -d --name skim -p 8080:80 skim
```

Visit http://localhost:8080/ to access the WebApp.

## Usage Example

- Paste your valid long url in the input box
- Hit *Shorten* to generate the short link

## Development Setup

Make sure to have .NET Core SDK installed on your machine. Git clone this repository and run the following in the cloned directory.

```sh
dotnet restore
```

## Meta

Distributed under the GNU GPLv3 license. See ``LICENSE.txt`` for more information.

[https://github.com/smnbhw/Skim.RazorPage.git](https://github.com/smnbhw/Skim.RazorPage.git)
 
