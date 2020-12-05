using System.Collections.Generic;
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

        public CardView Build(Card card, GameSettings settings, Vector3 position, Quaternion rotation)
        {
            var cardView = Object.Instantiate(settings.cardPrefab);
            cardView.SetModel(card);
            cardView.SetTransform(position, rotation);
            SetImageTextureByRndUrl(cardView.imageIcon, settings.mainIconUrls);
            SetImageTextureByRndUrl(cardView.imageAttack, settings.attackIconUrls);
            SetImageTextureByRndUrl(cardView.imageHp, settings.hpIconUrls);
            SetImageTextureByRndUrl(cardView.imageMana, settings.manaIcoUrls);

            return cardView;
        }

        private void SetImageTextureByRndUrl(RawImage image, List<string> urls)
        {
            var rndUrlIndex = Random.Range(0, urls.Count);
            var rndUrl = urls[rndUrlIndex]; 
            _loader.Load(rndUrl, texture =>
            {
                image.texture = texture;
            });
        }
    }
}