using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    public IEnumerator ChangeScene(){
        Debug.Log("Test1");
        yield return new WaitForSeconds(5f);
        Debug.Log("Test2");
        SceneManager.LoadScene("Win");
    }
}
