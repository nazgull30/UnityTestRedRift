using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityTestRedRift.Model;

namespace UnityTestRedRift.View
{
    public class CardView : MonoBehaviour
    {
        private const float Smooth = 2;
        
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

            textTitle.text = card.Title;
            textDescription.text = card.Description;
            
            OnAttackChanged(_card.Attack.Value);
            OnHpChanged(_card.Hp.Value);
            OnManaChanged(_card.Mana.Value);

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
            transform.DOMove(position, Smooth);
            transform.DORotateQuaternion(rotation, Smooth);
        }

        private void OnAttackChanged(int attack) => SetCounter(textAttack, attack);

        private void OnHpChanged(int hp) => SetCounter(textHp,  hp);

        private void OnManaChanged(int mana) => SetCounter(textMana, mana);

        private void SetCounter(Text text, int value)
        {
            var initVal = int.Parse(text.text);
            text.text = value.ToString();
            var scale = text.transform.localScale;
            if (initVal != value)
            {
                text.transform.DOScale(scale * 1.2f, Smooth).SetEase(Ease.OutBack);
                // var sequence = DOTween.Sequence();
                // sequence
                //     .Append(text.transform.DOScale(scale * 1.2f, Smooth))
                //     .Append(text.transform.DOScale(scale, Smooth));

            }
        }
        
        private void OnDestroy()
        {
            if(_card == null)
                return;
            
            _card.Attack.OnChanged = null;
            _card.Hp.OnChanged = null;
            _card.Mana.OnChanged = null;
        }
    }
}