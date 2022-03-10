using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevelButton : MonoBehaviour
{
    [SerializeField] private int levelID;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelID);
    }
}
