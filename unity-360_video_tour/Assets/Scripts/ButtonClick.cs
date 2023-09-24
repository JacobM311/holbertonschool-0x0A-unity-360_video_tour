using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public Material skyboxMaterial; // Drag your skybox material here in the inspector
    private float targetExposure = 1f;
    private string sceneToLoad;

    private void Start()
    {
        // When the scene starts, begin the fade in.
        StartCoroutine(FadeIn());
    }

    public void StartSceneTransition(string sceneName)
    {
        sceneToLoad = sceneName;
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float currentExposure = skyboxMaterial.GetFloat("_Exposure");
        while (currentExposure > -.5f)
        {
            currentExposure -= Time.deltaTime; // adjust this value if it's too fast/slow
            skyboxMaterial.SetFloat("_Exposure", currentExposure);
            yield return null;
        }

        // Load the scene after fade out is complete
        SceneManager.LoadScene(sceneToLoad);
    }

    private IEnumerator FadeIn()
    {
        float currentExposure = skyboxMaterial.GetFloat("_Exposure");
        while (currentExposure < targetExposure)
        {
            currentExposure += .5f * Time.deltaTime; // adjust this value if it's too fast/slow
            skyboxMaterial.SetFloat("_Exposure", currentExposure);
            yield return null;
        }
    }
}
