using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UıManager : MonoBehaviour
{
    [SerializeField]
    public int level;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Play()
    {

        SceneManager.LoadScene(1);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            SceneManager.LoadScene("Level"+level);

        }
    }
}
