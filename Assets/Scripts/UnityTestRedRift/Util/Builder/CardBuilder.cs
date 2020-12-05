using UnityTestRedRift.Model;
using UnityTestRedRift.Settings;
using Random = UnityEngine.Random;

namespace UnityTestRedRift.Util.Builder
{
    public class CardBuilder
    {
        public Card BuildRandom(int index, GameSettings settings)
        {
            var card = new Card(index);
            
            var rndTitleIndex = Random.Range(0, settings.titles.Count - 1);
            var rndDescription = Random.Range(0, settings.descriptions.Count - 1);

            card.Title.Value =  settings.titles[rndTitleIndex];
            card.Description.Value = settings.descriptions[rndDescription];
            
            card.Attack.Value = Random.Range(settings.minValue, settings.maxValue);
            card.Hp.Value = Random.Range(settings.minValue, settings.maxValue);
            card.Mana.Value = Random.Range(settings.minValue, settings.maxValue);

            return card;
        }
    }
}