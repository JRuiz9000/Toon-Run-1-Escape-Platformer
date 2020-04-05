using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneSwitcher : MonoBehaviour
{
    public string switchScene; //Variable to indicate the scene to switch to

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Transition to Indicated Scene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(switchScene); //Switches to the indicated scene when Space Key is pressed
        }
    }
}
