using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // Required to manage scene transitions



public class ExitDoor : MonoBehaviour
{
    public bool isActivated = false;        // Indicates if the exit door has been activated
    public Color activatedColor = Color.green;  // Color to change to when the door is activated
    public Color deactivatedColor = Color.red;  // Default color of the door when not activated
    private Renderer doorRenderer;          // Reference to the Renderer component of the exit door

    void Start()
    {
        // Get the Renderer component of the exit door to change its color
        doorRenderer = GetComponent<Renderer>();

        // Set the initial color to deactivated color
        if (doorRenderer != null)
        {
            doorRenderer.material.color = deactivatedColor;
        }
    }

    // This method is called to activate the exit door, usually when all switches are hit by the laser
    public void ActivateExitDoor()
    {
        isActivated = true; // Mark the door as activated
        Debug.Log("Exit door is now activated.");

        // Change the door color to indicate it is activated
        if (doorRenderer != null)
        {
            doorRenderer.material.color = activatedColor;
        }
    }

    // This method will handle when the player collides with the exit door
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has collided with the exit door and the door is activated
        if (other.CompareTag("Player") && isActivated)
        {
            Debug.Log("Player reached the exit door. You win!");

            // Optional: Show a win message or perform other actions (e.g., play a sound)

            // Destroy the player object to indicate the game has ended (replace with your own win condition logic)
            Destroy(other.gameObject);
        }
    }
}
