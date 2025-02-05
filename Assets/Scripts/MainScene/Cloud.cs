using System.Collections;
using TMPro;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(yMovement());
    }

    void FixedUpdate()
    {
        transform.position -= new Vector3(Time.fixedDeltaTime * 40, 0, 0);
        if (transform.position.x < -1200)
            Destroy(gameObject);

    }

    IEnumerator yMovement()
    {
        float targetY, speed = 20;
        while (true)
        {
            targetY = transform.position.y + Random.Range(20.0f, 30.0f);
            speed = 20;
            while (transform.position.y < targetY)
            {
                rb.velocity = new Vector3(0, speed, 0);
                speed -= 0.1f;
                yield return new WaitForFixedUpdate();
            }
            rb.velocity = Vector3.zero;

            targetY = transform.position.y - Random.Range(20.0f, 30.0f);
            speed = 20;
            while (targetY < transform.position.y)
            {
                rb.velocity = new Vector3(0, speed * -1, 0);
                speed -= 0.1f;
                yield return new WaitForFixedUpdate();
            }
            rb.velocity = Vector3.zero;
        }
    }
}
