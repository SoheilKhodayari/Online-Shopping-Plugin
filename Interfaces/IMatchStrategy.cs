using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Interfaces
{
    public interface IMatchStrategy
    {
        bool matches(ItemSpec thisSpec, ItemSpec otherSpec);
        bool strictlyMatches(ItemSpec thisSpec, ItemSpec otherSpec);

    }
}
