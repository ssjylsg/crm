using System;

namespace WebCrm.Framework.Model
{
    public abstract class Enttiy<Key> : IEnity<Key>
    {
        public virtual Key Id { get; protected set; }
    }
    public interface IEnity<Key>
    {

    }
    public abstract class BaseEntity : Enttiy<int>
    {
        public virtual void SetId(int key)
        {
            this.Id = key;
        }
    }

}
