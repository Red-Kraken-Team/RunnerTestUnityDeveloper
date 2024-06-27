public class Booster : Pickup
{
    private const string _Particle = "booster";

    #region PUBLIC
    public override void Accept(IPickupVisitor pickupVisitor) => pickupVisitor.Visit(this);


    public override void Use()
    {
        base.Use();
        
        ParticleManager.Instance.SetRequiredParticle(_Particle, transform.position); //bad old system, no time to change

        Destroy(gameObject);
    }
    #endregion

    #region PRIVATE

    #endregion

}
