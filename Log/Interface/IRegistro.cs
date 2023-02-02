using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Interface
{
    public interface IRegistro
    {
        public bool GravaRegistro<T>(T register, string message, string fileName, string stackTrace);
        public T RecuperaRegistro<T>();
    }
}
