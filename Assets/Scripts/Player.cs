using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public LaserPool laserPool;
    public Transform laserOrigin;
    private Transform target = null;
    private bool isMoving;
    private float speed = 3;

	// Use this for initialization
	void Start () {
        Recenter();
	}
	
	// Update is called once per frame
	void Update () {
        if (isMoving && target != null)
        {

            // move towards target
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // stop moving if target is reached
            if (transform.position == target.position)
            {
                isMoving = false;
                CancelInvoke("MoveTowardsPillar");
            }
        }
	}

    public void SetTarget (Transform toSet)
    {
        target = toSet;
    }

    void OnEnable() {
    }
        
    public void Recenter() {
        //Debug.Log("recenter");
        #if !UNITY_EDITOR
        GvrCardboardHelpers.Recenter();
        #else
        GvrEditorEmulator emulator = FindObjectOfType<GvrEditorEmulator>();
        if (emulator == null) {
            return;
        }
        emulator.Recenter();
        #endif  // !UNITY_EDITOR
    }

    public void FireLaser(Transform target)
    {
        //Debug.Log("Fire laser");
        laserPool.ActivateLaser(laserOrigin, target);
    }

    // called when gaze enters pillar
    public void OnEnterPillar(Transform newTarget)
    {
        target = newTarget;
        Invoke("MoveTowardsPillar", 1f);
    }

    // called when gaze moves away from pillar
    public void OnExitPillar()
    {
        if (isMoving != true)
        {
            target = null;  
        }
    }

    public void MoveTowardsPillar()
    {
        isMoving = true;
    }
     
}
