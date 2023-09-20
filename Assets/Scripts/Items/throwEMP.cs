using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwEMP : MonoBehaviour
{
    [SerializeField] private GameObject empPrefab;
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float empFireSpeed;
    [SerializeField] private float initialUpwardSpeed;
    [SerializeField] private float gravityForce;
    private bool hasFired = false;
    private float timer = 0f;
    private Rigidbody bulletRigidbody;

   /* public void Awake()
    {
        Destroy(empPrefab, 2f);
    }*/  // method gives an error - destroy prefab 2 seconds after being fired

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !hasFired)
        {
            var bullet = Instantiate(empPrefab, FirePoint.position, FirePoint.rotation);
            bulletRigidbody = bullet.GetComponent<Rigidbody>();
            Vector3 initialVelocity = FirePoint.forward * empFireSpeed;
            initialVelocity += Vector3.up * initialUpwardSpeed;
            bulletRigidbody.velocity = initialVelocity;
            hasFired = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            hasFired = false;
        }
    }

    private void FixedUpdate()
    {
        if (hasFired)
        {
            timer += Time.fixedDeltaTime;
            if (timer < 1f)
            {
                Vector3 currentVelocity = bulletRigidbody.velocity;
                currentVelocity -= currentVelocity.normalized * (empFireSpeed / 1f) * Time.fixedDeltaTime;
                bulletRigidbody.velocity = currentVelocity;
            }
            if (timer >= 0.5f)
            {
                bulletRigidbody.AddForce(Vector3.down * gravityForce);
            }
        }
    }
}
