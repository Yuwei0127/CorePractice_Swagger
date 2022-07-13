using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePractice_Swagger.Models.ViewModel;
using CorePractice_SwaggerService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorePractice_Swagger.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CovidController : ControllerBase
    {
        private readonly ICovidService _covidService;

        public CovidController(ICovidService covidService)
        {
            _covidService = covidService;
        }
        
        /// <summary>
        /// 取得台中全部確診資料
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            // 取得確診資訊
            var dtos = await _covidService.Get();

            if (dtos.Any().Equals(false))
            {
                return NoContent();
            }
            var result = dtos.Select(x => new CovidViewModel
            {
                Date = x.Date,
                DiagnosedCountOriginTW = x.DiagnosedCountOriginTW,
                DiagnosedCountForeignTW = x.DiagnosedCountForeignTW,
                DiagnosedCountOriginTaichung = x.DiagnosedCountOriginTaichung,
                DiagnosedCountForeignTaichung = x.DiagnosedCountForeignTaichung
            });
            return Ok(result);
        }

    }
}
