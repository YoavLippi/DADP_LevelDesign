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
    [SerializeField] private bool hasFired = false;
    private float timer = 0f;
    private Rigidbody bulletRigidbody;
    
    public EMPCount _EmpCount;
    
    private void Update()
    {
        if (Input.GetButtonDown("Fire2") && !hasFired)
        {
            if (_EmpCount.EMPs >=1 )
            {
                _EmpCount.EMPs --;
                Debug.Log("Counter is increased");
                var EMPGrenade = Instantiate(empPrefab, FirePoint.position, FirePoint.rotation);
                bulletRigidbody = EMPGrenade.GetComponent<Rigidbody>();
                Vector3 initialVelocity = FirePoint.forward * empFireSpeed;
                initialVelocity += Vector3.up * initialUpwardSpeed;
                bulletRigidbody.velocity = initialVelocity;
                hasFired = true;    
            }
        }
        
        if (Input.GetButtonUp("Fire2"))
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
