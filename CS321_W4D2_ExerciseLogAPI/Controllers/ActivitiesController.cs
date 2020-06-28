using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D2_ExerciseLogAPI.ApiModels;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;

        // Constructor
        public ActivitiesController(IActivityService ActivityService)
        {
            _activityService = ActivityService;
        }

        // GET api/activities
        [HttpGet]
        public IActionResult Get()
        {
            var activityModels = _activityService
                .GetAll()
                .ToApiModels(); // convert Activities to ActivityModels

            return Ok(activityModels);
        }

        // TODO: Add a route that returns all activities for an activity
        // GET api/activity/{activityId}/activities
        [HttpGet("/api/authors/{activityId}/activities")]
        public IActionResult GetActivitiesForUser(int UserId)
        {
            var activityModels = _activityService
                .GetActivitiesForUser(userId)
                .ToApiModels();

            return Ok(activityModels);
        }

        // get specific activity by id
        // GET api/activities/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var activity = _activityService.Get(id);
            if (activity == null) return NotFound();
            return Ok(activity.ToApiModel());
        }

        // create a new activity
        // POST api/activities
        [HttpPost]
        public IActionResult Post([FromBody] ActivityModel newActivity)
        {
            try
            {

                // add the new activity
                _activityService.Add(newActivity.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddActivity", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newActivity.Id }, newActivity);
        }

        // PUT api/activities/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActivityModel updatedActivity)
        {
            var activity = _activityService.Update(updatedActivity.ToDomainModel());
            if (activity == null) return NotFound();
            return Ok(activity.ToApiModel());
        }

        // DELETE api/activities/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var activity = _activityService.Get(id);
            if (activity == null) return NotFound();
            _activityService.Remove(activity);
            return NoContent();
        }
    }
}
