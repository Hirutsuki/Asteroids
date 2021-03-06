using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// setting the sprite for asteroid & get the asteroid moving
/// </summary>
public class Asteroid : MonoBehaviour
{
    [SerializeField]
    float minForce = 0.5f;
    [SerializeField]
    float maxForce = 1.5f;
    [SerializeField]
    Sprite sprite1;
    [SerializeField]
    Sprite sprite2;
    [SerializeField]
    Sprite sprite3;

    public float magnitude;
    public float angle;

    /// <summary>
    /// setting random sprite for asteroids
    /// </summary>
    void Start()
    {
        int randomSprite = Random.Range(1, 4);
        switch (randomSprite)
        {
            case 1:
                GetComponent<SpriteRenderer>().sprite = sprite1;
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = sprite2;
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = sprite3;
                break;
        }
    }

    /// <summary>
    /// setting different starting location & moving direction for asteroids
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="location"></param>
    public void Initialise(Direction direction, Vector3 location)
    {
        GetComponent<Rigidbody2D>().transform.position = location;

        switch (direction)
        {
            case Direction.Left:
                angle = Random.Range(165, 195) * Mathf.Deg2Rad;
                break;

            case Direction.Right:
                angle = Random.Range(-15, 15) * Mathf.Deg2Rad;
                break;

            case Direction.Up:
                angle = Random.Range(75, 105) * Mathf.Deg2Rad;
                break;

            case Direction.Down:
                angle = Random.Range(-105, -75) * Mathf.Deg2Rad;
                break;
        }
        magnitude = Random.Range(minForce, maxForce);
        StartMoving();
    }

    public void StartMoving()
    {
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(moveDirection * magnitude, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            AudioManager.Play(AudioClipName.AsteroidHit);
            Vector3 scale = gameObject.transform.localScale;
            scale.x *= 0.5f;
            scale.y *= 0.5f;

            if (scale.x < 0.5 || scale.y < 0.5)
            {
                Destroy(gameObject);
            }

            else
            {
                gameObject.transform.localScale = scale;

                GameObject asteroid1 = Instantiate(gameObject);
                angle += Random.Range(0, Mathf.PI);
                asteroid1.GetComponent<Asteroid>().StartMoving();
                GameObject asteroid2 = Instantiate(gameObject);
                angle += Random.Range(0, Mathf.PI);
                asteroid2.GetComponent<Asteroid>().StartMoving();

                Destroy(gameObject);
            }
        }
    }
}
