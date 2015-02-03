using UnityEngine;
using System.Collections;

public class LaunchZone : MonoBehaviour
{
    LaunchBlocker launchBlock;

    void Start()
    {
        launchBlock = GameObject.FindObjectOfType<LaunchBlocker>();
    }

    void OnTriggerEnter(Collider c)
    {
        InteractionManager.EnableLaunch();
        InteractionManager.DisableRotation();
        launchBlock.UnBlock();
    }

    void OnTriggerExit(Collider c)
    {
        InteractionManager.DisableLaunch();
        InteractionManager.EnableRotation();
        launchBlock.Block();
    }
}
