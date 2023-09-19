using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private Transform FirePoint;
    [SerializeField] private GameObject empPrefab;
    [SerializeField] private float empFireSpeed;
    [SerializeField] private float initialUpwardSpeed;
    [SerializeField] private float gravityForce;
    private bool hasFired = false;
    private float timer = 0f;
    private Rigidbody bulletRigidbody;

    private bool isFiring = false;
    private float fireTimer = 0f;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isFiring)
        {
            StartCoroutine(FireGrenade());
        }
    }

    private IEnumerator FireGrenade()
    {
        isFiring = true;

        var bullet = Instantiate(empPrefab, FirePoint.position, FirePoint.rotation);
        bulletRigidbody = bullet.GetComponent<Rigidbody>();
        Vector3 initialVelocity = FirePoint.forward * empFireSpeed;
        initialVelocity += Vector3.up * initialUpwardSpeed; // Add initial upward velocity
        bulletRigidbody.velocity = initialVelocity;

        fireTimer = 0f;

        while (fireTimer < 1f)
        {
            // Check if the Rigidbody is null before accessing it
            if (bulletRigidbody != null)
            {
                Vector3 currentVelocity = bulletRigidbody.velocity;
                currentVelocity -= currentVelocity.normalized * (empFireSpeed / 1f) * Time.deltaTime;
                bulletRigidbody.velocity = currentVelocity;

                if (fireTimer >= 0.5f)
                {
                    bulletRigidbody.AddForce(Vector3.down * gravityForce);
                }
            }
            fireTimer += Time.deltaTime;

            yield return null;
        }

        isFiring = false;
    }
}
