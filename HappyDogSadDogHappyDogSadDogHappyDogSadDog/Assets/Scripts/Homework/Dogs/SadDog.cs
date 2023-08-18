using UnityEngine;

namespace Homework.Dogs
{
    /**
     * TODO:
     * done 1. Реализовать этот тип по аналогии с HappyDog.
     * done 2. Грустная собака должна перекрашиваться в оттенки синего.
     * done 3. (сложно) Перенести метод GetSpriteRenderer в более подходящее место.
     * done дополнительное задание от меня: переосмыслить ChangeColor
     */
    public sealed class SadDog : Dog
    {
        public override void ChangeColor()
        {
            GetSpriteRenderer().color = ColorGenerator.GenerateRandomBlueColor();
        }

        protected override void Bark()
        {
            Debug.Log("ГАВᴗ_ᴗ ГАВᴗ_ᴗ ГАВᴗ_ᴗ ГАВᴗ_ᴗ ГАВᴗ_ᴗ ГАВᴗ_ᴗ ГАВᴗ_ᴗ");
        }
    }
}