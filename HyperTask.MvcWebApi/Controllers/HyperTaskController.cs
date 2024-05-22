using HyperTask.Application.Contract.HyperTasks;
using HyperTask.Application.Contract.HyperTasks.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HyperTask.MvcWebApi.Controllers;

[EnableCors]
[ApiController]
[Route("[controller]/[action]")]
public class HyperTaskController : Controller
{
    private readonly IHyperTaskAppService _appService;

    public HyperTaskController(IHyperTaskAppService appService)
    {
        _appService = appService;
    }


    [HttpPost]
    public async Task<IActionResult> Add([FromBody] HyperTaskDto hyperTask)
    {

        try
        {
           var entity= await _appService.AddTask(hyperTask);
            return Ok(entity);
        } catch (Exception ex)
        {
            return BadRequest(ex);
        }
        
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] HyperTaskDto hyperTask)
    {
        try
        {
           var entity= await  _appService.Update(hyperTask);
            return Ok(entity);
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _appService.RemoveTask(id);
            return Ok();
        }catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    [HttpGet]
    public async Task<List<HyperTaskDto>> GettAll()
    {
        try
        {
            return await _appService.GetAllTasks();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    [HttpGet]
    public async Task<List<HyperTaskDto>> GetCompletedTasks()
    {
        try
        {
            return await _appService.GetCompletedTasks();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    [HttpGet]
    public async Task<List<HyperTaskDto>> GetUnCompletedTasks()
    {
        try
        {
            return await _appService.GetUnCompletedTasks();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    [HttpPut]
    public async Task<IActionResult> SignAsCompleted([FromBody] int id)
    {

        try
        {
            await _appService.SignAsCompleted(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }

    }

}
