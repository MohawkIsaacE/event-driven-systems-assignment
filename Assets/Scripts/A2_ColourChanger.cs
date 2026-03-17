using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class A2_ColourChanger : MonoBehaviour, IHittable
{
    [HideInInspector]
    public UnityEvent<Colour> OnColourChangerHit;

    public Colour objectColour;

    public void Awake()
    {
        if (OnColourChangerHit == null) OnColourChangerHit = new UnityEvent<Colour>();
    }

    public void Hit(GameObject otherGameObject)
    {
        OnColourChangerHit.Invoke(objectColour);
    }
}
