using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Butten_E : MonoBehaviour
{

    public void ScenLoader(int SceneNum)
    {
        SceneManager.LoadScene(SceneNum);
    }
}
