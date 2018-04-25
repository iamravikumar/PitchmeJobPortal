using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pitchme.Models.Contracts;
using System.Runtime.Serialization;

namespace Pitchme.Models.Implementation
{
    /// <summary>
    /// Defines the Default Behaviour of the Entity
    /// </summary>
    [Serializable]
    [DataContract]
    public class Entity : IEntity
    {
        public virtual long ID
        {
            get;
            set;
        }
        public virtual DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual DateTime DateModified { get; set; } = DateTime.Now;
    }
}
