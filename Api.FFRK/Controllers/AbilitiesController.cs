﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.SwaggerGen;
using D = FFRKApi.Dto.Api;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface IAbilitiesController
    {
        IActionResult GetAllAbilities();
        IActionResult GetAbilitiesById(int abilityId);
        IActionResult GetAbilitiesByAbilityType(int abilityType);
        IActionResult GetAbilitiesByRarity(int rarity);
        IActionResult GetAbilitiesBySchool(int schoolType);
        IActionResult GetAbilitiesByElement(int elementType);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class AbilitiesController : Controller, IAbilitiesController
    {
        #region Class Variables

        private readonly IAbilitiesLogic _abilitiesLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<AbilitiesController> _logger;
        #endregion

        #region Constructors

        public AbilitiesController(IAbilitiesLogic abilitiesLogic, IMapper mapper, ILogger<AbilitiesController> logger)
        {
            _abilitiesLogic = abilitiesLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region IAbilitiesController Implementation

        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_All)]
        [SwaggerOperation(nameof(GetAllAbilities))]
        [ProducesResponseType(typeof(IEnumerable<Action>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllAbilities()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllAbilities)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAllAbilities();

            IEnumerable<D.Ability> result = _mapper.Map< IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_Id)]
        [SwaggerOperation(nameof(GetAbilitiesById))]
        [ProducesResponseType(typeof(IEnumerable<Action>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesById(int abilityId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesById)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesById(abilityId);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_AbilityType)]
        [SwaggerOperation(nameof(GetAbilitiesByAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<Action>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesByAbilityType)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesByAbilityType(abilityType);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_Rarity)]
        [SwaggerOperation(nameof(GetAbilitiesByRarity))]
        [ProducesResponseType(typeof(IEnumerable<Action>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesByRarity(int rarity)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesByRarity)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesByRarity(rarity);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_School)]
        [SwaggerOperation(nameof(GetAbilitiesBySchool))]
        [ProducesResponseType(typeof(IEnumerable<Action>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesBySchool(int schoolType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesBySchool)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesBySchool(schoolType);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        [HttpGet]
        [Route(RouteConstants.AbilitiesRoute_Element)]
        [SwaggerOperation(nameof(GetAbilitiesByElement))]
        [ProducesResponseType(typeof(IEnumerable<Action>), (int)HttpStatusCode.OK)]
        public IActionResult GetAbilitiesByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAbilitiesByElement)}");

            IEnumerable<Ability> model = _abilitiesLogic.GetAbilitiesByElement(elementType);

            IEnumerable<D.Ability> result = _mapper.Map<IEnumerable<D.Ability>>(model);

            return new ObjectResult(result);
        }

        #endregion
    }
}
