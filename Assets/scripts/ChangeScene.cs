using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string levelToLoad;
    private int layerIndex;
    
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Object");
    }
    // Start is called before the first frame update
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layerIndex)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
