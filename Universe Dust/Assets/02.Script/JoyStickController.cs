using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class JoyStickController : MonoBehaviour
{

    private enum State
    {
        Idle,       // 0
        Walk,       // 1
        Die,        // 2
        Hit,        // 3
    }

    State currentState;
    public float walkSpeed = 3;
    
    private Vector3 newPos;
    private PlayerParams playerParams;

    private float boundary_horizon = 8.2f;
    private float boundary_vertical = 4.3f;


    // Use this for initialization
    void Start()
    {
        currentState = State.Idle;
        playerParams = GetComponent<PlayerParams>();
    }


    void TurnFromJoyStick()
    {
        // 방향에 따른 애니메이션        
    }

    void MoveFromJoyStick()
    {
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        
        float v = CrossPlatformInputManager.GetAxis("Vertical");

        GetComponent<Animator>().SetFloat("moveSpeed", Mathf.Abs(h) + Mathf.Abs(v));
        
        //transform.Translate(Vector2.right * h * walkSpeed * Time.deltaTime + Vector2.up * v * walkSpeed * Time.deltaTime);
        
        
        newPos = new Vector3(transform.position.x + h, transform.position.y + v, 0);
        transform.position = Vector3.MoveTowards(transform.position, newPos, walkSpeed * Time.deltaTime);

        // 경계 넘어가면 못움직이게
        if (transform.position.x > boundary_horizon) transform.position = new Vector3(boundary_horizon, transform.position.y, transform.position.z);
        if (transform.position.x < -boundary_horizon) transform.position = new Vector3(-boundary_horizon, transform.position.y, transform.position.z);
        if (transform.position.y > boundary_vertical) transform.position = new Vector3(transform.position.x, boundary_vertical, transform.position.z);
        if (transform.position.y < -boundary_vertical) transform.position = new Vector3(transform.position.x, -boundary_vertical, transform.position.z);

    }





    // Update is called once per frame
    void Update()
    {
        

        MoveFromJoyStick();
        TurnFromJoyStick();

    }
}
