using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pitchme.Models.Contracts
{
    public interface IEntity : IEntity<long>
    {

    }
    /// <summary>
    /// Defines Basic Properties of an Entity ID
    /// </summary>
    /// <typeparam name="idT"></typeparam>
    public interface IEntity<idT>
    {
        idT ID { get; set; }
        DateTime DateCreated { get; set; }
        DateTime DateModified { get; set; }
    }
}
