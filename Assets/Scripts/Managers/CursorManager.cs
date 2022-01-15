using UnityEngine;
using Seedling.Seeds;
using UnityEngine.EventSystems;

namespace Seedling.Managers
{
    public class CursorManager : MonoBehaviour
    {
        [SerializeField] SeedManager seedlingManager;
        [SerializeField] Texture2D cursorTexture;
        [SerializeField] Texture2D cursorClickedTexture;
        private int UIObjects = -1;

        private void Awake()
        {
            ChangeCursor(cursorTexture);
            Cursor.lockState = CursorLockMode.Confined;
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
        }

        private void ChangeCursor(Texture2D cursorType)
        {
            Cursor.SetCursor(cursorType, Vector2.zero, CursorMode.Auto);
        }
    }
}