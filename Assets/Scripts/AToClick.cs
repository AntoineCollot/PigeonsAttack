using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;

public class AToClick : MonoBehaviour {

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; ++i)
        {
            PlayerIndex testPlayerIndex = (PlayerIndex)i;
            GamePadState testState = GamePad.GetState(testPlayerIndex);
            if (testState.IsConnected)
            {
                prevState = state;
                state = GamePad.GetState(playerIndex);

                if (prevState.Buttons.A == ButtonState.Released && state.Buttons.A == ButtonState.Pressed)
                {
                    GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}
