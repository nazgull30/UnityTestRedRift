using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityTestRedRift.Model;

namespace UnityTestRedRift.View
{
    public class CardView : MonoBehaviour
    {
        private const float ScaleSmooth = 0.6f;
        private const float TransformSmooth = 0.8f;
        
        public RawImage imageIcon;

        [SerializeField] private Text textTitle;
        [SerializeField] private Text textDescription;
        [SerializeField] private Text textAttack;
        [SerializeField] private Text textHp;
        [SerializeField] private Text textMana;
        
        [SerializeField] public int index;

        private RectTransform _rectTransform;
        
        private Card _card;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
        
        public void SetModel(Card card)
        {
            _card = card;
            index = card.Index;

            textTitle.text = card.Title;
            textDescription.text = card.Description;
            
            OnAttackChanged(_card.Attack.Value);
            OnHpChanged(_card.Hp.Value);
            OnManaChanged(_card.Mana.Value);

            _card.Attack.OnChanged += OnAttackChanged;
            _card.Hp.OnChanged += OnHpChanged;
            _card.Mana.OnChanged += OnManaChanged;
        }

        public void SetParent(RectTransform parent, Vector2 sizeDelta)
        {
            _rectTransform.SetParent(parent);
            _rectTransform.offsetMin = Vector2.zero;
            _rectTransform.offsetMax = Vector2.zero;
            _rectTransform.sizeDelta = sizeDelta;
            _rectTransform.localScale = Vector3.one;
        }
        
        public void SetInstantTransform(float positionX, float positionY, float rotationZ)
        {
            _rectTransform.anchoredPosition = new Vector2(positionX, positionY);
            _rectTransform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
        
        public void SetSmoothTransform(float positionX, float positionY, float rotationZ)
        {
            _rectTransform.DOAnchorPosX(positionX, TransformSmooth);
            _rectTransform.DOAnchorPosY(positionY, TransformSmooth);
            var rot = _rectTransform.rotation.eulerAngles;
            _rectTransform.DOLocalRotate(new Vector3(rot.x, rot.y, rotationZ), TransformSmooth);
        }

        private void OnAttackChanged(int attack) => SetCounter(textAttack, attack);

        private void OnHpChanged(int hp) => SetCounter(textHp,  hp);

        private void OnManaChanged(int mana) => SetCounter(textMana, mana);

        private void SetCounter(Text text, int value)
        {
            text.text = value.ToString();
            var scale = text.transform.localScale;
            var sequence = DOTween.Sequence();
            sequence
                .Append(text.transform.DOScale(scale * 1.5f, ScaleSmooth))
                .Append(text.transform.DOScale(scale, ScaleSmooth));
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