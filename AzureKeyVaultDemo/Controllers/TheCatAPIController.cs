﻿using AzureKeyVaultDemo.Models;
using AzureKeyVaultDemo.Services;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzureKeyVaultDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheCatAPIController : ControllerBase
    {
        private readonly CatApiService _catApiService;
        public TheCatAPIController(CatApiService catApiService)
        {
            _catApiService = catApiService;
        }
        // GET: api/<TheCatAPIController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //TODO - Use Azure KeyVault to extract API Key (CatApiKey)
            string apiKey = "";
            List<Cat> cats = await _catApiService.GetCatAsync(apiKey);
            if (cats == null)
            {
                return StatusCode(500, "Error within GetCats method");
            }
            return Ok(cats);
        }

        // GET api/<TheCatAPIController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<TheCatAPIController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<TheCatAPIController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<TheCatAPIController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
