using ExempleDapper.Dto;
using ExempleDapper.Interfaces;
using ExempleDapper.Models;
using Intercom.Data;
using MediaBrowser.Model.Dto;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace ExempleDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUsers _user;
        public readonly IUserRole _userRole;
        public readonly IStatus _status;

        public UsersController(IUsers user, IUserRole userRole, IStatus status)
        {
            _user = user;
            _userRole = userRole;
            _status = status;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _user.GetUsersAllAsync();
            if (users is null)
                return NotFound();

            foreach (var item in users)
            {
                item.Role = await _userRole.GetUserRoleByUserId(item.UserId);
                item.Status = await _status.GetStatusById(item.StatusId);
            }
            return Ok(users);
        }

        [HttpGet("ById")]
        public async Task<IActionResult> UsersById(int id)
        {
            try
            {
                var user = await _user.GetUsersByIdAsync(id);
                if (user is null)
                    return NotFound();
                user.Role = await _userRole.GetUserRoleByUserId(user.UserId);
                user.Status = await _status.GetStatusById(user.StatusId);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Username")]
        public async Task<IActionResult> GetUser(string username, string password)
        {
            var user = await _user.GetUsersByNameAsync(username, password);
            if (user is null)
                return NotFound();
            user.Role = await _userRole.GetUserRoleByUserId(user.UserId);
            user.Status = await _status.GetStatusById(user.StatusId);
            return Ok(user);
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> InsertUsers(UsersDto user)
        {
            try
            {
                var isUser = await _user.GetUsersByNameAsync(user.UserName, user.Password);
                if (isUser is not null)
                    return BadRequest("Username Or Password Duplicate");

                var dbUser = await _user.InsertUsersAsync(user);
                var userRole = new UserRoleDto { UserId = dbUser.UserId, RoleId = (int)RoleStatus.Member };
                if (dbUser.UserId > 0)
                    await _userRole.InsertUserRole(userRole);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUsers(int id, UsersDto user)
        {
            try
            {
                var book = await _user.GetUsersByIdAsync(id);
                if (book is null)
                    return NotFound();

                await _user.UpdateUsersAsync(id, user);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            try
            {
                var book = await _user.GetUsersByIdAsync(id);
                if (book is null)
                    return NotFound();

                await _user.DeleteUsersAsync(book.UserId);
                return NoContent();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
