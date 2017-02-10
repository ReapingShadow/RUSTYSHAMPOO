using UnityEngine;
using System.Collections;

public class PlayerInput : PlayerInterface {

    // Use this for initialization
    private readonly PlayerManager player;
    public PlayerInput(PlayerManager PlayerInterface)
    {
        player = PlayerInterface;
    }
    public void UpdateInput()
    {
        Input();
    }
    public void toPlayerInput()
    {
        player.PlayerInterface = player.playerInput;
    }
    public void Input()
    {
        if(player.weaponID == 1)
        {
            //float x = Input.GetAxis("LeftStickX");
        }
        if(player.weaponID == 2)
        {

        }
    }
}
