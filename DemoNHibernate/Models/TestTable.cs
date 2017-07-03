using System;
using System.Text;
using System.Collections.Generic;


namespace DemoNHibernate {
    
    public class TestTable {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual int? Age { get; set; }
        public virtual string City { get; set; }
    }
}
