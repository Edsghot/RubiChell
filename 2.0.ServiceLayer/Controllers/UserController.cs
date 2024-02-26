using _0._0.DataTransferLayer.Objects;
using _2._0.ServiceLayer.ServiceObject;
using _3._0.BusinessLayer.Business.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _2._0.ServiceLayer.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UserController : Controller
    {
        BusinessUser _business = null;
        SoGeneric _so = null;

        public UserController() 
        {
            _business = new();
            _so = new();
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoGeneric> GetByPk(string idUser)
        {
            var res = _business.getByPk(idUser);
            _so.setResponse(res);
            return _so;
        }

        [HttpGet]
        [Route("[action]")]
        public ActionResult<SoGeneric> GetAll() 
        {
            var res = _business.getAll();
            _so.setResponse(res);
            return _so;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoGeneric> Insert([FromBody] DtoCreateUser request)
        {
            var res = _business.insert(request);
            _so.setResponse(res);
            return _so;
        }

        [HttpPut]
        [Route("[action]")]
        public ActionResult<SoGeneric> Update([FromBody] DtoUser dto)
        {
            var res = _business.update(dto);

            _so.setResponse(res);
            return _so;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("[action]")]
        public ActionResult<SoGeneric> Login([FromBody] DtoLoginUser request)
        {
            var res = _business.Login(request);
            _so.setResponse(res);
            return _so;
        }

        [HttpDelete]
        [Route("[action]")]
        public ActionResult<SoGeneric> Delete(string id)
        {
            var res = _business.delete(id);

            _so.setResponse(res);
            return _so;
        }
    }
}