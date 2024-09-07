using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    //public GameObject laserPrefab;
    public LaserEye laserPrefab;
    public BigAsteroid[] basterPrefab;
    Rigidbody2D rb;
    public float vertical;
    private float around;
    private UnityEngine.Vector2 startpos;
    private UnityEngine.Vector2 initforce;
    private bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world!");
        rb = GetComponent<Rigidbody2D>();
        //send cow in to center (speed up until lil buddy is in the middle of the screen)
        startpos = new UnityEngine.Vector2(0, 0);
        initforce = new UnityEngine.Vector2(0, speed);
        rb.MovePosition(startpos);
        //laserPrefab = Resources.Load("LaserEye") as LaserEye;

        
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){
        if(isMoving){
            rb.velocity = transform.up*speed*vertical;
        }
        transform.eulerAngles = new UnityEngine.Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + around);
    }

    void OnMove(InputValue value){
        //Debug.Log("Moving: " + value.Get<float>());
        isMoving = true;
        speed = 2;
        vertical = value.Get<float>();
    }

    void OnFlip(){
        //Debug.Log("Flipping!");
        transform.eulerAngles = new UnityEngine.Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180);
    }

    void OnRotation(InputValue value){
        around = value.Get<float>();
    }    

    void OnShoot(){
        Debug.Log("Shooting!");
        UnityEngine.Vector3 offset = new UnityEngine.Vector3(-0.5f, 0.5f, 0); 
        //UnityEngine.Vector3 bulPos = transform.localPosition + offset;
        //LaserEye thisLE = Instantiate(laserPrefab, transform.localPosition, transform.rotation);
        LaserEye thisLE = Instantiate(laserPrefab, transform, false);
        thisLE.transform.localScale = new UnityEngine.Vector3(0.3359034f, 0.4396459f, 2.246736f);
        thisLE.transform.position = new UnityEngine.Vector3(thisLE.transform.localPosition.x - 0.5f, thisLE.transform.localPosition.y + 0.5f);
        //thisLE.transform.rotation = transform.rotation;
        UnityEngine.Vector2 vel = new UnityEngine.Vector2(-5, around);
        //UnityEngine.Vector3 above = new UnityEngine.Vector3(3,0,0);
        //UnityEngine.Vector3 bulplace = transform.localPosition + above;
        Debug.Log("transform.forward: "+ transform.forward);
        //Debug.Log("transform.localRotation: " + transform.localRotation); 
        UnityEngine.Vector2 dir = transform.forward*-1;
        thisLE.Shoot(dir, vel);
        //figure out if you can use around to fix the velocity
        //with transform.forward there should be a local scale. Use that to manipulate his posiiton
        //always switch to Assets to throw in your prefab
    }

    private void OnTriggerEnter2D(Collider2D other){ //this might need to be collider2d
        if(!other.gameObject.CompareTag("Background")&&!other.gameObject.CompareTag("LaserEye")){
            transform.position = UnityEngine.Vector3.zero;
        }
    }

    // private void enterAsteroids(){
    //     int count = 0;
    //     while(count<3){
    //         //find random positions at the edges of the screen for Asteroids to enter
    //         UnityEngine.Vector2 loc = new
    //         Instantiate(basterPrefab, , transform.localRotation);
    //     }
    // }

}
