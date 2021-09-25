# GUID Fields
#### USAGE NOTE
The majority of this code has been included in another API with more randomizable Unity fields. See [Randomizable Fields](https://github.com/austephner/RandomizableFields).

#### Summary
Adds some useful GUID field controls for within the Unity Editor. This small API uses the [Guid Struct](https://docs.microsoft.com/en-us/dotnet/api/system.guid?view=net-5.0) in the `System` namespace to generate new values.

![Example](https://i.imgur.com/kETVeFu.gif)

# Usage
### The `Guid` Attribute
1. Add a `using` statement to include the `SmartGuid` namespace.
2. Add the `[Guid]` attribute onto any `string` field. 
```c#
using System;
using GuidFields;
using UnityEngine;

namespace TestBehaviours
{
    public class MyBehaviour : MonoBehaviour
    {
        [GUID] public string myGuid = Guid.NewGuid().ToString();
    }
}
```

### The `SmartGuid` Class
1. Add a `using` statement to include the `GuidFields` namespace.
2. Add a new `SmartGuid` field.
3. Access the fields of the object to read its value, assign a new value, or evaluate its locked state.
```c#
using GuidFields;
using UnityEngine;

namespace TestBehaviours
{
    public class MyBehaviour : MonoBehaviour
    {
        public SmartGuid mySmartGuid = new SmartGuid();

        private void Update()
        {
            // print the current value and lock state
        
            Debug.Log($"{mySmartGuid.value}, {mySmartGuid.locked}");
            
            // assign a random new GUID to the value
            
            mySmartGuid.NewGuid(); 
            
            // attempt to parse a GUID value by updating the object. When the second parameter is true,
            // the function will throw an exception if the given GUID isn't valid.
            
            try 
            {
                mySmartGuid.SetGuid("This Is Not a GUID", true);
            } 
            catch 
            {
                Debug.Log("Invalid GUID!");
            }
        }
    }
}
```