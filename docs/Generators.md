# DataTableGenerator

The DataTableGenerator is a generic class that creates a DataTable from any list model.

## Instantiation and call

```csharp
private void YourMethod()
{
List<SourceModel> yourModel = new();
var logger = new ILogger<DataTableGenerator>();
var dtg = new DataTableGenerator<SourceModel>(logger);
var yourDataTable = dtg.GenerateDataTablleFromModelList(yourModel, false);
}
```

## ID field
The method offers two modes. In the "withId = true" mode, a DataTable with an ID field is created. If false is set, a table without an ID field is generated.

# Hash

Simple hashing method. Just give him a string and it works for you.

# Temporary Directory

This method creates a randomly generated directory and returns the path.

## Usage

```csharp
var tempDirectory = TempTools.GetTemporaryDirectory();
```

# TemporaryFile

Generates and disposes a temporary file.