namespace CustomUpdate
{
    public interface IUpdating
    {
        void AddUpdatableItem( IUpdatable item);
        void RemoveUpdateItem( IUpdatable item);
    }
    
    public interface IUpdatable
    {
        void EnableUpdate();
        void DisableUpdate();
        
        void UpdateMe();
    }
}