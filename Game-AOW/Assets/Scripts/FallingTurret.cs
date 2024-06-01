using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTurret : MonoBehaviour
{
    public float fallSpeed = 5.0f;
    public float destroyDelay = 1.0f;

    private void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject, destroyDelay);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, destroyDelay);
        }
    }
}
