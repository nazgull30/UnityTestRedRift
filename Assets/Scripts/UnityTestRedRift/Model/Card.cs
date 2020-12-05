using UnityTestRedRift.Util;

namespace UnityTestRedRift.Model
{
    public class Card
    {
        public int Index { get; }
        public Property<string> Title { get; } = new Property<string>();
        public Property<string> Description { get; } = new Property<string>();
        public Property<int> Attack { get; } = new Property<int>();
        public Property<int> Hp { get; } = new Property<int>();
        public Property<int> Mana { get; } = new Property<int>();
        
        public Property<bool> IsDragging { get; } = new Property<bool>();

        public Card(int index)
        {
            Index = index;
        }
    }
}