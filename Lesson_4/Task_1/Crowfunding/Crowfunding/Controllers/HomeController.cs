using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crowfunding.Models;
using BusinessLogicLayer.Services.Interface;

namespace Crowfunding.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;
    private readonly IProjectService _projectService;
    private readonly ICommentService _commentService;
    private readonly IVoteService _voteService;
    private readonly ICategoryService _categoryService;

    public HomeController(ILogger<HomeController> logger, IUserService userService, 
        IProjectService projectService, ICommentService commentService, 
        IVoteService voteService, ICategoryService categoryService)
    {
        _logger = logger;
        _userService = userService;
        _projectService = projectService;
        _commentService = commentService;
        _voteService = voteService;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/votes")]
    public async Task<IActionResult> GetVotes()
    {
        var votes = await _voteService.GetAllVotesAsync();
        return Ok(votes);
    }

    [HttpGet("/votes/user/{userId}")]
    public async Task<IActionResult> GetVotesByUserId(Guid userId)
    {
        var votes = await _voteService.GetVotesByUserIdAsync(userId);
        return Ok(votes);
    }

    [HttpGet("/votes/project/{projectId}")]
    public async Task<IActionResult> GetVotesByProjectId(Guid projectId)
    {
        var votes = await _voteService.GetVotesByProjectIdAsync(projectId);
        return Ok(votes);
    }

    [HttpGet("/vote/user/{userId}/project/{projectId}")]
    public async Task<IActionResult> GetVoteByUserIdAndProjectId(Guid userId, Guid projectId)
    {
        var vote = await _voteService.GetVoteByUserIdAndProjectIdAsync(userId, projectId);
        return Ok(vote);
    }

    [HttpGet("/user/{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _userService.GetUserAsync(id);
        return Ok(user);
    }

    [HttpGet("/users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("/user/{id}/projects")]
    public async Task<IActionResult> GetUserProjects(Guid id)
    {
        var projects = await _userService.GetUserWithProjectsAsync(id);
        return Ok(projects);
    }

    [HttpGet("/user/{id}/commentary")]
    public async Task<IActionResult> GetUserCommentary(Guid id)
    {
        var commentary = await _userService.GetUserWithCommentaryAsync(id);
        return Ok(commentary);
    }

    [HttpGet("/user/{id}/vote")]
    public async Task<IActionResult> GetUserVote(Guid id)
    {
        var vote = await _userService.GetUserWithVoteAsync(id);
        return Ok(vote);
    }

    [HttpGet("/users/projects")]
    public async Task<IActionResult> GetUsersWithProjects()
    {
        var users = await _userService.GetAllUsersWithProjectsAsync();
        return Ok(users);
    }

    [HttpGet("/project/{id}")]
    public async Task<IActionResult> GetProject(Guid id)
    {
        var project = await _projectService.GetProjectAsync(id);
        return Ok(project);
    }

    [HttpGet("/projects")]
    public async Task<IActionResult> GetProjects()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return Ok(projects);
    }

    [HttpGet("/projects/user/{userId}")]
    public async Task<IActionResult> GetProjectsByUserId(Guid userId)
    {
        var projects = await _projectService.GetProjectWithUserAsync(userId);
        return Ok(projects);
    }

    [HttpGet("/projects/{id}/commentary")]
    public async Task<IActionResult> GetProjectCommentary(Guid id)
    {
        var commentary = await _projectService.GetProjectWithCommentaryAsync(id);
        return Ok(commentary);
    }

    [HttpGet("/projects/{id}/vote")]
    public async Task<IActionResult> GetProjectVote(Guid id)
    {
        var vote = await _projectService.GetProjectWithVoteAsync(id);
        return Ok(vote);
    }

    [HttpGet("/projects/{id}/categories")]
    public async Task<IActionResult> GetProjectCategories(Guid id)
    {
        var categories = await _projectService.GetProjectWithCategoriesAsync(id);
        return Ok(categories);
    }

    [HttpGet("/projects/users")]
    public async Task<IActionResult> GetProjectsWithUsers()
    {
        var projects = await _projectService.GetAllProjectsWithUsersAsync();
        return Ok(projects);
    }

    [HttpGet("/comment/{id}")]
    public async Task<IActionResult> GetComment(Guid id)
    {
        var commentary = await _commentService.GetCommentAsync(id);
        return Ok(commentary);
    }

    [HttpGet("/comments")]
    public async Task<IActionResult> GetComments()
    {
        var commentary = await _commentService.GetAllCommentsAsync();
        return Ok(commentary);
    }

    [HttpGet("/comments/user/{userId}")]
    public async Task<IActionResult> GetCommentsByUserId(Guid userId)
    {
        var commentary = await _commentService.GetCommentsByUserIdAsync(userId);
        return Ok(commentary);
    }

    [HttpGet("/comments/project/{projectId}")]
    public async Task<IActionResult> GetCommentsByProjectId(Guid projectId)
    {
        var commentary = await _commentService.GetCommentsByProjectIdAsync(projectId);
        return Ok(commentary);
    }

    [HttpGet("/comments/projects")]
    public async Task<IActionResult> GetCommentsWithProjects()
    {
        var commentary = await _commentService.GetAllCommentsWithProjectsAsync();
        return Ok(commentary);
    }

    [HttpGet("/comments/users")]
    public async Task<IActionResult> GetCommentsWithUsers()
    {
        var commentary = await _commentService.GetAllCommentsWithUsersAsync();
        return Ok(commentary);
    }

    [HttpGet("/category/{id}")]
    public async Task<IActionResult> GetCategory(Guid id)
    {
        var category = await _categoryService.GetCategoryAsync(id);
        return Ok(category);
    }

    [HttpGet("/categories")]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    [HttpGet("/categories/projects")]
    public async Task<IActionResult> GetCategoriesWithProjects()
    {
        var categories = await _categoryService.GetAllCategoriesWithProjectsAsync();
        return Ok(categories);
    }

    [HttpGet("/category/projects/{categoryId}")]
    public async Task<IActionResult> GetCategoriesByProjectId(Guid categoryId)
    {
        var categories = await _categoryService.GetCategoryWithProjectsAsync(categoryId);
        return Ok(categories);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
