﻿using InjectionLifeCycle.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InjectionLifeCycle.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;


        public WeatherForecastController(ITransientService transientService1,
                                         ITransientService transientService2,
                                         IScopedService scopedService1,
                                         IScopedService scopedService2,
                                         ISingletonService singletonService1,
                                         ISingletonService singletonService2)
        {
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }


        [HttpGet]
        [Route("GetActionInjection")]
        public string GetActionInjection([FromServices] IScopedService scopedService)
        {
            string result = $"ScopedService : {scopedService.GetId()}";
            return result;
        }

        [HttpGet]
        [Route("GetPropertyInjection")]
        public string GetPropertyInjection()
        {

            var services = this.HttpContext.RequestServices;
            var scopedService = (IScopedService)services.GetService(typeof(IScopedService));
            string res = $"Scoped Propery : {scopedService.GetId()}";
            return res;

        }



        [HttpGet]
        public string Get()
        {
            string result = $"Transient1 : {_transientService1.GetId()} {Environment.NewLine}" +
                            $"Transient2 : {_transientService2.GetId()} {Environment.NewLine}" +
                            $"Scoped1    : {_scopedService1.GetId() } {Environment.NewLine}" +
                            $"Scoped2    : {_scopedService2.GetId()} {Environment.NewLine}" +
                            $"Singleton1  : {_singletonService1.GetId() } {Environment.NewLine}" +
                            $"singleton2    : {_singletonService2.GetId()} {Environment.NewLine}";

            return result;



        }
    }
}
