namespace Project.Scripts.Health
{
    public class PlayerHealth : HealthComponent
    {
        protected override void OnDie()
        {
            Destroy(gameObject);
        }
    }
}