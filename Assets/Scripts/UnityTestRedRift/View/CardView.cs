using UnityEngine;
using UnityEngine.UI;
using UnityTestRedRift.Model;

namespace UnityTestRedRift.View
{
    public class CardView : MonoBehaviour
    {
        public RawImage imageIcon;
        public RawImage imageAttack;
        public RawImage imageHp;
        public RawImage imageMana;
        
        [SerializeField] private Text textTitle;
        [SerializeField] private Text textDescription;
        [SerializeField] private Text textAttack;
        [SerializeField] private Text textHp;
        [SerializeField] private Text textMana;

        private RectTransform _rectTransform;
        
        private Card _card;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
        
        public void SetModel(Card card)
        {
            _card = card;

            OnTitleChanged(_card.Title.Value);
            OnDescriptionChanged(_card.Description.Value);
            OnAttackChanged(_card.Attack.Value);
            OnHpChanged(_card.Hp.Value);
            OnManaChanged(_card.Mana.Value);
            
            _card.Title.OnChanged += OnTitleChanged;
            _card.Description.OnChanged += OnDescriptionChanged;
            _card.Attack.OnChanged += OnAttackChanged;
            _card.Hp.OnChanged += OnHpChanged;
            _card.Mana.OnChanged += OnManaChanged;
        }

        public void SetTransform(Vector3 position, Quaternion rotation)
        {
            _rectTransform.position = position;
            _rectTransform.rotation = rotation;
        }
        
        public void SetSmoothTransform(Vector3 position, Quaternion rotation)
        {

        }

        private void OnTitleChanged(string title) => textTitle.text = title;

        private void OnDescriptionChanged(string description) => textDescription.text = description;
       
        private void OnAttackChanged(int attack) => textAttack.text = attack.ToString();

        private void OnHpChanged(int hp) => textHp.text = hp.ToString();

        private void OnManaChanged(int mana) => textMana.text = mana.ToString();
        
        private void OnDestroy()
        {
            if(_card == null)
                return;
        
            _card.Title.OnChanged = null;
            _card.Description.OnChanged = null;
            _card.Attack.OnChanged = null;
            _card.Hp.OnChanged = null;
            _card.Mana.OnChanged = null;
        }
    }
}