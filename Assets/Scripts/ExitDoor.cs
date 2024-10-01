using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ExitDoor : MonoBehaviour
{
    public bool isActivated = false;   // Indicates if the exit door is activated

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isActivated)
        {
            Debug.Log("Player reached the exit door. Game Over!");
            // Add your game over or next level logic here
        }
    }

    // Call this method when the door should be unlocked
    public void ActivateExitDoor()
    {
        isActivated = true;
        Debug.Log("Exit door is now activated.");
    }

    // Optional: This method can be used to verify if all targets are activated
    public void CheckPuzzleCompletion()
    {
        if (isActivated)
        {
            Debug.Log("Puzzle completed, door unlocked!");
        }
    }
}



