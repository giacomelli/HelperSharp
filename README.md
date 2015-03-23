HelperSharp
=========
[![Build Status](https://travis-ci.org/giacomelli/HelperSharp.png?branch=master)](https://travis-ci.org/giacomelli/HelperSharp)

A set of helpers and extensions for C# programming.

Setup
=========

NuGet
------
PM> Install-Package HelperSharp
PM> Install-Package HelperSharp.Mvc
PM> Install-Package HelperSharp.WebApi

Features
=========
Helpers
------
* **CurrencyHelper**
	* IsValidIsoCurrencySymbol: determines if is valid ISO currency symbol.
* **EnumerableHelper**
	* AreEqual&lt;T&gt;: verify if collections are equal comparing each item. Order is considered.
	* CalculateHashCode: calculates the hash code using all items.
* **ExceptionHelper**
	* ThrowIfNull: throws an ArgumentNullException if argument is null.
	* ThrowIfNullOrEmpty: throws an ArgumentNullException if argument is null or an ArgumentException if string is empty.
* **ExpressionHelper**
	* GetMemberExpression: gets a member expression from the expression.
* **GravatarHelper**
	* GetAvatarUrl: gets the avatar URL for the specified e-mail.
* **MD5Helper**
	* Encrypt: encrypt the specified string using MD5 algorithm.	
	* IsEncrypted: check if the specified string is encrypted using MD5.
* **ObjectHelper**
	* IsNullOrDefault&lt;T&gt;: check if argument is null or default value of T type.
	* CreateShallowCopy: creates a shallow copy of the specified source.
* **ReflectionHelper**
	* GetProperty: gets the property with the specified name.
	* GetPropertyValue: gets the property's value.
	* InvokeMethod: invokes the method with the specified parameters.
	* GetSubclassesOf: gets the subclasses of the specified type.

Extensions
------
* **ArrayExtensions**
	* RemoveDuplicates&lt;T&gt;: removes the duplicates items from array.
* **CharExtensions**
	*  HasAccent: determines if char is an accent
*  **ConvertibleExtensions**
	* To&lt;T&gt;: converts the type to specified T.
* **DateTimeExtensions**
	* GetBeginOfDay: gets the begin of day.
	* GetBeginOfMonth: gets the begin of month.
	* GetEndOfDay: gets the end of day.
	* GetEndOfMonth: gets the end of month.
* **EnumerableExtensions**
	* Each<T>: iterates in the collection calling the action for each item.
	* GetTypes: gets the types of the specified objects.
	* ToString<T>: iterates in the collection calling the action for each item and concatenating the result.
* **NameValueCollectionExtensions**
	* GetBoolean: gets a boolean value with the specified name.
	* GetInt32: gets a integer value with the specified name.
	* GetSingle: gets a single (float) value with the specified name.
* **StringExtensions**
	* GetWordFromIndex: gets the word in the specified index.
	* CountWords: counts the words.
	* RemoveAccents: removes the accents
	* RemoveNonAlphanumeric: removes the non alphanumeric chars.
	* RemoveNonNumeric: removes the non numeric chars.
	* RemoveFromBorders: removes the speficied string from borders.
	* RemovePunctuations: removes the punctuations.
	* EscapeAccentsToHex: escapes the accents to hexadecimal equivalent.
	* EscapeAccentsToHtmlEntities: escapes the accents to html entities.
	* EndsWithPunctuation: verify if source ends the with punctuation.
	* HasAccent: determines if has accent.
	* InsertUnderscoreBeforeUpperCase: Inserts the underscore before every upper case char.
	* With: format the specified string. Is a String.Format(CultureInfo.InvariantCulture,..) shortcut.
	* Capitalize: capitalize the string.
	* ContainsIgnoreCase: returns a value indicating whether the specified substring occurs within this string.
	

MVC
------

Helpers
------
* **ControllerHelper**
	* GetControllerTypes: gets all concrete controller types.
	* GetActionsDescriptors: gets all actions descriptors of the controller.

Extensions
------
* **ByteExtensions**
	* SendOverHttp: send the byte array content over HTTP current response.

WebApi
------

Extensions
------
* **HttpRequestMessageExtensions**
	* IsLocal: check if is a local request.
	
#License

Licensed under the The MIT License (MIT).
In others words, you can use this library for developement any kind of software: open source, commercial, proprietary and alien.


#Change Log

###HelperSharp
* 0.0.4.2: Sign the assembly. 
* 0.0.4.0:
	* Created Helper.WebApi package.
	* Added:
		* MD5Helper
		* ObjectHelper.CreateShallowCopy.
* 0.0.3.7	
	* Added:
		* StringExtensions.ContainsIgnoreCase
		* ExpressionHelper.GetMemberExpression
* 0.0.0.1: Initial version.

###HelperSharp.Mvc
* 0.0.3: Sign the assembly.
* 0.0.2: Added ByteExtensions.
* 0.0.1: Initial version.


###HelperSharp.WebApi
* 0.0.2: Sign the assembly.
* 0.0.1: Initial version.