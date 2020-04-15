using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FFRKApi.Api.FFRK.Constants;
using FFRKApi.Logic.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FFRKApi.Model.EnlirTransform;
using Swashbuckle.AspNetCore.SwaggerGen;
using D = FFRKApi.Dto.Api;
using Swashbuckle.AspNetCore.Annotations;

namespace FFRKApi.Api.FFRK.Controllers
{
    public interface ILimitBreaksController
    {
        IActionResult GetAllLimitBreaks();
        IActionResult GetLimitBreaksById(int limitBreakId);
        IActionResult GetLimitBreaksByAbilityType(int abilityType);
        IActionResult GetLimitBreaksByName(string limitBreakName);
        IActionResult GetLimitBreaksByRealm(int realmType);
        IActionResult GetLimitBreaksByCharacter(int characterId);
        IActionResult GetLimitBreaksByMultiplier(int multiplier);
        IActionResult GetLimitBreaksByElement(int elementType);
        IActionResult GetLimitBreaksByEffect(string effectText);
        IActionResult GetLimitBreaksByTier(int limitBreakTier);
        IActionResult GetLimitBreaksByLimitBreakBonus(string limitBreakBonusText);
        IActionResult GetLimitBreaksByStatus(int statusId);
        IActionResult GetLimitBreaksBySearch(D.LimitBreak searchPrototype);
    }

    [Produces(RouteConstants.ContentType_ApplicationJson)]
    [Route(RouteConstants.BaseRoute)]
    public class LimitBreaksController : Controller, ILimitBreaksController
    {
        #region Class Variables

        private readonly ILimitBreaksLogic _LimitBreaksLogic;
        private readonly IMapper _mapper;
        private readonly ILogger<LimitBreaksController> _logger;
        #endregion

        #region Constructors

        public LimitBreaksController(ILimitBreaksLogic LimitBreaksLogic, IMapper mapper, ILogger<LimitBreaksController> logger)
        {
            _LimitBreaksLogic = LimitBreaksLogic;
            _mapper = mapper;
            _logger = logger;
        }
        #endregion

        #region ILimitBreaksController Implementation

