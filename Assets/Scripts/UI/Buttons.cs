using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void ChangeScene(string scene){
        SceneManager.LoadScene(scene);
    }

    public void ExitApp(){
        Application.Quit();
    }
}
