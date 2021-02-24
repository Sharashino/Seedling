using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Seedling.UI.Menu
{
    public class PageSwiper : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private Vector3 panelLocation;
        [SerializeField] private float percentThreshold = 0.2f;
        [SerializeField] private int totalPages;
        private int currentPage = 1;
        private float easing = 0.5f;

        private void Start()
        {
            panelLocation = transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            float difference = eventData.pressPosition.x - eventData.position.x;
            transform.position = panelLocation - new Vector3(difference, 0, 0);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            float percentage = (eventData.pressPosition.x - eventData.position.x) / Screen.width;

            if (Mathf.Abs(percentage) >= percentThreshold)
            {
                Vector3 newLocation = panelLocation;
                if (percentage > 0 && currentPage < totalPages)
                {
                    currentPage++;
                    newLocation += new Vector3(-Screen.width, 0, 0);
                }
                else if (percentage < 0 && currentPage > 1)
                {
                    currentPage--;
                    newLocation += new Vector3(Screen.width, 0, 0);
                }
                StartCoroutine(SmoothMove(transform.position, newLocation, easing));
                panelLocation = newLocation;
            }
            else
            {
                StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
            }
        }

        private IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float seconds)
        {
            float t = 0f;

            while (t <= 1.0)
            {
                t += Time.deltaTime / seconds;
                transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0f, 1f, t));
                yield return null;
            }
        }
    }
}