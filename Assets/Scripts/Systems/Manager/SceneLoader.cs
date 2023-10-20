using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject player;
    public void LoadLevelAdditive(string levelName, GameObject level, Vector3 pos, AudioClip audioClip){
        Destroy(level);
        SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
        MovePlayer(pos);
        if(audioClip != null){
            ChangeMusic(audioClip);
        }
    }
    public void LoadLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }
    public void DestroyLevel(GameObject level){
        Destroy(level);
    }
    public void MovePlayer(Vector3 playerPos){
        player.transform.position = playerPos;
    }
    public void ChangeMusic(AudioClip music){
        Camera.main.GetComponent<AudioSource>().clip = music;
        Camera.main.GetComponent<AudioSource>().Play();
    }
}
