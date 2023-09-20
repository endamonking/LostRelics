using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset = new Vector3(0, 8, -9); // The offset at which the camera follows the player

    void Update()
    {
        // Set the position of the camera's transform to be the same as the player's,
        // but offset by the calculated offset distance.
        transform.position = player.position + offset;
    }
}
