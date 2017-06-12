using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    public Transform target;
    public ParticleSystem explosion;
    private float speed = 1;
    private int secondsToRespawn = 3;
    private int spawnDistance = 20;
    private int verticalLimit = -45;
    public AlienInvaders alienInvaders;

 
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
    void Update () 
    {
        if (target != null)
        {
            transform.LookAt(target);
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
	}

    void OnEnable()
    {
        Vector3 newPosition = Random.onUnitSphere * spawnDistance;
        if (newPosition.y <= verticalLimit)
        {
            newPosition.y = verticalLimit;
        }
        transform.position = newPosition;

        gameObject.SetActive(true);            
    }

    public void OnEnter()
    {
        Invoke("FireLaser", 1f);
    }

    public void OnExit()
    {
        CancelInvoke("FireLaser");
    }
        
    void FireLaser()
    {
        target.gameObject.GetComponent<Player>().FireLaser(transform);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        explosion.transform.position = transform.position;
        explosion.Play();
        Invoke("Respawn", secondsToRespawn);
    }

    void Respawn() 
    {
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider collision)
    {
        // end game in ALIEN INVADERS
        if (collision.gameObject.tag == "Player")
        {
            alienInvaders.GameOver();
        }

    }
}
