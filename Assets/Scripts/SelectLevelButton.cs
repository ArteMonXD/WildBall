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
