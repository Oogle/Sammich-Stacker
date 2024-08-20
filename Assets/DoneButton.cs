using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class DoneButton : MonoBehaviour
{
    private bool playerDone = false;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] GameObject[] whatToHide;
    // Start is called before the first frame update
    public void checkDone()
    {
        if(!playerDone)
        {
            playerDone = true;
            buttonText.text = "Play Again?";
            hideStuff();
        }
        else
        {
            SceneManager.LoadScene("LevelScene");
            
        }
    }

    private void hideStuff()
    {
        print("hiding stuff");
        for(int i=0;i<whatToHide.Length;i++)
        {
            whatToHide[i].SetActive(false);
        }
    }
}
