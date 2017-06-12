using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour {

    public Transform target;
    private float speed = 5;
    public LazerEyeballs lazerEyeballs;

    private Vector3 normalizeDirection;

    // Access Functions
    public void SetTarget (Transform toSet)
    {
        target = toSet;
        transform.LookAt(target);
        NormalizeDirection();
    }

    public float GetSpeed()
    {
        return speed;
    }

    // For Initialization
    void Start () 
    {
    }

    void OnEnable()
    {
        NormalizeDirection();
    }
        
    void OnDisable()
    {
        transform.position = Vector3.zero;
    }

    public void NormalizeDirection()
    {
        transform.LookAt(target);
        normalizeDirection = (target.position - transform.position).normalized;
    }
	
    // Update is called once per frame
    void Update () 
    {
        if (target != null)
        {
            float step = speed * Time.deltaTime;
            transform.position += normalizeDirection * step;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        // when laser hits an enemy
        if (collision.gameObject.tag == "Enemy")
        {
            Deactivate();
            collision.GetComponentInParent<Enemy>().Deactivate();
            GameManager.AddToScore(1);
        }

        // end game for LAZER EYEBALLS
        if (GameManager.GetCurrentGameType() == GameManager.GameType.LazerEyeballs && collision.gameObject.tag == "Player")
        {
            Deactivate();
            lazerEyeballs.GameOver();
        }

        // when laser hits a pillar in LAZER EYEBALLS
        if (collision.gameObject.tag == "PillarCube")
        {
            Deactivate();
            collision.gameObject.GetComponent<PillarCube>().TriggerExplosion(transform);
            Debug.Log("laser  hit pillar");
        }

    }

    void Deactivate()
    {
        //Debug.Log("deactivate laser");
        gameObject.SetActive(false);
    }
}
