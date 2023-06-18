using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
    public Dropdown sceneDropdown;
    public Button saveButton;
    public Button loadButton;

    private List<string> savedScenes = new List<string>();

    private void Start()
    {
        savedScenes = LoadSavedScenes();
        UpdateSceneDropdown();

        saveButton.onClick.AddListener(SaveScene);
        loadButton.onClick.AddListener(LoadScene);
    }

    private void UpdateSceneDropdown()
    {
        sceneDropdown.ClearOptions();
        sceneDropdown.AddOptions(savedScenes);
    }

    private List<string> LoadSavedScenes()
    {
        List<string> scenes = new List<string>();

        int sceneCount = PlayerPrefs.GetInt("SceneCount", 0);
        for (int i = 0; i < sceneCount; i++)
        {
            string sceneName = PlayerPrefs.GetString("Scene" + i);
            scenes.Add(sceneName);
        }

        return scenes;
    }

    private void SaveScene()
    {
    Scene activeScene = SceneManager.GetActiveScene();
    string sceneName = activeScene.name;

    int existingIndex = savedScenes.FindIndex(scene => scene.Equals(sceneName));
    if (existingIndex >= 0)
    {
        savedScenes[existingIndex] = sceneName;
        UpdateSceneDropdown();

        Debug.Log("Scene overwritten: " + sceneName);
    }
    else
    {
        savedScenes.Add(sceneName);
        UpdateSceneDropdown();

        Debug.Log("Scene saved: " + sceneName);
    }

    for (int i = 0; i < savedScenes.Count; i++)
    {
        PlayerPrefs.SetString("Scene" + i, savedScenes[i]);
    }
    PlayerPrefs.SetInt("SceneCount", savedScenes.Count);
    }

    private void LoadScene()
    {
        string sceneName = sceneDropdown.options[sceneDropdown.value].text;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene loaded: " + sceneName);
    }
}
