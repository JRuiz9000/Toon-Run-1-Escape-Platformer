using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{ 

    public string levelName;
    public AudioClip enterDoor;

    public SoundEffectManager soundEffectManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      soundEffectManager.Play(enterDoor);
      SceneManager.LoadScene(levelName);
    }
}
