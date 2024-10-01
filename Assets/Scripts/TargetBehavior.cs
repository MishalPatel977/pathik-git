using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class TargetBehavior : MonoBehaviour
{
    public GameObject hiddenPlatform;   // Reference to the hidden platform that will be activated
    public ExitDoor exitDoor;           // Reference to the Exit Door script for checking puzzle completion

    private bool isActivated = false;   // To ensure the target is only activated once

    private void OnTriggerEnter(Collider other)
    {
        // Check if the laser has hit the target
        if (other.CompareTag("Laser") && !isActivated)
        {
            Debug.Log("Laser hit the target! Activating hidden platform.");
            ActivatePlatform();  // Call the ActivatePlatform method to activate the hidden platform
        }
    }

    // This method activates the hidden platform and checks the exit door's puzzle completion state
    public void ActivatePlatform()
    {
        if (hiddenPlatform != null)
        {
            hiddenPlatform.SetActive(true);  // Activate hidden platform
            Debug.Log("Hidden platform activated.");
        }

        if (exitDoor != null)
        {
            exitDoor.CheckPuzzleCompletion();  // Check if all switches are activated
        }

        isActivated = true;  // Mark this target as activated
    }
}
