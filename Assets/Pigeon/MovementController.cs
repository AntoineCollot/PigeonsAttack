using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float speed;
    public float smooth;

    Vector3 effectiveDisplacement;
    Vector3 refVelocity;

    Animator anim;
    PlayerInputs playerInputs;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        playerInputs = GetComponent<PlayerInputs>();
    }
	
	// Update is called once per frame
	void Update () {
        //Get the raw inputs
        Vector2 inputs = playerInputs.leftThumbstick;

        //Smooth it
        effectiveDisplacement = Vector3.SmoothDamp(effectiveDisplacement, inputs, ref refVelocity, smooth);

        //Apply it
        transform.Translate(effectiveDisplacement * speed * Time.deltaTime, Space.World);

        //Set the animation speed based on the inputs
        anim.SetFloat("FlySpeed", Mathf.Lerp(0.3f,1.8f,(inputs.y + Mathf.Abs(inputs.x * 0.5f))/2 + 0.5f));
        transform.position = PlayArea.Instance.ClampToPlayArea(transform.position);
    }
}
