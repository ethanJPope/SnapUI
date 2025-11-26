using UnityEngine;

[ExecuteAlways]
public class CanvasPreviewHook : MonoBehaviour
{
    public Camera previewCamera;

    Camera originalCamera;
    Canvas canvas;
    bool usePreview;

    void Awake()
    {
#if UNITY_EDITOR
        usePreview = true;
#else
        usePreview = false;
#endif
    }

    void OnEnable()
    {
        canvas = GetComponent<Canvas>();
        if (canvas == null) return;

        originalCamera = canvas.worldCamera;
    }

    void Update()
    {
        if (canvas == null) return;

        if (!usePreview)
        {
            RestoreOriginal();
            return;
        }

        if (previewCamera == null) return;

        if (canvas.worldCamera != previewCamera)
        {
            ApplyPreviewCamera();
        }
    }

    public void ApplyPreviewCamera()
    {
        if (!usePreview) return;
        if (canvas == null) return;
        if (previewCamera == null) return;

        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = previewCamera;
        canvas.planeDistance = 0.1f;
        canvas.sortingOrder = 5000;
    }

    public void RestoreOriginal()
    {
        if (canvas == null) return;

        if (originalCamera != null)
        {
            canvas.worldCamera = originalCamera;
        }
        else
        {
            canvas.worldCamera = Camera.main;
        }
    }
}