        /// <summary>
        /// Gets all LimitBreaks and their properties
        /// </summary>
        /// <remarks>
        /// Use Case - If you only need to access details for a small number of LimitBreaks, it is faster to get each individual LimitBreak instance using a separate api call, but if 
        /// you need to access most of them, it will be faster to call this api to get them all at once and store them locally so you can use them repeatedly.
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks (or use Try It Out to see data in this page)
        /// </remarks>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_All)]
        [SwaggerOperation(nameof(GetAllLimitBreaks))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetAllLimitBreaks()
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetAllLimitBreaks)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetAllLimitBreaks();

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets one LimitBreak by its unique id
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about the Paladin Force LimitBreak
        /// - You first call /api/v1.0/IdLists/LimitBreak to get the proper IdList
        /// - Then you look up the integer Key associated with the Value that contains "LimitBreak" in the IdList (the id is 238 in this case)
        /// - Finally you call this api: api/v1.0/LimitBreaks/238
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/238 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="limitBreakId">the integer id for the desired LimitBreak; it can be found in the LimitBreak IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_Id)]
        [SwaggerOperation(nameof(GetLimitBreaksById))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksById(int limitBreakId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksById)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksById(limitBreakId);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks that have the specified AbilityType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LimitBreaks that have an AbilityType of "PHY"
        /// - You first call /api/v1.0/TypeLists/AbilityType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "PHY" in the TypeList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/Abilities/LimitBreaks/AbilityType/6";
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/AbilityType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="abilityType">the integer id for the desired AbilityType; it can be found in the AbilityType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_AbilityType)]
        [SwaggerOperation(nameof(GetLimitBreaksByAbilityType))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksByAbilityType)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksByAbilityType(abilityType);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks whose name contains the provided name text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LimitBreaks with "Dragon" in their name.
        /// - You can straight away call this api: api/v1.0/LimitBreaks/Name/dragon";
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/Name/dragon (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="limitBreakName">the string that must be a part of a LimitBreak's name in order for them to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_Name)]
        [SwaggerOperation(nameof(GetLimitBreaksByName))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksByName(string limitBreakName)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksByName)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksByName(limitBreakName);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks that belong to Characters in the specified Realm
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LimitBreaks that belong to Characters in the Realm of FF VI
        /// - You first call /api/v1.0/TypeLists/RealmType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "VI" in the IdList (the id is 6 in this case)
        /// - Finally you call this api: api/v1.0/LimitBreaks/RealmType/6
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/RealmType/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="realmType">the integer id for the desired Realm; it can be found in the RealmType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_RealmType)]
        [SwaggerOperation(nameof(GetLimitBreaksByRealm))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksByRealm(int realmType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksByRealm)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksByRealm(realmType);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks that belong to the specified Character
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LimitBreaks that belong to Bartz.
        /// - You first call /api/v1.0/IdLists/Character to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Bartz" in the IdList (the id is 73 in this case)
        /// - Finally you call this api: api/v1.0/LimitBreaks/Character/73
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/Character/73 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="characterId">the integer id for the desired Character; it can be found in the Character IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_Character)]
        [SwaggerOperation(nameof(GetLimitBreaksByCharacter))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksByCharacter(int characterId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksByCharacter)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksByCharacter(characterId);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks that have a Multiplier greater than or equal to the specified Multiplier value
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LimitBreaks that have a multiplier greater than or equal to 6.
        /// - You can straight away call this api: api/v1.0/LimitBreaks/Multiplier/6";
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/Multiplier/6 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="multiplier">the integer multiplier value</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_Multiplier)]
        [SwaggerOperation(nameof(GetLimitBreaksByMultiplier))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksByMultiplier(int multiplier)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksByMultiplier)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksByMultiplier(multiplier);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks that have the specified ElementType
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LimitBreaks that have an ElementType of "Fire"
        /// - You first call /api/v1.0/TypeLists/ElementType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "Fire" in the TypeList (the id is 5 in this case)
        /// - Finally you call this api: api/v1.0/LimitBreaks/Element/5;
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/Element/5 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="elementType">the integer id for the desired ElementType; it can be found in the ElementType TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_Element)]
        [SwaggerOperation(nameof(GetLimitBreaksByElement))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksByElement(int elementType)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksByElement)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksByElement(elementType);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks whose Effect contains the provided text (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LimitBreaks with "Haste" in their Effect text.
        /// - You can straight away call this api: api/v1.0/LimitBreaks/Effect/haste";
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/Effect/haste (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="effectText">the string that must be a part of a LimitBreak's Effect text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_Effect)]
        [SwaggerOperation(nameof(GetLimitBreaksByEffect))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksByEffect(string effectText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksByEffect)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksByEffect(effectText);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks that are of the specified LimitBreak Tier
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LimitBreaks are in the Overflow Limit Break Tier
        /// - You first call /api/v1.0/TypeLists/LimitBreakTierType to get the proper TypeList
        /// - Then you look up the integer Key associated with the Value of "OLB" in the IdList (the id is 1 in this case)
        /// - Finally you call this api: api/v1.0/LimitBreaks/Tier/1
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/Tier/1 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="limitBreakTier">the integer id for the desired LimitBreakTier; it can be found in the LimitBreakTier TypeList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_Tier)]
        [SwaggerOperation(nameof(GetLimitBreaksByTier))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksByTier(int limitBreakTier)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksByTier)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksByTier(limitBreakTier);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks whose LimitBreakBonusText text contains the provided string (case is ignored)
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LimitBreaks with "Earth" limit break bonus.
        /// - You can straight away call this api: api/v1.0/LimitBreaks/LimitBreakBonus/earth";
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/LimitBreakBonus/earth (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="limitBreakBonusText">the string that must be a part of a LimitBreak's MasteryBonus text in order for it to be returned by this api call.</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_MasteryBonus)]
        [SwaggerOperation(nameof(GetLimitBreaksByLimitBreakBonus))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksByLimitBreakBonus(string limitBreakBonusText)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksByLimitBreakBonus)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksByLimitBreakBonus(limitBreakBonusText);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks that apply or provide a specified Status
        /// </summary>
        /// <remarks>
        /// Sample Use Case - You want to find out data about all LimitBreaks that apply / provide the Astra Status.
        /// - You first call /api/v1.0/IdLists/Status to get the proper IdList
        /// - Then you look up the integer Key associated with the Value of "Astra" in the IdList (the id is 86 in this case)
        /// - Finally you call this api: api/v1.0/LimitBreaks/Status/86
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/Status/86 (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="statusId">the integer id for the desired Status; it can be found in the Status IdList</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpGet]
        [Route(RouteConstants.LimitBreaksRoute_Status)]
        [SwaggerOperation(nameof(GetLimitBreaksByStatus))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksByStatus(int statusId)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksByStatus)}");

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksByStatus(statusId);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        /// <summary>
        /// Gets all LimitBreaks that match all of the considered criteria in the submitted search template/specification
        /// </summary>
        /// <remarks>
        /// While you pass in a full LimitBreak object as a search template, only the following fields are used in the search (all others are ignored):
        /// 
        /// - AbilityType
        /// - LimitBreakName (comparison is Contains, not exact match)
        /// - Realm
        /// - CharacterId
        /// - Multiplier (value specified or greater)
        /// - Elements (only the first in the list is considered)
        /// - Effect (comparison is Contains, not exact match)
        /// - LimitBreakTier
        /// - LimitBreakBonus (comparison is Contains, not exact match)
        /// - Statuses (only the first in the list is considered)
        /// - AutoTargetType
        /// - CastTime (value specified or lower)
        /// - DamageFormulaType
        /// - TargetType
        /// 
        /// Any of the above considered fields that you leave blank in the template object are NOT considered as part of the search. 
        /// Any of the above considered fields that you specify in the template object must ALL be matched by any LimitBreak in order for it to be returned in the search.
        /// <br /> 
        /// Sample Use Case - You want to find out data about all Relics that have an RealmType of "VI" and a RelicType of "Sword"
        /// - You first call TypeList Apis to get the id for RealmType = VI (the id is 6)) and the id for RelicType = Sword (the id is 2)
        /// - You create an LimitBreak object and fill in the above 6 into the Realm property, and 2 into the RelicType property
        /// - You attach the LimitBreak specification object as the body of a Post request.
        /// - Finally you call this api: api/v1.0/LimitBreaks [POST];
        /// <br /> 
        /// Example - https://www.ffrktoolkit.com/ffrk-api/api/v1.0/LimitBreaks/Search (or use Try It Out to see data in this page)
        /// </remarks>
        /// <param name="searchPrototype">the Relic object that contains the search criteria</param>
        /// <response code="200">
        ///     <see>IEnumerable&lt;LimitBreak&gt;</see>
        /// </response>
        [HttpPost]
        [Route(RouteConstants.LimitBreaksRoute_Search)]
        [SwaggerOperation(nameof(GetLimitBreaksBySearch))]
        [ProducesResponseType(typeof(IEnumerable<D.LimitBreak>), (int)HttpStatusCode.OK)]
        public IActionResult GetLimitBreaksBySearch([FromBody]D.LimitBreak searchPrototype)
        {
            _logger.LogInformation($"Controller Method invoked: {nameof(GetLimitBreaksBySearch)}");

            LimitBreak LimitBreak = _mapper.Map<LimitBreak>(searchPrototype);

            IEnumerable<LimitBreak> model = _LimitBreaksLogic.GetLimitBreaksBySearch(LimitBreak);

            IEnumerable<D.LimitBreak> result = _mapper.Map<IEnumerable<D.LimitBreak>>(model);

            return new ObjectResult(result);
        }

        //comment to force push to azure
        #endregion
    }
}
