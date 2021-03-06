﻿using UnityEngine;
using System.Collections;

public static class InteractionManager 
{
    
    static bool canLaunch = true;
    static bool canRotate = false;
    static bool canSwapCamera = false;

    public static void EnableLaunch()
    {
        canLaunch = true;
    }

    public static void DisableLaunch()
    {
        canLaunch = false;
    }

    public static void EnableRotation()
    {
        canRotate = true;
    }

    public static void DisableRotation()
    {
        canRotate = false;
    }

    public static void EnableCameraSwap()
    {
        canSwapCamera = true;
    }

    public static void DisableCameraSwap()
    {
        canSwapCamera = false;
    }

    public static bool IsLaunchEnable()
    {
        return canLaunch;
    }

    public static bool IsRotateEnable()
    {
        return canRotate;
    }    

    public static bool IsCameraSwapEnable()
    {
        return canSwapCamera;
    }
}
