using UnityEngine;

public class FixUICamera : MonoBehaviour
{
    void Start()
    {
        var canvas = GetComponent<Canvas>();

        if (canvas.renderMode == RenderMode.ScreenSpaceCamera && canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }
    }
}
