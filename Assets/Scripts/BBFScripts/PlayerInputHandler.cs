using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerMovement player;

    int playerIndex;
    bool jump;

    [SerializeField]  List<GameObject> prefabs = new List<GameObject>();

    //public GameObject VCam;
  
    // Start is called before the first frame update
    void Start()
    {
        if(!PIHChecker.isGarettSpawned)
        {
            player = GameObject.Instantiate(prefabs[0], transform.position, transform.rotation).GetComponent<PlayerMovement>(); //spawn garrett
            PIHChecker.isGarettSpawned = true;

            //Transform garrettTransform = player.GetComponent<Transform>();
            //VCam.GetComponent<CinemachineVirtualCamera>.Follow = garrettTransform;
        }     
        else
            player = GameObject.Instantiate(prefabs[1], transform.position, transform.rotation).GetComponent<PlayerMovement>(); //spawn Marian
    }

////////////////////////////////////
    public void OnMove(InputAction.CallbackContext context)
    {
        if(player)
        player.OnMove(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        
        if(context.started)
        {
            jump = true;
        }
        if(context.canceled){
            jump = false;
        }
        if(player)
        player.OnJump(jump);

    }


    ///////////////////////////////////////
}
