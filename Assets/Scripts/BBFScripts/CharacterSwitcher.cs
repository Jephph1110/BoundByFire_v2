using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    int index =0;
    [SerializeField] List<GameObject> characters = new List<GameObject>();
    PlayerInputManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<PlayerInputManager>();
        index = 0;
        manager.playerPrefab = characters[index];
    }

   public void SwitchNextSpawnCharacter(PlayerInput input)
   {
    index = 1;
    manager.playerPrefab=characters[1];
   }
}
