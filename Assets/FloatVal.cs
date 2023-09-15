using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatVal : ScriptableObject, ISerializationCallbackReceiver
{
    //this is the value we can see and set in Unity inspector
    public float InitialValue;

    //this is the value that changes over time, the "runtime" value
    [NonSerialized]
    public float Value;

    //below is some "magic" that makes InitialValue and Value work
    //my reference: https://unity.com/how-to/architect-game-code-scriptable-objects
    public void OnAfterDeserialize()
    {
        Value = InitialValue;
    }

    public void OnBeforeSerialize() { }

    //below is some "magic" that can let us use FloatVal wherever a "float" type can be used
    //my reference: GitHub Copilot, generated from the comment above
    public static implicit operator float(FloatVal reference)
    {
        return reference.Value;
    }
}