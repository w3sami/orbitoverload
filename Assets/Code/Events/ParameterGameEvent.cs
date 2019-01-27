// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
using UnityEngine.Events;

namespace RoboRyanTron.Unite2017.Events
{
    [System.Serializable]
    public class ParameterGameEvent : UnityEvent<object[]>
    {
    }
}