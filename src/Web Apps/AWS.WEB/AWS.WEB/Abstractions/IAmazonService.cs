using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWS.MVC.Abstractions
{
    interface IAmazonService
    {
        List<string> GetAllInstances();
        void Login();

    }
}
