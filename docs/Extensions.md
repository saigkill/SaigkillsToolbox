# DateTimeExtensions

## ConvertDateToNumeric

This method converts DateTime to a purely numeric value in the format "yyyyMMdd". Example: 20240112

```csharp
var dt = DateTime.Now;
var myInt = dt.ConvertDateToNumeric(dt);
```

## ConvertDateTimeToString

This method converts the DateTime object to the format "yyyy-MM-dd HH:mm:ssZ"

```csharp
var dt = DateTime.Now;
var myInt = dt.ConvertDateTimeToString(dt);
```

## IsBetween

This method checks if a given DateTime is between two other DateTime values. Returns true if the date is between the start and end dates, inclusive.

```csharp
var date = new DateTime(2023, 10, 15);
var startDate = new DateTime(2023, 10, 1);
var endDate = new DateTime(2023, 10, 31);

var result = date.IsBetween(startDate, endDate);
```

## StartOfDay

This method returns the start of the day for a given DateTime, setting the time to 00:00:00. 

```csharp
var date = new DateTime(2023, 10, 15, 14, 30, 45);     
var result = date.StartOfDay();
```

## EndOfDay

This method returns the end of the day for a given DateTime, setting the time to 23:59:59.

```csharp
var date = new DateTime(2023, 10, 15, 14, 30, 45);      
var result = date.EndOfDay();
```

## IsWeekend

This method checks if a given DateTime falls on a weekend (Saturday or Sunday).

```csharp
var date = new DateTime(2023, 10, 14); // Saturday
var result = date.IsWeekend();
```

## NextBusinessDay

This method calculates the next business day after a given DateTime, skipping weekends.

```csharp
var date = new DateTime(2023, 10, 13); // Friday      
var result = date.NextBusinessDay();
```

# IEnumerableExtensions

## IsEmpty

This method checks, if a given IEnumerable is empty.

```csharp
var filledEnumeration = new IEnumeration<Model>();
filledEnumeration.IsEmpty<Model>(); // returns true or false
```

## IsNotEmpty

This method checks, if a given IEnumerable is not empty.

```csharp
var filledEnumeration = new IEnumeration<Model>();
filledEnumeration.IsNotEmpty<Model>(); // returns true or false
```

## IsNullOrEmpty

This method checks if a given IEnumerable is null or empty.

```csharp
IEnumerable<int>? collection = null;
var result = collection.IsNullOrEmpty();
```

## HasItems

This method checks if a given IEnumerable has any items.

```csharp
var collection = new List<int> { 1, 2, 3 };
var result = collection.HasItems();
```

## Foreach

This method iterates over each item in an IEnumerable and executes a specified action on each item.

```csharp
var collection = new List<int> { 1, 2, 3 };      
var result = collection.HasItems();
```

## WhereNotNull
This method filters an IEnumerable to include only non-null items.

```csharp
var collection = new List<string?> { "a", null, "b", null, "c" };      
var result = collection.WhereNotNull();
```

## ToSafeList

This method converts an IEnumerable to a List, ensuring that it is not null. If the input is null, it returns an empty list.

```csharp
IEnumerable<int>? collection = null;      
var result = collection.ToSafeList();
```

# OptimisedLinqExtensions

## AnyFast

This method checks if any element in an IEnumerable satisfies a specified condition, optimized for performance.

```csharp
var collection = new List<int> { 1, 2, 3 };      
var result = collection.AnyFast();
```

## FirstOrDefault
This method retrieves the first element of an IEnumerable that satisfies a specified condition, or returns a default value if no such element exists. It is optimized for performance.

```csharp
var collection = new List<int>();
var result = collection.FirstOrDefault(0);
```

## TakeFast

This method retrieves a specified number of elements from the start of an IEnumerable, optimized for performance.

```csharp
var collection = new List<int> { 1, 2, 3 };
var result = collection.TakeFast(0);
```

# String Extensions

## GetSalutationText

This method returns the salutation based on a gender characteristic.

"Male" becomes "Herr" and "Female" becomes "Frau" (german words).

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

## IsNullOrEmpty
This method checks if a given string is null or empty.

```csharp
var value = "Test";
var result = value.IsNullOrEmpty();
```

## ToSafeString

This method converts a string to a safe string, returning an empty string if the input is null.

```csharp
object? value = null;
var result = value.ToSafeString();
```

## Truncate

This method truncates a string to a specified length, appending an ellipsis ("...") if the string exceeds that length.

```csharp
var value = "This is a long string";
var maxLength = 10;
var result = value.Truncate(maxLength);
```

# ValidationExtensions

## IsValidEmail

This method checks if a given string is a valid email address using System.Net.Mail.

```csharp
var email = "test@example.com";
var result = email.IsValidEmail();
```

## IsValidPhoneNumber

This method checks if a given string is a valid phone number. Number must between 10 and 15 digits long.

```csharp
var phoneNumber = "+1234567890";
var result = phoneNumber.IsValidPhoneNumber();
```

## IsInRange

This method checks if a given integer is within a specified range. Can be usedwith int and decimal types.

```csharp
var value = 15;
var result = value.IsInRange(1, 10);
```

## ValidateRequired

This method checks if a given string is not null or empty, and throws an exception if it is.

```csharp
var value = "Test";
var fieldName = "Field";
var result = value.ValidateRequired(fieldName);
```