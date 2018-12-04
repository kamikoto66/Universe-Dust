using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    Vector3 CurrentCameraPos;

    [SerializeField] private ItemPlayerController ItemPlayerController;
    private Transform CamTransform;

    // Use this for initialization
    void Start () {
        CamTransform = GetComponent<Transform>();
        CurrentCameraPos = Vector3.zero;
        CurrentCameraPos.z = -10.0f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        CurrentCameraPos.x = Mathf.Clamp(ItemPlayerController.transform.position.x, -46.0f, 46.0f);
        CurrentCameraPos.y = Mathf.Clamp(ItemPlayerController.transform.position.y, -25, 25f);

        CamTransform.position = CurrentCameraPos;

    }
}
