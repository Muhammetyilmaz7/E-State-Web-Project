using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Entities;

namespace E_State.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes ="Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class SituationController : ControllerBase
    {
        SituationService situationService;

        public SituationController(SituationService situationService)
        {
            this.situationService = situationService;


        }

        [HttpGet]
        public IActionResult SituationGet()
        {
            var list = situationService.List(x => x.Status == true);
            if (list == null)
            {
                return BadRequest();
            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetOneSituation(int id)
        {
            var getsituation = situationService.GetById(id);
            if (getsituation == null)
            {
                return BadRequest();
            }
            return Ok(getsituation);
        }

        [HttpPost]

        public IActionResult Create(Situation data)
        {
            if (data == null)

            {
                return BadRequest();
            }

            situationService.Add(data);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var delete = situationService.GetById(id);
            situationService.Delete(delete);
            return Ok(delete);
        }

        [HttpPut]
        public IActionResult Update(Situation data)
        {

            situationService.Update(data);
            return Ok(data);
        }
    }

}