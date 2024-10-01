using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private int _maxBounce = 20;               // Maximum number of laser bounces
    private int _count;                        // Count of current laser reflections
    private LineRenderer _laser;               // Reference to the LineRenderer component

    [SerializeField]
    private Vector3 _offSet;                   // Offset to position the laser correctly

    void Start()
    {
        _laser = GetComponent<LineRenderer>(); // Get the LineRenderer component
        _laser.positionCount = _maxBounce;     // Set the number of positions in the LineRenderer
    }

    void Update()
    {
        _count = 0;                            // Reset the count of reflections
        castLaser(transform.position + _offSet, transform.forward); // Start the laser cast
    }

    void castLaser(Vector3 position, Vector3 direction)
    {
        _laser.SetPosition(0, transform.position + _offSet);  // Set initial position of the laser

        for (int i = 0; i < _maxBounce; i++)
        {
            Ray ray = new Ray(position, direction);           // Create a ray at the given position and direction
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 300))
            {
                position = hit.point;                        // Update position to the hit point
                direction = Vector3.Reflect(direction, hit.normal); // Reflect direction based on the hit normal

                _laser.SetPosition(i + 1, hit.point);        // Set position in the LineRenderer

                // Check for interaction with other objects
                if (hit.transform.CompareTag("Player"))
                {
                    Debug.Log("Player hit by laser. Game Over.");
                    Destroy(hit.transform.gameObject);       // Destroy the player or trigger a death event
                    break;
                }
                else if (hit.transform.CompareTag("Target"))
                {
                    
                    TargetBehavior targetBehavior = hit.transform.GetComponent<TargetBehavior>();
                    if (targetBehavior != null)
                    {
                        targetBehavior.ActivatePlatform();  // Activate the platform using the target's script
                    }
                    break;
                }
                else if (hit.transform.CompareTag("Mirror"))
                {
                    // Continue the reflection logic, already handled by direction update
                }
                else
                {
                    // If it hits an object that is not a Mirror, Player, or Target, stop reflecting
                    for (int j = i + 1; j < _maxBounce; j++)
                    {
                        _laser.SetPosition(j, hit.point);  // Set all remaining positions to the hit point
                    }
                    break;
                }
            }
            else
            {
                // If no objects are hit, set the laser to maximum length
                _laser.SetPosition(i + 1, ray.GetPoint(300));
                break;
            }
        }
    }
}

