using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// spawning asteroids
/// </summary>
public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabAsteroid;

    // Start is called before the first frame update
    void Start()
    {
        //get collider radius
        GameObject asteroid = Instantiate(prefabAsteroid);
        float colliderRadius = asteroid.GetComponent<CircleCollider2D>().radius;
        Destroy(asteroid);

        //instantiating & initialising asteroids
        GameObject asteroid1 = Instantiate(prefabAsteroid);
        Vector3 location1 = new Vector3(0, ScreenUtils.ScreenTop + colliderRadius + 0.25f, 0);
        asteroid1.GetComponent<Asteroid>().Initialise(Direction.Down, location1);

        GameObject asteroid2 = Instantiate(prefabAsteroid);
        Vector3 location2 = new Vector3(ScreenUtils.ScreenRight + colliderRadius + 0.25f, 0, 0);
        asteroid2.GetComponent<Asteroid>().Initialise(Direction.Left, location2);

        GameObject asteroid3 = Instantiate(prefabAsteroid);
        Vector3 location3 = new Vector3(ScreenUtils.ScreenLeft - colliderRadius - 0.25f, 0, 0);
        asteroid3.GetComponent<Asteroid>().Initialise(Direction.Right, location3);

        GameObject asteroid4 = Instantiate(prefabAsteroid);
        Vector3 location4 = new Vector3(0, ScreenUtils.ScreenBottom - colliderRadius - 0.25f, 0);
        asteroid4.GetComponent<Asteroid>().Initialise(Direction.Up, location4);
    }
}
