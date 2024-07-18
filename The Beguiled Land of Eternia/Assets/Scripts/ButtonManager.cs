using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject titleCanvas;
    public GameObject controlsCanvas;
    public GameObject backgroundCanvas;
   
   public void StartGame() {
        SceneManager.LoadScene(1);

   }
   public void Controls() {
    titleCanvas.SetActive(false);
    controlsCanvas.SetActive(true);
     backgroundCanvas.SetActive(false);

   }
   public void TitleView() {
    backgroundCanvas.SetActive(true);
    titleCanvas.SetActive(true);
    controlsCanvas.SetActive(false);
    
   }
   
   
    // Start is called before the first frame update
}

