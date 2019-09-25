# Search Assessment

## Environment

* .NET Core 2.2 (https://www.microsoft.com/net/download)
* git

## How to check

### Clone the repo

```sh
> git clone https://github.com/cbelyaev/search-assessment.git
```

### `appsettings.json` files

Extract archive `appsettings.zip` to `appsettings` folder.

```sh
> copy /Y appsettings\Uploader\appsettings.json search-assessment\Uploader
> copy /Y appsettings\Searcher\appsettings.json search-assessment\Searcher
> copy /Y appsettings\SearcherClient\appsettings.json search-assessment\SearcherClient
```

### Uploader

Use this tool to upload the data to AWS.

```sh
> cd search-assessment\Uploader
> dotnet run
> cd ..\..
```

### SearchClient

Use this tool to check search client without WebApi.
```sh
> cd search-assessment\SearcherClient
> 
```

### Start WebApi

The following commands start the development web server with Searcher API at http://localhost:5000/.
```sh
> cd search-assessment\Searcher
> dotnet run
```

Use the url http://localhost:5000/swagger/index.html to view the API reference.

### SearchWebClient (in the separate console window)

```sh
> cd search-assessment\SearcherWebClient
> dotnet run "greystone" "Austin,Los Angeles"
```
