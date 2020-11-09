using Kerberos.DataAccess.Interfaces;
using Kerberos.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.DataAccess.Repositories
{
    public class ProductRepository:BaseRepository<Product>,IProductRepository
    {
    }
}
