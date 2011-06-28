using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Strider.Client.TextMiner.Client
{
    interface IStriderService
    {
        string Get(string endPoint);
        string Post(string endPoint, string contentType, string data);
    }
}
