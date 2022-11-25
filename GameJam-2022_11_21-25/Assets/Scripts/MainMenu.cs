using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJam
{
    public class MainMenu : MonoBehaviour
    {
        //[SerializeField] private ship shipStats;
        [SerializeField] private CharaterLevelSystem resetSystem;
        [SerializeField] private AudioSource titleMusic;
        [SerializeField] private TextMeshProUGUI information;
    // Start is called before the first frame update
    void Start()
        {
            titleMusic.Play();
            information.text = "A simple game made with time, redbull, and stress";
        }

        // Update is called once per frame
        public void OnEmbarkButton()
        {
            resetSystem.ResetShip();
            StartCoroutine(Countdown());
        }

        public void OnExitButton() 
        { 
            Application.Quit();
        }

        public IEnumerator Countdown() 
        {
            StartCoroutine(LowerSound());
            information.text = "Voyage begins in: \n 3";
            yield return new WaitForSeconds(1);
            information.text = "Voyage begins in: \n 2";
            yield return new WaitForSeconds(1);
            information.text = "Voyage begins in: \n 1";
            yield return new WaitForSeconds(1);
            SceneManager.LoadScene(1);
        }

        public IEnumerator LowerSound()
        {
            while (titleMusic.volume > 0)
            {
                float decreaseTime;
                decreaseTime = .01f;
                titleMusic.volume -= decreaseTime;
                yield return new WaitForSeconds (.4f);
            }
        }
    }
}