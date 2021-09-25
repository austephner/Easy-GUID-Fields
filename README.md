# Easy GUID Fields
#### Summary
Adds some useful GUID field controls for within the Unity Editor. This small API uses the [Guid Struct](https://docs.microsoft.com/en-us/dotnet/api/system.guid?view=net-5.0) in the `System` namespace to generate new values.

![Example](https://i.imgur.com/kETVeFu.gif)

#Usage
### The `GUID` Attribute
1. Add a `using` statement to include the `QuickGUIDs` namespace.
2. Add the `[GUID]` attribute onto any `string` field. 
```c#
using System;
using QuickGUIDs;
using UnityEngine;

namespace TestBehaviours
{
    public class MyBehaviour : MonoBehaviour
    {
        [GUID] public string myGuid = Guid.NewGuid().ToString();
    }
}
```

### The `SmartGUID` Class
1. Add a `using` statement to include the `QuickGUIDs` namespace.
2. Add a new `SmartGUID` field.
3. Access the fields of the object to read its value, assign a new value, or evaluate its locked state.
```c#
using QuickGUIDs;
using UnityEngine;

namespace TestBehaviours
{
    public class MyBehaviour : MonoBehaviour
    {
        public SmartGUID mySmartGuid = new SmartGUID();

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