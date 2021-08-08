namespace Interfaces
{
    public interface IFadeEffect
    {
        public void FadeIn(float endValue, float duration);
        public void FadeOut(float endValue, float duration);

        public void FadeIn();
        public void FadeOut();
    }
}
