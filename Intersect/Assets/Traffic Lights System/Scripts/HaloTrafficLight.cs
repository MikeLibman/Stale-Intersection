using UnityEngine;
using System.Collections;

//=============================================================================
//  HaloTrafficLight
//  by Mariusz Skowroński
//
//  Simple implementation of TrafficLight
//  For each of three light colors (red, yellow and green) it requires one
//  mesh renderer and one object with halo effect attached.
//  To visualize the states of lights (on / off) it requires two materials:
//  - one with a texture for the lights turned off
//  - and one with a texture for the lights turned on.
//  You can use (like in demo scene) two different materials with single,
//  common texture for lights states.
//=============================================================================
public class HaloTrafficLight : TrafficLightBase
{
    public Renderer redLightRenderer;
    public GameObject redLightHalo;

    public Renderer yellowLightRenderer;
    public GameObject yellowLightHalo;

    public Renderer greenLightRenderer;
    public GameObject greenLightHalo;
    
    public Material lightsOnMat;
    public Material lightsOffMat;

    private bool mInitialized = false;

    void Awake()
    {
        if (redLightRenderer != null && yellowLightRenderer != null && greenLightRenderer != null
            && redLightHalo != null && yellowLightHalo != null && greenLightHalo != null)
        {
            mInitialized = true;
        }
        else
        {
            mInitialized = false;
            Debug.LogError("Some variables haven't been assigned correctly for HaloTrafficLight script.", this);
        }
    }

    // implementation of the callback from TrafficLight - called when lights state has changed
    public override void OnLightStateChanged(bool redLightState, bool yellowLightState, bool greenLightState)
    {
        if (!mInitialized)
            return;

        redLightHalo.SetActive(redLightState);
        redLightRenderer.material = (redLightState) ? lightsOnMat : lightsOffMat;

        yellowLightHalo.SetActive(yellowLightState);
        yellowLightRenderer.material = (yellowLightState) ? lightsOnMat : lightsOffMat;

        greenLightHalo.SetActive(greenLightState);
        greenLightRenderer.material = (greenLightState) ? lightsOnMat : lightsOffMat;
    }
}
