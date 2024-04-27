using UnityEngine;

namespace LiteNinja.Applications
{
    public abstract class BaseApplicationSettings : ScriptableObject
    {
        [SerializeField]
        protected int _targetFrameRate = -1;
        
        public int TargetFrameRate => _targetFrameRate;
    }
}