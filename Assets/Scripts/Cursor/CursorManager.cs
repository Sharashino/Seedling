using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] Texture2D cursorTexture;
    [SerializeField] Texture2D cursorClickedTexture;
    private CursorControls cursorControls;

    private void Awake()
    {
        cursorControls = new CursorControls();
        ChangeCursor(cursorTexture);
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void Start()
    {
        cursorControls.Mouse.Click.started += _ => StartedClick();
        cursorControls.Mouse.Click.performed += _ => EndedClick();
    }

    private void StartedClick()
    {
        ChangeCursor(cursorClickedTexture);
    }
    private void EndedClick()
    {
        ChangeCursor(cursorTexture);
    }
    private void OnEnable()
    {
        cursorControls.Enable();
    }

    private void OnDisable()
    {
        cursorControls.Disable();
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
    }
}
