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
        private readonly CardViewBuilder _cardViewBuilder = new CardViewBuilder();
        private readonly CardTransformCalculator _cardTransformCalculator = new CardTransformCalculator();
        
        private int _currentCardIndexChangeValue;

        public Game(GameSettings settings)
        {
            _settings = settings;
        }

        public void Initialize()
        {
            var cardCount = Random.Range(_settings.minCardCount, _settings.maxCardCount);
            for (var i = 1; i <= cardCount; i++)
            {
                CreateCard(i, cardCount);
            }
        }

        public void ChangeNextChardRandomValue()
        {
            var rndValue = Random.Range(_settings.minValue, _settings.maxValue);
            var rdPropertyIndex = Random.Range(1, 3);
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

            _currentCardIndexChangeValue = _currentCardIndexChangeValue == _cards.Count
                ? 0
                : _currentCardIndexChangeValue++;
        }

        private void CreateCard(int index, int cardCount)
        {
            var card = _cardBuilder.BuildRandom(index, _settings);
            card.Hp.OnChanged += hp => OnCardHpChanged(hp, card);
            var position = _cardTransformCalculator.CalcPosition(index, cardCount);
            var rotation = _cardTransformCalculator.CalcRotation(index, cardCount);
            var cardView = _cardViewBuilder.Build(card, _settings, position, rotation);
            _cards.Add(card);
            _cardViews.Add(index, cardView);
        }

        private void OnCardHpChanged(int hp, Card card)
        {
            if (hp == 0)
            {
                RemoveCard(card);
            }
        }

        private void RemoveCard(Card card)
        {
            _cards.Remove(card);
            Object.Destroy(_cardViews[card.Index].gameObject);

            var index = 0;
            foreach (var cardView in _cardViews.Values)
            {
                var position = _cardTransformCalculator.CalcPosition(index, _cardViews.Count);
                var rotation = _cardTransformCalculator.CalcRotation(index, _cardViews.Count);
                cardView.SetSmoothTransform(position, rotation);
                index++;
            }
        }
    }
}