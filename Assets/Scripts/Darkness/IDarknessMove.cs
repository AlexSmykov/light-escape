namespace Darkness
{
    public interface IDarknessMove
    {
        public float Speed { get; }
        public void StopDarkness();
        public void ContinueDarkness();
        public void AddMultipleToDarkness(float multiplier);
        public void ClearAllMultiple();
    }
}