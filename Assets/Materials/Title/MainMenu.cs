using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GenshinImpactMovementSystem
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {   
            if( SceneManager.GetActiveScene().buildIndex == 0 )
            {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        public void QuitGame()
        {
            Debug.Log("Quit");

            Application.Quit();


        }
    }
}
