using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPool : MonoBehaviour {

    public GameObject[] laserPool;
    private int laserCount = 0;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {

    }

    public void ActivateLaser(Transform origin, Transform target)
    {
        laserPool[laserCount].transform.position = origin.position;
        laserPool[laserCount].GetComponent<Laser>().SetTarget(target);
        laserPool[laserCount].transform.LookAt(target);
        laserPool[laserCount].SetActive(true);
        laserCount++;
        if (laserCount >= laserPool.Length)
        {
            laserCount = 0;
        }
        //Debug.Log("laser activiated -> " + laserCount.ToString());
    }
}
