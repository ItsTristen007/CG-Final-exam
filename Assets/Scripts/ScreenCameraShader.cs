using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCameraShader : MonoBehaviour
{
    public Material Lut1;
    

    private Material[] luts;
    private bool[] lutEnabled;
    private int currentLutIndex = -1; 

    void Start()
    {
        luts = new Material[] { Lut1};
        lutEnabled = new bool[] {true}; 
    }

    void Update()
    {
        // Toggle LUTs on/off
        if (Input.GetKeyDown(KeyCode.Alpha1)) ToggleLUT(0);


        // Switch LUTs based on the number pressed, if enabled
        if (Input.GetKeyDown(KeyCode.Alpha1) && lutEnabled[0]) SwitchLUT(0);

    }

    private void SwitchLUT(int index)
    {
        if (index >= 0 && index < luts.Length && lutEnabled[index])
        {
            currentLutIndex = index;
        }
    }

    private void ToggleLUT(int index)
    {
        if (index >= 0 && index < lutEnabled.Length)
        {
            lutEnabled[index] = !lutEnabled[index];

            
            if (currentLutIndex == index && !lutEnabled[index])
            {
                currentLutIndex = -1; 
            }
        }
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (currentLutIndex >= 0)
        {
            Graphics.Blit(source, destination, luts[currentLutIndex]);
        }
        else
        {
            Graphics.Blit(source, destination); 
        }
    }
}
