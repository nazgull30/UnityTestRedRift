using UnityTestRedRift.Model;
using UnityTestRedRift.Settings;
using Random = UnityEngine.Random;

namespace UnityTestRedRift.Util.Builder
{
    public class CardBuilder
    {
        public Card BuildRandom(int index, GameSettings settings)
        {
            var rndTitleIndex = Random.Range(0, settings.titles.Count);
            var rndDescription = Random.Range(0, settings.descriptions.Count);

            var title =  settings.titles[rndTitleIndex];
            var description = settings.descriptions[rndDescription];
            var card = new Card(index, title, description);
            
            card.Attack.Value = Random.Range(settings.minValue, settings.maxValue + 1);
            card.Hp.Value = Random.Range(settings.minValue, settings.maxValue + 1);
            card.Mana.Value = Random.Range(settings.minValue, settings.maxValue + 1);

            return card;
        }
    }
}