using UnityEngine;
using UnityEngine.UI;
using UnityTestRedRift.Model;
using UnityTestRedRift.Settings;
using UnityTestRedRift.View;

namespace UnityTestRedRift.Util.Builder
{
    public class CardViewBuilder
    {
        private readonly TextureWWWLoader _loader = new TextureWWWLoader();

        private RectTransform _hand;

        public CardViewBuilder(RectTransform hand)
        {
            _hand = hand;
        }

        public CardView Build(Card card, GameSettings settings)
        {
            var cardView = Object.Instantiate(settings.cardPrefab);
            cardView.SetModel(card);
            var sizeDelta = settings.cardPrefab.GetComponent<RectTransform>().sizeDelta;
            cardView.SetParent(_hand, sizeDelta);
            SetImageTextureByUrl(cardView.imageIcon, settings.mainIconUrl);

            return cardView;
        }

        private void SetImageTextureByUrl(RawImage image, string url)
        {
            _loader.Load(url, texture =>
            {
                image.texture = texture;
            });
        }
    }
}