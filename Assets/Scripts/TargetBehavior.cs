using System.Collections;
using System.Collections.Generic;
using UnityEngine;







public class TargetBehavior : MonoBehaviour
{
    public GameObject hiddenPlatform;   // Reference to the hidden platform that will be activated
    public ExitDoor exitDoor;           // Reference to the Exit Door script for checking puzzle completion
    private bool isActivated = false;   // To ensure the target is only activated once

    private Renderer platformRenderer;  // Reference to the Renderer component of the hidden platform

    private void Start()
    {
        if (hiddenPlatform != null)
        {
            // Set the hidden platform to inactive and invisible at the start
            hiddenPlatform.SetActive(false);

            // Get the Renderer component of the hidden platform (if available)
            platformRenderer = hiddenPlatform.GetComponent<Renderer>();

            if (platformRenderer != null)
            {
                platformRenderer.enabled = false;  // Make the platform invisible
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only activate if the target hasn't been activated before and is hit by a laser
        if (other.CompareTag("Laser") && !isActivated)
        {
            ActivatePlatform(); // Call the common activation method
        }
    }

    // This method activates the hidden platform and checks the exit door's puzzle completion state
    public void ActivatePlatform()
    {
        if (!isActivated)  // Ensure the platform is only activated once
        {
            if (hiddenPlatform != null)
            {
                hiddenPlatform.SetActive(true);  // Activate hidden platform
                if (platformRenderer != null)
                {
                    platformRenderer.enabled = true;  // Make the platform visible
                }
                Debug.Log("Hidden platform activated and made visible.");
            }

            if (exitDoor != null)
            {
                exitDoor.ActivateExitDoor();  // Call the method to activate the exit door
                Debug.Log("Exit door activated.");
            }

            isActivated = true;  // Mark this target as activated
        }
    }
}
