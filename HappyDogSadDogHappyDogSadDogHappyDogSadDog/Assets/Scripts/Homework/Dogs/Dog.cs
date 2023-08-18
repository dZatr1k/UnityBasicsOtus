using Homework.Common;
using Homework.Movement;
using UnityEngine;

namespace Homework.Dogs
{
    /**
     * TODO:
     * done 1. Добавить всем собакам способность гавкать: достаточно метода, пишущего в Unity-консоль строку с сообщение.
     * done 2. HappyDog должен гавкать более радостно.
     * done 3. (сложно) Пусть собаки гавкают только тогда, когда меняют направление движения.
     */
    public abstract class Dog : MonoBehaviour, IColorChangeable
    {
        public abstract void ChangeColor();

        protected Move Move;

        protected SpriteRenderer SpriteRenderer;


        protected void Start()
        {
            ChangeColor();

            Move = new Run(this, 4, -Mathf.PI, Mathf.PI, 1);
            Move.OnDirectionChanged += OnDirectionChanged;

            InputController.Instance.OnColorChanged += OnColorChanged;
        }

        protected void Update()
        {
            Move.Execute();
        }

        private void OnDisable()
        {
            InputController.Instance.OnColorChanged -= OnColorChanged;
        }

        private void OnColorChanged()
        {
            ChangeColor();
        }

        protected SpriteRenderer GetSpriteRenderer()
        {
            if (SpriteRenderer == null)
                SpriteRenderer = GetComponentInChildren<SpriteRenderer>();

            return SpriteRenderer;
        }

        protected virtual void OnDirectionChanged(float direction)
        {
            Bark();
        }

        protected virtual void Bark()
        {
            Debug.Log("ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ ГАВ");
        }

        ~Dog()
        {
            Move.OnDirectionChanged -= OnDirectionChanged;
        }
    }
}