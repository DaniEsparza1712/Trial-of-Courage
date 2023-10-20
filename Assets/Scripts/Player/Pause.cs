using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pause : MonoBehaviour
{
    public bool paused;
    public GameObject inventoryPane;
    // Start is called before the first frame update
    void Start()
    {
        paused = false;
        inventoryPane.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause") && !paused){
            paused = true;
            inventoryPane.SetActive(true);
            Inventory.instance.UpdateInventoryUI();
        }
        else if(Input.GetButtonDown("Pause") && paused){
            paused = false;
            inventoryPane.SetActive(false);
        }

        if(paused)
            Time.timeScale = 0;
        else if(!paused)
            Time.timeScale = 1;

        if(paused && Input.GetMouseButtonDown(0)){
            Inventory.instance.UpdateInventoryUI();
        }
    }
}
