using UnityEngine;
using UnityEngine.SceneManagement;

public class LeverAngleSceneLoader : MonoBehaviour
{
    public HingeJoint hingeJoint;             
    public float triggerAngle = 40f;         
    public string sceneNameToLoad;           

    private bool triggered = false;

    void Update()
    {
        if (triggered) return;

        if (Mathf.Abs(hingeJoint.angle) >= triggerAngle)
        {
            triggered = true;
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}
