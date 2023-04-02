using Events;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class StartScreen : BaseScreen
    {
        [SerializeField]
        private Button _newGameButton;

        [SerializeField]
        private Button _continueGameButton;

        [SerializeField]
        private Button _exitGameButton;

        private void Awake()
        {
            _newGameButton.onClick.AddListener(OnNewGame);
            _continueGameButton.onClick.AddListener(OnContinueGame);
            _exitGameButton.onClick.AddListener(OnExitGame);
        }

        private void OnNewGame()
        {
            EventStreams.Game.Publish(new StartNewGameEvent());
        }

        private void OnContinueGame()
        {
            EventStreams.Game.Publish(new ContinueGameEvent());
        }

        private void OnExitGame()
        {
            EventStreams.Game.Publish(new ExitGameEvent());
        }
    }
}