using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenText.ProjectApi.Models;

namespace OpenText.ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectSettingsController : ControllerBase
    {

        private readonly IMediator mediator;
        private readonly IObjectQueries queries;

        public ObjectSettingsController(IMediator med, IObjectQueries qsvc)
        {
            mediator = med;
            queries = qsvc;
        }


        /// <summary>
        ///  Get all repository objects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<SysObjectEntity>> Get()
        {
            IEnumerable<SysObjectEntity> query = queries.GetObjects();

            return Ok(query);
        }

        /// <summary>
        ///  Print out a list of all target object members and their current values.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<List<string>> Get(int id)
        {
            List<string> query = queries.GetAllMembersOfObject(id);

            return Ok(query);
        }

        //// POST: api/ObjectSettings
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/ObjectSettings/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
