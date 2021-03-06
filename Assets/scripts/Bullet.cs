using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Timer deathTimer;

    void Start()
    {
        const float BulletLife = 0.5f;

        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = BulletLife;
        deathTimer.Run();
    }

    void Update()
    {
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    public void ApplyForce(Vector2 direction)
    {
        const float Magnitude = 20f;
        GetComponent<Rigidbody2D>().AddForce(Magnitude * direction, ForceMode2D.Impulse);
    }
}
