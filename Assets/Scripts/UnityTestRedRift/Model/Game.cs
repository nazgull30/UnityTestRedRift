using System.Collections.Generic;
using UnityEngine;
using UnityTestRedRift.Settings;
using UnityTestRedRift.Util;
using UnityTestRedRift.Util.Builder;
using UnityTestRedRift.View;

namespace UnityTestRedRift.Model
{
    public class Game
    {
        private readonly List<Card> _cards = new List<Card>();
        private readonly Dictionary<int, CardView> _cardViews = new Dictionary<int, CardView>();

        private readonly GameSettings _settings;
        
        private readonly CardBuilder _cardBuilder = new CardBuilder();
        private readonly CardViewBuilder _cardViewBuilder;
        private readonly CardTransformCalculator _cardTransformCalculator = new CardTransformCalculator();
        
        private int _currentCardIndexChangeValue;

        public Game(GameSettings settings, CardViewBuilder cardViewBuilder)
        {
            _settings = settings;
            _cardViewBuilder = cardViewBuilder;
        }

        public void Initialize()
        {
            for (var i = 1; i <= _settings.cardCount; i++)
            {
                CreateCard(i);
            }
            RecalculateCardTransforms(false);
        }

        public void ChangeNextChardRandomValue()
        {
            var rndValue = Random.Range(_settings.minChangeValue, _settings.maxChangeValue + 1);
            var rdPropertyIndex = Random.Range(1, 4);
            var card = _cards[_currentCardIndexChangeValue];
            switch (rdPropertyIndex)
            {
                case 1:
                    card.Attack.Value = rndValue;
                    break;
                case 2:
                    card.Hp.Value = rndValue;
                    break;
                case 3:
                    card.Mana.Value = rndValue;
                    break;
            }

            _currentCardIndexChangeValue = _currentCardIndexChangeValue >= _cards.Count - 1
                ? 0
                : _currentCardIndexChangeValue + 1;
        }

        private void CreateCard(int index)
        {
            var card = _cardBuilder.BuildRandom(index, _settings);
            card.Hp.OnChanged += hp => OnCardHpChanged(hp, card);
            var cardView = _cardViewBuilder.Build(card, _settings);
            _cards.Add(card);
            _cardViews.Add(index, cardView);
        }

        private void OnCardHpChanged(int hp, Card card)
        {
            if (hp <= 0)
            {
                RemoveCard(card);
            }
        }

        private void RemoveCard(Card card)
        {
            _cards.Remove(card);
            Object.Destroy(_cardViews[card.Index].gameObject);
            _cardViews.Remove(card.Index);
            
            RecalculateCardTransforms(true);
        }

        private void RecalculateCardTransforms(bool smooth)
        {
            var counter = 1;
            foreach (var cardView in _cardViews.Values)
            {
                var positionX = _cardTransformCalculator.CalcPositionX(counter, _cardViews.Count, _settings.distanceBetweenCards);
                var positionY = _cardTransformCalculator.CalcPositionY(counter, _cardViews.Count, _settings.deltaPosY);
                var rotationZ = _cardTransformCalculator.CalcRotationZ(counter, _cardViews.Count, _settings.deltaRotation);
                if (smooth)
                {
                    cardView.SetSmoothTransform(positionX, positionY, rotationZ);   
                }
                else
                {
                    cardView.SetInstantTransform(positionX, positionY, rotationZ);
                }
                counter++;
            }
        }
    }
}