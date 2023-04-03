using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolucoes : MonoBehaviour
{
    public void SetResolutionQHD()
    {
        Screen.SetResolution(2560, 1440, true);
    }
    public void SetResolutionFullHD()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    public void SetResolutionNotebook()
    {
        Screen.SetResolution(1366,768, true);
    }
    public void SetResolutionHD()
    {
        Screen.SetResolution(1280,720, true);
    }
}
