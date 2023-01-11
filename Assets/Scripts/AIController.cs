using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    private bool onCollision = false;
    private int onCollisionTimer = 25;
    private float speed = 0.1f;
    private Vector3 lookDirection;
    private Rigidbody opponentRigidbody;
    private GameObject player;

    void Start()
    {
        opponentRigidbody = GetComponent<Rigidbody>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
        if (CountDownTimer.countDownTime == -1)
        {
            if (!onCollision)
            {
                lookDirection = player.transform.position;
                lookDirection = new Vector3(lookDirection.x, player.transform.position.y, lookDirection.z);
                transform.LookAt(lookDirection);
                transform.Translate(Vector3.forward*speed);
            }
            else if (onCollision)
            {
                lookDirection = player.transform.position;
                lookDirection = new Vector3(lookDirection.x, player.transform.position.y, lookDirection.z);
                transform.LookAt(lookDirection);
            }   
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        // force is how forcefully we will push the player away from the enemy.
        float magnitude = 10;
        Vector3 direction;
 
        if (other.gameObject.tag == "Player")
        {

            direction = transform.position - other.transform.position;
            opponentRigidbody.AddForce(direction*magnitude, ForceMode.Impulse);
            onCollision = true;
            StartCoroutine(OnCollisionRoutine());
        }    
    }

    IEnumerator OnCollisionRoutine()
    {
        while (onCollisionTimer >= 0)
        {
            onCollision = true;
            yield return new WaitForFixedUpdate();
            onCollisionTimer--;
        }

        yield return new WaitForFixedUpdate();
        onCollision = false;
        onCollisionTimer = 25;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OutPlatform")
        {
            Destroy(gameObject);
            SpawnManager.enemyNumber--;
        }       
    }
}
