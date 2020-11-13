using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class ChangeLevel : MonoBehaviour
{

    public AudioClip ChangeLevelClip;


    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>(); // CONTROLLER == RUBY
        Debug.Log("here");
        if (controller != null)
        {
            Debug.Log("passed");
            controller.PlaySound(ChangeLevelClip);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

