using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutscene : MonoBehaviour
{
    [SerializeField] private GameObject _cutscene;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            _cutscene.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
