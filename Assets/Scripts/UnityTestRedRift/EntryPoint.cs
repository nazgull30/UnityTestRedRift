using UnityEngine;
using UnityEngine.UI;
using UnityTestRedRift.Model;
using UnityTestRedRift.Settings;
using UnityTestRedRift.Util.Builder;

namespace UnityTestRedRift
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private RectTransform handPosition;
        [SerializeField] private GameSettings gameSettings;

        private void Awake()
        {
            var cardViewBuilder = new CardViewBuilder(handPosition);
            var game = new Game(gameSettings, cardViewBuilder);
            game.Initialize();

            button.onClick.AddListener(() =>
            {
                game.ChangeNextChardRandomValue();
            });
        }
    }
}