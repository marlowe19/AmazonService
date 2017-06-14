using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.API.services;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.API.Controllers
{
     

    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private services.IInstanceService _service;

        public ValuesController(IInstanceService service)
        {
            _service = service;
        }

        // GET api/values
        [HttpPost]
        public async Task<IActionResult> Get(string key, string secret)
        {

            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(secret))
            {
                return BadRequest("Bad Request");
            }
            var user = new AwsUser
            {
                AccessKeySecret = key,
                AccesskeyId = secret
            };
           
            var instances = await _service.ListInstances(user);

            return Ok(instances);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

       
        [HttpPost("start/")]
        public async Task<IActionResult> StartInstance(string key, string secret, string instanceId)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(instanceId))
            {
                return BadRequest("Bad Request");
            }
            var user = new AwsUser
            {
                AccessKeySecret = secret,
                AccesskeyId = key
            };

            var instanceExits = await _service.ListInstances(user);
            if (instanceExits.All(x => x.InstanceId != instanceId))
            {
                return BadRequest("Bad Request");
            }

            var instanceStatus = await _service.StartInstance(user, instanceId);
            return Ok("instance starting");
        }
        
        [HttpPost("stop/")]
        public async Task<IActionResult> StopInstance(string key, string secret, string instanceId)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(instanceId))
            {
                return BadRequest("Bad Request");
            }
            var user = new AwsUser
            {
                AccessKeySecret = secret,
                AccesskeyId = key
            };

            var instanceExits = await _service.ListInstances(user);
            if (instanceExits.All(x => x.InstanceId != instanceId))
            {
                return BadRequest("Bad Request");
            }

            var instanceStatus = await _service.StopInstance(user, instanceId);
            return Ok("stopping instance");
        }


    }
}
