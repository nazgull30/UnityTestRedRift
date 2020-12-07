using UnityTestRedRift.Util;

namespace UnityTestRedRift.Model
{
    public class Card
    {
        public int Index { get; }
        public string Title { get; }
        public string Description { get; }
        public Property<int> Attack { get; } = new Property<int>();
        public Property<int> Hp { get; } = new Property<int>();
        public Property<int> Mana { get; } = new Property<int>();

        public Card(int index, string title, string description)
        {
            Index = index;
            Title = title;
            Description = description;
        }
    }
}