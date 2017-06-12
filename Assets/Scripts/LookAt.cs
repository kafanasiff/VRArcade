using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
        transform.LookAt(target);
	}
	
    void OnEnable()
    {
        transform.LookAt(target);
    }

    public void SetTarget (Transform toSet)
    {
        target = toSet;
    }

	// Update is called once per frame
	void Update () {
        transform.LookAt(target);
	}


}
