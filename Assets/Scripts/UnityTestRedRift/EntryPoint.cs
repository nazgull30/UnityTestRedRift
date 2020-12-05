using UnityEngine;
using UnityEngine.UI;
using UnityTestRedRift.Model;
using UnityTestRedRift.Settings;

namespace UnityTestRedRift
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private RectTransform handPosition;
        [SerializeField] private GameSettings gameSettings;

        private void Awake()
        {
            var game = new Game(gameSettings);
            game.Initialize();

            button.onClick.AddListener(() =>
            {
                game.ChangeNextChardRandomValue();
            });
        }
    }
}