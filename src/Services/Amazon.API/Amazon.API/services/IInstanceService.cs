using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.EC2.Model;

namespace Amazon.API.services
{
    public interface IInstanceService
    {
        Task<IEnumerable<InstanceViewModel>> ListInstances(AwsUser user);
        Task<StartInstancesResponse> StartInstance(AwsUser user,string instanceId);
        Task<StopInstancesResponse> StopInstance(AwsUser user,string instanceId);
    }
}
