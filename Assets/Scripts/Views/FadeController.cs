using DG.Tweening;
using UnityEngine;

namespace Views
{
    public class FadeController : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private float _duration;

        public void FadeIn()
        {
            _canvasGroup.alpha = 0;
            gameObject.SetActive(true);
            _canvasGroup.DOFade(1, _duration);
        }

        public void FadeOut()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.DOFade(0, _duration)
                .OnComplete(() => gameObject.SetActive(false));
        }
    }
}