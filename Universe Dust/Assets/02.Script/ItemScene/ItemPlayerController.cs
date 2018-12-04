using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlayerController : MonoBehaviour {

    private bool IsTouchDown;

    public float MoveSpeed;
    private Transform PlayerTrans;
    private Vector2 PrevTouchPos;
    private Vector2 CurrentTouchPos;

	// Use this for initialization
	void Start () {
        PlayerTrans = GetComponent<Transform>();
        IsTouchDown = false;
    }
	
	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR || UNITY_STANDALONE_WIN

        if (Input.GetMouseButtonDown(0))
        {
            IsTouchDown = true;
            CurrentTouchPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            IsTouchDown = false;
            PrevTouchPos = CurrentTouchPos = Vector2.zero;
        }

        if (IsTouchDown.Equals(true))
        {
            PrevTouchPos = CurrentTouchPos;
            CurrentTouchPos = Input.mousePosition;

            var dir = CurrentTouchPos - PrevTouchPos;
            dir.Normalize();

            PlayerTrans.Translate(-dir * MoveSpeed * Time.deltaTime);
        }

#elif UNITY_ANDROID
        //이동
        if (Input.touchCount == 1)
        {
            PrevTouchPos = CurrentTouchPos;
            CurrentTouchPos = Input.GetTouch(0).position;

            var dir = CurrentTouchPos - PrevTouchPos;
            dir.Normalize();

            PlayerTrans.Translate(-dir * MoveSpeed * Time.deltaTime);
        }
#endif

    }
}
