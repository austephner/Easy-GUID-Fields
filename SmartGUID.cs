using System;
using UnityEngine;

namespace EasyGuidFields
{
    /// <summary>
    /// Serializable GUID field that can be locked to prevent changes to values from the editor. 
    /// </summary>
    [Serializable]
    public class SmartGuid
    {
        [SerializeField] private string _value = Guid.NewGuid().ToString();

        [SerializeField] private bool _locked;

        public string value => _value;

        public bool locked => _locked;

        public void SetLock(bool newLockedStatus)
        {
            _locked = newLockedStatus;
        }

        public void SetGuid(string guid, bool overrideLock = false, bool throwOnInvalidInput = false)
        {
            if (_locked && overrideLock)
            {
                return;
            }

            if (!Guid.TryParse(guid, out Guid _))
            {
                if (throwOnInvalidInput)
                {
                    throw new ArgumentException("Given GUID value is incorrectly formatted and not parseable.");
                }
                
                return;
            }
            
            _value = guid;
        }

        public void NewGuid()
        {
            if (_locked)
            {
                return;
            }

            _value = Guid.NewGuid().ToString();
        }
    }
}