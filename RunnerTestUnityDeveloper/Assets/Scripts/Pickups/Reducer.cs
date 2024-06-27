public class Reducer : Pickup
{
    private const string _Particle = "reducer";

    #region PUBLIC
    public override void Accept(IPickupVisitor pickupVisitor) => pickupVisitor.Visit(this);


    public override void Use()
    {
        base.Use();

        ParticleManager.Instance.SetRequiredParticle(_Particle, transform.position);

        Destroy(gameObject);
    }
    #endregion

    #region PRIVATE

    #endregion

}
