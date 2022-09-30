using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GenshinImpactMovementSystem
{
    public class PauseMenu : MonoBehaviour
    {   
        private PlayerInputActions playerControls;
        private InputAction menu;

        [SerializeField] private GameObject pauseUI;
        [SerializeField] private bool isPaused;

        void Awake() 
        {
            playerControls = new PlayerInputActions();   
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnEnable() 
        {
            menu = playerControls.Menu.Escape;
            menu.Enable();

            menu.performed += Pause;
        }

        private void OnDisable() 
        {
            menu.Disable();
        }

        void Pause(InputAction.CallbackContext canceled)
        {
            isPaused = !isPaused;
            
            if (isPaused)
            {
                ActivateMenu();
            }

            else
            {
                DeactivateMenu();
            }
        }
        

        void ActivateMenu()
        {
            Time.timeScale = 0;

            AudioListener.pause = true;
            
            pauseUI.SetActive(true);
        }

        public void DeactivateMenu()
        {
            Time.timeScale = 1;

            AudioListener.pause = false;
            
            pauseUI.SetActive(false);

            isPaused = false;
        }
         
    }
}
