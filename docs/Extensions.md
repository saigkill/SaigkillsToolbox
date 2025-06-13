# DateTimeExtensions

## ConvertDateToNumeric

This method converts DateTime to a purely numeric value in the format "yyyyMMdd". Example: 20240112

### Usage

```csharp
var dt = DateTime.Now;
var myInt = dt.ConvertDateToNumeric(dt);
```

## ConvertDateTimeToString

This method converts the DateTime object to the format "yyyy-MM-dd HH:mm:ssZ"

### Usage

```csharp
var dt = DateTime.Now;
var myInt = dt.ConvertDateTimeToString(dt);
```

# IEnumerableExtensions

## IsEmpty<T>

This method checks, if a given IEnumerable is empty.

```csharp
var filledEnumeration = new IEnumeration<Model>();
filledEnumeration.IsEmpty<Model>(); // returns true or false
```

## IsNotEmpty<T>

This method checks, if a given IEnumerable is not empty.

```csharp
var filledEnumeration = new IEnumeration<Model>();
filledEnumeration.IsNotEmpty<Model>(); // returns true or false
```

# String Extensions

## GetSalutationText

This method returns the salutation based on a gender characteristic.

"Male" becomes "Herr" and "Female" becomes "Frau" (german words).

### Usage

```csharp
var gender = "Male"
var salutation = gender.GetSalutationText();

```

## ReturnGenderId

This method returns a gender ID based on a gender characteristic.

"Male" becomes "1" and "Female" becomes "2."

```csharp
var gender = "Male"
var genderId = gender.ReturnGenderId();

```