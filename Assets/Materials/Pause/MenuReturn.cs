using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GenshinImpactMovementSystem
{
    public class MenuReturn : MonoBehaviour
    {
        public void ReturnMenu()
        {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

       
    }
}