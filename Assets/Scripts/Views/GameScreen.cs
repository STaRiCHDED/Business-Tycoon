using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class GameScreen : BaseScreen
    {
        [SerializeField]
        private Button _backButton;

        private void Awake()
        {
            _backButton.onClick.AddListener(OnBackButtonClicked);
        }

        private void OnBackButtonClicked()
        {
            EventStreams.Game.Publish(new ExitToMainMenuEvent());
        }
    }
}