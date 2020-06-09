using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Log:IEntity
    {
        public int Id { get; set; }
        public string ModelData { get; set; }
        public string Detail { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserName { get; set; }
    }
}
