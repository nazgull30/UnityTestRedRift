using System.Collections.Generic;
using UnityEngine;
using UnityTestRedRift.View;

namespace UnityTestRedRift.Settings
{
    [CreateAssetMenu(menuName = "Settings", fileName = "Game")]
    public class GameSettings : ScriptableObject
    {
        public int cardCount;
        public float distanceBetweenCards;
        public float deltaRotation;
        public float deltaPosY;
        public int minChangeValue;
        public int maxChangeValue;
        
        public CardView cardPrefab;
        
        public string mainIconUrl;

        public List<string> titles;
        public List<string> descriptions;
        public int minValue;
        public int maxValue;
    }
}