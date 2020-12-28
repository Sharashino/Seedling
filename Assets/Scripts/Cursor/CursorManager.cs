using UnityEngine;
using UnityEngine.EventSystems;

public class CursorManager : MonoBehaviour
{
    [SerializeField] SeedlingManager seedlingManager;
    [SerializeField] Texture2D cursorTexture;
    [SerializeField] Texture2D cursorClickedTexture;
    private CursorControls cursorControls;
    private int UIObjects = -1;

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
        DetectObject();
    }

    private void DetectObject()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(cursorControls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;

        if(Physics.Raycast(mouseRay, out hit))
        {
            if(hit.collider != null)
            {
                if(EventSystem.current.IsPointerOverGameObject(UIObjects))
                {
                    return;
                }
                
                if(hit.collider.tag == "Flower")
                {
                    seedlingManager.HarvestFlower(hit.collider.gameObject.GetComponent<Flower>());
                }
            }
        }
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
