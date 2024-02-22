using _0._0.DataTransferLayer.Objects;
using _0._0.DataTransferLayer.Request;
using _2._0.ServiceLayer.ServiceObject;
using _3._0.BusinessLayer.Business.User;
using Microsoft.AspNetCore.Mvc;

namespace _2._0.ServiceLayer.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        BusinessUser _business = null;
        SoUser _so = null;

        public UserController() 
        {
            _business = new();
            _so = new();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoUser> GetByPk(string idUser)
        {
            _so.dtoUser = _business.getByPk(idUser);

            return _so;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoUser> GetAll() 
        {
            _so.listDtoUser = _business.getAll();

            return _so;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoUser> Insert([FromBody] RequestUser request)
        {
            var res = _business.insert(request);

            return Ok("se creo correctamente "+res);
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult<SoUser> Update([FromBody] DtoUser dto)
        {
            var res = _business.update(dto);

            return Ok("se Actualizo correctamente " + res);
        }
    }
}