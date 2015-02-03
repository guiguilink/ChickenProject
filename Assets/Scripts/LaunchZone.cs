using UnityEngine;
using System.Collections;

public class LaunchZone : MonoBehaviour
{
    void OnTriggerEnter(Collider c)
    {
        InteractionManager.EnableLaunch();
        InteractionManager.DisableRotation();
    }

    void OnTriggerExit(Collider c)
    {
        InteractionManager.DisableLaunch();
        InteractionManager.EnableRotation();
    }
}
