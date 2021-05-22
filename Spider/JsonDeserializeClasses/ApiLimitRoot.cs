using System;
using System.Collections.Generic;
using System.Text;

namespace Spider.JsonDeserializeClasses
{
    public class ApiLimit
    {
        public int used { get; set; }
        public int of { get; set; }
    }
    public class Data
    {
        public ApiLimit api_limit { get; set; }
    }

    public class ApiLimitRoot
    {
        public Data data { get; set; }
    }
}
