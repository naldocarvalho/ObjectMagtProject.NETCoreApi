using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenText.ProjectApi.Commands;
using OpenText.ProjectApi.Models;

namespace OpenText.ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IObjectQueries queries;

        public ValuesController(IMediator med, IObjectQueries qsvc)
        {
            mediator = med;
            queries = qsvc;
        }

        /// <summary>
        ///  Introduction
        /// </summary>
        /// <returns></returns>
        [HttpGet]      
        public ActionResult<List<string>> Get()
        {
            List<string> query = new List<string>(); 
            query.Add("Please navigate to http://localhost:<port>/");
            return Ok(query);
        }

        /// <summary>
        ///  Print out the current value of the target object’s member named “propertyname” if it exist
        /// </summary>
        /// <param name="propertyname"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]       
        public ActionResult<object> GetById(string propertyname, int id)
        {
            object query = queries.GetpropertynameValue(propertyname, id);

            return query;
        }

        /// <summary>
        ///Command to insert new object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]       
        public IActionResult Post([FromBody] InsertCommand obj)
        {
            if (!ModelState.IsValid) return BadRequest();

            Task<CommandResult> result = mediator.Send(obj);

            return Ok();
        }

        /// <summary>
        /// Command to set object propertyname
        /// </summary>
        /// <param name="updatpropertyname"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult SetPropertyName([FromBody]SetPropertyCommand updatpropertyname)
        {
            Task<CommandResult> result = mediator.Send(updatpropertyname);

            return Ok();
        }

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
