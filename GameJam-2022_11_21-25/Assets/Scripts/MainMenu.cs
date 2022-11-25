using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJam
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private ship shipStats;
        [SerializeField] private CharaterLevelSystem resetSystem;
        [SerializeField] private AudioSource titleMusic;
    // Start is called before the first frame update
    void Start()
        {
            titleMusic.Play();
        }

        // Update is called once per frame
        public void OnEmbarkButton()
        {
          resetSystem.ResetShip();
        }

        public void OnExitButton() 
        { 
            Application.Quit();
        }
    }
}