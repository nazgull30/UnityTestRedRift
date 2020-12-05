using System.Collections.Generic;
using UnityEngine;
using UnityTestRedRift.View;

namespace UnityTestRedRift.Settings
{
    [CreateAssetMenu(menuName = "Settings", fileName = "Game")]
    public class GameSettings : ScriptableObject
    {
        public int minCardCount;
        public int maxCardCount;
        public float distanceBetweenCards;
        public int minChangeValue;
        public int maxChangeValue;
        
        public CardView cardPrefab;
        
        public List<string> mainIconUrls;
        public List<string> attackIconUrls;
        public List<string> hpIconUrls;
        public List<string> manaIcoUrls;
        
        public List<string> titles;
        public List<string> descriptions;
        public int minValue;
        public int maxValue;
    }
}