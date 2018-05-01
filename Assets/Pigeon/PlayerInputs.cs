using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XInputDotNetPure;

public class PlayerInputs : MonoBehaviour {

    public PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;
    public bool desactivateOnInactive;

   public Vector2 leftThumbstick
    {
        get
        {
            return new Vector2(state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y);
        }
    }

    [HideInInspector]
    public UnityEvent onAPressed = new UnityEvent();
    public bool aIsPressed
    {
        get
        {
            return prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed;
        }
    }
	
    void Awake()
    {
        state = GamePad.GetState(playerIndex);
        if (!state.IsConnected && desactivateOnInactive)
            gameObject.SetActive(false);
    }

	void Update () {
        state = GamePad.GetState(playerIndex);

        if (aIsPressed)
            onAPressed.Invoke();
    }

    public void Vibrate()
    {
        GamePad.SetVibration(playerIndex,1,1);

        Invoke("StopVibrations", 0.1f);
    }

    public void StopVibrations()
    {
        GamePad.SetVibration(playerIndex, 0, 0);
    }

    void OnDisable()
    {
        StopVibrations();
    }

    void LateUpdate()
    {
        prevState = state;
    }
}
