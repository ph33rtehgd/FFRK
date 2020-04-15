using System;
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
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using D = FFRKApi.Dto.Api;
using M = FFRKApi.Model.EnlirTransform;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface ISynchroCommandsController
    {
        IActionResult GetAllSynchroCommands();
        IActionResult GetSynchroCommandsById(int commandId);

        IActionResult GetSynchroCommandsByAbilityType(int abilityType);
        IActionResult GetSynchroCommandsByCharacter(int characterId);
        IActionResult GetSynchroCommandsBySchool(int schoolType);
        IActionResult GetSynchroCommandsByElement(int elementType);
        IActionResult GetSynchroCommandsBySearch(D.SynchroCommand searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class SynchroCommandsController : Controller, ISynchroCommandsController
    {
        #region Class Variables

        private readonly ISynchroCommandsLogic _synchroCommandsLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<SynchroCommandsController> _logger;
        #endregion

        #region Constructors

        public SynchroCommandsController(ISynchroCommandsLogic commandsLogic, IMapper mapper, ILogger<SynchroCommandsController> logger)
        {
            _synchroCommandsLogic = commandsLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ISynchroCommandsController Implementation

        /// <summary>
        /// Gets all Synchro Soul Break Commands and their associated data.
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of Synchro Commands, it is faster to get each individual Synchro Command instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/SynchroCommands (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SynchroCommand&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SynchroCommandsRoute_All)]
        [SwaggerOperation(nameof(GetAllSynchroCommands))]
        [ProducesResponseType(typeof(IEnumerable<D.SynchroCommand>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllSynchroCommands()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllSynchroCommands)}");

            IEnumerable<M.SynchroCommand> model = _synchroCommandsLogic.GetAllSynchroCommands();

            IEnumerable<D.SynchroCommand> result = _mapper.Map<IEnumerable<D.SynchroCommand>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one Synchro Soul Break Command by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Synchro Command identified by "Fantasy Grimoire Vol. II - Chapter of Omnipotence"
        /// - You first call /api/v1.0/IdLists/SynchroCommand to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Fantasy Grimoire Vol. II - Chapter of Omnipotence" in the IdList (the id is 1 in this case)
        /// - Finally you call this api: api/v1.0/SynchroCommands/1
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/SynchroCommands/1 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="commandId">the integer id for the desired Command; it can be found in the Command IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SynchroCommand&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SynchroCommandsRoute_Id)]
        [SwaggerOperation(nameof(GetSynchroCommandsById))]
        [ProducesResponseType(typeof(IEnumerable<D.SynchroCommand>), (int)HttpStatusCode.OK)]
        public IActionResult GetSynchroCommandsById(int commandId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSynchroCommandsById)}");

            IEnumerable<M.SynchroCommand> model = _synchroCommandsLogic.GetSynchroCommandsById(commandId);

            IEnumerable<D.SynchroCommand> result = _mapper.Map<IEnumerable<D.SynchroCommand>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Synchro Soul Break Commands that have the specified AbilityType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Synchro Commands that have the AbilityType of "BLK"
        /// - You first call /api/v1.0/TypeLists/AbilityType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "BLK" in the TypeList (the id is 2 in this case)
        /// - Finally you call this api: api/v1.0/SynchroCommands/AbilityType/2
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/SynchroCommands/AbilityType/2 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityType">the integer id for the desired AbilityType; it can be found in the AbilityType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SynchroCommand&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SynchroCommandsRoute_AbilityType)]
        [SwaggerOperation(nameof(GetSynchroCommandsByAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.SynchroCommand>), (int)HttpStatusCode.OK)]
        public IActionResult GetSynchroCommandsByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSynchroCommandsByAbilityType)}");

            IEnumerable<M.SynchroCommand> model = _synchroCommandsLogic.GetSynchroCommandsByAbilityType(abilityType);

            IEnumerable<D.SynchroCommand> result = _mapper.Map<IEnumerable<D.SynchroCommand>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Synchro Soul Break Commands that belong to the specified Character
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Synchro Commands that belong to Bartz (that is, to Synchro Commands for the Synchro Soul Breaks associated with the Relics that belong to Bartz)
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Bartz" in the IdList (the id is 73 in this case)
        /// - Finally you call this api: api/v1.0/SynchroCommands/Character/73
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/SynchroCommands/Character/73 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SynchroCommand&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SynchroCommandsRoute_Character)]
        [SwaggerOperation(nameof(GetSynchroCommandsByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.SynchroCommand>), (int)HttpStatusCode.OK)]
        public IActionResult GetSynchroCommandsByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSynchroCommandsByCharacter)}");

            IEnumerable<M.SynchroCommand> model = _synchroCommandsLogic.GetSynchroCommandsByCharacter(characterId);

            IEnumerable<D.SynchroCommand> result = _mapper.Map<IEnumerable<D.SynchroCommand>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Synchro Soul Break Commands that belong to the specified School 
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Synchro Commands that belong to the Summoning School
        /// - You first call /api/v1.0/TypeLists/SchoolType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Summoning" in the TypeList (the id is 19 in this case)
        /// - Finally you call this api: api/v1.0/SynchroCommands/School/19
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/SynchroCommands/School/19 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="schoolType">the integer id for the desired School; it can be found in the SchoolType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;Command&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SynchroCommandsRoute_School)]
        [SwaggerOperation(nameof(GetSynchroCommandsBySchool))]
        [ProducesResponseType(typeof(IEnumerable<D.SynchroCommand>), (int)HttpStatusCode.OK)]
        public IActionResult GetSynchroCommandsBySchool(int schoolType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSynchroCommandsBySchool)}");

            IEnumerable<M.SynchroCommand> model = _synchroCommandsLogic.GetSynchroCommandsBySchool(schoolType);

            IEnumerable<D.SynchroCommand> result = _mapper.Map<IEnumerable<D.SynchroCommand>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Synchro Soul Break Commands that have the specified element 
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all Synchro Commands that do Fire damage
        /// - You first call /api/v1.0/TypeLists/ElementType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Fire" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/SynchroCommands/School/19
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/SynchroCommands/Element/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="elementType">the integer id for the desired Element; it can be found in the ElementType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SynchroCommand&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.SynchroCommandsRoute_Element)]
        [SwaggerOperation(nameof(GetSynchroCommandsByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.SynchroCommand>), (int)HttpStatusCode.OK)]
        public IActionResult GetSynchroCommandsByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSynchroCommandsByElement)}");

            IEnumerable<M.SynchroCommand> model = _synchroCommandsLogic.GetSynchroCommandsByElement(elementType);

            IEnumerable<D.SynchroCommand> result = _mapper.Map<IEnumerable<D.SynchroCommand>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all Synchro Soul Break Commands that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full Synchro Command object as a search template, only the following fields are used in the search (all others are ignored):
        /// - CharacterId
        /// - AbilityType
        /// - School 
        /// - Elements (only the first in the list is considered)
        /// - SynchroCommandName (comparison is Contains, not exact match)
        /// - AutoTargetType 
        /// - CastTime (value specified or less)
        /// - DamageFormulaType
        /// - Multiplier (value specified or greater)
        /// - SoulBreakPointsGained (value specified or greater)
        /// - TargetType
        /// 
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any Synchro Command in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all Synchro Commands that have an ElementType of "Fire" and a SchoolType of Black Magic
        /// - You first call Type List Apis to get the ids for Element = Fire and SchoolType = Black Magic (4 and 3)
        /// - You create a Synchro Command object and fill in the above ids into the Element collection and School property
        /// - You attach the Synchro Command specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/Abilities/Search [POST];
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/SynchroCommands/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the SynchroCommand object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;SynchroCommand&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.SynchroCommandsRoute_Search)]
        [SwaggerOperation(nameof(GetSynchroCommandsBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.SynchroCommand>), (int)HttpStatusCode.OK)]
        public IActionResult GetSynchroCommandsBySearch([FromBody]D.SynchroCommand searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetSynchroCommandsBySearch)}");

            M.SynchroCommand command = _mapper.Map<M.SynchroCommand>(searchPrototype);

            IEnumerable<M.SynchroCommand> model = _synchroCommandsLogic.GetSynchroCommandsBySearch(command);

            IEnumerable<D.SynchroCommand> result = _mapper.Map<IEnumerable<D.SynchroCommand>>(model);

            return new ObjectResult(result);
        }

        //comment to force push to azure
        #endregion
    }
}
