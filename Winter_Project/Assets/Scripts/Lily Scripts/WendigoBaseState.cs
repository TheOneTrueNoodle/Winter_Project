using UnityEngine;

public abstract class WendigoBaseState
{
   public abstract void EnterState(WendigoStateManager wendigo);

   public abstract void UpdateState(WendigoStateManager wendigo);

   public abstract void OnCollide(WendigoStateManager wendigo);

   public abstract void OnTrig(WendigoStateManager wendigo);

   public abstract void OnTrigExit(WendigoStateManager wendigo);
}
