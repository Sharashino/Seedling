using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Seedling.UI.Panels
{
    public class FadeAwayStartPanel : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private float fadeSpeed = 0.05f;
        private void Start()
        {
            StartCoroutine(FadeText());
        }

        private IEnumerator FadeText()
        {
            //wait 2 seconds before fading out
            yield return new WaitForSeconds(2);

            //variable for fading out text color
            Color color;
            color = image.color;

            while (image.color.a > 0)
            {
                yield return new WaitForEndOfFrame();
                color.a -= fadeSpeed;
                image.color = color;
            }

            gameObject.SetActive(false);
            color.a = 1;
            image.color = color;
        }
    }
}
