using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCoreNET.AccessData.Data.Repository.IRepository
{
    public interface IContenedorWork : IDisposable
    {
        ICategoryRepository Category { get; }
        void Save();
    }
}
