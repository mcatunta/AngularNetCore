using Microsoft.AspNetCore.Mvc;
using System;

namespace SalesDiego.Web.Controllers
{
    public class BaseController : ControllerBase
    {
        public ActionResult<T> Execute<T>(Func<T> function)
        {
            try
            {
                return function();
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest("Server Error.");
            }
        }
    }
}
