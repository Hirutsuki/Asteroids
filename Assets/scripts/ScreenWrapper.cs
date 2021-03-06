using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    /// <summary>
    /// Called when the game object becomes invisible to the camera
    /// </summary>
    void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        // check left, right, top, and bottom sides
        if (position.x < ScreenUtils.ScreenLeft ||
            position.x > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        if (position.y > ScreenUtils.ScreenTop ||
            position.y < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }

        // move gameObject
        transform.position = position;
    }
}
