using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuLevel : MonoBehaviour
{
   public void PlayGame()

    {
        SceneManager.LoadSceneAsync(2);
        
    }
}