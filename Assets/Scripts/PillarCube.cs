using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarCube : MonoBehaviour {

    public ParticleSystem explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TriggerExplosion(Transform location) 
    {
        explosion.transform.position = location.position;
        explosion.Play();
    }
}
