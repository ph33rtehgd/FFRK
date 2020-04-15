using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform.IdLists
{
    public class LimitBreakTierList : ITypeList
    {
        private IList<KeyValuePair<int, string>> _typeList = new List<KeyValuePair<int, string>>()
                                                             {
                                                                    new KeyValuePair<int, string>(0, "Unknown"),
                                                                    new KeyValuePair<int, string>(3, "GLB"),
                                                                    new KeyValuePair<int, string>(4, "OLB")
                                                             };

        public IList<KeyValuePair<int, string>> TypeList => _typeList;
    }
}
