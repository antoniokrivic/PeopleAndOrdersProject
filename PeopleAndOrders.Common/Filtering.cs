using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAndOrders.Common
{
    public class Filtering
    {
        public DateTime? PreMade { get; set; }
        public DateTime? PostMade { get; set; }

        public bool GoodOrderReview { get; set; }
        public Filtering(DateTime? preMade, DateTime? postMade, bool goodOrderReview)
        {
            PreMade = preMade;
            PostMade = postMade;
            GoodOrderReview = goodOrderReview;
        }
    }
}
