using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static bool gameOver = false;
    
    private bool onCollision = false;

    // its unit is a single FixedUpdate (tb used in waitforfixedupdate)
    private int onCollisionTimer = 25;
    private float speed = 0.1f;
    // This will hold the position of the mouse, raycasted into the world. 
    // It determines the movement direction.
    private Vector3 lookDirection;
    private Rigidbody playerRigidbody;
    // This is the layer we want to isolate for raycasting.
    // 6: Platform; 7: Ground
    // I will use the ground layer, also serves as the outplatform, located slightly below the surface of the platform.
    // A correction on the y axis of the moveDirection will be needed
    // since hit position on the ground, resulted from raycasting, will have a lower y-position than the character,
    // hence moving towards the hit point will force the character go below the surface.
    [SerializeField] private int layer = 7; 
    private int layerAsLayerMask; 
    
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // Caching the rb component.
        layerAsLayerMask = (1 << layer);
    }

    void Update()
    {
       

    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (CountDownTimer.countDownTime == -1)
        {
            if (Physics.Raycast(ray, out hit, 100, layerAsLayerMask) && !onCollision)
            {
                Debug.DrawLine(ray.origin, hit.point);
                lookDirection = hit.point;
                lookDirection = new Vector3(lookDirection.x, transform.position.y, lookDirection.z);
                transform.LookAt(lookDirection);
                transform.Translate(Vector3.forward*speed);
            }
            else if (Physics.Raycast(ray, out hit, 100, layerAsLayerMask) && onCollision)
            {
                Debug.DrawLine(ray.origin, hit.point);
                lookDirection = hit.point;
                lookDirection = new Vector3(lookDirection.x, transform.position.y, lookDirection.z);
                transform.LookAt(lookDirection);
            }
           
        
        }
 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "OutPlatform")
        {
            Destroy(gameObject);
            SpawnManager.enemyNumber--;
        }       
    }
    

    private void OnCollisionEnter(Collision other)
    {
        // force is how forcefully we will push the player away from the enemy.
        float magnitude = 10;
        Vector3 direction;
 
        if (other.gameObject.tag == "Enemy")
        {

            direction = transform.position - other.transform.position;
            playerRigidbody.AddForce(direction*magnitude, ForceMode.Impulse);
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


}