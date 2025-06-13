# CsvService

The CsvService offers the possibility to pass any list model in order to generate a CSV file from it.

## Usage

### DependencyInjection (Program.cs)
```csharp
Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
    {
        configuration.Sources.Clear();
        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configurationRoot = configuration.Build();
        Configuration = configurationRoot;              
	}).ConfigureServices((services) =>
    {
        services.AddSingleton<IConfigurationRoot>(Configuration);        
        services.AddSingleton<ICsvWriterService, CsvWriterService>();
    });
```

### Usage after Dependency Injection
```csharp
private void DeineMethode()
{
   var model = new SomeModel();
   await _service,Write(model, pathWithFilename);
}
```

# EmailService

A service for sending emails. This implementation is for usecases where the mailserver is reachable internal without authentification.

## Usage

### Configuration

You need to configure the follwing in the sppsettings.json:

```json
{
  "EmailServer": {
    "DefaultEmailAddress": "x@y.com",
    "DefaultSenderName": "My Bot or My Name",
    "ServerIP": "Servers IP or Hostname",
    "Host": "Hostname",
    "Port": 587,
    "UseSSL": true
}
```

### DependencyInjection (Program.cs)
```csharp
Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
    {
        configuration.Sources.Clear();
        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configurationRoot = configuration.Build();
        Configuration = configurationRoot;              
	}).ConfigureServices((services) =>
    {
        services.AddSingleton<IConfigurationRoot>(Configuration);
        services.AddSingleton<IEmailService, EmailService>();
    });
```

### Usage

```csharp
private void AMethod()
{
var email = new MimeMessage
		{
			Subject = "Subject",
			Body = new TextPart("plain") { Text = @$"Lorem ipsum dolor Saschas Bot :-)" },
			To =
			{
				new MailboxAddress("recipient1", "Emailaddress"),
				new MailboxAddress("recipient2", "Emailaddress")
			}
		};

		await _emailService.SendMessageAsync(email);
}
```

# EmailServiceWithAuth

A service for sending emails. This implementation is regular scenarios with authentification.

## Usage

### Configuration

You need to configure the follwing in the sppsettings.json:

```json
{
  "EmailServer": {
    "DefaultEmailAddress": "x@y.com",
    "DefaultSenderName": "My Bot or My Name",
    "Host": "Hostname",
    "Port": 587,
    "UseSSL": true
    "User": "anything@example.de",
    "Password": "password"
}
```

### DependencyInjection (Program.cs)
```csharp
Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
    {
        configuration.Sources.Clear();
        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configurationRoot = configuration.Build();
        Configuration = configurationRoot;              
	}).ConfigureServices((services) =>
    {
        services.AddSingleton<IConfigurationRoot>(Configuration);
        services.AddSingleton<IEmailService, EmailServiceWithAuth>();
    });
```

### Usage

```csharp
private void AMethod()
{
var email = new MimeMessage
		{
			Subject = "Subject",
			Body = new TextPart("plain") { Text = @$"Lorem ipsum dolor Saschas Bot :-)" },
			To =
			{
				new MailboxAddress("recipient1", "Emailaddress"),
				new MailboxAddress("recipient2", "Emailaddress")
			}
		};

		await _emailService.SendMessageAsync(email);
}
```

# WebDavService

The WebDavService offers the possibility to upload or download files to a WebDavServer.

## Instantiation
The service is integrated via dependency injection:
```csharp
Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, configuration) =>
    {
        configuration.Sources.Clear();
        configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configurationRoot = configuration.Build();
        Configuration = configurationRoot;              
	}).ConfigureServices((services) =>
    {
        services.AddSingleton<IConfigurationRoot>(Configuration);
        services.AddSingleton<IWebDavService, WebDavService>();
    });
```

## Configuration
As a minimum configuration we need the following settings:
The respective values ​​are for demo purposes only and must be adjusted.

```json
{
   "WebDavServer": {
	"Password": "Password",	
	"Url": "Webdav Server Url",
	"Username": "Username"
   }
}
```

The "WebDavServer:Password" is the password for the WebDav server, the "WebDavServer:Url" is the URL of the WebDav server. The "WebDavServer:Username" is the login username.

## Call
The following methods can be called:

### `DownloadFileAsync(string remotefilepath, string localfilepath)`
The method downloads a file (remotefilepath) and saves it in the localfilepath.

**IMPORTANT**: Both paths contain both the path to the file and the file name itself.

### `DeleteFileAsync(string remotefilepath)`
The method deletes a file.

**IMPORTANT**: The remotefilepath contains the path to the file and also the file name itself.

### `UploadFileAsync(string localfilepath, string remotefilepath)`
The method uploads a file to a WebDav path.
**IMPORTANT**: Both paths include the path to the file as well as the file name itself.