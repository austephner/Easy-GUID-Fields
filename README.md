# GUID Attribute
#### Summary
Adds an attribute with a custom drawer that allows for easily generating and randomizing new GUID values within the Unity Editor. This small API uses the [Guid Struct](https://docs.microsoft.com/en-us/dotnet/api/system.guid?view=net-5.0) in the `System` namespace to generate new values.

# General Usage
1. Download the repository into your `Assets` folder (if downloading from Git). 
2. Import the uGUID namespace into a C# file.

```c#
using uGUID;
```

3. Create a `string` field inside any serializable class that you would use within the Unity Editor.

```c#
[Serializable]
public class MyBehaviour : MonoBehaviour
{
  public string myGuid;
}
```

4. Add the `[GUID]` attribute to the `string` field.

```c#
[GUID] public string myGuid;
```

5. In the Unity Editor, press the "R" button next to the field to randomize the GUID value. 
6. NOTE: You can initialize a GUID field by doing this:

```c#
using System;

...

[GUID] public string myGuid = Guid.NewGuid().ToString();
```

# Detailed Usage
More GUID handling with advanced classes coming soon. 
