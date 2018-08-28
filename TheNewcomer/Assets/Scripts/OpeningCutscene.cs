using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningCutscene : MonoBehaviour
{
    //when cutscene ends, load to map
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
    }
}