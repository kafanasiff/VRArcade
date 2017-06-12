using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {

    public float fireDelay = 1f;
    private float fireInterval = 5f;
    public LaserPool laserPool;
    public Transform target;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEnable()
    {
        InvokeRepeating ("FireLaser", fireDelay, fireInterval);
    }

    public void FireLaser()
    {
        Debug.Log("Fire laser");
        laserPool.ActivateLaser(transform, target); 
    }

    public void StopFiringLasers() 
    {
        CancelInvoke("FireLaser");
    }
}
