using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Intro
{
    public class IntroTransition : MonoBehaviour
    {
        public float uonScreenDuration = 4f, pegiSplashScreenDuration = 8f, introScreenDuration = 8f, currentDuration = 0f, sinceLastTime = 0f;
        public GameObject uonSplashScreen, pegiSplashScreen, introScreen, loadingScreen;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time - sinceLastTime >= 1f && currentDuration <= 4)
            {
                sinceLastTime = Time.time;
                currentDuration++;
                if (currentDuration >= uonScreenDuration)
                {
                    uonSplashScreen.SetActive(false);
                    pegiSplashScreen.SetActive(true);
                }
            }
            else if (Time.time - sinceLastTime >= 1f && currentDuration <= 8)
            {
                sinceLastTime = Time.time;
                currentDuration++;
                if (currentDuration >= pegiSplashScreenDuration)
                {
                    pegiSplashScreen.SetActive(false);
                    introScreen.SetActive(true);
                }
            }
            else if (Time.time - sinceLastTime >= 1f && currentDuration <= 16)
            {
                sinceLastTime = Time.time;
                currentDuration++;
                if (currentDuration >= introScreenDuration)
                {
                    introScreen.SetActive(false);
                    loadingScreen.SetActive(true);
                    if (!SceneManager.GetSceneByName("MainMenu").isLoaded)
                    {
                        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                    }
                    else
                    {
                        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenu"));
                    }
                }
            }


                /*if (currentDuration < uonScreenDuration)
                {
                    uonSplashScreen.SetActive(true);
                    currentDuration += Time.deltaTime;
                }
                else if (currentDuration < pegiSplashScreenDuration)
                {
                    uonSplashScreen.SetActive(false);
                    pegiSplashScreen.SetActive(true);
                    currentDuration += Time.deltaTime;
                }
                else if (currentDuration < introScreenDuration)
                {
                    pegiSplashScreen.SetActive(false);
                    introScreen.SetActive(true);
                    currentDuration += Time.deltaTime;
                }
                else
                {
                    introScreen.SetActive(false);
                }*/
        }
    }
}
