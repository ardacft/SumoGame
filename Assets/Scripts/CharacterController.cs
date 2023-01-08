using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{
    
    public float speed = 5.0f;  // Speed will be constant throughout the game.  
    private Vector3 targetDirection;    // Position of the mouse. Determines the movement direction.
    private Rigidbody playerRigidbody;   // This will hold the rb component of the player character.
    [SerializeField] private int layer = 7; // This is the layer we want to isolate for raycasting.
    private int layerAsLayerMask; 
    private bool onRing = true;
    //private Scene _scene;
    public static bool gameOver = false;
    private Vector3 collisionDirection;
    public GameObject enemy;
    private Rigidbody enemyRigidbody;
    private bool hitEnemy = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>(); // Caching the rb component
        layerAsLayerMask = (1 << layer);
        enemyRigidbody = enemy.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        

        if (CountDownTimer.countDownTime == -1)
        {
            if (Physics.Raycast(ray, out hit, 100, layerAsLayerMask) && onRing)
            {
                Debug.DrawLine(ray.origin, hit.point);
                targetDirection = hit.point;
                targetDirection = new Vector3 (targetDirection.x, transform.position.y, targetDirection.z);
                transform.LookAt(targetDirection);
                //targetDirection = new Vector3 (targetDirection.x, 0, targetDirection.z).normalized;
                //targetDirection = new Vector3 (targetDirection.x, transform.position.y, targetDirection.z);
                //Debug.Log(targetDirection);
                playerRigidbody.velocity = transform.forward * speed;
                //transform.position += (targetDirection * speed);
                //playerNavMesh.Move(targetDirection);
            }
            else if (Physics.Raycast(ray, out hit, 100, layerAsLayerMask) && onRing!)
            {
                Debug.DrawLine(ray.origin, hit.point);
                targetDirection = hit.point;
                transform.LookAt(targetDirection);
                playerRigidbody.velocity = transform.forward * speed;
            }
        }
        

        

        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Walls")
        {
            onRing = false;
        }

        if (other.gameObject.tag == "Ground")
        {
            gameOver = true;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            
            collisionDirection = transform.position - other.gameObject.transform.position;
            collisionDirection = collisionDirection.normalized;
            hitEnemy = true;
            //enemyRigidbody.AddForce(collisionDirection * 30, ForceMode.Impulse);
            //playerRigidbody.AddForce(-collisionDirection * 30, ForceMode.Impulse);

            Debug.Log(collisionDirection);
        }
    }

}
