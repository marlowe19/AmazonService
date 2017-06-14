using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Amazon.API.services
{
    

    public class AwsInstanceService: IInstanceService
    {
        private readonly AmazonEC2Client _client;

        public AwsInstanceService()
        {
            //_client = new AmazonEC2Client(accesskeyId, accessKeySecret, RegionEndpoint.EUWest1);
        }

        public IEnumerable<InstanceViewModel> MapInstances(IEnumerable<Instance> instances)
        {
            foreach (var item in instances)
            {
                yield return new InstanceViewModel
                {
                   Name = item.Tags.FirstOrDefault(x => x.Key =="Name")?.Value,
                   InstanceId = item.InstanceId,
                   IsOnline = item.State.Name,
                   Timetstarted = item.LaunchTime,
                };
            }
        }
        public async Task< IEnumerable<InstanceViewModel>> ListInstances(AwsUser user)
        {
            var client = new AmazonEC2Client(user.AccesskeyId, user.AccessKeySecret, RegionEndpoint.EUWest1);

            var response = await client.DescribeInstancesAsync();
            var instances = response.Reservations.Select(x => x.Instances.FirstOrDefault()).Where(x => x != null);
            return MapInstances(instances);
        }

        public async Task<StartInstancesResponse> StartInstance(AwsUser user, string instanceId)
        {
            var client = new AmazonEC2Client(user.AccesskeyId, user.AccessKeySecret, RegionEndpoint.EUWest1);
            var result = await client.StartInstancesAsync(new StartInstancesRequest(new List<string> { instanceId }));

            return result;
        }

        public async  Task<StopInstancesResponse> StopInstance(AwsUser user,string instanceId)
        {
            var client = new AmazonEC2Client(user.AccesskeyId, user.AccessKeySecret, RegionEndpoint.EUWest1);
            var result = await client.StopInstancesAsync(new StopInstancesRequest(new List<string> { instanceId }));

            return result;
        }

    }
}
