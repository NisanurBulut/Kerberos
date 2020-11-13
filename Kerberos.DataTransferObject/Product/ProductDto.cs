using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.DataTransferObject
{
    public class ProductDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
