using System;
using UnityEngine;

namespace EasyGuidFields
{
    [Serializable]
    public class SmartGUID
    {
        [SerializeField] private string _value = Guid.NewGuid().ToString();

        [SerializeField] private bool _locked;

        public string value => _value;

        public bool locked => _locked;

        public void SetGuid(string guid, bool throwOnInvalidInput = false)
        {
            if (_locked)
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